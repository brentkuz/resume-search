/*
 * Author: Brent Kuzmanich
 * Comment: Class for tokenizing English text.
 */

using OpenNLP.Tools.Tokenize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ResumeSearch.NLP.Tokenizing
{
    /// <summary>
    /// Class for tokenizing English text.
    /// </summary>
    public class EnglishTokenizer : OpenNLPBase, ITokenizer
    {
        private EnglishMaximumEntropyTokenizer tok;

        public EnglishTokenizer() : base(Language.English)
        {
            modelPath = Utility.GetModelPath(OpenNLPModel.Tokenizer, Language);
            tok = new EnglishMaximumEntropyTokenizer(modelPath);
        }

        /// <summary>
        /// Method for splitting English text into tokens (aka words)
        /// </summary>
        /// <param name="text">Text to split</param>
        /// <returns>List of tokens</returns>
        public IEnumerable<string> Tokenize(string text)
        {
            if (string.IsNullOrEmpty(modelPath) || !File.Exists(modelPath))
                throw new Exception("Failed to access NLP tokenizer model");
            
            var tmp = tok.Tokenize(text);
            return tmp.Where(x => Regex.IsMatch(x, @"[\w\s]")).ToList();
        }


    }
}
