using FluentMigrator;

namespace DataLibary.Migrations
{
    [Migration(20210607224725, "Create Table ParkTickets")]
    public class Migration_20210607224725 : Migration
    {
        public override void Down()
        {
            Delete.Table("ParkTickets");
        }

        public override void Up()
        {
            Create.Table("ParkTickets")
                .WithColumn("LicensePlate").AsString(8).NotNullable().PrimaryKey()
                .WithColumn("LongTerm").AsBoolean().NotNullable()
                .WithColumn("InParkhaus").AsBoolean();
        }
    }
}
