using FluentMigrator;

namespace DataLibary.Migrations
{
    [Migration(20210608001850, "Insert Into Costs ShortTerm Values")]
    public class Migration_20210608001850 : Migration
    {
        public override void Down()
        {
            Delete.FromTable("Costs").Row(new { ID = 0 });
        }

        public override void Up()
        {
            Insert.IntoTable("Costs")
                .Row(new {
                    ID = 0,
                    Name = "ShortTerm",
                    EuroPerHour = 4.20,
                });
        }
    }
}
