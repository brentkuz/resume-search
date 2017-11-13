/*
 * Author: Brent Kuzmanich
 * Comment: Factory class and interface for getting a text processor.
 */

using ResumeSearch.NLP.SentenceDetection;
using ResumeSearch.NLP.Stemming;
using ResumeSearch.NLP.Tokenizing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.NLP.Processors
{
    /// <summary>
    /// Defines methods for getting an ITextProcessor
    /// </summary>
    public interface ITextProcessorFactory
    {
        /// <summary>
        /// Defines a method to get an ITextProcessor by language
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        ITextProcessor GetTextProcessor(Language language);
    }

    /// <summary>
    /// Factory class for getting an instance of a text processor.
    /// </summary>
    public class TextProcessorFactory : ITextProcessorFactory
    {
        private ISentenceDetectorFactory sdFact;
        private ITokenizerFactory tokFact;
        private IStemmerFactory stemFact;

        public TextProcessorFactory(ISentenceDetectorFactory sdFact, ITokenizerFactory tokFact, IStemmerFactory stemFact)
        {
            this.sdFact = sdFact;
            this.tokFact = tokFact;
            this.stemFact = stemFact;
        }

        /// <summary>
        /// Method for getting a text processor.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public ITextProcessor GetTextProcessor(Language language)
        {
            switch (language)
            {
                case Language.English:
                    return new EnglishTextProcessor(sdFact, tokFact, stemFact);
                default:
                    throw new NotSupportedException("Unsupported language: " + language.ToString());
            }
        }
    }
}
