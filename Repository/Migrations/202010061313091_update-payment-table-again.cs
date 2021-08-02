namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepaymenttableagain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "ProductType", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "Payed", c => c.Int(nullable: false));
            DropColumn("dbo.Payments", "PaymentType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "PaymentType", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "Payed", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Payments", "ProductType");
        }
    }
}
