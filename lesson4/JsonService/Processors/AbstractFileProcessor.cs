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
        public CommonData ProcessContent(string content)
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

        protected abstract CommonData Process(string content);
    }
}
