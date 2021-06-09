using FluentMigrator;

namespace DataLibary.Migrations
{
    [Migration(20210607234322, "Create Table Arrivals")]
    public class Migration_20210607234322 : Migration
    {
        public override void Down()
        {
            Delete.Table("Arrivals");
        }

        public override void Up()
        {
            Create.Table("Arrivals")
                .WithColumn("ID").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Time").AsDateTime().NotNullable();
        }
    }
}
