using JsonService.Data;
using JsonService.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonService
{
    abstract class AbstractFileProcessor
    {
        public BaseData ProcessContent(string content)
        {
            if (content != "")
            {
                return Process(content);
            }
            else
            {
                return null;
            }
        }

        protected abstract BaseData Process(string content);
    }
}
