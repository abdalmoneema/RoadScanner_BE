//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoadScanner.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Segments_SpeedDifference_SegmentChain5_Minimized
    {
        public int Segment1Id { get; set; }
        public int Segment2Id { get; set; }
        public int Segment3Id { get; set; }
        public int Segment4Id { get; set; }
        public int Segment5Id { get; set; }
        public Nullable<double> SpeedDiff1 { get; set; }
        public Nullable<double> SpeedDiff2 { get; set; }
        public Nullable<double> AvgTime { get; set; }
        public Nullable<int> anomalyId { get; set; }
        public int ContainAnomaly { get; set; }
        public Nullable<double> speedAvg4 { get; set; }
    }
}
