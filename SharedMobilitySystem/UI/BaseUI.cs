using SharedMobilitySystem.Data;
using SharedMobilitySystem.Models;
using SharedMobilitySystem.Models.Base;
using SharedMobilitySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem.UI
{
    internal class BaseUI
    {
        public void AppRun()
        {
            UserRepository userRepository = new UserRepository();
            TransactionRepository transactionRepository = new TransactionRepository();
            StationRepository stationRepository = new StationRepository();
            VehicleRepository vehicleRepository = new VehicleRepository();
            MainService mainService = new MainService(userRepository, vehicleRepository, transactionRepository, stationRepository);
            StationUI stationUI = new StationUI(stationRepository);
            VehicleUI vehicleUI = new VehicleUI(vehicleRepository);
            TransactionUI transactionUI = new TransactionUI(transactionRepository);
            UserUI userUI = new UserUI(userRepository);
            User user1 = new User()
            {
                FirstName = "Ehsan",
                LastName = "Arefzadeh",
                Username = "ehsan",
                Password = "1234",
                Balance = 3000
            };
            userRepository.Add(user1);
            BaseStation station1 = new StationA()
            {
                Title = "Station 1",
                Description = "test",
                Address = "Narmak tehran",
                OpenTime = new TimeOnly(08, 00),
                CloseTime = new TimeOnly(22, 00)
            };
            stationRepository.Add(station1);
            BaseVehicle vehicle1 = new MotorcycleVehicle()
            {
                Title = "Honda",
                Description = "125 cc",
                PricePerMinute = 10,
                Station = station1
            };
            vehicleRepository.Add(vehicle1);
            BaseVehicle vehicle2 = new BicycleVehicle()
            {
                Title = "Phonix",
                Description = "5 Gear",
                PricePerMinute = 8,
                Station = station1
            };
            vehicleRepository.Add(vehicle2);

            User currentUser;
            while (true)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                var result = userRepository.GetByUsernameAndPassword(username, password);
                if (result != null)
                {
                    currentUser = result;
                    Console.WriteLine($"Welcome {currentUser.FirstName} {currentUser.LastName}");
                    break;
                }
                else
                {
                    Console.WriteLine("Login Error!");
                }
            }
            bool isRun = true;
            while (isRun)
            {
                Console.Write("[1] Stations | [2] Rent | [3] Active Transaction | [4] Transactions | [5] Profile | [6] Exit => ");
                switch (Console.ReadLine())
                {
                    case "1":
                        stationUI.GetAll();
                        string input;
                        while (true)
                        {
                            Console.Write("Select a station ID to display vehicles ([b] Back) => ");
                            input = Console.ReadLine();
                            if (input == "b") break;
                            vehicleUI.GetByStationId(int.Parse(input));
                        }
                        break;
                    case "2":
                        Console.Write("Select a vehicle ID to rent ([b] Back) => ");
                        input = Console.ReadLine();
                        if (input == "b") break;
                        vehicleUI.GetById(int.Parse(input));
                        var response = mainService.Rent(currentUser.Id, int.Parse(input));
                        if (response.Staus) Console.WriteLine("Register Successfull!");
                        break;
                    case "3":
                        transactionUI.GetByStatus(TransactionStatus.Active);
                        var transaction = transactionRepository.GetByStatus(TransactionStatus.Active);
                        Console.Write("[1] Delivery | [2] Back => ");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Write("Select a Station ID to Delivery ([b] Back) => ");
                                int stationId = int.Parse(Console.ReadLine());
                                if (mainService.Return(stationId, transaction.ToList()[0].Id).Staus)
                                    Console.WriteLine("Successfull!");
                                break;
                            case "2":
                                break;
                            default:
                                break;
                        }
                        break;
                    case "4":
                        transactionUI.GetByStatus(TransactionStatus.Delivered);
                        break;
                    case "5":
                        userUI.GetById(currentUser.Id);
                        break;
                    case "6":
                        isRun = false;
                        break;
                    default:
                        Console.WriteLine("Out Of Range!");
                        break;
                }
            }
        }
    }
}