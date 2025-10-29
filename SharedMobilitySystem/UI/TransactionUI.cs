using SharedMobilitySystem.Data;
using SharedMobilitySystem.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem.UI
{
    internal class TransactionUI
    {
        private TransactionRepository _transactionRepository;
        public TransactionUI(TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public void GetByStatus(TransactionStatus transactionStatus, User user)
        {
            const int pad = 15;
            Console.WriteLine($"+{"".PadRight(6, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad + 5, '-')}+");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"| {"#",-4} | {"ID",-pad + 2} | {"VEHICLE ID",-pad + 2} | {"PAYSTATUS",-pad + 2} | {"DURATION",-pad + 2} | {"STATUS",-pad + 2} | {"PRICE",-pad - 3} |");
            Console.ResetColor();
            Console.WriteLine($"+{"".PadRight(6, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad + 5, '-')}+");
            foreach (var item in _transactionRepository.GetByStatusAndUser(transactionStatus, user))
            {
                Console.WriteLine($"| {1,-4} | {item.Id,-pad + 2} | {item.Vehicle.Id,-pad + 2} | {item.PayStatus,-pad + 2} | {(transactionStatus == TransactionStatus.Delivered ? item.Duration() + " m" : item.Duration(DateTime.Now) + " m"),-pad + 2} | {item.Status,-pad + 2} | {(transactionStatus == TransactionStatus.Delivered ? item.TotalPrice() : item.TotalPrice(DateTime.Now)),-pad - 3} |");
                Console.WriteLine($"+{"".PadRight(6, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad, '-')}+{"".PadRight(pad + 5, '-')}+");
            }
        }
    }
}