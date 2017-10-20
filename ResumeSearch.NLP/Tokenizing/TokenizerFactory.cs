using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.NLP.Tokenizing
{
    public interface ITokenizerFactory
    {
        ITokenizer GetTokenizer(Language language);
    }
    public class TokenizerFactory : ITokenizerFactory
    {
        public ITokenizer GetTokenizer(Language language)
        {
            switch (language)
            {
                case Language.English:
                    return new EnglishTokenizer();
                default:
                    throw new NotSupportedException("Unsupported language: " + language.ToString());
            }
        }
    }
}
