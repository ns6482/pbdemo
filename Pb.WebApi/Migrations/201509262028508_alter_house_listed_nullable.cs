using System.Data.Entity.Migrations;

namespace Pb.WebApi.Migrations
{
    public partial class alter_house_listed_nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.House", "Accepted", c => c.DateTime());
        }

        public override void Down()
        {
            AlterColumn("dbo.House", "Accepted", c => c.DateTime(false));
        }
    }
}