using JsonService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonService.Data
{
    [Serializable]
    public class Effect : CommonData
    {
        public EffectType TypeOfEffect { get; set; }
    }
}
