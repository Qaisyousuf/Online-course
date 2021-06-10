namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiteSettinghasChnagedtheProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SiteSettings", "SiteContent", c => c.String());
            AddColumn("dbo.SiteSettings", "DesignedBy", c => c.String());
            AddColumn("dbo.SiteSettings", "Sitecopyright", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SiteSettings", "Sitecopyright");
            DropColumn("dbo.SiteSettings", "DesignedBy");
            DropColumn("dbo.SiteSettings", "SiteContent");
        }
    }
}
