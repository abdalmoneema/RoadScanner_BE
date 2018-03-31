using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadScanner.Entities.Services
{
    public class TripPathService
    {
        RoadScannerContext db;
        public TripPathService()
        {
            db = new RoadScannerContext();
        }

        public List<Trip> GetAllTrips()
        {
            return db.Trips.ToList();
        }

        public List<Measurement> GetTripMeasuremnts(int tripId)
        {
            return db.Measurements.Where(m=>m.TripId == tripId).ToList();
        }

        public List<Measurement> GetTripMeasuremnts(int FromSampleId, int ToSampleId)
        {
            return db.Measurements.Where(m => m.Id >= FromSampleId  && m.Id <= ToSampleId).ToList();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
