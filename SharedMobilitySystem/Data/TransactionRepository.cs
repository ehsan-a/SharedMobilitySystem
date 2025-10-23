using SharedMobilitySystem.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem.Data
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
        public IEnumerable<Transaction> GetByStatusAndUser(TransactionStatus status, User user)
        {
            return Items.Where(x => x.Status == status && x.User == user);
        }
    }
}