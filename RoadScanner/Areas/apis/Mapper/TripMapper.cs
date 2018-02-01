using RoadScanner.Areas.API.Models;
using RoadScanner.Areas.apis;
using RoadScanner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace RoadScanner.Areas.API.Mapper
{
    public static class TripMapper
    {
        public static Trip MapToTrip(this TripModel tripModel)
        {
            return new Trip()
            {
                DeviceID = tripModel.DeviceID,
                Measurements = tripModel.Measurements.Select(m => new Measurement()
                {
                    Longitude = m.Longitude,
                    Latitude = m.Latitude,
                    AccelerationX = m.AccelerationX,
                    AccelerationY = m.AccelerationY,
                    AccelerationZ = m.AccelerationZ,
                    AccelerationMagnitude = Math.Sqrt((m.AccelerationX * m.AccelerationX) + (m.AccelerationY * m.AccelerationY) + (m.AccelerationZ * m.AccelerationZ)),
                    Speed = 0,
                    MeasurementTime = m.MeasurementTime
                }).ToList().MapToSnappedLocations()
            };
        }

        private static List<Measurement> MapToSnappedLocations(this List<Measurement> measurements)
        {
            if (measurements.Count > 0)
            {
                int batchesCount = measurements.Count/100 + (measurements.Count % 100 > 0? 1:0 );
                for (int i = 0; i < batchesCount; i++)
                {
                    var batch =measurements.Skip(100 * i).Take(100).ToList();

                    string locationPoints = "";
                    for (int j = 0; j < batch.Count; j++)
                    {
                        if (j > 0)
                            locationPoints += "|";
                        locationPoints += batch[j].Latitude + "," + batch[j].Longitude;
                    }

                    using (var client = new HttpClient())
                    {
                        string path = String.Format("https://roads.googleapis.com/v1/snapToRoads?path={0}&key={1}", locationPoints, Constants.GoogleMapsRoadsAPIKey);
                        HttpResponseMessage response = client.GetAsync(path).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            SnappedPath snappedPath = response.Content.ReadAsAsync<SnappedPath>().Result;

                            if (snappedPath != null && snappedPath.snappedPoints.Count() > 0)
                            {
                                for (int j = 0; j < snappedPath.snappedPoints.Count(); j++)
                                {
                                    measurements[100 * i + snappedPath.snappedPoints.ElementAt(j).originalIndex].SnappedLatitude = snappedPath.snappedPoints.ElementAt(j).location.latitude;
                                    measurements[100 * i + snappedPath.snappedPoints.ElementAt(j).originalIndex].SnappedLongitude = snappedPath.snappedPoints.ElementAt(j).location.longitude;
                                }
                            }

                        }
                    }  
                }

                for (int j = 1; j < measurements.Count; j++)
                {
                    var longitude = measurements[j].Longitude;
                    var latitude = measurements[j].Latitude;
                    var perviouslongitude = measurements[j - 1].Longitude;
                    var perviouslatitude = measurements[j - 1].Latitude;

                    if (measurements[j].SnappedLongitude.HasValue)
                    {
                        longitude = measurements[j].SnappedLongitude.Value;
                    }

                    if (measurements[j].SnappedLatitude.HasValue)
                    {
                        latitude = measurements[j].SnappedLatitude.Value;
                    }

                    if (measurements[j - 1].SnappedLongitude.HasValue)
                    {
                        perviouslongitude = measurements[j - 1].SnappedLongitude.Value;
                    }

                    if (measurements[j - 1].SnappedLatitude.HasValue)
                    {
                        perviouslatitude = measurements[j - 1].SnappedLatitude.Value;
                    }

                    double timeSeconds = measurements[j].MeasurementTime.Subtract(measurements[j - 1].MeasurementTime).TotalSeconds;
                    if (timeSeconds > 0)
                    {
                        measurements[j].Speed = Math.Sqrt(Math.Pow(longitude - perviouslongitude, 2) + Math.Pow(latitude - perviouslatitude, 2)) / timeSeconds;
                        if (measurements[j].Speed > measurements[j - 1].Speed)
                            measurements[j].IsAccelerating = true;
                        else if (measurements[j].Speed < measurements[j - 1].Speed)
                            measurements[j].IsAccelerating = false;
                    }
                 }
            }

            return measurements;
        }
    }
}