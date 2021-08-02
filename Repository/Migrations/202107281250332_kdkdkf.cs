namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kdkdkf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "UserId", "dbo.Users");
            DropForeignKey("dbo.AnswerLikes", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.AnswerLikes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Coupons", "UserId", "dbo.Users");
            DropForeignKey("dbo.Units", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Lessons", "UnitId", "dbo.Units");
            DropForeignKey("dbo.Exams", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Homeworks", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Lectures", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Lives", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Posts", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.PostLikes", "PostId", "dbo.Posts");
            DropForeignKey("dbo.PostLikes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Questions", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Questions", "UnitId", "dbo.Units");
            DropForeignKey("dbo.QuestionAnswers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionAnswers", "UserId", "dbo.Users");
            DropIndex("dbo.AnswerLikes", new[] { "AnswerId" });
            DropIndex("dbo.AnswerLikes", new[] { "UserId" });
            DropIndex("dbo.Answers", new[] { "UserId" });
            DropIndex("dbo.Coupons", new[] { "UserId" });
            DropIndex("dbo.Exams", new[] { "LessonId" });
            DropIndex("dbo.Lessons", new[] { "UnitId" });
            DropIndex("dbo.Units", new[] { "MaterialId" });
            DropIndex("dbo.Homeworks", new[] { "LessonId" });
            DropIndex("dbo.Lectures", new[] { "LessonId" });
            DropIndex("dbo.Lives", new[] { "LessonId" });
            DropIndex("dbo.PostLikes", new[] { "PostId" });
            DropIndex("dbo.PostLikes", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "MaterialId" });
            DropIndex("dbo.QuestionAnswers", new[] { "QuestionId" });
            DropIndex("dbo.QuestionAnswers", new[] { "UserId" });
            DropIndex("dbo.Questions", new[] { "MaterialId" });
            DropIndex("dbo.Questions", new[] { "UnitId" });
            AddColumn("dbo.Rooms", "LevelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "LevelId");
            AddForeignKey("dbo.Rooms", "LevelId", "dbo.Levels", "Id", cascadeDelete: true);
            DropColumn("dbo.Users", "IMEI");
            DropColumn("dbo.Users", "ExpireDate");
            DropColumn("dbo.Users", "Points");
            DropColumn("dbo.ExamDetails", "AnswerDescription");
            DropColumn("dbo.Exams", "isHomework");
            DropColumn("dbo.Exams", "DependancyId");
            DropColumn("dbo.Exams", "DependancyType");
            DropColumn("dbo.Exams", "Repeatable");
            DropColumn("dbo.Exams", "LessonId");
            DropColumn("dbo.Homeworks", "DependancyId");
            DropColumn("dbo.Homeworks", "DependancyType");
            DropColumn("dbo.Homeworks", "LessonId");
            DropColumn("dbo.Lectures", "DependancyId");
            DropColumn("dbo.Lectures", "DependancyType");
            DropColumn("dbo.Lectures", "LessonId");
            DropColumn("dbo.Lives", "DependancyId");
            DropColumn("dbo.Lives", "DependancyType");
            DropColumn("dbo.Lives", "LessonId");
            DropTable("dbo.AnswerLikes");
            DropTable("dbo.Answers");
            DropTable("dbo.Coupons");
            DropTable("dbo.Lessons");
            DropTable("dbo.Units");
            DropTable("dbo.PostLikes");
            DropTable("dbo.Posts");
            DropTable("dbo.QuestionAnswers");
            DropTable("dbo.Questions");
            DropTable("dbo.Settings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeFrom = c.DateTime(nullable: false),
                        TimeTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Answer1 = c.String(),
                        Answer2 = c.String(),
                        Answer3 = c.String(),
                        Answer4 = c.String(),
                        CorrectAnswerNumber = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        AnswerNumber = c.Int(nullable: false),
                        isCorrect = c.Boolean(nullable: false),
                        AnswerDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        MaterialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostLikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialId = c.Int(nullable: false),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        Name = c.String(),
                        ContentType = c.Int(nullable: false),
                        ContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Answers = c.String(),
                        AnswerDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AnswerLikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnswerId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Lives", "LessonId", c => c.Int());
            AddColumn("dbo.Lives", "DependancyType", c => c.Int());
            AddColumn("dbo.Lives", "DependancyId", c => c.Int());
            AddColumn("dbo.Lectures", "LessonId", c => c.Int());
            AddColumn("dbo.Lectures", "DependancyType", c => c.Int());
            AddColumn("dbo.Lectures", "DependancyId", c => c.Int());
            AddColumn("dbo.Homeworks", "LessonId", c => c.Int());
            AddColumn("dbo.Homeworks", "DependancyType", c => c.Int());
            AddColumn("dbo.Homeworks", "DependancyId", c => c.Int());
            AddColumn("dbo.Exams", "LessonId", c => c.Int());
            AddColumn("dbo.Exams", "Repeatable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Exams", "DependancyType", c => c.Int());
            AddColumn("dbo.Exams", "DependancyId", c => c.Int());
            AddColumn("dbo.Exams", "isHomework", c => c.Boolean(nullable: false));
            AddColumn("dbo.ExamDetails", "AnswerDescription", c => c.String());
            AddColumn("dbo.Users", "Points", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "ExpireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "IMEI", c => c.String());
            DropForeignKey("dbo.Rooms", "LevelId", "dbo.Levels");
            DropIndex("dbo.Rooms", new[] { "LevelId" });
            DropColumn("dbo.Rooms", "LevelId");
            CreateIndex("dbo.Questions", "UnitId");
            CreateIndex("dbo.Questions", "MaterialId");
            CreateIndex("dbo.QuestionAnswers", "UserId");
            CreateIndex("dbo.QuestionAnswers", "QuestionId");
            CreateIndex("dbo.Posts", "MaterialId");
            CreateIndex("dbo.PostLikes", "UserId");
            CreateIndex("dbo.PostLikes", "PostId");
            CreateIndex("dbo.Lives", "LessonId");
            CreateIndex("dbo.Lectures", "LessonId");
            CreateIndex("dbo.Homeworks", "LessonId");
            CreateIndex("dbo.Units", "MaterialId");
            CreateIndex("dbo.Lessons", "UnitId");
            CreateIndex("dbo.Exams", "LessonId");
            CreateIndex("dbo.Coupons", "UserId");
            CreateIndex("dbo.Answers", "UserId");
            CreateIndex("dbo.AnswerLikes", "UserId");
            CreateIndex("dbo.AnswerLikes", "AnswerId");
            AddForeignKey("dbo.QuestionAnswers", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuestionAnswers", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "UnitId", "dbo.Units", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "MaterialId", "dbo.Materials", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PostLikes", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PostLikes", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "MaterialId", "dbo.Materials", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lives", "LessonId", "dbo.Lessons", "Id");
            AddForeignKey("dbo.Lectures", "LessonId", "dbo.Lessons", "Id");
            AddForeignKey("dbo.Homeworks", "LessonId", "dbo.Lessons", "Id");
            AddForeignKey("dbo.Exams", "LessonId", "dbo.Lessons", "Id");
            AddForeignKey("dbo.Lessons", "UnitId", "dbo.Units", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Units", "MaterialId", "dbo.Materials", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Coupons", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.AnswerLikes", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AnswerLikes", "AnswerId", "dbo.Answers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Answers", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
