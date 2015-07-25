using System;
using System.Data.Entity.Migrations.Model;

namespace EFCustomMigrationOperations.DefaultContraints
{
    public class CreateDefaultConstraintOperation : MigrationOperation
    {
        private string _table;
        private string _column;
        private string _DefaultConstraint;
        private string _DefaultConstraintName;

        public CreateDefaultConstraintOperation()
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

        public string Column
        {
            get { return _column; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Argument is null or contains only white spaces.",  "value");
                }

                _column = value;
            }
        }

        public string DefaultConstraint
        {
            get { return _DefaultConstraint; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Argument is null or contains only white spaces.", "value");
                }

                _DefaultConstraint = value;
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

        public string BuildDefaultName()
        {
            return string.Format("DF_{0}_{1}", Table.Replace(".", "_").Replace("[", "").Replace("]", ""), Column);
        }

        public string BuildVariableName()
        {
            return string.Format("@{0}_{1}", Table.Replace(".", "_").Replace("[", "").Replace("]", ""), Column);
        }
    }
}
