using ResumeSearch.NLP.SentenceDetection;
using ResumeSearch.NLP.Stemming;
using ResumeSearch.NLP.Tokenizing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.NLP.Processors
{
    public interface ITextProcessorFactory
    {
        ITextProcessor GetTextProcessor(Language language);
    }
    class TextProcessorFactory : ITextProcessorFactory
    {
        private ISentenceDetectorFactory sdFact;
        private ITokenizerFactory tokFact;
        private IStemmerFactory stemFact;
        public TextProcessorFactory(ISentenceDetectorFactory sdFact, ITokenizerFactory tokFact, IStemmerFactory stemFact)
        {
            this.sdFact = sdFact;
            this.tokFact = tokFact;
            this.stemFact = stemFact;
        }
        public ITextProcessor GetTextProcessor(Language language)
        {
            switch (language)
            {
                case Language.English:
                    return new EnglishTextProcessor(sdFact.GetSentenceDetector(Language.English), tokFact.GetTokenizer(Language.English), );
                default:
                    throw new NotSupportedException("Unsupported language: " + language.ToString());
            }
        }
    }
}
