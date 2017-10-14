namespace ResumeSearch.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFKs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Keywords", "Resume_Id", "dbo.Resumes");
            DropForeignKey("dbo.Resumes", "User_Id", "dbo.Users");
            DropIndex("dbo.Keywords", new[] { "Resume_Id" });
            DropIndex("dbo.Resumes", new[] { "User_Id" });
            RenameColumn(table: "dbo.Keywords", name: "Resume_Id", newName: "ResumeId");
            RenameColumn(table: "dbo.Resumes", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Keywords", "ResumeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Resumes", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Keywords", "ResumeId");
            CreateIndex("dbo.Resumes", "UserId");
            AddForeignKey("dbo.Keywords", "ResumeId", "dbo.Resumes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Resumes", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resumes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Keywords", "ResumeId", "dbo.Resumes");
            DropIndex("dbo.Resumes", new[] { "UserId" });
            DropIndex("dbo.Keywords", new[] { "ResumeId" });
            AlterColumn("dbo.Resumes", "UserId", c => c.Int());
            AlterColumn("dbo.Keywords", "ResumeId", c => c.Int());
            RenameColumn(table: "dbo.Resumes", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Keywords", name: "ResumeId", newName: "Resume_Id");
            CreateIndex("dbo.Resumes", "User_Id");
            CreateIndex("dbo.Keywords", "Resume_Id");
            AddForeignKey("dbo.Resumes", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Keywords", "Resume_Id", "dbo.Resumes", "Id");
        }
    }
}
