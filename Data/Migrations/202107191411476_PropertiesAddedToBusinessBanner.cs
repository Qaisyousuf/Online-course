namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertiesAddedToBusinessBanner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BusinessBanners", "Content", c => c.String());
            AddColumn("dbo.BusinessBanners", "SubContent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BusinessBanners", "SubContent");
            DropColumn("dbo.BusinessBanners", "Content");
        }
    }
}
