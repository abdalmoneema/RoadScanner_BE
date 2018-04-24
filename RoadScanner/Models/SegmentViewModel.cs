using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoadScanner.Models
{
    public class SegmentViewModel
    {
        public List<ManualAnomalyViewModel> ManualAnomalies { get; set; }
        //public List<SegmentModel> Segments { get; set; }
        public string SegmentsJson{get; set;}

        public int AnomaliesCount { get; set; }
    }
}