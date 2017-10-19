using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.NLP.Stemming
{    
    public interface IStemmerFactory
    {
        IStemmer GetStemmer(Language language);
    }
    public class StemmerFactory : IStemmerFactory
    {
        public IStemmer GetStemmer(Language language)
        {
            switch (language)
            {
                case Language.English:
                    return new EnglishStemmer();
                default:
                    throw new NotSupportedException("Unsupported language: " + language.ToString());
            }

        }
    }
}
