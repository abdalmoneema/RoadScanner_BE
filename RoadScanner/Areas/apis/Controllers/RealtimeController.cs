using RoadScanner.Areas.apis.Models;
using RoadScanner.Entities.HelperModels;
using RoadScanner.Entities.Services;
using RoadScanner.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RoadScanner.Areas.apis.Controllers
{
    public class RealtimeController : ApiController
    {
        RealtimeService service;

        public RealtimeController()
        {
            service = new RealtimeService();
        }

        [HttpPost]
        [Route("api/GetNextAnomaly")]
        [ResponseType(typeof(List<PredictedAnomaly>))]
        public IHttpActionResult GetNextAnomaly(PathModel model)
        {
            List<PredictedAnomaly> anomalies = new List<PredictedAnomaly>();
            var snapped = model.PathPoints.MapToSnappedLocations();

            if (snapped != null && snapped.Count > 0)
            {
                var lastpoint = snapped.Last();
                int? segmentId = service.GetPointSegment(lastpoint.Latitude,lastpoint.Longitude);

                if (segmentId.HasValue) {
                    anomalies = service.GetNextAnomalies(segmentId.Value);

                }
            }

            return Ok(anomalies);

        }
    }
}
