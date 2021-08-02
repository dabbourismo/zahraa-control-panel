namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addhomeowrkuserid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Homeworks", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Homeworks", "UserId");
            AddForeignKey("dbo.Homeworks", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Homeworks", "UserId", "dbo.Users");
            DropIndex("dbo.Homeworks", new[] { "UserId" });
            DropColumn("dbo.Homeworks", "UserId");
        }
    }
}
