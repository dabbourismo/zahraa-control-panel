namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatestatusmodels : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Divisions", "Status");
            DropColumn("dbo.Materials", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Materials", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Divisions", "Status", c => c.Int(nullable: false));
        }
    }
}
