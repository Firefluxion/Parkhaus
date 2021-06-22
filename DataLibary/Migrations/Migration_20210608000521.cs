using FluentMigrator;

namespace DataLibary.Migrations
{
    [Migration(20210608000521, "Create Table Arrivals")]
    public class Migration_20210608000521 : Migration
    {
        public override void Down()
        {
            Delete.Table("Arrivals");
        }

        public override void Up()
        {
            Create.Table("Arrivals")
                .WithColumn("GarageID").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("LicensePlate").AsString().NotNullable().PrimaryKey()
                .WithColumn("Time").AsDateTime2().NotNullable().PrimaryKey();
        }
    }
}
