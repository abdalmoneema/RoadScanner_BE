using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoadScanner.Areas.API.Models
{
    public class MeasurementModel
    {
        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public double AccelerationX { get; set; }

        public double AccelerationY { get; set; }

        public double AccelerationZ { get; set; }

        public DateTime MeasurementTime { get; set; }
    }
}