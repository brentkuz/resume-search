namespace ResumeSearch.Web.Migrations
{
    using ResumeSearch.Web.Core.Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ResumeSearch.Web.Core.Data.Contexts.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ResumeSearch.Web.Core.Data.Contexts.AppContext context)
        {
            //Delete data
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'");
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'IF OBJECT_ID(''?'') NOT IN (ISNULL(OBJECT_ID(''[dbo].[__MigrationHistory]''),0)) DELETE FROM ?'");
            context.Database.ExecuteSqlCommand("EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'");

            var lines = File.ReadAllLines(@"C:\Users\brentkuz\Documents\Visual Studio 2017\Projects\KeywordSearch\ResumeSearch.Web\stopwords.txt");
            int i = 1;
            foreach (var l in lines)
                context.Stopwords.Add(new Stopword() { Id = i++, Word = l, Created = DateTime.Now, Modified = DateTime.Now });

            context.SaveChanges();
        }
    }
}
