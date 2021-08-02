namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updategovernmenttype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Governemnt", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Governemnt", c => c.String());
        }
    }
}
