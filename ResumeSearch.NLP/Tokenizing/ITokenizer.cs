/*
 * Author: Brent Kuzmanich
 * Comment: Interface defining methods for tokenization.
 */

using System.Collections.Generic;

namespace ResumeSearch.NLP.Tokenizing
{
    /// <summary>
    /// Defines methods for splitting text into tokens (aka words)
    /// </summary>
    public interface ITokenizer
    {
        /// <summary>
        /// Defines a method to split text into tokens (aka words)
        /// </summary>
        /// <param name="text">Text to split</param>
        /// <returns>List of tokens</returns>
        IEnumerable<string> Tokenize(string text);
    }
}
