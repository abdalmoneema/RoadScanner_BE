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


        public List<Segments_SegmentChain2> GetAllSegments_SegmentChain2()
        {
            return db.Segments_SegmentChain2.ToList();
        }

        public List<Segments_SegmentChain3> GetAllSegments_SegmentChain3()
        {
            return db.Segments_SegmentChain3.ToList();
        }

        public List<Segments_SegmentChain4> GetAllSegments_SegmentChain4()
        {
            return db.Segments_SegmentChain4.ToList();
        }

        public List<Segments_SegmentChain5> GetAllSegments_SegmentChain5()
        {
            return db.Segments_SegmentChain5.ToList();
        }

        public List<Segments_SegmentChain6> GetAllSegments_SegmentChain6()
        {
            return db.Segments_SegmentChain6.ToList();
        }

        public List<Segments_SpeedDifference_SegmentChain5> GetAllSegments_SpeedDifference_SegmentChain5()
        {
            return db.Segments_SpeedDifference_SegmentChain5.ToList();
        }

        public List<Segments_HighSamplesCount_SegmentChain5> GetAllSegments_HighSamplesCount_SegmentChain5()
        {
            return db.Segments_HighSamplesCount_SegmentChain5.ToList();
        }

        public List<Segments_SegmentChain5_Top28> GetAllSegments_SegmentChain5_Top28()
        {
            return db.Segments_SegmentChain5_Top28.OrderBy(s=>s.speedAvg1).ToList();
        }

        public List<Segments_SegmentChain5_HighSampleCount> GetAllSegments_SegmentChain5_HighSampleCount()
        {
            return db.Segments_SegmentChain5_HighSampleCount.ToList();
        }
        public List<Segments_SegmentChain4_HighSampleCount> GetAllSegments_SegmentChain4_HighSampleCount()
        {
            return db.Segments_SegmentChain4_HighSampleCount.ToList();
        }
        public List<Segments_SegmentChain3_HighSampleCount> GetAllSegments_SegmentChain3_HighSampleCount()
        {
            return db.Segments_SegmentChain3_HighSampleCount.ToList();
        }

        public List<Segments_SpeedDifference_SegmentChain5_Minimized> GetAllSegments_SpeedDifference_SegmentChain5_Minimized()
        {
            return db.Segments_SpeedDifference_SegmentChain5_Minimized.OrderBy(s => s.Segment1Id).ToList();
        }

        public List<Segments_SegmentChain6_Rounded> GetAllSegments_SegmentChain6_Rounded()
        {
            return db.Segments_SegmentChain6_Rounded.ToList();
        }

        public List<Segments_SegmentChain6_AnomalySpreaded> GetAllSegments_SegmentChain6_AnomalySpreaded()
        {
            return db.Segments_SegmentChain6_AnomalySpreaded.ToList();
        }

        public List<Segments_SegmentChain6_4AnomalySpreaded> GetAllSegments_SegmentChain6_4AnomalySpreaded()
        {
            return db.Segments_SegmentChain6_4AnomalySpreaded.ToList();
        }
        public List<Segments_SegmentChain7_AnomalySpreaded> GetAllSegments_SegmentChain7_AnomalySpreaded()
        {
            return db.Segments_SegmentChain7_AnomalySpreaded.ToList();
        }

        public List<Segments_SegmentChain7_AnomalySpreaded_OnLyAnomaly> GetAllSegments_SegmentChain7_AnomalySpreaded_OnlyANomaly()
        {
            return db.Segments_SegmentChain7_AnomalySpreaded_OnLyAnomaly.ToList();
        }

        public List<Segments_SegmentChain7_AnomalySpreaded_ALL> GetAllSegments_SegmentChain7_AnomalySpreaded_All()
        {
            return db.Segments_SegmentChain7_AnomalySpreaded_ALL.ToList();
        }

        
    }
}
