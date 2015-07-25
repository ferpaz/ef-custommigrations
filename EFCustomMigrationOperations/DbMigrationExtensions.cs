using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using EFCustomMigrationOperations.CheckConstraints;
using EFCustomMigrationOperations.DefaultContraints;

namespace EFCustomMigrationOperations
{
    public static class DbMigrationExtensions
    {
        public static void CreateCheckConstraint(this DbMigration migration, string table, string column, string checkConstraint)
        {
            var createCheckConstraint = new CreateCheckConstraintOperation
            {
                Table = table,
                Column = column,
                CheckConstraint = checkConstraint
            };

            ((IDbMigration)migration).AddOperation(createCheckConstraint);
        }

        public static void DropCheckConstraint(this DbMigration migration, string table, string checkConstraintName)
        {
            var dropCheckConstraint = new DropCheckConstraintOperation
            {
                Table = table,
                CheckConstraintName = checkConstraintName
            };

            ((IDbMigration)migration).AddOperation(dropCheckConstraint);
        }

        public static void CreateDefaultConstraint(this DbMigration migration, string table, string column, string defaultConstraint)
        {
            var createDefaultConstraint = new CreateDefaultConstraintOperation
            {
                Table = table,
                Column = column,
                DefaultConstraint = defaultConstraint
            };

            ((IDbMigration)migration).AddOperation(createDefaultConstraint);
        }

        public static void DropDefaultConstraint(this DbMigration migration, string table, string defaultConstraintName)
        {
            var dropDefaultConstraint = new DropDefaultConstraintOperation
            {
                Table = table,
                DefaultConstraintName = defaultConstraintName
            };

            ((IDbMigration)migration).AddOperation(dropDefaultConstraint);
        }

    }
}
