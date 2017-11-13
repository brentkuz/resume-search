/*
 * Author: Brent Kuzmanich
 * Comment: Factory class and interface for getting a sentence detector.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.NLP.SentenceDetection
{
    /// <summary>
    /// Defines methods for getting a sentence detector.
    /// </summary>
    public interface ISentenceDetectorFactory
    {
        /// <summary>
        /// Method to get a sentence detector by language.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        ISentenceDetector GetSentenceDetector(Language language);
    }

    /// <summary>
    /// Factory class for getting a sentence detector.
    /// </summary>
    public class SentenceDetectorFactory : ISentenceDetectorFactory
    {
        /// <summary>
        /// Method for getting a sentence detector by language. 
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
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
