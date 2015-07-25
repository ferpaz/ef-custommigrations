using System;
using System.Data.Entity.Migrations.Model;

namespace EFCustomMigrationOperations.DefaultContraints
{
    public class DropDefaultConstraintOperation : MigrationOperation
    {
        private string _table;
        private string _DefaultConstraintName;

        public DropDefaultConstraintOperation()
            : base(null)
        {
        }

        public string Table
        {
            get { return _table; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Argument is null or contains only white spaces.", "value");
                }

                _table = value;
            }
        }
        
        public string DefaultConstraintName
        {
            get { return _DefaultConstraintName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Argument is null or contains only white spaces.", "value");
                }

                _DefaultConstraintName = value;
            }
        }

        public override bool IsDestructiveChange
        {
            get { return false; }
        }
    }
}
