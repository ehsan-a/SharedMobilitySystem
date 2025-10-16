using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem
{
    internal class UserRepository : BaseRepository<User>
    {
        public override void Add(User input)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public override User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Remove(User input)
        {
            throw new NotImplementedException();
        }
    }
}
