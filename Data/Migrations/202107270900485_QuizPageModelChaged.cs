namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuizPageModelChaged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuizPages", "QuizBasicInfoID", "dbo.QuizBasicInfoes");
            DropForeignKey("dbo.QuizQuestions", "QuizPage_Id", "dbo.QuizPages");
            DropIndex("dbo.QuizPages", new[] { "QuizBasicInfoID" });
            DropIndex("dbo.QuizQuestions", new[] { "QuizPage_Id" });
            AddColumn("dbo.QuizPages", "QuizBannerId", c => c.Int(nullable: false));
            CreateIndex("dbo.QuizPages", "QuizBannerId");
            AddForeignKey("dbo.QuizPages", "QuizBannerId", "dbo.QuizBanners", "Id", cascadeDelete: true);
            DropColumn("dbo.QuizPages", "QuizDateTiem");
            DropColumn("dbo.QuizPages", "QuizBasicInfoID");
            DropColumn("dbo.QuizQuestions", "QuizPage_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuizQuestions", "QuizPage_Id", c => c.Int());
            AddColumn("dbo.QuizPages", "QuizBasicInfoID", c => c.Int(nullable: false));
            AddColumn("dbo.QuizPages", "QuizDateTiem", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropForeignKey("dbo.QuizPages", "QuizBannerId", "dbo.QuizBanners");
            DropIndex("dbo.QuizPages", new[] { "QuizBannerId" });
            DropColumn("dbo.QuizPages", "QuizBannerId");
            CreateIndex("dbo.QuizQuestions", "QuizPage_Id");
            CreateIndex("dbo.QuizPages", "QuizBasicInfoID");
            AddForeignKey("dbo.QuizQuestions", "QuizPage_Id", "dbo.QuizPages", "Id");
            AddForeignKey("dbo.QuizPages", "QuizBasicInfoID", "dbo.QuizBasicInfoes", "Id", cascadeDelete: true);
        }
    }
}
