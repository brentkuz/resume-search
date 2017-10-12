using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.Logic.NLP
{
    public interface ITextProcessor
    {
        List<string> Tokenize(string text);
        string ProcessWord(string word);
    }
    public class TextProcessor : ITextProcessor
    {
        protected string Stem(string word)
        {
            return word;
        }
        protected string CleanWord(string word)
        {
            return Regex.Replace(word.Trim().ToLower(), @"[^\w\s]", "");
        }
        public string ProcessWord(string word)
        {
            return Stem(CleanWord(word));
        }
        public List<string> Tokenize(string text)
        {
            return text.Split(null).ToList();
        }
    }
}
