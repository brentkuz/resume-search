using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.MachineLearning.Text.Stemmers;

namespace ResumeSearch.NLP.Stemming
{
    public class EnglishStemmer : IStemmer
    {
        public string Stem(string word)
        {
            var stem = new EnglishStemmer();
            return stem.Stem(word);
        }
    }
}
