using SharedMobilitySystem.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem.Data
{
    internal class StationRepository : BaseRepository<BaseStation>
    {
        public override void Add(BaseStation input)
        {
            Items.Add(input);
        }
        public override IEnumerable<BaseStation> GetAll()
        {
            return Items;
        }
        public override BaseStation GetById(int id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }
        public override void Remove(BaseStation input)
        {
            Items.Remove(input);
        }
    }
}