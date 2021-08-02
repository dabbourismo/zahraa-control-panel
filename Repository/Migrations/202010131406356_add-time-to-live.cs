namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtimetolive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lives", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lives", "Time");
        }
    }
}
