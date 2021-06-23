namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CovidModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.COVID_19", "CovidButtonText", c => c.String());
            AddColumn("dbo.COVID_19", "CovidButtonUrl", c => c.String());
            AddColumn("dbo.COVID_19", "CourseButtonText", c => c.String());
            AddColumn("dbo.COVID_19", "CourseButtonUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.COVID_19", "CourseButtonUrl");
            DropColumn("dbo.COVID_19", "CourseButtonText");
            DropColumn("dbo.COVID_19", "CovidButtonUrl");
            DropColumn("dbo.COVID_19", "CovidButtonText");
        }
    }
}
