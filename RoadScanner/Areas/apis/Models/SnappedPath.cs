using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoadScanner.Areas.API.Models
{
    public class SnappedPath
    {
        public IEnumerable<SnappedPoint> snappedPoints { get; set; }
    }
}