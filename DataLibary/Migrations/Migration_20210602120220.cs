using FluentMigrator;

namespace DataLibary.Migrations
{
    [Migration(20210602120220, "Insert Into Garages DefaultGarage Values")]
    public class Migration_20210602120220 : Migration
    {
        public override void Down()
        {
            Delete.FromTable("Garages").Row(new { ID = 0 });
        }

        public override void Up()
        {
            Insert.IntoTable("Garages")
                .Row(new { 
                    ID = 0,
                    Name = "DefaultGarage",
                    Capacity = 180,
                    ReservedForLongTerm = 40,
                    ShortTermAccessMinThreshold = 4,
                    DisplayOccupiedThreshold = 4,
                });
        }
    }
}
