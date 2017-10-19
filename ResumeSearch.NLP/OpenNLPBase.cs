using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.NLP
{
    public abstract class OpenNLPBase
    {
        protected string modelPath;
        public OpenNLPBase(Language language)
        {
            Language = language;
        }
        public Language Language { get; private set; }


    }
}
