namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyAddedToContactDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactDetails", "MapAnimationUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactDetails", "MapAnimationUrl");
        }
    }
}
