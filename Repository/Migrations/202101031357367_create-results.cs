namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createresults : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ExamId = c.Int(nullable: false),
                        UserResult = c.Int(nullable: false),
                        TotalDegree = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.ExamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "UserId", "dbo.Users");
            DropForeignKey("dbo.Results", "ExamId", "dbo.Exams");
            DropIndex("dbo.Results", new[] { "ExamId" });
            DropIndex("dbo.Results", new[] { "UserId" });
            DropTable("dbo.Results");
        }
    }
}
