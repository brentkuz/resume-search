using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResumeSearch.Data.Initilializers;

namespace ResumeSearch.Test
{
    [TestClass]
    public class Global
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            System.Data.Entity.Database.SetInitializer(new TestInitializer());
        }

        //[AssemblyCleanup]
        //public static void AssemblyCleanup()
        //{

        //}
    }
}
