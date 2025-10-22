using SharedMobilitySystem.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem.Data
{
    internal class UserRepository : BaseRepository<User>
    {
        public override void Add(User input)
        {
            Items.Add(input);
        }
        public override IEnumerable<User> GetAll()
        {
            return Items;
        }
        public override User GetById(int id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }
        public override void Remove(User input)
        {
            Items.Remove(input);
        }
        public User GetByUsernameAndPassword(string username, string password)
        {
            return Items.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}