namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountryNameAddedToStudentSaysModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentsSays", "CountryName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentsSays", "CountryName");
        }
    }
}
