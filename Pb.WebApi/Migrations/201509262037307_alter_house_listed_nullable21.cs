using System.Data.Entity.Migrations;

namespace Pb.WebApi.Migrations
{
    public partial class alter_house_listed_nullable21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.House", "Listed", c => c.DateTime(false));
        }

        public override void Down()
        {
            AlterColumn("dbo.House", "Listed", c => c.DateTime(false));
        }
    }
}