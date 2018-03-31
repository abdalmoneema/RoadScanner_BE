using RoadScanner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadScanner.Entities.Services
{
    public class MLService
    {
        RoadScannerContext db;
        public MLService()
        {
            db = new RoadScannerContext();
        }

        public List<SegmentChain2> GetAllSegmentChain2()
        {
            return db.SegmentChain2.ToList();
        }

        public List<SegmentChain3> GetAllSegmentChain3()
        {
            return db.SegmentChain3.ToList();
        }

        public List<SegmentChain4> GetAllSegmentChain4()
        {
            return db.SegmentChain4.ToList();
        }

        public List<SegmentChain5> GetAllSegmentChain5()
        {
            return db.SegmentChain5.ToList();
        }
    }
}
