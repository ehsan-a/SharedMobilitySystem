using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem
{
    internal class BicycleVehicle : BaseVehicle
    {
        public BicycleVehicle()
        {
            Id = _nextId++;
            Type = VehicleType.Bicycle;
            Status = VehicleStatus.Available;
        }
    }
}
