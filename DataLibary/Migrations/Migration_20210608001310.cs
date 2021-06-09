using FluentMigrator;

namespace DataLibary.Migrations
{
    [Migration(20210608001310, "Create Table Costs")]
    public class Migration_20210608001310 : Migration
    {
        public override void Down()
        {
            Delete.Table("Costs");
        }

        public override void Up()
        {
            Create.Table("Costs")
                .WithColumn("ID").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("EuroPerHour").AsDecimal().NotNullable();
        }
    }
}
