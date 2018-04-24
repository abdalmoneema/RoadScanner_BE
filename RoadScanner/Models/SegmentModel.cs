using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoadScanner.Models
{
    public class SegmentModel
    {
        public int Id { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> speedAvg { get; set; }
        public Nullable<double> speedVar { get; set; }
        public Nullable<int> NextSegmentId { get; set; }
        public Nullable<int> samplesCount { get; set; }
        public Nullable<double> AvgSpentTime { get; set; }
        public Nullable<double> VarSpentTime { get; set; }
    }
}