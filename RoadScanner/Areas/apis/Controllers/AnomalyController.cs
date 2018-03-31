using RoadScanner.Areas.API.Models;
using RoadScanner.Areas.apis.Mapper;
using RoadScanner.Areas.apis.Models.Anomaly;
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
    public class AnomalyController : ApiController
    {
        AnomalyService service;

        public AnomalyController()
        {
            service = new AnomalyService();
        }

        [HttpPost]
        [Route("api/CreateAnomaly")]
        [ResponseType(typeof(GeneralModel))]

        public IHttpActionResult Create(AnomalyModel model)
        {

            int id = service.Create(model.MapToAnomaly());
            if (id > 0)
                return Ok(new GeneralModel() { Success = 1, Message = "Saved successfully" });
            else
                return Ok(new GeneralModel() { Success = 0, Message = "Error Saving Anomaly" });
        }
    }
}
