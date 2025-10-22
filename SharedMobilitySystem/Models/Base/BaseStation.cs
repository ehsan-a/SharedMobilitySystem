using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem.Models.Base
{
    public enum StationType
    {
        A,
        B,
        C
    }
    internal class BaseStation
    {
        public int Id { get; set; }
        public static int _nextId { get; set; } = 1;
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public TimeOnly OpenTime { get; set; }
        public TimeOnly CloseTime { get; set; }
        public StationType Type { get; set; }
    }
}
