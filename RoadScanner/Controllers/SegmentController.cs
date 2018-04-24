using RoadScanner.Entities.Services;
using RoadScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace RoadScanner.Controllers
{
    public class SegmentController : Controller
    {
        SegmentService service;
        AnomalyService anomalyService;

        public SegmentController()
        {
            service = new SegmentService();
            anomalyService = new AnomalyService();
        }

        public ActionResult Index()
        {

            ViewBag.Title = "Home Page";

             
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                serializer.MaxJsonLength = Int32.MaxValue;
                
            

            SegmentViewModel model = new SegmentViewModel();
        
            var segments = service.GetAllSegments().Select(a => new SegmentModel()
            {
                Id = a.Id,
                Latitude =a.Latitude,
                Longitude = a.Longitude,
                NextSegmentId = a.NextSegmentId,
                speedAvg = a.speedAvg,
                AvgSpentTime = a.AvgSpentTime,
                speedVar = a.speedVar,
                VarSpentTime = a.VarSpentTime,
                samplesCount = a.samplesCount
                
            }).ToList();

            var segmentsJson = serializer.Serialize(segments);
            model.SegmentsJson = segmentsJson;
            model.AnomaliesCount = anomalyService.GetAnomalyCount();
            model.ManualAnomalies = anomalyService.GetAllManualAnomalies().Select(a => new ManualAnomalyViewModel()
            {
                Id = a.Id,
                CreationDate = a.CreationDate.ToString(),
                SnappedLatitude = a.SnappedLatitude,
                SnappedLongitude = a.SnappedLongitude,
                Type = a.Type,
                SegmentId = a.SegmentId
            }).ToList();

           
            return View(model);
        }
    }
}