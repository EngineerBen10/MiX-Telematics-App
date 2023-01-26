using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePoisitions.Models
{
    public  class Vehicle
    {
        public int PositionId { get; set; }
        public string? VehicleRegistration { get; set; }
        public Coordinate? Coord { get; set; }
        public DateTime RecordedTimeUTC { get; set; }
    }
}
