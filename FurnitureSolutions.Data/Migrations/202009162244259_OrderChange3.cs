namespace FurnitureSolutions.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderChange3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "UserId", c => c.Guid(nullable: false));
            DropColumn("dbo.SalesRep", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesRep", "UserId", c => c.Guid(nullable: false));
            DropColumn("dbo.Order", "UserId");
        }
    }
}
