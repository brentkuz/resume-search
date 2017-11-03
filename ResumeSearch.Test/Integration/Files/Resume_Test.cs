using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ResumeSearch.Web.Core.Logic.DocumentReaders;
using ResumeSearch.Web.Core.Logic.Preprocess.Files;
using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using ResumeSearch.Web.Core.Logic;
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
    public class Resume_Integration_Test
    {
        private FilePreprocessFactory preFact;
        private DocumentReaderFactory docFact;
        private string basePath;
        private StopwordsFile stop;

        [TestInitialize]
        public void Init()
        {
            preFact = new FilePreprocessFactory(new TextProcessorFactory(new SentenceDetectorFactory(), new TokenizerFactory(), new StemmerFactory()));
            docFact = new DocumentReaderFactory();
            basePath = Helpers.GetProjectDir();
            stop = new StopwordsFile(basePath + "\\stopwords.txt", DocumentType.Text, preFact, docFact);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Resume_Integration_TextFile_Ctor_FileNotExistsException()
        {                       
            var resume = new ResumeFile(basePath + "\\oops.txt", DocumentType.Text, stop, preFact, docFact);
        }
        [TestMethod]
        public void Resume_Integration_TextFile_Exists_WordExistsReturnTrue()
        {
            var resume = new ResumeFile(basePath + "\\resume.txt", DocumentType.Text, stop, preFact, docFact);
            var word = "work";

            var res = resume.Exists(word);

            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void Resume_Integration_TextFile_Exists_WordNotExistsReturnFalse()
        {
            var basePath = Helpers.GetProjectDir();
            var resume = new ResumeFile(basePath + "\\resume.txt", DocumentType.Text, stop, preFact, docFact);
            var word = "poop";

            var res = resume.Exists(word);

            Assert.AreEqual(false, res);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Resume_Integration_WordFile_Ctor_FileNotExistsException()
        {
            var resume = new ResumeFile(basePath + "\\oops.docx", DocumentType.Word, stop, preFact, docFact);
        }
        [TestMethod]
        public void Resume_Integration_WordFile_Exists_WordExistsReturnTrue()
        {
            var resume = new ResumeFile(basePath + "\\resume.docx", DocumentType.Word, stop, preFact, docFact);
            var word = "work";

            var res = resume.Exists(word);

            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void Resume_Integration_WordFile_Exists_WordNotExistsReturnFalse()
        {
            var basePath = Helpers.GetProjectDir();
            var resume = new ResumeFile(basePath + "\\resume.docx", DocumentType.Word, stop, preFact, docFact);
            var word = "poop";

            var res = resume.Exists(word);

            Assert.AreEqual(false, res);
        }

    }
}
