namespace ResumeSearch.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDateTimes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Keywords", "Created", c => c.DateTime());
            AlterColumn("dbo.Keywords", "Modified", c => c.DateTime());
            AlterColumn("dbo.Resumes", "Created", c => c.DateTime());
            AlterColumn("dbo.Resumes", "Modified", c => c.DateTime());
            AlterColumn("dbo.Users", "Created", c => c.DateTime());
            AlterColumn("dbo.Users", "Modified", c => c.DateTime());
            AlterColumn("dbo.Stopwords", "Created", c => c.DateTime());
            AlterColumn("dbo.Stopwords", "Modified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stopwords", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Stopwords", "Created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "Created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Resumes", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Resumes", "Created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Keywords", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Keywords", "Created", c => c.DateTime(nullable: false));
        }
    }
}
