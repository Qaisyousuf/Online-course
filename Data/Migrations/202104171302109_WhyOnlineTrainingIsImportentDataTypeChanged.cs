namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WhyOnlineTrainingIsImportentDataTypeChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WhyOnlineTrainingIsImportants", "SubContent", c => c.String());
            AlterColumn("dbo.WhyOnlineTrainingIsImportants", "MainTitle", c => c.String());
            DropColumn("dbo.WhyOnlineTrainingIsImportants", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WhyOnlineTrainingIsImportants", "Content", c => c.String());
            AlterColumn("dbo.WhyOnlineTrainingIsImportants", "MainTitle", c => c.Int(nullable: false));
            DropColumn("dbo.WhyOnlineTrainingIsImportants", "SubContent");
        }
    }
}
