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
            AuthenticationUI authenticationUI = new AuthenticationUI(userRepository);
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
                Address = "Narmak",
                OpenTime = new TimeOnly(08, 00),
                CloseTime = new TimeOnly(22, 00)
            };
            stationRepository.Add(station1);
            BaseStation station2 = new StationB()
            {
                Title = "Station 2",
                Description = "test",
                Address = "Resalat",
                OpenTime = new TimeOnly(12, 00),
                CloseTime = new TimeOnly(22, 00)
            };
            stationRepository.Add(station2);
            BaseStation station3 = new StationC()
            {
                Title = "At the city",
                Description = "Vehicles in the city",
                Address = "-",
                OpenTime = new TimeOnly(00, 00),
                CloseTime = new TimeOnly(00, 00)
            };
            stationRepository.Add(station3);
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
            BaseVehicle vehicle3 = new ScooterVehicle()
            {
                Title = "Xiaomi",
                Description = "30 kph",
                PricePerMinute = 17,
                Station = station1
            };
            vehicleRepository.Add(vehicle3);
            BaseVehicle vehicle4 = new BicycleVehicle
            {
                Title = "Phonix",
                Description = "5 Gear",
                PricePerMinute = 8,
                Station = station2
            };
            vehicleRepository.Add(vehicle4);
            BaseVehicle vehicle5 = new BicycleVehicle
            {
                Title = "Phonix",
                Description = "5 Gear",
                PricePerMinute = 8,
                Station = station2
            };
            vehicleRepository.Add(vehicle5);
            BaseVehicle vehicle6 = new BicycleVehicle
            {
                Title = "Phonix",
                Description = "5 Gear",
                PricePerMinute = 8,
                Station = station2
            };
            vehicleRepository.Add(vehicle6);

            User currentUser = null;
            while (true)
            {
                Console.Write("[1] Login - [2] Register => ");
                switch (Console.ReadLine())
                {
                    case "1":
                        while (true)
                        {
                            var user = authenticationUI.Login();
                            if (user != null)
                            {
                                currentUser = user;
                                break;
                            }
                        }
                        break;
                    case "2":
                        while (true)
                        {
                            if (authenticationUI.Register()) break;
                        }
                        break;
                    default:
                        Console.WriteLine("Out Of Range!");
                        break;
                }
                if (currentUser != null) break;
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
                        if (transactionRepository.GetByStatusAndUser(TransactionStatus.Active, currentUser).Count() > 0)
                        {
                            Console.WriteLine("You Have Active Transaction!");
                            break;
                        }
                        while (true)
                        {
                            Console.Write("Select a vehicle ID to rent ([b] Back) => ");
                            input = Console.ReadLine();
                            if (input == "b") break;
                            if (!int.TryParse(input, out int id))
                            {
                                Console.WriteLine("Input not Valid!");
                                break;
                            }

                            if (vehicleRepository.GetById(int.Parse(input)) == null)
                            {
                                Console.WriteLine("Error Id!");
                                continue;
                            }
                            vehicleUI.GetById(int.Parse(input));
                            var response = mainService.Rent(currentUser.Id, int.Parse(input));
                            if (response.Staus) Console.WriteLine("Register Successfull!");
                            break;
                        }
                        break;
                    case "3":
                        var transaction = transactionRepository.GetByStatusAndUser(TransactionStatus.Active, currentUser);
                        if (transaction.ToList().Count == 0)
                        {
                            Console.WriteLine("No Data!");
                            break;
                        }
                        transactionUI.GetByStatus(TransactionStatus.Active, currentUser);
                        Console.Write("[1] Delivery In Station | [2] Delivery In City | [3] Back => ");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Write("Select a Station ID to Delivery ([b] Back) => ");
                                input = Console.ReadLine();
                                if (input == "b") break;
                                int stationId = int.Parse(input);
                                if (mainService.Return(stationId, transaction.ToList()[0].Id).Staus)
                                    Console.WriteLine("Successfull!");
                                break;
                            case "2":
                                Console.Write("Enter Address To Delivery In City ([b] Back) => ");
                                string address = Console.ReadLine();
                                if (address == "b") break;
                                if (mainService.Return(address, transaction.ToList()[0].Id).Staus)
                                    Console.WriteLine("Successfull!");
                                break;
                            case "3":
                                break;
                            default:
                                break;
                        }
                        break;
                    case "4":
                        if (transactionRepository.GetByStatusAndUser(TransactionStatus.Delivered, currentUser).ToList().Count == 0)
                        {
                            Console.WriteLine("No Data!");
                            break;
                        }
                        transactionUI.GetByStatus(TransactionStatus.Delivered, currentUser);
                        Console.Write("[1] Payment | [2] Back => ");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Write("Select a Transaction ID to Payment ([b] Back) => ");
                                input = Console.ReadLine();
                                if (input == "b") break;
                                int transactionId = int.Parse(input);
                                if (transactionRepository.GetById(transactionId) == null)
                                {
                                    Console.WriteLine("Transaction Not found!");
                                    break;
                                }
                                if (transactionRepository.GetById(transactionId).PayStatus == PaymentStatus.NotPaid)
                                {
                                    if (transactionRepository.GetById(transactionId).Payment())
                                        Console.WriteLine("Successfull!");
                                    else Console.WriteLine("Not Successfull!");
                                }
                                else
                                {
                                    Console.WriteLine("Transaction Is Paid!");
                                }
                                break;
                            case "2":
                                break;
                        }
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