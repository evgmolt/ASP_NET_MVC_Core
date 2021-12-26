using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDemo 
{
    public class IntRepository : IRepository<int>
    {
        public List<int> Items;

        public IntRepository()
        {
            Items = new List<int>();
        }

        public void Create(int item)
        {
            Items.Add(item);
        }

        public bool Delete(int item)
        {
            return Items.Remove(item);
        }

        public IEnumerable<int> Read()
        {
            return Items;
        }
    }
}
