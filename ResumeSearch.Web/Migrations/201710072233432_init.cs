namespace ResumeSearch.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 100),
                        Password = c.String(maxLength: 50),
                        Email = c.String(maxLength: 200),
                        Role = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.Username, t.Password }, unique: true, name: "IX_UniqueUsernamePassword");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", "IX_UniqueUsernamePassword");
            DropTable("dbo.Users");
        }
    }
}
