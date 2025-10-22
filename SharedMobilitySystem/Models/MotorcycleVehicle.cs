using SharedMobilitySystem.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem.Models
{
    internal class MotorcycleVehicle : BaseVehicle
    {
        public MotorcycleVehicle()
        {
            Id = _nextId++;
            Type = VehicleType.Motorcycle;
            Status = VehicleStatus.Available;
        }
    }
}