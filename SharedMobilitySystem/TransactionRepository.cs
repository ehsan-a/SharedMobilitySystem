using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem
{
    internal class TransactionRepository : BaseRepository<Transaction>
    {
        public override void Add(Transaction input)
        {
            Items.Add(input);
        }
        public override IEnumerable<Transaction> GetAll()
        {
            return Items;
        }
        public override Transaction GetById(int id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }
        public override void Remove(Transaction input)
        {
            Items.Remove(input);
        }
        public Transaction GetByStatus(Transaction.TransactionStatus status)
        {
            return Items.FirstOrDefault(x => x.Status == status);
        }
    }
}