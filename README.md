##Entity Framework 6
##Custom migration operations

This repository contains a custom migration operation for entity framework 6 for creating and dropping a CHECK CONSTRAINTS and DEFAULT CONSTRAINTS.

## Usage

for Check Constraint

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

for Default Constraint

    namespace EFCustomMigrationOperations.Sample.Migrations
    {
        using System;
        using System.Data.Entity.Migrations;
    
        public partial class AddDefaultContraint : DbMigration
        {
            public override void Up()
            {
                this.CreateDefaultConstraint("Products", "InStock", "1");
            }
        
            public override void Down()
            {
                this.DropDefaultConstraint("Products", "DF_Products_InStock");
            }
        }
    }


For more details, look at this [article](https://dolinkamark.wordpress.com/2014/05/03/creating-a-custom-migration-operation-in-entity-framework/).
 
