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
                { OpenNLPModel.Tokenizer, @"\Models\EnglishTok.nbin" },
                { OpenNLPModel.SentenceDetector, @"\Models\EnglishSD.nbin" },
                { OpenNLPModel.POS, @"\Models\EnglishPOS.nbin"}
            };
        internal static string GetModelPath(OpenNLPModel model, Language language)
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

            //get path for assembly
            var path = current[model];
            var dirPath = Assembly.GetExecutingAssembly().Location;
            dirPath = Path.GetDirectoryName(dirPath);
            return dirPath + path;
        }
    }
}
