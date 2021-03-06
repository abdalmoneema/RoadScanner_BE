﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadScanner.Entities.Services
{
    public class SegmentService
    {
        RoadScannerContext db;
        public SegmentService()
        {
            db = new RoadScannerContext();
        }

        public List<Segment> GetAllSegments()
        {
            return db.Segments.ToList();
        }

        public int CreateSegmentChain(SegmentChain segmentChain)
        {
            db.SegmentChains.Add(segmentChain);
            segmentChain.CreationDate = DateTime.UtcNow;
            db.SaveChanges();
            return segmentChain.Id;
        }


    }
}
