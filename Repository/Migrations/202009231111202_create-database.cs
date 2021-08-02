namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LevelId = c.Int(nullable: false),
                        Name = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacultyId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Facultys", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Facultys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainerId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                        ZoomMeetingId = c.String(),
                        ZoomPassword = c.String(),
                        Price = c.Int(nullable: false),
                        UserId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId_Id)
                .Index(t => t.MaterialId)
                .Index(t => t.UserId_Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LevelId = c.Int(nullable: false),
                        DivisionId = c.Int(),
                        Name = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Divisions", t => t.DivisionId)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId)
                .Index(t => t.DivisionId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Phone1 = c.String(),
                        Phone2 = c.String(),
                        Governemnt = c.String(),
                        Address = c.String(),
                        SchoolName = c.String(),
                        UserType = c.Int(nullable: false),
                        NationalId = c.String(),
                        Balance = c.Int(nullable: false),
                        FacultyId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                        DivisionId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Divisions", t => t.DivisionId, cascadeDelete: true)
                .ForeignKey("dbo.Facultys", t => t.FacultyId, cascadeDelete: false)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: false)
                .Index(t => t.FacultyId)
                .Index(t => t.LevelId)
                .Index(t => t.DivisionId);
            
            CreateTable(
                "dbo.Notifs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        FacultyId = c.Int(),
                        LevelId = c.Int(),
                        DivisionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Divisions", t => t.DivisionId)
                .ForeignKey("dbo.Facultys", t => t.FacultyId)
                .ForeignKey("dbo.Levels", t => t.LevelId)
                .Index(t => t.FacultyId)
                .Index(t => t.LevelId)
                .Index(t => t.DivisionId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Payed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                        PaymentType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Notifs", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.Notifs", "FacultyId", "dbo.Facultys");
            DropForeignKey("dbo.Notifs", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Lives", "UserId_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.Users", "FacultyId", "dbo.Facultys");
            DropForeignKey("dbo.Users", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Lives", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Materials", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.Materials", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Divisions", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.Levels", "FacultyId", "dbo.Facultys");
            DropIndex("dbo.Payments", new[] { "UserId" });
            DropIndex("dbo.Notifs", new[] { "DivisionId" });
            DropIndex("dbo.Notifs", new[] { "LevelId" });
            DropIndex("dbo.Notifs", new[] { "FacultyId" });
            DropIndex("dbo.Users", new[] { "DivisionId" });
            DropIndex("dbo.Users", new[] { "LevelId" });
            DropIndex("dbo.Users", new[] { "FacultyId" });
            DropIndex("dbo.Materials", new[] { "DivisionId" });
            DropIndex("dbo.Materials", new[] { "LevelId" });
            DropIndex("dbo.Lives", new[] { "UserId_Id" });
            DropIndex("dbo.Lives", new[] { "MaterialId" });
            DropIndex("dbo.Levels", new[] { "FacultyId" });
            DropIndex("dbo.Divisions", new[] { "LevelId" });
            DropTable("dbo.Payments");
            DropTable("dbo.Notifs");
            DropTable("dbo.Users");
            DropTable("dbo.Materials");
            DropTable("dbo.Lives");
            DropTable("dbo.Facultys");
            DropTable("dbo.Levels");
            DropTable("dbo.Divisions");
        }
    }
}
