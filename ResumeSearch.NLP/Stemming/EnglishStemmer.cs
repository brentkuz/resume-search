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
        private Accord.MachineLearning.Text.Stemmers.EnglishStemmer stemmer;
        public EnglishStemmer()
        {
            stemmer = new Accord.MachineLearning.Text.Stemmers.EnglishStemmer();
        }
        public string Stem(string word)
        {            
            return stemmer.Stem(word);
        }
    }
}
