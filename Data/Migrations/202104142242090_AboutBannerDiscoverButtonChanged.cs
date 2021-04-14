namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AboutBannerDiscoverButtonChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AboutBanners", "DiscoverButtonUrl", c => c.String());
            DropColumn("dbo.AboutBanners", "DiscoverButtonTUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AboutBanners", "DiscoverButtonTUrl", c => c.String());
            DropColumn("dbo.AboutBanners", "DiscoverButtonUrl");
        }
    }
}
