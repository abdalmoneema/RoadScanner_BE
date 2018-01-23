using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoadScanner.Areas.API.Models
{
    public class TripModel
    {
        public string DeviceID { get; set; }
        public List<MeasurementModel> Measurements { get; set; }
    }
}