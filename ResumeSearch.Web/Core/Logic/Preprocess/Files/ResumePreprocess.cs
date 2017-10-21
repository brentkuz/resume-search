using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
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
                var line = reader.ReadLine().ToLower();
                if (line != string.Empty)
                { 
                    //split line into sentences
                    var sent = textProcessor.GetSentences(line);                   
                    foreach (var s in sent)
                    {
                        //tokenize
                        var toks = textProcessor.Tokenize(s);
                        foreach (var t in toks)
                        {
                            //add full word
                            if (!res.Contains(t) && !stopwords.Exists(t))
                                res.Add(t);
                            //add stemmed word
                            var st = textProcessor.Stem(t);
                            if (!res.Contains(st) && !stopwords.Exists(st))
                                res.Add(st);
                        }
                    }
                }
            }
            return res;
        }
    }
}
