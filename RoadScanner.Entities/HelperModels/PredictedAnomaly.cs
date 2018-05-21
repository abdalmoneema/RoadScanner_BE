using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadScanner.Entities.HelperModels
{
    public class PredictedAnomaly
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public short Type { get; set; }
    }
}
