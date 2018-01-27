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
                string locationPoints = "";
                for (int i = 0; i < measurements.Count; i++)
                {
                    if (i >= 100) break; //api allow only 100 point
                    if (i > 0)
                        locationPoints += "|";
                    locationPoints += measurements[i].Latitude + "," + measurements[i].Longitude;
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
                            for (int i = 0; i < snappedPath.snappedPoints.Count(); i++)
                            {
                                measurements[snappedPath.snappedPoints.ElementAt(i).originalIndex].SnappedLatitude = snappedPath.snappedPoints.ElementAt(i).location.latitude;
                                measurements[snappedPath.snappedPoints.ElementAt(i).originalIndex].SnappedLongitude = snappedPath.snappedPoints.ElementAt(i).location.longitude;
                            }
                        }

                    }
                }

                for (int i = 1; i < measurements.Count; i++)
                {

                    var longitude = measurements[i].Longitude;
                    var latitude = measurements[i].Latitude;
                    var perviouslongitude = measurements[i - 1].Longitude;
                    var perviouslatitude = measurements[i - 1].Latitude;

                    if (measurements[i].SnappedLongitude.HasValue)
                    {
                        longitude = measurements[i].SnappedLongitude.Value;
                    }

                    if (measurements[i].SnappedLatitude.HasValue)
                    {
                        latitude = measurements[i].SnappedLatitude.Value;
                    }

                    if (measurements[i - 1].SnappedLongitude.HasValue)
                    {
                        perviouslongitude = measurements[i - 1].SnappedLongitude.Value;
                    }

                    if (measurements[i - 1].SnappedLatitude.HasValue)
                    {
                        perviouslatitude = measurements[i - 1].SnappedLatitude.Value;
                    }

                    double timeSeconds = measurements[i].MeasurementTime.Subtract(measurements[i - 1].MeasurementTime).TotalSeconds;
                    if (timeSeconds > 0)
                        measurements[i].Speed = Math.Sqrt(Math.Pow(longitude - perviouslongitude, 2) + Math.Pow(latitude - perviouslatitude, 2))/ timeSeconds;
                }
            }

            return measurements;
        }
    }
}