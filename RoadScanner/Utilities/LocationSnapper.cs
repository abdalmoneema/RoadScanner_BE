using RoadScanner.Areas.API.Models;
using RoadScanner.Areas.apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace RoadScanner.Utilities
{
    public static class LocationSnapper
    {
        public static List<Location> MapToSnappedLocations(this List<Location> pathPoints)
        {
            List<Location> snappedPathPoints = new List<Location>();
            if (pathPoints.Count > 0)
            {
                int batchesCount = pathPoints.Count / 100 + (pathPoints.Count % 100 > 0 ? 1 : 0);
                for (int i = 0; i < batchesCount; i++)
                {
                    var batch = pathPoints.Skip(100 * i).Take(100).ToList();

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
                                    Location location = new Location();

                                    location.Latitude = snappedPath.snappedPoints.ElementAt(j).location.Latitude;
                                    location.Longitude = snappedPath.snappedPoints.ElementAt(j).location.Longitude;
                                    snappedPathPoints.Add(location);
                                }
                            }

                        }
                    }
                }
            }
            return snappedPathPoints;


        }
    }
}