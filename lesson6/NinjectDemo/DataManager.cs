using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDemo
{
    public class DataManager
    {
        IRepository<int> _intRepository;
        IRepository<string> _stringRepository;

        public DataManager(IRepository<int> intRepository, IRepository<string> stringRepository)
        {
            _intRepository = intRepository;
            _stringRepository = stringRepository;
        }

        public void CreateString(string item)
        {
            _stringRepository.Create(item);
        }

        public void CreateInt(int item)
        {
            _intRepository.Create(item);
        }

        public IEnumerable<string> GetStrings()
        {
            return _stringRepository.Read();
        }

        public IEnumerable<int> GetInts()
        {
            return _intRepository.Read();
        }
    }

}
