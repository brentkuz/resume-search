namespace ResumeSearch.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingResume : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Resume_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resumes", t => t.Resume_Id)
                .Index(t => t.Resume_Id);
            
            CreateTable(
                "dbo.Resumes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.Binary(),
                        FileType = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Stopwords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(maxLength: 100),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Word, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resumes", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Keywords", "Resume_Id", "dbo.Resumes");
            DropIndex("dbo.Stopwords", new[] { "Word" });
            DropIndex("dbo.Resumes", new[] { "User_Id" });
            DropIndex("dbo.Keywords", new[] { "Resume_Id" });
            DropTable("dbo.Stopwords");
            DropTable("dbo.Resumes");
            DropTable("dbo.Keywords");
        }
    }
}
