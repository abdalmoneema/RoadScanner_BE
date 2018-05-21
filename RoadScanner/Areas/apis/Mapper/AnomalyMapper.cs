using RoadScanner.Areas.API.Models;
using RoadScanner.Areas.apis.Models.Anomaly;
using RoadScanner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace RoadScanner.Areas.apis.Mapper
{
    public static class AnomalyMapper
    {
        public static ManualAnomaly MapToAnomaly(this AnomalyModel anomalyModel)
        {
            double? snappedLatitude = null;
            double? snappedLongitude = null;

            using (var client = new HttpClient())
            {
                string path = String.Format("https://roads.googleapis.com/v1/snapToRoads?path={0}&key={1}", anomalyModel.Latitude+","+ anomalyModel.Longitude, Constants.GoogleMapsRoadsAPIKey);
                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    SnappedPath snappedPath = response.Content.ReadAsAsync<SnappedPath>().Result;

                    if (snappedPath != null && snappedPath.snappedPoints != null && snappedPath.snappedPoints.Count() > 0)
                    {
                        snappedLatitude = snappedPath.snappedPoints.ElementAt(0).location.Latitude;
                        snappedLongitude = snappedPath.snappedPoints.ElementAt(0).location.Longitude;
                    }
                }
            }

            return new ManualAnomaly()
            {
                Latitude = anomalyModel.Latitude,
                Longitude = anomalyModel.Longitude,
                SnappedLatitude = snappedLatitude,
                SnappedLongitude = snappedLongitude,
                Type = anomalyModel.Type
            };
        }
    }
}