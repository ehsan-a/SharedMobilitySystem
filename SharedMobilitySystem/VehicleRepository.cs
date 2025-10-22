using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem
{
    internal class VehicleRepository : BaseRepository<BaseVehicle>
    {
        public override void Add(BaseVehicle input)
        {
            Items.Add(input);
        }
        public override IEnumerable<BaseVehicle> GetAll()
        {
            return Items;
        }
        public override BaseVehicle GetById(int id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }
        public override void Remove(BaseVehicle input)
        {
            Items.Remove(input);
        }
        public IEnumerable<BaseVehicle> GetByStationId(int id)
        {
            return Items.Where(x => x.Station.Id == id && x.Status == BaseVehicle.VehicleStatus.Available);
        }
    }
}