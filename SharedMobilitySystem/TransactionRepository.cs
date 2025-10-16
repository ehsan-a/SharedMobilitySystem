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
            throw new NotImplementedException();
        }

        public override IEnumerable<Transaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Transaction GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Transaction input)
        {
            throw new NotImplementedException();
        }
    }
}
