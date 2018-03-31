using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoadScanner.Areas.apis.Models.Anomaly
{
    public class AnomalyModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Type { get; set; }
    }
}