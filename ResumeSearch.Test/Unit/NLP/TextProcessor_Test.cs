using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResumeSearch.Web.Core.Logic.NLP;

namespace ResumeSearch.Test.Unit.NLP
{
    [TestClass]
    public class TextProcessor_Test
    {
        private TextProcessor proc = new TextProcessor();
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
