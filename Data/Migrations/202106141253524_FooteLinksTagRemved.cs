namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FooteLinksTagRemved : DbMigration
    {
        public override void Up()
        {
          
            DropForeignKey("dbo.FooterLinksSiteSettings", "SiteSettings_Id", "dbo.SiteSettings");
           
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FooterLinksSiteSettings",
                c => new
                    {
                        FooterLinks_Id = c.Int(nullable: false),
                        SiteSettings_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FooterLinks_Id, t.SiteSettings_Id });
            
            CreateTable(
                "dbo.FooterLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NavigationName = c.String(),
                        LinkUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.FooterLinksSiteSettings", "SiteSettings_Id");
            CreateIndex("dbo.FooterLinksSiteSettings", "FooterLinks_Id");
            AddForeignKey("dbo.FooterLinksSiteSettings", "SiteSettings_Id", "dbo.SiteSettings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FooterLinksSiteSettings", "FooterLinks_Id", "dbo.FooterLinks", "Id", cascadeDelete: true);
        }
    }
}
