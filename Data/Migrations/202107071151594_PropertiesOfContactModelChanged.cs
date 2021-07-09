namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertiesOfContactModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactBanners", "Content", c => c.String());
            AddColumn("dbo.ContactBanners", "SubContent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactBanners", "SubContent");
            DropColumn("dbo.ContactBanners", "Content");
        }
    }
}
