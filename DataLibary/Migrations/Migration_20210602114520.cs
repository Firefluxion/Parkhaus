using FluentMigrator;

namespace DataLibary.Migrations
{
    [Migration(20210602114520, "Create Table Garages")]
    public class Migration_20210602114520 : Migration
    {
        public override void Down()
        {
            Delete.Table("Garages");
        }

        public override void Up()
        {
            Create.Table("Garages")
                .WithColumn("ID").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Capacity").AsInt32().NotNullable()
                .WithColumn("ReservedForLongTerm").AsInt32().NotNullable()
                .WithColumn("ShortTermAccessMinThreshold").AsInt32().NotNullable()
                .WithColumn("DisplayOccupiedThreshold").AsInt32().NotNullable();
        }
    }
}
