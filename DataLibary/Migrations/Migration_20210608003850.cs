using FluentMigrator;

namespace DataLibary.Migrations
{
    [Migration(20210608003850, "Insert Into Costs LongTerm Values")]
    public class Migration_20210608003850 : Migration
    {
        public override void Down()
        {
            Delete.FromTable("Costs").Row(new { ID = 1 });
        }

        public override void Up()
        {
            Insert.IntoTable("Costs")
                .Row(new {
                    ID = 1,
                    Name = "LongTerm",
                    EuroPerHour = 0.69
                });
        }
    }
}
