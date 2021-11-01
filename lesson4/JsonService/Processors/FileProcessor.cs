using JsonService.Data;
using JsonService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonService
{
    class FileProcessor
    {
        public AbstractFileProcessor fileProcessor;

        public FileProcessor(AbstractFileProcessor fileProcessor) => this.fileProcessor = fileProcessor;

        public CommonData Process(string content)
        {
            return fileProcessor.ProcessContent(content);
        }
    }
}
