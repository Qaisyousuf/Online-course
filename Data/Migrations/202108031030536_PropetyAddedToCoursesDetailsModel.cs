namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropetyAddedToCoursesDetailsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseDetails", "SubContents", c => c.String());
            AddColumn("dbo.CourseDetails", "RegisterButton", c => c.String());
            AddColumn("dbo.CourseDetails", "RegisterButtonUrl", c => c.String());
            AddColumn("dbo.CourseDetails", "LifeTimeAccess", c => c.String());
            AddColumn("dbo.CourseDetails", "CourseType", c => c.String());
            AddColumn("dbo.CourseDetails", "NumArticales", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseDetails", "NumArticales");
            DropColumn("dbo.CourseDetails", "CourseType");
            DropColumn("dbo.CourseDetails", "LifeTimeAccess");
            DropColumn("dbo.CourseDetails", "RegisterButtonUrl");
            DropColumn("dbo.CourseDetails", "RegisterButton");
            DropColumn("dbo.CourseDetails", "SubContents");
        }
    }
}
