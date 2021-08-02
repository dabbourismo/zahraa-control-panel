namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makelevelidnullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Users", "LevelId", "dbo.Levels");
            DropIndex("dbo.Users", new[] { "LevelId" });
            DropIndex("dbo.Users", new[] { "DivisionId" });
            AlterColumn("dbo.Users", "LevelId", c => c.Int());
            AlterColumn("dbo.Users", "DivisionId", c => c.Int());
            CreateIndex("dbo.Users", "LevelId");
            CreateIndex("dbo.Users", "DivisionId");
            AddForeignKey("dbo.Users", "DivisionId", "dbo.Divisions", "Id");
            AddForeignKey("dbo.Users", "LevelId", "dbo.Levels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.Users", "DivisionId", "dbo.Divisions");
            DropIndex("dbo.Users", new[] { "DivisionId" });
            DropIndex("dbo.Users", new[] { "LevelId" });
            AlterColumn("dbo.Users", "DivisionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "LevelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "DivisionId");
            CreateIndex("dbo.Users", "LevelId");
            AddForeignKey("dbo.Users", "LevelId", "dbo.Levels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "DivisionId", "dbo.Divisions", "Id", cascadeDelete: true);
        }
    }
}
