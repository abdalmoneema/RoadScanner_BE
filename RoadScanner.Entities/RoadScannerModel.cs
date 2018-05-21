using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadScanner.Entities
{
    public partial class RoadScannerContext 
    {
        [DbFunction("RoadScanner.Entities.Store", "GetPointSegment")]
        public int? GetPointSegment(float? latitude, float? longitude)
        {
            List<ObjectParameter> parameters = new List<ObjectParameter>(3);
            parameters.Add(new ObjectParameter("latitude", latitude));
            parameters.Add(new ObjectParameter("longitude", longitude));
            var lObjectContext = ((IObjectContextAdapter)this).ObjectContext;
            var output = lObjectContext.
                    CreateQuery<int?>("RoadScanner.Entities.Store.GetPointSegment(@latitude, @longitude)", parameters.ToArray())
                .Execute(MergeOption.NoTracking)
                .FirstOrDefault();
            return output;
        }
    }
}
