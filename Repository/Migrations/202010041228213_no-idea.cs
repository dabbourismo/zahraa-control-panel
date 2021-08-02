namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noidea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Government", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Governemnt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Governemnt", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Government");
        }
    }
}
