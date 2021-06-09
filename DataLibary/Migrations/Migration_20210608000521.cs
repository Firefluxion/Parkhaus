using FluentMigrator;

namespace DataLibary.Migrations
{
    [Migration(20210608000521, "Create Table TicketArrivals")]
    public class Migration_20210608000521 : Migration
    {
        public override void Down()
        {
            Delete.Table("TicketArrivals");
        }

        public override void Up()
        {
            Create.Table("TicketArrivals")
                .WithColumn("TicketID").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("ArrivalID").AsInt32().NotNullable().PrimaryKey();
        }
    }
}
