using SharedMobilitySystem.Data;
using SharedMobilitySystem.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem.UI
{
    internal class AuthenticationUI
    {
        public UserRepository UserRepository { get; set; }

        public AuthenticationUI(UserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public User Login()
        {
            Console.Write("Username: ");
            string usernameLogin = Console.ReadLine();
            Console.Write("Password: ");
            string passwordLogin = Console.ReadLine();
            var result = UserRepository.GetByUsernameAndPassword(usernameLogin, passwordLogin);
            if (result != null)
            {
                Console.WriteLine($"Welcome {result.FirstName} {result.LastName}");
                return result;
            }
            else
            {
                Console.WriteLine("Login Error!");
                return null;
            }
        }
        public bool Register()
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            User user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Password = password,
                Balance = 0
            };
            if (UserRepository.GetByUsername(username) == null)
            {
                UserRepository.Add(user);
                Console.WriteLine("Register Successfull!");
                return true;
            }
            else
            {
                Console.WriteLine("Username Avaiable!");
                return false;
            }
        }
    }
}
