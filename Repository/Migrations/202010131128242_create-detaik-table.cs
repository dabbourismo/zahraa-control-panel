namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdetaiktable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PayDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Payed = c.Int(nullable: false),
                        Direction = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentDetails", "UserId", "dbo.Users");
            DropIndex("dbo.PaymentDetails", new[] { "UserId" });
            DropTable("dbo.PaymentDetails");
        }
    }
}
