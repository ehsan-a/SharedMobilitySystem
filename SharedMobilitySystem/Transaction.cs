using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem
{
    internal class Transaction
    {

        public enum TransactionStatus
        {
            Active,
            Delivered
        }
        public enum PaymentStatus
        {
            NotPaid,
            Paid
        }
        public int Id { get; set; }
        private static int _nextId { get; set; } = 1;
        public User User { get; set; }
        public BaseVehicle Vehicle { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TransactionStatus Status { get; set; }
        public PaymentStatus PayStatus { get; set; }
        public Transaction()
        {
            Id = _nextId++;
            StartTime = DateTime.Now;
            Status = TransactionStatus.Active;
            PayStatus = PaymentStatus.NotPaid;
        }
        public int Duration()
        {
            return (EndTime - StartTime).Minutes;
        }
        public decimal TotalPrice()
        {
            var duration = Duration();
            if (duration <= 15)
            {
                return 15 * this.Vehicle.PricePerMinute;
            }
            else
            {
                return duration * this.Vehicle.PricePerMinute;
            }
        }
    }
}