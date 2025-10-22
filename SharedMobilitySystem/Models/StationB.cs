using SharedMobilitySystem.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem.Models
{
    internal class StationB : BaseStation
    {
        public StationB()
        {
            Id = _nextId++;
            Type = StationType.B;
            Capacity = 10;
        }
    }
}
