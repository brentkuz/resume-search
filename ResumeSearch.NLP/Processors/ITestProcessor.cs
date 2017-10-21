using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.NLP.Processors
{
    public interface ITextProcessor
    {
        List<string> GetSentences(string text);
        List<string> Tokenize(string text);
        string Stem(string word);      
    }
}
