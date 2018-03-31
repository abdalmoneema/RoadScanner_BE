using RoadScanner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoadScanner.Models
{
    public class TripPathViewModel
    {
        public int? TripId { get; set; }
        public bool ViewRawLocation { get; set; }

        public ICollection<Trip> Trips { get; set; }
        public List<SelectListItem> AllTrips
        {
            get
            {
                return Trips.Select(x => new SelectListItem()
                {
                    Text = x.Id.ToString(),
                    Value = x.Id.ToString()
                }).ToList();
            }
        }

        public List<ManualAnomalyViewModel> ManualAnomalies { get; set; }

        public List<MeasurementViewModel> Measurements { get; set; }
        public int SamplesCount { get { return Measurements ==null? 0: Measurements.Count; } }
    }
}