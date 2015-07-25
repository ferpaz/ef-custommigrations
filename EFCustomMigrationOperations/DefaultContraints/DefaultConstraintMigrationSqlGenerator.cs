using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;

namespace EFCustomMigrationOperations.DefaultContraints
{
    public class DefaultConstraintMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(MigrationOperation migrationOperation)
        {
            if (migrationOperation is CreateDefaultConstraintOperation)
            {
                Generate((CreateDefaultConstraintOperation)migrationOperation);
            }
            else if (migrationOperation is DropDefaultConstraintOperation)
            {
                Generate(migrationOperation as DropDefaultConstraintOperation);
            }
        }

        protected virtual void Generate(CreateDefaultConstraintOperation migrationOperation)
        {
            if (migrationOperation.DefaultConstraintName == null)
            {
                migrationOperation.DefaultConstraintName = migrationOperation.BuildDefaultName();
            }

            using (var writer = Writer())
            {
                writer.WriteLine("declare {0} as nvarchar(max)", migrationOperation.BuildVariableName());
                writer.WriteLine("SELECT {0} = 'ALTER TABLE {1} DROP CONSTRAINT ' + name FROM sys.default_constraints" +
                                 " WHERE parent_object_id = object_id(N'{1}', N'U')" +
                                   " and parent_column_id = (select parent_column_id from sys.columns where object_id = object_id(N'{1}', N'U') and name = N'{2}')",
                                 migrationOperation.BuildVariableName(),
                                 Name(migrationOperation.Table),
                                 migrationOperation.Column
                        );
                writer.WriteLine("if {0} is not null exec ({0})", migrationOperation.BuildVariableName());
                writer.WriteLine("ALTER TABLE {0} ADD CONSTRAINT {1} DEFAULT ({2}) FOR {3}",
                                 Name(migrationOperation.Table),
                                 Quote(migrationOperation.DefaultConstraintName),
                                 migrationOperation.DefaultConstraint,
                                 migrationOperation.Column
                        );
                Statement(writer);
            }
        }

        protected virtual void Generate(DropDefaultConstraintOperation migrationOperation)
        {
            using (var writer = Writer())
            {
                writer.WriteLine(
                    "IF EXISTS (SELECT name FROM sys.default_constraints WHERE name = N'{0}' " +
                    "AND parent_object_id = object_id(N'{1}', N'U'))",
                    migrationOperation.DefaultConstraintName.Replace("'", "''"),
                    Name(migrationOperation.Table).Replace("'", "''")
                );

                writer.Write(
                    "ALTER TABLE {0} DROP CONSTRAINT {1}",
                    Name(migrationOperation.Table),
                    Quote(migrationOperation.DefaultConstraintName)
                );

                Statement(writer);
            }
        }
    }
}
