using ResumeSearch.Crosscutting.Entities;
using ResumeSearch.Crosscutting.Security;
using ResumeSearch.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Data.Initilializers
{
    public class TestInitializer : System.Data.Entity.DropCreateDatabaseAlways<ResumeSearchContext>
    {
        public override void InitializeDatabase(ResumeSearchContext context)
        {
            KillConnections(context);
            base.InitializeDatabase(context);
        }

        public void DoSeed(ResumeSearchContext context)
        {
            // Deletes all data, from all tables, except for __MigrationHistory
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'");
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'IF OBJECT_ID(''?'') NOT IN (ISNULL(OBJECT_ID(''[dbo].[__MigrationHistory]''),0)) DELETE FROM ?'");
            context.Database.ExecuteSqlCommand("EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'");

            Seed(context);
        }
        protected override void Seed(ResumeSearchContext context)
        {
            base.Seed(context);

            //user            
            var salt = SecurityHelpers.CreateSalt();
            var user = new User()
            {
                Username = "brentkuz",
                Password = SecurityHelpers.EncryptPassword("test123", salt),
                Salt = salt,
                Email = "brentkuzmanich@gmail.com",
                Role = Crosscutting.Enums.Role.Applicant
            };
            context.Users.Add(user);

            //stopwords
            var lines = File.ReadAllLines(@"C:\Users\brentkuz\Source\Repos\resume-search\ResumeSearch.Data\stopwords.txt");
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
        private void DropAllObjects(ResumeSearchContext context)
        {
            //// Deletes all data, from all tables, except for __MigrationHistory
            //context.Database.ExecuteSqlCommand("sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'");
            //context.Database.ExecuteSqlCommand("sp_MSForEachTable 'IF OBJECT_ID(''?'') NOT IN (ISNULL(OBJECT_ID(''[dbo].[__MigrationHistory]''),0)) DELETE FROM ?'");
            //context.Database.ExecuteSqlCommand("EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'");



            string sqlDropStatements = @"
                DECLARE @DROP_FKs NVARCHAR(MAX) = ''
                DECLARE @DROP_TABLES NVARCHAR(MAX) = ''

                SELECT @DROP_FKs = @DROP_FKs + '
                ALTER TABLE [dbo].' + QUOTENAME(t.name) + ' DROP CONSTRAINT ' + QUOTENAME(fk.name)
                FROM sys.foreign_keys fk
                INNER JOIN sys.tables t
                 on fk.parent_object_id = t.object_id

                EXEC (@DROP_FKs)

                SELECT @DROP_TABLES = @DROP_TABLES + '
                DROP TABLE dbo.' + QUOTENAME(t.name)
                FROM sys.tables t

                EXEC (@DROP_TABLES)";

            context.Database.ExecuteSqlCommand(sqlDropStatements);
        }

        private void KillConnections(ResumeSearchContext context)
        {
            try
            {
                SqlConnectionStringBuilder sqlConnBuilder = new SqlConnectionStringBuilder(context.Database.Connection.ConnectionString);
                sqlConnBuilder.InitialCatalog = "master";

                using (SqlConnection sqlConnection = new SqlConnection(sqlConnBuilder.ConnectionString))
                {
                    sqlConnection.Open();
                    string dbName = context.Database.Connection.Database;
                    string sql = @"IF EXISTS(SELECT NULL FROM sys.databases WHERE name = '" + dbName + "') BEGIN ALTER DATABASE [" + dbName + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE END";

                    using (SqlCommand sqlCmd = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.Text;
                        sqlCmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw new Exception("The TestInitializer failed.");
            }
        }
    }
}
