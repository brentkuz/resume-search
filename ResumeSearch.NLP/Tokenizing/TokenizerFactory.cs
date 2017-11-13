/*
 * Author: Brent Kuzmanich
 * Comment: Factory class and interface for getting a tokenizer.
 */

using System;

namespace ResumeSearch.NLP.Tokenizing
{
    /// <summary>
    /// Defines methods for getting a tokenizer.
    /// </summary>
    public interface ITokenizerFactory
    {
        /// <summary>
        /// Defines a method to get a tokenizer by language.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        ITokenizer GetTokenizer(Language language);
    }

    /// <summary>
    /// Factory class for getting a tokenizer.
    /// </summary>
    public class TokenizerFactory : ITokenizerFactory
    {
        /// <summary>
        /// Method to get a tokenizer by language.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
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
