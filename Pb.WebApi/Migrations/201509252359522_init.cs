using System.Data.Entity.Migrations;

namespace Pb.WebApi.Migrations
{
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.House",
                c => new
                {
                    ID = c.Int(false, true),
                    Title = c.String(),
                    Description = c.String(),
                    Value = c.Int(false),
                    OwnerId = c.String(),
                    Owner = c.String(),
                    Listed = c.DateTime(false),
                    AcceptedOffer = c.Int(),
                    Accepted = c.DateTime(false)
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Offer",
                c => new
                {
                    ID = c.Int(false, true),
                    BuyerId = c.String(),
                    Buyer = c.String(),
                    Amount = c.Int(false),
                    OfferDate = c.DateTime(false),
                    NumChainsBuyer = c.Int(false),
                    House_ID = c.Int()
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.House", t => t.House_ID)
                .Index(t => t.House_ID);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Offer", "House_ID", "dbo.House");
            DropIndex("dbo.Offer", new[] {"House_ID"});
            DropTable("dbo.Offer");
            DropTable("dbo.House");
        }
    }
}