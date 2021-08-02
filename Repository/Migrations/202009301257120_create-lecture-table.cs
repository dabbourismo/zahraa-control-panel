namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createlecturetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lectures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Url = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MaterialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lectures", "UserId", "dbo.Users");
            DropForeignKey("dbo.Lectures", "MaterialId", "dbo.Materials");
            DropIndex("dbo.Lectures", new[] { "MaterialId" });
            DropIndex("dbo.Lectures", new[] { "UserId" });
            DropTable("dbo.Lectures");
        }
    }
}
