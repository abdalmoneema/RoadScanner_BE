﻿using RoadScanner.Areas.apis.Models;
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

        public DateTime MeasurementTime { get; set; }

    }
}