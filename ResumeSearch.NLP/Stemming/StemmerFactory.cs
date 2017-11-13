/*
 * Author: Brent Kuzmanich
 * Comment: Factory class and interface for getting a stemmer.
 */

using System;

namespace ResumeSearch.NLP.Stemming
{
    /// <summary>
    /// Defines methods for getting a stemmer by language
    /// </summary>
    public interface IStemmerFactory
    {
        /// <summary>
        /// Defines a method for getting a stemmer by language.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        IStemmer GetStemmer(Language language);
    }

    /// <summary>
    /// Class for getting a stemmer.
    /// </summary>
    public class StemmerFactory : IStemmerFactory
    {
        /// <summary>
        /// Method to getting a stemmer by language.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
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
