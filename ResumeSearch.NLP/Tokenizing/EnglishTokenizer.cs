using OpenNLP.Tools.Tokenize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.NLP.Tokenizing
{
    public class EnglishTokenizer : OpenNLPBase, ITokenizer
    {
        private EnglishMaximumEntropyTokenizer tok;
        public EnglishTokenizer() : base(Language.English)
        {
            modelPath = Utility.GetModelPath(OpenNLPModel.Tokenizer, Language);
            tok = new EnglishMaximumEntropyTokenizer(modelPath);
        }

        public IEnumerable<string> Tokenize(string text)
        {
            if (string.IsNullOrEmpty(modelPath) || !File.Exists(modelPath))
                throw new Exception("Failed to access NLP tokenizer model");
            
            return tok.Tokenize(text);
        }


    }
}
