using SharedMobilitySystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem.UI
{
    internal class UserUI
    {
        private UserRepository _userRepository;
        public UserUI(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void GetById(int id)
        {

            const int pad = 15;
            Console.WriteLine($"+{"".PadRight(6, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad + 5, '-')}+");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"| {"#",-4} | {"ID",-pad + 2} | {"FIRST NAME",-pad + 2} | {"LAST NAME",-pad + 2} | {"USERNAME",-pad + 2} | {"BALANCE",-pad + 2} | {"#",-pad - 3} |");
            Console.ResetColor();
            Console.WriteLine($"+{"".PadRight(6, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad + 5, '-')}+");
            var item = _userRepository.GetById(id);
            Console.WriteLine($"| {1,-4} | {item.Id,-pad + 2} | {item.FirstName,-pad + 2} | {item.LastName,-pad + 2} | {item.Username,-pad + 2} | {item.Balance,-pad + 2} | {"#",-pad - 3} |");
            Console.WriteLine($"+{"".PadRight(6, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad + 5, '-')}+");
        }
    }
}
