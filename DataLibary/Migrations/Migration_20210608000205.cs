using FluentMigrator;

namespace DataLibary.Migrations
{
    [Migration(20210608000205, "Create Table Exits")]
    public class Migration_20210608000205 : Migration
    {
        public override void Down()
        {
            Delete.Table("Exits");
        }

        public override void Up()
        {
            Create.Table("Exits")
                .WithColumn("ID").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Time").AsDateTime().NotNullable();
        }
    }
}
