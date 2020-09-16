namespace FurnitureSolutions.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesRep : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesRep",
                c => new
                    {
                        RepId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        RepName = c.String(),
                        Territory = c.String(),
                    })
                .PrimaryKey(t => t.RepId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SalesRep");
        }
    }
}
