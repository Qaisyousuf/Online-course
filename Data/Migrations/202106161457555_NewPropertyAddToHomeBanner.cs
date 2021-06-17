namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPropertyAddToHomeBanner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HomeBanners", "SubMaintitle", c => c.String());
            AddColumn("dbo.HomeBanners", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HomeBanners", "Content");
            DropColumn("dbo.HomeBanners", "SubMaintitle");
        }
    }
}
