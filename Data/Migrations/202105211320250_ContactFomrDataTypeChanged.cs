namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactFomrDataTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactForms", "Message", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactForms", "Message", c => c.Int(nullable: false));
        }
    }
}
