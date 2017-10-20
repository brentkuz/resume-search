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

        public List<string> GetSentences(string text)
        {
            return sd.DetectSentences(text).ToList();
        }

        public List<string> Tokenize(string text)
        {
            return tokenizer.Tokenize(text).ToList();
        }

        public string Stem(string word)
        {
            return stemmer.Stem(word);
        }

        public List<string> ProcessText(string text)
        {
            var words = new List<string>();
            var sent = sd.DetectSentences(text);
            foreach(var s in sent)
            {
                var toks = tokenizer.Tokenize(s);
                foreach(var t in toks)
                {
                    words.Add(stemmer.Stem(t));
                }
            }
            return words;
        }

       
    }
}
