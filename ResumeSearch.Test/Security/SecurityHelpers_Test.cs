using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResumeSearch.Web.Security;
using ResumeSearch.Crosscutting.Security;

namespace ResumeSearch.Test.Security
{
    [TestClass]
    public class SecurityHelpers_Test
    {
        [TestMethod]
        public void SecurityHelpers_TestEncryptionStability()
        {
            var password = "hosehound123";
            var salt = SecurityHelpers.CreateSalt();

            var h1 = SecurityHelpers.EncryptPassword(password, salt);
            var h2 = SecurityHelpers.EncryptPassword(password, salt);

            Assert.AreEqual(h1, h2);
        }
    }
}
