/*
 * Author: Brent Kuzmanich
 * Comment: Class for processing English text. 
 */

using ResumeSearch.NLP.SentenceDetection;
using ResumeSearch.NLP.Stemming;
using ResumeSearch.NLP.Tokenizing;
using System.Collections.Generic;
using System.Linq;

namespace ResumeSearch.NLP.Processors
{
    /// <summary>
    /// Class for processing English language text.
    /// </summary>
    public class EnglishTextProcessor : TextProcessorBase, ITextProcessor
    {
        private ISentenceDetector sd;
        private ITokenizer tokenizer;
        private IStemmer stemmer;

        public EnglishTextProcessor(ISentenceDetectorFactory sdFact, ITokenizerFactory tokenizerFact, IStemmerFactory stemmerFact) : base(Language.English)
        {
            sd = sdFact.GetSentenceDetector(Language);
            tokenizer = tokenizerFact.GetTokenizer(Language);
            stemmer = stemmerFact.GetStemmer(Language);
        }

        /// <summary>
        /// Method for splitting text into sentences.
        /// </summary>
        /// <param name="text">Text to split</param>
        /// <returns>List of sentences</returns>
        public List<string> GetSentences(string text)
        {
            return sd.DetectSentences(text).ToList();
        }

        /// <summary>
        /// Method for splitting a sentence into tokens (aka words)
        /// </summary>
        /// <param name="text">Sentence to tokenize</param>
        /// <returns>List of tokens</returns>
        public List<string> Tokenize(string text)
        {
            return tokenizer.Tokenize(text).ToList();
        }

        /// <summary>
        /// Method to stem a word into it's base form.
        /// </summary>
        /// <param name="word">Word to stem</param>
        /// <returns>Stemmed version of word</returns>
        public string Stem(string word)
        {
            return stemmer.Stem(word);
        }
    }
}
