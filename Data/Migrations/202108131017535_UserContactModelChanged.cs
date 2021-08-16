namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserContactModelChanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserContacts", name: "ApplicationUser_Id", newName: "ApplicationUsers_Id");
            RenameIndex(table: "dbo.UserContacts", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUsers_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserContacts", name: "IX_ApplicationUsers_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.UserContacts", name: "ApplicationUsers_Id", newName: "ApplicationUser_Id");
        }
    }
}
