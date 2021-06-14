namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FooterLinksRemoved : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SiteSettingsFooterLinks", newName: "FooterLinksSiteSettings");
            DropPrimaryKey("dbo.FooterLinksSiteSettings");
            AddPrimaryKey("dbo.FooterLinksSiteSettings", new[] { "FooterLinks_Id", "SiteSettings_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.FooterLinksSiteSettings");
            AddPrimaryKey("dbo.FooterLinksSiteSettings", new[] { "SiteSettings_Id", "FooterLinks_Id" });
            RenameTable(name: "dbo.FooterLinksSiteSettings", newName: "SiteSettingsFooterLinks");
        }
    }
}
