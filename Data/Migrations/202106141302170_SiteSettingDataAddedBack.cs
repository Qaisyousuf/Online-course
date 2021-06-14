namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiteSettingDataAddedBack : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SiteSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiteTitle = c.String(),
                        SiteName = c.String(),
                        SiteOwner = c.String(),
                        GoogleSiteVerification = c.String(),
                        GoogleAnalytics = c.String(),
                        SiteLastUpdatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SiteContent = c.String(),
                        DesignedBy = c.String(),
                        Sitecopyright = c.String(),
                        AnimationUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SiteSettings");
        }
    }
}
