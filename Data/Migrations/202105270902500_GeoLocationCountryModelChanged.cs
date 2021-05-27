namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeoLocationCountryModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeolocationStudents", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.GeolocationStudents", "CountryId");
            AddForeignKey("dbo.GeolocationStudents", "CountryId", "dbo.CountryNames", "Id", cascadeDelete: true);
            DropColumn("dbo.GeolocationStudents", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GeolocationStudents", "Country", c => c.String());
            DropForeignKey("dbo.GeolocationStudents", "CountryId", "dbo.CountryNames");
            DropIndex("dbo.GeolocationStudents", new[] { "CountryId" });
            DropColumn("dbo.GeolocationStudents", "CountryId");
        }
    }
}
