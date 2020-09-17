namespace FurnitureSolutions.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "DeliveryDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "DeliveryDate", c => c.DateTime(nullable: false));
        }
    }
}
