namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyAddedToCoursesBanner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseBanners", "SubContent", c => c.String());
            AddColumn("dbo.CourseBanners", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseBanners", "Content");
            DropColumn("dbo.CourseBanners", "SubContent");
        }
    }
}
