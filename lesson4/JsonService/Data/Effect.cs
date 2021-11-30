using JsonService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonService.Data
{
    //Средства для нанесения эффетктов (смывки, пигменты и т.д.)
    [Serializable]
    public class Effect : BaseVolumeData
    {
        public EffectType TypeOfEffect { get; set; }
    }
}
