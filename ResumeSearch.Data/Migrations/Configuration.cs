namespace ResumeSearch.Web.Migrations
{
    using ResumeSearch.Crosscutting.Entities;
    using ResumeSearch.Data;
    using ResumeSearch.Data.Initilializers;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ResumeSearch.Data.Contexts.ResumeSearchContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ResumeSearch.Data.Contexts.ResumeSearchContext context)
        {
            var init = new TestInitializer();
            init.DoSeed(context);
        }
    }
}
