using FluentMigrator;

namespace DataLibary.Migrations
{
    [Migration(20210608000850, "Create Table Checkouts")]
    public class Migration_20210608000850 : Migration
    {
        public override void Down()
        {
            Delete.Table("Checkouts");
        }

        public override void Up()
        {
            Create.Table("Checkouts")
                .WithColumn("GarageID").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("LicensePlate").AsString().NotNullable().PrimaryKey()
                .WithColumn("Time").AsDateTime2().NotNullable().PrimaryKey();
        }
    }
}
