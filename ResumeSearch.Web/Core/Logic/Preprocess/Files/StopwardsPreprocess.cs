using ResumeSearch.Web.Core.Logic.DocumentReaders;
using ResumeSearch.Web.Core.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResumeSearch.NLP.Processors;

namespace ResumeSearch.Web.Core.Logic.Preprocess.Files
{
    public class StopwardsPreprocess : FilePreprocessBase, IFilePreprocess
    {
        public StopwardsPreprocess(ITextProcessor textProcessor) : base(textProcessor)
        {
        }
        public HashSet<string> Process(IDocumentReader reader)
        {
            var res = new HashSet<string>();
            while(!reader.EndOfFile())
            {
                var word = reader.ReadLine();
                if (!res.Contains(word))
                    res.Add(word);
            }
            return res;
        }
    }
}
