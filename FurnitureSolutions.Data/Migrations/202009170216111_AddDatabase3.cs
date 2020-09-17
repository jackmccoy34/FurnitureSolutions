namespace FurnitureSolutions.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatabase3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Order", "CustomerId");
            AddForeignKey("dbo.Order", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropColumn("dbo.Order", "CustomerId");
        }
    }
}
