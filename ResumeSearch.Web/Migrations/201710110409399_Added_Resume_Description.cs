namespace ResumeSearch.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Resume_Description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resumes", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resumes", "Description");
        }
    }
}
