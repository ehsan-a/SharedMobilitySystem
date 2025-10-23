using SharedMobilitySystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SharedMobilitySystem.Models.Base.BaseStation;

namespace SharedMobilitySystem.UI
{
    internal class StationUI
    {
        private StationRepository _stationRepository;
        public StationUI(StationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }
        public void GetAll()
        {
            const int pad = 15;
            Console.WriteLine($"+{"".PadRight(6, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad + 7, '-')}+");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"| {"#",-4} | {"ID",-pad + 2} | {"TITLE",-pad + 2} | {"ADDRESS",-pad + 2} | {"CAPACITY",-pad + 2} | {"TYPE",-pad + 2} | {"WORKING TIME",-pad - 5} |");
            Console.ResetColor();
            Console.WriteLine($"+{"".PadRight(6, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad + 7, '-')}+");
            int counter = 1;
            foreach (var item in _stationRepository.GetAll())
            {
                Console.WriteLine($"| {counter,-4} | {item.Id,-pad + 2} | {item.Title,-pad + 2} | {item.Address,-pad + 2} | {item.Capacity,-pad + 2} | {item.Type,-pad + 2} | {item.OpenTime + " - " + item.CloseTime,-pad - 5} |");
                Console.WriteLine($"+{"".PadRight(6, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad + 7, '-')}+");
                counter++;
            }
        }
    }
}