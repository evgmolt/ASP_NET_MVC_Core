using System;
using System.Collections.Generic;
using System.Text;

namespace JsonService.Data
{
    [Serializable]
    public abstract class CommonData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
    }
}
