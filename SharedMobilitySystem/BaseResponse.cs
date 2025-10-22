using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem
{
    public enum ErrorType
    {
        None = 0,
        UserError = 1,
        VehicleError = 2,
        InputError = 3,
        StationError = 4,
        TransactionError = 5,
    }
    internal class BaseResponse<T>
    {
        public bool Staus { get; set; }
        public ErrorType ErrorType { get; set; }
        public T? Output { get; set; }

    }
}
