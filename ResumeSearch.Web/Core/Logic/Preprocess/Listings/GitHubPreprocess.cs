using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using ResumeSearch.Web.Core.Logic;
using ResumeSearch.Web.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResumeSearch.NLP.Processors;

namespace ResumeSearch.Web.Core.Logic.Preprocess.Listings
{
    public class GitHubPreprocess : ListingPreprocessBase, IListingPreprocess
    {
        private IStopwordsFile stopwords;
        public GitHubPreprocess(IStopwordsFile stopwords, ITextProcessor textProcessor) : base(textProcessor)
        {
            this.stopwords = stopwords;
        }
        public HashSet<string> Process(string body)
        {
            var res = new HashSet<string>();
            var text = Helpers.StripHTML(body).ToLower();
            //split into sentences
            var sent = textProcessor.GetSentences(text);
            foreach (var s in sent)
            {
                //tokenize
                var words = textProcessor.Tokenize(s);
                foreach (var word in words)
                {
                    if (!res.Contains(word) && !stopwords.Exists(word))
                        res.Add(word);
                    var st = textProcessor.Stem(word);
                    if (!res.Contains(st) && !stopwords.Exists(st))
                        res.Add(st);
                }
            }
            return res;
        }
    }
}
