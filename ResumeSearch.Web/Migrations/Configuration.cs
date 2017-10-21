namespace ResumeSearch.Web.Migrations
{
    using ResumeSearch.Web.Core.Data;
    using ResumeSearch.Web.Core.Data.Entities;
    using ResumeSearch.Web.Core.Logic.Services;
    using ResumeSearch.Web.Security;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ResumeSearch.Web.Core.Data.Contexts.ResumeSearchContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ResumeSearch.Web.Core.Data.Contexts.ResumeSearchContext context)
        {
            //Delete data
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'");
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'IF OBJECT_ID(''?'') NOT IN (ISNULL(OBJECT_ID(''[dbo].[__MigrationHistory]''),0)) DELETE FROM ?'");
            context.Database.ExecuteSqlCommand("EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'");


            //user            
            var memb = new AppMembershipProvider();
            memb.CreateUser(new UserPrincipal("brentkuz", "btk1987", "brentkuzmanich@gmail.com"));
           

            //stopwords
            var lines = File.ReadAllLines(@"C:\Users\brentkuz\Source\Repos\resume-search\ResumeSearch.Web\stopwords.txt");
            int i = 1;
            var exists = new HashSet<string>();
            foreach (var l in lines)
            {
                if (!exists.Contains(l))
                {
                    context.Stopwords.Add(new Stopword() { Id = i++, Word = l, Created = DateTime.Now, Modified = DateTime.Now });
                    exists.Add(l);
                }
            }


            context.SaveChanges();
        }
    }
}
