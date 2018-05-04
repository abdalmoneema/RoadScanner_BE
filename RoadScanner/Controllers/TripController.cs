using RoadScanner.Entities.Services;
using RoadScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoadScanner.Controllers
{
    public class TripController : Controller
    {

        TripPathService service;
        AnomalyService anomalyService;

        public TripController()
        {
            service = new TripPathService();
            anomalyService = new AnomalyService();
        }

        public ActionResult Index(int? tripId,bool viewRawLocation =false)
        {

            ViewBag.Title = "Home Page";

            TripPathViewModel model = new TripPathViewModel();
            model.ViewRawLocation = viewRawLocation;
            model.Trips = service.GetAllTrips();
            model.ManualAnomalies = anomalyService.GetAllManualAnomalies().Select(a => new ManualAnomalyViewModel()
            {
                Id = a.Id,
                CreationDate = a.CreationDate.ToString(),
                SnappedLatitude = a.SnappedLatitude,
                SnappedLongitude = a.SnappedLongitude,
                Type = a.Type,
                SegmentId = a.SegmentId
            }).ToList();

            if (tripId !=null && tripId.HasValue)
            {
                model.Measurements = service.GetTripMeasuremnts(tripId.Value).Select(a => new MeasurementViewModel()
                {
                    Id = a.Id,
                    MeasurementTime = a.MeasurementTime.ToString(),
                    SnappedLatitude = a.SnappedLatitude,
                    SnappedLongitude = a.SnappedLongitude,
                    Latitude =a.Latitude,
                    Longitude =a.Longitude,
                    SegmentId = a.SegmentId
                }).ToList();
            }
          
            return View(model);
        }
    }
}