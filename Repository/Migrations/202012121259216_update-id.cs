namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateid : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ExamDetails", new[] { "ExamID" });
            CreateIndex("dbo.ExamDetails", "ExamId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ExamDetails", new[] { "ExamId" });
            CreateIndex("dbo.ExamDetails", "ExamID");
        }
    }
}
