namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuizBasicInfoAddedToQuizPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuizPages", "QuizBasicInfoID", c => c.Int(nullable: false));
            CreateIndex("dbo.QuizPages", "QuizBasicInfoID");
            AddForeignKey("dbo.QuizPages", "QuizBasicInfoID", "dbo.QuizBasicInfoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuizPages", "QuizBasicInfoID", "dbo.QuizBasicInfoes");
            DropIndex("dbo.QuizPages", new[] { "QuizBasicInfoID" });
            DropColumn("dbo.QuizPages", "QuizBasicInfoID");
        }
    }
}
