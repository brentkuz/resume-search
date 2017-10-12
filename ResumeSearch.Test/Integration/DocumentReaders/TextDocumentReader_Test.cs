using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ResumeSearch.Web.Core.Logic.Utility;
using ResumeSearch.Web.Core.Logic.DocumentReaders;

namespace ResumeSearch.Test.Integration.DocumentReaders
{
    [TestClass]
    public class TextDocumentReader_Integration_Test
    {
        private string baseDir = Helpers.GetProjectDir();
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TextDocumentReader_Integration_Ctor_BadPathException()
        {
            var rdr = new TextDocumentReader("asdfasd");
            rdr.Dispose();
        }
        [TestMethod]
        public void TextDocumentReader_Integration_ReadLine_ReturnsLine()
        {
            using (var rdr = new TextDocumentReader(baseDir + "resume.txt"))
            {
                var line = rdr.ReadLine();

                Assert.IsNotNull(line);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(EndOfStreamException))]
        public void TextDocumentReader_Integration_ReadLine_EmptyThrowsException()
        {
            using (var rdr = new TextDocumentReader(baseDir + "empty.txt"))
            {
                var line = rdr.ReadLine();
            }
        }
    }
}
