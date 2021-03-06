﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RoadScannerContext : DbContext
    {
        public RoadScannerContext()
            : base("name=RoadScannerContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ManualAnomaly> ManualAnomalies { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<Segment> Segments { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<SegmentChain3> SegmentChain3 { get; set; }
        public virtual DbSet<SegmentChain2> SegmentChain2 { get; set; }
        public virtual DbSet<SegmentChain4> SegmentChain4 { get; set; }
        public virtual DbSet<SegmentChain5> SegmentChain5 { get; set; }
        public virtual DbSet<Segments_SegmentChain2> Segments_SegmentChain2 { get; set; }
        public virtual DbSet<Segments_SegmentChain3> Segments_SegmentChain3 { get; set; }
        public virtual DbSet<Segments_SegmentChain4> Segments_SegmentChain4 { get; set; }
        public virtual DbSet<Segments_SegmentChain5> Segments_SegmentChain5 { get; set; }
        public virtual DbSet<Segments_SpeedDifference_SegmentChain5> Segments_SpeedDifference_SegmentChain5 { get; set; }
        public virtual DbSet<Segments_HighSamplesCount_SegmentChain5> Segments_HighSamplesCount_SegmentChain5 { get; set; }
        public virtual DbSet<Segments_SegmentChain5_Top28> Segments_SegmentChain5_Top28 { get; set; }
        public virtual DbSet<Segments_SegmentChain3_HighSampleCount> Segments_SegmentChain3_HighSampleCount { get; set; }
        public virtual DbSet<Segments_SegmentChain4_HighSampleCount> Segments_SegmentChain4_HighSampleCount { get; set; }
        public virtual DbSet<Segments_SegmentChain5_HighSampleCount> Segments_SegmentChain5_HighSampleCount { get; set; }
        public virtual DbSet<Segments_SegmentChain6> Segments_SegmentChain6 { get; set; }
        public virtual DbSet<Segments_SpeedDifference_SegmentChain5_Minimized> Segments_SpeedDifference_SegmentChain5_Minimized { get; set; }
        public virtual DbSet<Segments_SegmentChain6_Rounded> Segments_SegmentChain6_Rounded { get; set; }
        public virtual DbSet<Segments_SegmentChain6_AnomalySpreaded> Segments_SegmentChain6_AnomalySpreaded { get; set; }
        public virtual DbSet<Segments_SegmentChain6_4AnomalySpreaded> Segments_SegmentChain6_4AnomalySpreaded { get; set; }
        public virtual DbSet<Segments_SegmentChain7_AnomalySpreaded> Segments_SegmentChain7_AnomalySpreaded { get; set; }
        public virtual DbSet<Segments_SegmentChain7_AnomalySpreaded_OnLyAnomaly> Segments_SegmentChain7_AnomalySpreaded_OnLyAnomaly { get; set; }
        public virtual DbSet<Segments_SegmentChain7_AnomalySpreaded_ALL> Segments_SegmentChain7_AnomalySpreaded_ALL { get; set; }
        public virtual DbSet<SegmentChain> SegmentChains { get; set; }
    }
}
