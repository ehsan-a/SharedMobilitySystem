// See https://aka.ms/new-console-template for more information
using SharedMobilitySystem;
UserRepository userRepository = new UserRepository();
TransactionRepository transactionRepository = new TransactionRepository();
StationRepository stationRepository = new StationRepository();
VehicleRepository vehicleRepository = new VehicleRepository();
MainService mainService = new MainService(userRepository, vehicleRepository, transactionRepository, stationRepository);
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
//---------------------------
Console.WriteLine("Login: => User:ehsan -  ID:1");
var currentUser = userRepository.GetById(1);
Console.WriteLine($"Welcome {currentUser.FirstName} {currentUser.LastName}");
Console.WriteLine();
Console.WriteLine("List of Station with Avaiable vehicle: =>");
foreach (var item in stationRepository.GetAll())
{
    Console.WriteLine($"ID: {item.Id} - Station Name: {item.Title} - Address {item.Address}");
    Console.WriteLine("List Of Vehicle =>");
    foreach (var item1 in vehicleRepository.GetByStation(item))
    {
        Console.WriteLine($"ID: {item1.Id} - Vehicle name: {item1.Title} - Status: {item1.Status} - Type: {item1.Type}");
    }
    Console.WriteLine("------------------------------");
}
Console.WriteLine();
Console.WriteLine("Rent Vehicle Id:1 =>");
var result = mainService.Rent(1, 1);
if (result.Staus)
{
    Console.WriteLine($"Transaction Id: {result.Output.Id} - StartTime: {result.Output.StartTime} - Status: {result.Output.Status} - Payment: {result.Output.PayStatus}");
}
Console.WriteLine();
Console.WriteLine("List of Station with Avaiable vehicle (After Rent): =>");
foreach (var item in stationRepository.GetAll())
{
    Console.WriteLine($"ID: {item.Id} - Station Name: {item.Title} - Address {item.Address}");
    Console.WriteLine("List Of Vehicle =>");
    foreach (var item1 in vehicleRepository.GetByStation(item))
    {
        Console.WriteLine($"ID: {item1.Id} - Vehicle name: {item1.Title} - Status: {item1.Status}");
    }
    Console.WriteLine("------------------------------");
}
Console.WriteLine();
Console.WriteLine("Return Vehicle Id:1 - Station Id:1 =>");

result = mainService.Return(1, 1);
if (result.Staus)
{
    Console.WriteLine($"Transaction Id: {result.Output.Id} - StartTime: {result.Output.StartTime} - EndTime: {result.Output.EndTime} - Status: {result.Output.Status} - TotalPrice: {result.Output.TotalPrice()} - Payment: {result.Output.PayStatus}");
}
Console.WriteLine();
Console.WriteLine("List of Station with Avaiable vehicle (After Return): =>");
foreach (var item in stationRepository.GetAll())
{
    Console.WriteLine($"ID: {item.Id} - Station Name: {item.Title} - Address {item.Address}");
    Console.WriteLine("List Of Vehicle =>");
    foreach (var item1 in vehicleRepository.GetByStation(item))
    {
        Console.WriteLine($"ID: {item1.Id} - Vehicle name: {item1.Title} - Status: {item1.Status}");
    }
    Console.WriteLine("------------------------------");
}