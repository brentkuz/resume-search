using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using ResumeSearch.Web.Core.Logic.DocumentReaders;
using ResumeSearch.Web.Core.Logic.NLP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.Logic.Preprocess.Files
{
    public class ResumePreprocess : FilePreprocessBase, IFilePreprocess
    {
        private IStopwordsFile stopwords;
        public ResumePreprocess(IStopwordsFile stopwords, ITextProcessor textProcessor) : base(textProcessor)
        {
            this.stopwords = stopwords;
        }
        public HashSet<string> Process(IDocumentReader reader)
        {
            var res = new HashSet<string>();
            while (!reader.EndOfFile())
            {
                var line = reader.ReadLine();
                if (line != string.Empty)
                {
                    var words = textProcessor.Tokenize(line);
                    foreach (var word in words)
                    {
                        if (!res.Contains(word) && !stopwords.Exists(word))
                            res.Add(textProcessor.ProcessWord(word));
                    }
                }
            }
            return res;
        }
    }
}
