using RoadScanner.Areas.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoadScanner.Areas.apis.Models
{
    public class PathModel
    {
        public List<Location> PathPoints { get; set; }
    }
}