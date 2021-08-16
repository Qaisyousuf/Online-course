namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersContactModelChangedWithFullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserContacts", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserContacts", "FullName");
        }
    }
}
