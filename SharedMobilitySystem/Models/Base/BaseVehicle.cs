using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem.Models.Base
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
        UnderMaintenance,
    }
    internal class BaseVehicle
    {
        public int Id { get; set; }
        public static int _nextId { get; set; } = 1;
        public string Title { get; set; }
        public string Description { get; set; }
        public VehicleType Type { get; set; }
        public decimal PricePerMinute { get; set; }
        public BaseStation Station { get; set; }
        public VehicleStatus Status { get; set; }
        public string? LastLocation { get; set; }
    }
}
