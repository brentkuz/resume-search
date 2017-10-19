using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.NLP.SentenceDetection
{
    public interface ISentenceDetectorFactory
    {
        ISentenceDetector GetSentenceDetector(Language language);
    }

    class SentenceDetectorFactory : ISentenceDetectorFactory
    {
        public ISentenceDetector GetSentenceDetector(Language language)
        {
            switch (language)
            {
                case Language.English:
                    return new EnglishSentenceDetector();
                default:
                    throw new NotSupportedException("Unsupported language: " + language.ToString());
            }
        }
    }
}
