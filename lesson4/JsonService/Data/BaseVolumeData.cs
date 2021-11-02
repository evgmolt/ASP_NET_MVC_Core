using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonService.Data
{
    //Базовый тип для емкостей 
    public class BaseVolumeData : BaseData
    {
        public decimal Volume { get; set; }
    }
}
