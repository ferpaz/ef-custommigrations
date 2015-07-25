using EFCustomMigrationOperations;

namespace EFCustomMigrationOperations.Sample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultContraint : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "InStock", c => c.Boolean(nullable: false));
            this.CreateDefaultConstraint("Products", "InStock", "1");
        }
        
        public override void Down()
        {
            this.DropDefaultConstraint("Products", "DF_Products_InStock");
            DropColumn("dbo.Products", "InStock");
        }
    }
}
