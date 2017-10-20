using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResumeSearch.NLP;

namespace ResumeSearch.Test.NLP
{
    [TestClass]
    public class Utility_Test
    {
        [TestMethod]
        public void Utility_BuildPath_BuildsAccuratePath()
        {
            var actual = "C:\\Users\\brentkuz\\Source\\Repos\\resume-search\\ResumeSearch.Test\\test.txt";
            var path = Utility.BuildPath("test.txt");

            Assert.AreEqual(actual, path);
        }
    }
}
