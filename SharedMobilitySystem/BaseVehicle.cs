using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem
{
    internal class BaseVehicle
    {
        public enum VehicleType
        {
            Bicycle,
            Scooter,
            Motorcycle
        }
        public enum VehicleStatus
        {
            Available,
            InUse,
            UnderMaintenance
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public VehicleType Type { get; set; }
        public decimal PricePerMinute { get; set; }
        public BaseStation Station { get; set; }
        public VehicleStatus Status { get; set; }
    }
}
