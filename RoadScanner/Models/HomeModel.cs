using RoadScanner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoadScanner.Models
{
    public class HomeModel
    {
        public IEnumerable<ManualAnomalyViewModel> ManualAnomalies { get; set; }
    }
}