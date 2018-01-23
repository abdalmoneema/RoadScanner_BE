using RoadScanner.Areas.API.Models;
using RoadScanner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoadScanner.Areas.API.Mapper
{
    public static class TripMapper
    {
        public static Trip MapToTrip(this TripModel tripModel)
        {
            return new Trip()
            {
                DeviceID = tripModel.DeviceID,
                Measurements = tripModel.Measurements.Select(m => new Measurement() {
                    Longitude = m.Longitude,
                    Latitude = m.Latitude,
                    AccelerationX = m.AccelerationX,
                    AccelerationY=m.AccelerationY,
                    AccelerationZ = m.AccelerationZ,
                    Speed = 0,
                    MeasurementTime = m.MeasurementTime             
                    }).ToList()
            };
        }
    }
}