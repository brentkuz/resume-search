using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ResumeSearch.Test.Integration.NLP
{
    [TestClass]
    public class WordDocumentReader_Integration_Test
    {
        //private string baseDir = Helpers.GetProjectDir();
        //[TestMethod]
        //[ExpectedException(typeof(FileNotFoundException))]
        //public void WordDocumentReader_Integration_Ctor_BadPathException()
        //{
        //    var rdr = new WordDocumentReader("asdfasd");
        //    rdr.Dispose();
        //}
        //[TestMethod]
        //public void WordDocumentReader_Integration_ReadLine_ReturnsLine()
        //{
        //    using (var rdr = new WordDocumentReader(baseDir + "resume.docx"))
        //    {
        //        var line = rdr.ReadLine();

        //        Assert.IsNotNull(line);
        //    }
        //}
        //[TestMethod]
        //[ExpectedException(typeof(EndOfStreamException))]
        //public void WordDocumentReader_Integration_ReadLine_EmptyThrowsException()
        //{
        //    using (var rdr = new WordDocumentReader(baseDir + "empty.docx"))
        //    {
        //        var line = rdr.ReadLine();
        //    }
        //}

    }
}
