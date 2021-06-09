using FluentMigrator;

namespace DataLibary.Migrations
{
    [Migration(20210608000850, "Create Table TicketExits")]
    public class Migration_20210608000850 : Migration
    {
        public override void Down()
        {
            Delete.Table("TicketExits");
        }

        public override void Up()
        {
            Create.Table("TicketExits")
                .WithColumn("TicketID").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("ExitID").AsInt32().NotNullable().PrimaryKey();
        }
    }
}
