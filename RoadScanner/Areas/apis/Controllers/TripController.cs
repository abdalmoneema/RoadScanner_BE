using RoadScanner.Areas.API.Mapper;
using RoadScanner.Areas.API.Models;
using RoadScanner.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RoadScanner.Areas.apis.Controllers
{
    public class TripController : ApiController
    {
        TripService service;

        public TripController()
        {
            service = new TripService();
        }
        
        [HttpPost]
        [Route("api/CreateTrip")]
        [ResponseType(typeof(GeneralModel))]

        public IHttpActionResult Create(TripModel model)
        {
            int id = service.Create(model.MapToTrip());
            if (id > 0)
                return Ok(new GeneralModel() { Success = 1, Message = "Saved successfully" });
            else
                return Ok(new GeneralModel() { Success = 0, Message = "Error Saving Trip" });
        }
    }
}
