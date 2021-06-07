namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyRelationshipForSiteSettingsAndFooterLinksCreated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FooterLinks", "SiteSettings_Id", "dbo.SiteSettings");
            DropIndex("dbo.FooterLinks", new[] { "SiteSettings_Id" });
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
            
            AddColumn("dbo.SiteSettings", "SiteTitle", c => c.String());
            DropColumn("dbo.FooterLinks", "SiteSettings_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FooterLinks", "SiteSettings_Id", c => c.Int());
            DropForeignKey("dbo.SiteSettingsFooterLinks", "FooterLinks_Id", "dbo.FooterLinks");
            DropForeignKey("dbo.SiteSettingsFooterLinks", "SiteSettings_Id", "dbo.SiteSettings");
            DropIndex("dbo.SiteSettingsFooterLinks", new[] { "FooterLinks_Id" });
            DropIndex("dbo.SiteSettingsFooterLinks", new[] { "SiteSettings_Id" });
            DropColumn("dbo.SiteSettings", "SiteTitle");
            DropTable("dbo.SiteSettingsFooterLinks");
            CreateIndex("dbo.FooterLinks", "SiteSettings_Id");
            AddForeignKey("dbo.FooterLinks", "SiteSettings_Id", "dbo.SiteSettings", "Id");
        }
    }
}
