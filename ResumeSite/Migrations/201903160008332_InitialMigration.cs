namespace ResumeSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ConfirmationNo", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "EmailConfirmed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Users", "PassHash");
            DropColumn("dbo.Users", "PassSalt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PassSalt", c => c.String());
            AddColumn("dbo.Users", "PassHash", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            DropColumn("dbo.Users", "EmailConfirmed");
            DropColumn("dbo.Users", "ConfirmationNo");
        }
    }
}
