using ResumeSearch.Web.Core.Logic.NLP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.Logic.Preprocess.Listings
{
    public class ListingPreprocessBase
    {
        protected ITextProcessor textProcessor;
        public ListingPreprocessBase(ITextProcessor textProcessor)
        {
            this.textProcessor = textProcessor;
        }
    }
}
