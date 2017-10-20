using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.NLP
{
    public static class Utility
    {
        private static Dictionary<OpenNLPModel, string> englishPaths = new Dictionary<OpenNLPModel, string>()
            {
                { OpenNLPModel.Tokenizer, @"NLPModels\EnglishTok.nbin" },
                { OpenNLPModel.SentenceDetector, @"NLPModels\EnglishSD.nbin" },
                { OpenNLPModel.POS, @"NLPModels\EnglishPOS.nbin"}
            };
        public static string GetModelPath(OpenNLPModel model, Language language)
        {
            Dictionary<OpenNLPModel, string> current;
            //set correct path map
            switch (language)
            {
                case Language.English:
                    {
                        current = englishPaths;
                        break;
                    }
                default:
                    throw new NotSupportedException("Language not supported: " + language.ToString());
            }

            return BuildPath(current[model]);

        }
        public static string BuildPath(string relativePath)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var bin = dir.IndexOf("bin");
            if (bin > 0)
            {
                dir = dir.Substring(0, bin);
            }
            return dir + relativePath;           
        }
    }
}
