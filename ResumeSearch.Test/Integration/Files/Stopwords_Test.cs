using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ResumeSearch.Web.Core.Logic.Preprocess.Files;
using ResumeSearch.Web.Core.Logic;
using ResumeSearch.Web.Core.Logic.DocumentReaders;
using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using ResumeSearch.Web.Core.Logic.Utility;
using ResumeSearch.Web.Core.Utility;
using ResumeSearch.NLP.Processors;
using ResumeSearch.NLP.SentenceDetection;
using ResumeSearch.NLP.Tokenizing;
using ResumeSearch.NLP.Stemming;
using ResumeSearch.Crosscutting.Enums;

namespace ResumeSearch.Test.Integration.Files
{
    [TestClass]
    public class Stopwords_Integration_Test
    {
        private FilePreprocessFactory preFact;
        private DocumentReaderFactory docFact;

        [TestInitialize]
        public void Init()
        {
            preFact = new FilePreprocessFactory(new TextProcessorFactory(new SentenceDetectorFactory(), new TokenizerFactory(), new StemmerFactory()));
            docFact = new DocumentReaderFactory();
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Stopwords_Integration_Ctor_FileNotExistsException()
        {
            var basePath = Helpers.GetProjectDir();
            var stopwords = new StopwordsFile(basePath + "\\oops.txt", DocumentType.Text, preFact, docFact);

        }
        [TestMethod]
        public void Stopwords_Integration_Exists_WordExistsReturnTrue()
        {
            var basePath = Helpers.GetProjectDir();
            var stopwords = new StopwordsFile(basePath + "\\stopwords.txt", DocumentType.Text, preFact, docFact);
            var word = "affected";

            var res = stopwords.Exists(word);

            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void Stopwords_Integration_Exists_WordNotExistsReturnFalse()
        {
            var basePath = Helpers.GetProjectDir();
            var stopwords = new StopwordsFile(basePath + "\\stopwords.txt", DocumentType.Text, preFact, docFact);
            var word = "poop";

            var res = stopwords.Exists(word);

            Assert.AreEqual(false, res);
        }


    }
}
