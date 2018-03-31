using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoadScanner.Models
{
    public class MeasurementViewModel
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public Nullable<double> AccelerationX { get; set; }
        public Nullable<double> AccelerationY { get; set; }
        public Nullable<double> AccelerationZ { get; set; }
        public Nullable<double> Speed { get; set; }
        public string MeasurementTime { get; set; }
        public Nullable<double> AccelerationMagnitude { get; set; }
        public Nullable<double> SnappedLatitude { get; set; }
        public Nullable<double> SnappedLongitude { get; set; }
        public Nullable<bool> IsSpeedIncrease { get; set; }
        public Nullable<int> SegmentId { get; set; }
    }
}