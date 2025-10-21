using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem
{
    internal class StationA : BaseStation
    {
        public StationA()
        {
            Id = _nextId++;
            Type = StationType.A;
            Capacity = 15;
        }
    }
}
