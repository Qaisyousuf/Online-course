namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AboutBannerAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        ImageUrl = c.String(),
                        JoinButton = c.String(),
                        JoinButtonUrl = c.String(),
                        DiscoverButton = c.String(),
                        DiscoverButtonTUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AboutBanners");
        }
    }
}
