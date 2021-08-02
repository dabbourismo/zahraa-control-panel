namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateroommodellevel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "LevelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "LevelId");
            AddForeignKey("dbo.Rooms", "LevelId", "dbo.Levels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "LevelId", "dbo.Levels");
            DropIndex("dbo.Rooms", new[] { "LevelId" });
            DropColumn("dbo.Rooms", "LevelId");
        }
    }
}
