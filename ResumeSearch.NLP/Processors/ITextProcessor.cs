/*
 * Author: Brent Kuzmanich
 * Comment: Interface defining methods for processing text.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.NLP.Processors
{
    /// <summary>
    /// Defines natural language processing methods for processing text.
    /// </summary>
    public interface ITextProcessor
    {
        /// <summary>
        /// Defines a method for splitting text into sentences.
        /// </summary>
        /// <param name="text">Text to split.</param>
        /// <returns>List of sentences</returns>
        List<string> GetSentences(string text);

        /// <summary>
        /// Defines a method for splitting a sentence into tokens (aka words).
        /// </summary>
        /// <param name="text">Sentence to tokenize</param>
        /// <returns>List of tokens</returns>
        List<string> Tokenize(string text);

        /// <summary>
        /// Defines a method for stemming a word to its base form.
        /// </summary>
        /// <param name="word">Word to stem</param>
        /// <returns>Stemmed word</returns>
        string Stem(string word);      
    }
}
