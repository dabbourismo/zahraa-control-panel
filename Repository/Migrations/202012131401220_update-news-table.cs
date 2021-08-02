namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatenewstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.News", "FacultyId", c => c.Int());
            CreateIndex("dbo.News", "FacultyId");
            AddForeignKey("dbo.News", "FacultyId", "dbo.Facultys", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "FacultyId", "dbo.Facultys");
            DropIndex("dbo.News", new[] { "FacultyId" });
            DropColumn("dbo.News", "FacultyId");
            DropColumn("dbo.News", "Date");
        }
    }
}
