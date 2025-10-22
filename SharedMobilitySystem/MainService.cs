using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem
{
    internal class MainService
    {
        public UserRepository UserRepository { get; set; }
        public VehicleRepository VehicleRepository { get; set; }
        public TransactionRepository TransactionRepository { get; set; }
        public StationRepository StationRepository { get; set; }
        public MainService(UserRepository userRepository, VehicleRepository vehicleRepository, TransactionRepository transactionRepository, StationRepository stationRepository)
        {
            UserRepository = userRepository;
            VehicleRepository = vehicleRepository;
            TransactionRepository = transactionRepository;
            StationRepository = stationRepository;
        }
        public BaseResponse<Transaction> Rent(int userId, int vehicleId)
        {
            var result = new BaseResponse<Transaction>();
            var user = UserRepository.GetById(userId);
            if (user == null)
            {
                result.Staus = false;
                result.ErrorType = ErrorType.UserError;
                return result;
            }
            var vehicle = VehicleRepository.GetById(vehicleId);
            if (vehicle == null)
            {
                result.Staus = false;
                result.ErrorType = ErrorType.VehicleError;
                return result;
            }
            var transaction = new Transaction()
            {
                Vehicle = vehicle,
                User = user,
            };
            TransactionRepository.Add(transaction);
            vehicle.Status = BaseVehicle.VehicleStatus.InUse;
            result.Staus = true;
            result.Output = transaction;
            return result;
        }
        public BaseResponse<Transaction> Return(int stationId, int transactionId)
        {
            var result = new BaseResponse<Transaction>();
            var station = StationRepository.GetById(stationId);
            if (station == null)
            {
                result.Staus = false;
                result.ErrorType = ErrorType.StationError;
                return result;
            }
            var transaction = TransactionRepository.GetById(transactionId);
            if (transaction == null)
            {
                result.Staus = false;
                result.ErrorType = ErrorType.TransactionError;
                return result;
            }
            result.Staus = true;
            result.Output = transaction;
            transaction.EndTime = DateTime.Now;
            transaction.Status = Transaction.TransactionStatus.Delivered;
            transaction.Vehicle.Station = station;
            transaction.Vehicle.Status = BaseVehicle.VehicleStatus.Available;
            return result;
        }
    }
}