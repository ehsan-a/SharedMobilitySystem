using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem.Models.Base
{
    internal class User
    {
        public int Id { get; set; }
        public static int _nextId { get; set; } = 1;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public User()
        {
            Id = _nextId++;
        }
    }
}