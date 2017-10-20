using OpenNLP.Tools.SentenceDetect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.NLP.SentenceDetection
{
    public class EnglishSentenceDetector : OpenNLPBase, ISentenceDetector
    {
        private EnglishMaximumEntropySentenceDetector sd;
        public EnglishSentenceDetector() : base(Language.English)
        {
            modelPath = Utility.GetModelPath(OpenNLPModel.SentenceDetector, Language);
            sd = new EnglishMaximumEntropySentenceDetector(modelPath);
        }

        public IEnumerable<string> DetectSentences(string text)
        {
            return sd.SentenceDetect(text).ToList();
        }
    }
}
