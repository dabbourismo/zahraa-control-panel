namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noideawhat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "Name");
        }
    }
}
