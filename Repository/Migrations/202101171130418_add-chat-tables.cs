namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addchattables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromUserId = c.Int(nullable: false),
                        FromUserName = c.String(),
                        RoomId = c.Int(nullable: false),
                        Message = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChatStatues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        UserName = c.String(),
                        UserId = c.Int(nullable: false),
                        isDelivered = c.Boolean(nullable: false),
                        isRead = c.Boolean(nullable: false),
                        ChatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chats", t => t.ChatId, cascadeDelete: true)
                .Index(t => t.ChatId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomName = c.String(),
                        HostUserId = c.Int(nullable: false),
                        ZoomUser = c.String(),
                        ZoomPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoomUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChatStatues", "ChatId", "dbo.Chats");
            DropIndex("dbo.ChatStatues", new[] { "ChatId" });
            DropTable("dbo.RoomUsers");
            DropTable("dbo.Rooms");
            DropTable("dbo.ChatStatues");
            DropTable("dbo.Chats");
        }
    }
}
