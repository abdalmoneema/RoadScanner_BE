using RoadScanner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PointToRoadSnapper
{
    public static class Utility
    {
        public static void MapToSnappedLocations(this List<Measurement> measurements)
        {
            if (measurements.Count > 0)
            {
                int batchesCount = measurements.Count / 100 + (measurements.Count % 100 > 0 ? 1 : 0);
                for (int i = 0; i < batchesCount; i++)
                {
                    var batch = measurements.Skip(100 * i).Take(100).ToList();

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
                   
                }
            }

            //return measurements;
        }
    }
}
