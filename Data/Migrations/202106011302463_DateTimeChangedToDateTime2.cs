namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeChangedToDateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactDetails", "WorkingStartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ContactDetails", "WrokingEndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.HomeCourseSections", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.QuizPages", "QuizDateTiem", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.AspNetUsers", "CreatedData", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.VideoReviews", "ProgramCompletionDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VideoReviews", "ProgramCompletionDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "CreatedData", c => c.DateTime(nullable: false));
            AlterColumn("dbo.QuizPages", "QuizDateTiem", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HomeCourseSections", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ContactDetails", "WrokingEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ContactDetails", "WorkingStartDate", c => c.DateTime(nullable: false));
        }
    }
}
