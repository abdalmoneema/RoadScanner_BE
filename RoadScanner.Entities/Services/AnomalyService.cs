using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadScanner.Entities.Services
{
    public class AnomalyService
    {
        RoadScannerContext db;
        public AnomalyService()
        {
            db = new RoadScannerContext();
        }

        public int Create(ManualAnomaly anomaly)
        {
            db.ManualAnomalies.Add(anomaly);
            anomaly.CreationDate = DateTime.UtcNow;
            db.SaveChanges();
            return anomaly.Id;
        }

        public IEnumerable<ManualAnomaly> GetAllManualAnomalies()
        {
            return db.ManualAnomalies.ToList();
        }
    }
}
