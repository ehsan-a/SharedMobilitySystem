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
        public User User { get; set; }
        public BaseVehicle Vehicle { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TransactionStatus Status { get; set; }
        public PaymentStatus PayStatus { get; set; }
        public TimeSpan Duration()
        {
            throw new NotImplementedException();
        }
        public decimal TotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}