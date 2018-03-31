using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoadScanner.Models
{
    public class ManualAnomalyViewModel
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string CreationDate { get; set; }
        public Nullable<int> SegmentId { get; set; }
        public Nullable<double> SnappedLatitude { get; set; }
        public Nullable<double> SnappedLongitude { get; set; }
    }
}