namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addexamtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamName = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                        Degree = c.Int(nullable: false),
                        NumberOfQuestions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MaterialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "UserId", "dbo.Users");
            DropForeignKey("dbo.Exams", "MaterialId", "dbo.Materials");
            DropIndex("dbo.Exams", new[] { "MaterialId" });
            DropIndex("dbo.Exams", new[] { "UserId" });
            DropTable("dbo.Exams");
        }
    }
}
