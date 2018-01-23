using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadScanner.Entities.Services
{
    public class TripService
    {
        RoadScannerContext db;
        public TripService()
        {
            db = new RoadScannerContext();
        }

        public int Create(Trip trip)
        {
            db.Trips.Add(trip);
            db.SaveChanges();
            return trip.Id;
        }
    }
}
