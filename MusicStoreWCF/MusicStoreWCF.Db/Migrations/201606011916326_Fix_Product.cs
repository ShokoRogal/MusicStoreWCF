namespace MusicStoreWCF.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix_Product : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 6, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Price", c => c.Decimal(precision: 6, scale: 2));
        }
    }
}
