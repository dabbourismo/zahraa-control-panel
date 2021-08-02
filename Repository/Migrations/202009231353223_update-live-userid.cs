namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateliveuserid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lives", "UserId_Id", "dbo.Users");
            DropIndex("dbo.Lives", new[] { "UserId_Id" });
            RenameColumn(table: "dbo.Lives", name: "UserId_Id", newName: "UserId");
            AddColumn("dbo.Payments", "BuyedItemId", c => c.Int(nullable: false));
            AddColumn("dbo.Payments", "BuyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Payments", "TrainerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Lives", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Lives", "UserId");
            AddForeignKey("dbo.Lives", "UserId", "dbo.Users", "Id", cascadeDelete: false);
            DropColumn("dbo.Lives", "TrainerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lives", "TrainerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Lives", "UserId", "dbo.Users");
            DropIndex("dbo.Lives", new[] { "UserId" });
            AlterColumn("dbo.Lives", "UserId", c => c.Int());
            DropColumn("dbo.Payments", "TrainerId");
            DropColumn("dbo.Payments", "BuyDate");
            DropColumn("dbo.Payments", "BuyedItemId");
            RenameColumn(table: "dbo.Lives", name: "UserId", newName: "UserId_Id");
            CreateIndex("dbo.Lives", "UserId_Id");
            AddForeignKey("dbo.Lives", "UserId_Id", "dbo.Users", "Id");
        }
    }
}
