using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResumeSearch.Web.Core.Logic;
using ResumeSearch.NLP.Processors;
using ResumeSearch.NLP.SentenceDetection;
using ResumeSearch.NLP.Tokenizing;
using ResumeSearch.NLP.Stemming;

namespace ResumeSearch.Test.Unit.NLP
{
    [TestClass]
    public class TextProcessor_Test
    {
        private EnglishTextProcessor proc = new EnglishTextProcessor(new SentenceDetectorFactory(), new TokenizerFactory(), new StemmerFactory());
        [TestMethod]
        public void TextProcessor_TestTokenize()
        {
            var text = "This is a test";

            var res = proc.Tokenize(text);

            Assert.AreEqual(4, res.Count);
        }
        [TestMethod]
        public void TextProcessor_TestStem()
        {
        }
    }
}
