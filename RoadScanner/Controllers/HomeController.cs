using RoadScanner.Entities.Services;
using RoadScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoadScanner.Controllers
{
    public class HomeController : Controller
    {

        AnomalyService service;

        public HomeController()
        {
            service = new AnomalyService();
        }

        public ActionResult Index()
        {

            ViewBag.Title = "Home Page";

            HomeModel model = new HomeModel();
            model.ManualAnomalies = service.GetAllManualAnomalies().Select(a => new ManualAnomalyViewModel() {
                Id = a.Id,
                CreationDate = a.CreationDate.ToString(),
                SnappedLatitude = a.SnappedLatitude,
                SnappedLongitude = a.SnappedLongitude,
                Type = a.Type,
                SegmentId =a.SegmentId
            });
            return View(model);
        }
    }
}
