namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addhomework : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Homeworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialId = c.Int(nullable: false),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .Index(t => t.MaterialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Homeworks", "MaterialId", "dbo.Materials");
            DropIndex("dbo.Homeworks", new[] { "MaterialId" });
            DropTable("dbo.Homeworks");
        }
    }
}
