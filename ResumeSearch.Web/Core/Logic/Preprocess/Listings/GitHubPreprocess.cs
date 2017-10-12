using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using ResumeSearch.Web.Core.Logic.NLP;
using ResumeSearch.Web.Core.Logic.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.Logic.Preprocess.Listings
{
    public class GitHubPreprocess : ListingPreprocessBase, IListingPreprocess
    {
        private IStopwordsFile stopwords;
        public GitHubPreprocess(IStopwordsFile stopwords, ITextProcessor processor) : base(processor)
        {
            this.stopwords = stopwords;
        }
        public HashSet<string> Process(string body)
        {
            var res = new HashSet<string>();
            var text = Helpers.StripHTML(body);
            var words = textProcessor.Tokenize(text);
            foreach (var word in words)
            {
                if (!res.Contains(word) && !stopwords.Exists(word))
                    res.Add(textProcessor.ProcessWord(word));
            }
            return res;
        }
    }
}
