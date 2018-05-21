using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.SqlServer;
using RoadScanner.Entities.HelperModels;

namespace RoadScanner.Entities.Services
{
    public class RealtimeService
    {
        RoadScannerContext db;
        public RealtimeService()
        {
            db = new RoadScannerContext();
        }

        public List<PredictedAnomaly> GetNextAnomalies(int segmentId)
        {
            List<PredictedAnomaly> segmentsChains = new List<PredictedAnomaly>();

            var chain = db.SegmentChains.Where(s => s.Segment1Id == segmentId).FirstOrDefault();
            if (chain != null)
            {
                var seg = db.Segments.Find(chain.Segment4Id);
                segmentsChains.Add(new PredictedAnomaly() { Latitude = seg.Latitude.Value, Longitude = seg.Longitude.Value, Type = chain.PredictedAnomalyType });

                var chain2 = db.SegmentChains.Where(s => s.Segment1Id == chain.Segment2Id || s.Segment1Id == chain.Segment3Id || s.Segment1Id == chain.Segment4Id || s.Segment1Id == chain.Segment5Id || s.Segment1Id == chain.Segment6Id || s.Segment1Id == chain.Segment7Id).ToList();
                if (chain2 != null && chain2.Count > 0)
                {
                    foreach (var ch in chain2)
                    {
                        var segmnt = db.Segments.Find(ch.Segment4Id);
                        segmentsChains.Add(new PredictedAnomaly() { Latitude = segmnt.Latitude.Value, Longitude = segmnt.Longitude.Value, Type = ch.PredictedAnomalyType });
                    }
                }
            }


            return segmentsChains;
        }

        public int? GetPointSegment(float latitude, float longitude)
        {
            return db.GetPointSegment(latitude, longitude);
        }
    }
}
