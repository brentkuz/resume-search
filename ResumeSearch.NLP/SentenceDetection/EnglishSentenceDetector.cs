/*
 * Author: Brent Kuzmanich
 * Comment: Class for detecting sentences in text.
 */

using OpenNLP.Tools.SentenceDetect;
using System.Collections.Generic;
using System.Linq;

namespace ResumeSearch.NLP.SentenceDetection
{

    /// <summary>
    /// Class for detecting sentences in English text.
    /// </summary>
    public class EnglishSentenceDetector : OpenNLPBase, ISentenceDetector
    {
        private EnglishMaximumEntropySentenceDetector sd;

        public EnglishSentenceDetector() : base(Language.English)
        {
            modelPath = Utility.GetModelPath(OpenNLPModel.SentenceDetector, Language);
            sd = new EnglishMaximumEntropySentenceDetector(modelPath);
        }

        /// <summary>
        /// Method for splitting text into English sentences.
        /// </summary>
        /// <param name="text">Text to split</param>
        /// <returns>List of English sentences</returns>
        public IEnumerable<string> DetectSentences(string text)
        {
            return sd.SentenceDetect(text).ToList();
        }
    }
}
