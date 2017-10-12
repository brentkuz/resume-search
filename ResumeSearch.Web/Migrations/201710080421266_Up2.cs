namespace ResumeSearch.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Up2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", "IX_UniqueUsernamePassword");
            AlterColumn("dbo.Users", "Username", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 200));
            CreateIndex("dbo.Users", "Username", unique: true);
            CreateIndex("dbo.Users", "Password", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Password" });
            DropIndex("dbo.Users", new[] { "Username" });
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Users", new[] { "Username", "Password" }, unique: true, name: "IX_UniqueUsernamePassword");
        }
    }
}
