namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiteSettingdAndFooterLinksAddedBackToDatabase : DbMigration
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SiteSettingsFooterLinks",
                c => new
                    {
                        SiteSettings_Id = c.Int(nullable: false),
                        FooterLinks_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SiteSettings_Id, t.FooterLinks_Id })
                .ForeignKey("dbo.SiteSettings", t => t.SiteSettings_Id, cascadeDelete: true)
                .ForeignKey("dbo.FooterLinks", t => t.FooterLinks_Id, cascadeDelete: true)
                .Index(t => t.SiteSettings_Id)
                .Index(t => t.FooterLinks_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SiteSettingsFooterLinks", "FooterLinks_Id", "dbo.FooterLinks");
            DropForeignKey("dbo.SiteSettingsFooterLinks", "SiteSettings_Id", "dbo.SiteSettings");
            DropIndex("dbo.SiteSettingsFooterLinks", new[] { "FooterLinks_Id" });
            DropIndex("dbo.SiteSettingsFooterLinks", new[] { "SiteSettings_Id" });
            DropTable("dbo.SiteSettingsFooterLinks");
            DropTable("dbo.FooterLinks");
        }
    }
}
