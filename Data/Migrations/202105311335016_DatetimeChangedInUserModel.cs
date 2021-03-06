namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatetimeChangedInUserModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "CreatedData", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "CreatedData", c => c.DateTime(nullable: false));
        }
    }
}
