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

                            if (snappedPath != null && snappedPath.snappedPoints != null && snappedPath.snappedPoints.Count() > 0)
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
            }

            return measurements;
        }
    }
}