using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMobilitySystem
{
    internal abstract class BaseRepository<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public abstract void Add(T input);
        public abstract void Remove(T input);
        public abstract T GetById(int id);
        public abstract IEnumerable<T> GetAll();
    }
}
