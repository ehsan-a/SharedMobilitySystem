using SharedMobilitySystem.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem.Models
{
    internal class StationC : BaseStation
    {
        public StationC()
        {
            Id = _nextId++;
            Type = StationType.C;
            Capacity = 20;
        }
    }
}
