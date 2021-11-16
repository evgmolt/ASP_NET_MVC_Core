using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDemo
{
    public class StringRepository : IRepository<string>
    {
        public List<string> Items;

        public StringRepository()
        {
            Items = new List<string>();
        }

        public void Create(string item)
        {
            Items.Add(item);
        }

        public bool Delete(string item)
        {
            return Items.Remove(item);
        }

        public IEnumerable<string> Read()
        {
            return Items;
        }
    }
}
