namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addexamdetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExamDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExamID = c.Int(nullable: false),
                        Question = c.String(),
                        Image = c.String(),
                        Answer1 = c.String(),
                        Answer2 = c.String(),
                        Answer3 = c.String(),
                        Answer4 = c.String(),
                        Answer5 = c.String(),
                        RightAnswer = c.Int(nullable: false),
                        QuestionTimer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exams", t => t.ExamID, cascadeDelete: true)
                .Index(t => t.ExamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamDetails", "ExamID", "dbo.Exams");
            DropIndex("dbo.ExamDetails", new[] { "ExamID" });
            DropTable("dbo.ExamDetails");
        }
    }
}
