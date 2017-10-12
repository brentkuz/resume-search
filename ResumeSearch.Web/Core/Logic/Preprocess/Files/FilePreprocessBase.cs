using ResumeSearch.Web.Core.Logic.NLP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.Logic.Preprocess.Files
{
    public class FilePreprocessBase
    {
        protected ITextProcessor textProcessor;
        public FilePreprocessBase(ITextProcessor textProcessor) 
        {
            this.textProcessor = textProcessor;
        }
    }
}
