using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SharedMobilitySystem.BaseVehicle;

namespace SharedMobilitySystem
{
    internal class VehicleUI
    {
        private VehicleRepository _vehicleRepository;
        public VehicleUI(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public void GetByStationId(int id)
        {
            const int pad = 15;
            Console.WriteLine($"+{"".PadRight(6, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad + 5, '-')}+");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"| {"#",-4} | {"ID",-pad + 2} | {"TITLE",-pad + 2} | {"DESCRIPTION",-pad + 2} | {"TYPE",-pad + 2} | {"STATUS",-pad + 2} | {"PRICE PER MIN",-pad - 3} |");
            Console.ResetColor();
            Console.WriteLine($"+{"".PadRight(6, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad + 5, '-')}+");
            int counter = 1;
            foreach (var item in _vehicleRepository.GetByStationId(id))
            {
                Console.WriteLine($"| {counter,-4} | {item.Id,-pad + 2} | {item.Title,-pad + 2} | {item.Description,-pad + 2} | {item.Type,-pad + 2} | {item.Status,-pad + 2} | {item.PricePerMinute,-pad - 3} |");
                Console.WriteLine($"+{"".PadRight(6, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad + 5, '-')}+");
                counter++;
            }
        }
        public void GetById(int id)
        {
            const int pad = 15;
            Console.WriteLine($"+{"".PadRight(6, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad + 5, '-')}+");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"| {"#",-4} | {"ID",-pad + 2} | {"TITLE",-pad + 2} | {"DESCRIPTION",-pad + 2} | {"TYPE",-pad + 2} | {"STATUS",-pad + 2} | {"PRICE PER MIN",-pad - 3} |");
            Console.ResetColor();
            Console.WriteLine($"+{"".PadRight(6, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad + 5, '-')}+");
            var item = _vehicleRepository.GetById(id);
            Console.WriteLine($"| {1,-4} | {item.Id,-pad + 2} | {item.Title,-pad + 2} | {item.Description,-pad + 2} | {item.Type,-pad + 2} | {item.Status,-pad + 2} | {item.PricePerMinute,-pad - 3} |");
            Console.WriteLine($"+{"".PadRight(6, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad + 5, '-')}+");
        }
    }
}
