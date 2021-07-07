namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AboutPageModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AboutBanners", "Content", c => c.String());
            AddColumn("dbo.AboutBanners", "MainSubTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AboutBanners", "MainSubTitle");
            DropColumn("dbo.AboutBanners", "Content");
        }
    }
}
