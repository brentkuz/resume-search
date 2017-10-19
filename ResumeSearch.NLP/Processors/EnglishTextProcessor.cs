using OpenNLP.Tools.Util.Process;
using ResumeSearch.NLP.SentenceDetection;
using ResumeSearch.NLP.Stemming;
using ResumeSearch.NLP.Tokenizing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ResumeSearch.NLP.Processors
{

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

        public string ProcessWord(string word)
        {
            return Stem(CleanWord(word));
        }
        public List<string> Tokenize(string text)
        {
            return text.Split(null).ToList();
        }

        protected string Stem(string word)
        {
            //TODO: wire up to OleanderStemming proj
            return word;
        }
        protected string CleanWord(string word)
        {
            return Regex.Replace(word.Trim().ToLower(), @"[^\w\s]", "");
        }

    }
}
