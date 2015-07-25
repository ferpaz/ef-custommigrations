using System.Data.Entity.Migrations;

namespace EFCustomMigrationOperations.Sample.Migrations
{
    public partial class AddCheckConstraint : DbMigration
    {
        public override void Up()
        {
            this.CreateCheckConstraint("Products", "SKU", "SKU LIKE '[A-Z][A-Z]-[0-9][0-9]%'");
        }
        
        public override void Down()
        {
            this.DropCheckConstraint("Products", "CK_Products_SKU");
        }
    }
}
