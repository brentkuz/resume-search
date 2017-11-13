/*
 * Author: Brent Kuzmanich
 * Comment: Interface defining methods for sentence detection.
 */

using System.Collections.Generic;

namespace ResumeSearch.NLP.SentenceDetection
{
    /// <summary>
    /// Defines methods for detecting sentences in text.
    /// </summary>
    public interface ISentenceDetector
    {
        /// <summary>
        /// Defines a method for splitting text into sentences.
        /// </summary>
        /// <param name="text">Text to split</param>
        /// <returns>List of sentences</returns>
        IEnumerable<string> DetectSentences(string text);
    }
}
