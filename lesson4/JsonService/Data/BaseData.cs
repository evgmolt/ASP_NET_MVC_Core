using System;
using System.Collections.Generic;
using System.Text;

namespace JsonService.Data
{
    //Базовый тип данных
    [Serializable]
    public abstract class BaseData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
    }
}
