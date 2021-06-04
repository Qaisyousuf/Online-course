namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FooterLinksAndSiteSettingModelsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FooterLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NavigationName = c.String(),
                        LinkUrl = c.String(),
                        SiteSettings_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SiteSettings", t => t.SiteSettings_Id)
                .Index(t => t.SiteSettings_Id);
            
            CreateTable(
                "dbo.SiteSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiteName = c.String(),
                        SiteOwner = c.String(),
                        GoogleSiteVerification = c.String(),
                        GoogleAnalytics = c.String(),
                        SiteLastUpdatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AnimationUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FooterLinks", "SiteSettings_Id", "dbo.SiteSettings");
            DropIndex("dbo.FooterLinks", new[] { "SiteSettings_Id" });
            DropTable("dbo.SiteSettings");
            DropTable("dbo.FooterLinks");
        }
    }
}
