using SharedMobilitySystem.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem.Models
{
    internal class ScooterVehicle : BaseVehicle
    {
        public ScooterVehicle()
        {
            Id = _nextId++;
            Type = VehicleType.Scooter;
            Status = VehicleStatus.Available;
        }
    }
}