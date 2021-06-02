using FluentMigrator;

namespace Parkhaus.Migrations
{
    [Migration(202106020301540)]
    public class Migration_202106020301540 : Migration
    {
        public override void Down()
        {
            Delete.Table("Examples");
        }

        public override void Up()
        {
            Create.Table("Examples")
                .WithColumn("ID").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString().NotNullable();
        }
    }
}
