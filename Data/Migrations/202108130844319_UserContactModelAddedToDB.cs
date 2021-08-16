namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserContactModelAddedToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        ContactBy = c.String(),
                        ContactEmail = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserContacts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserContacts", new[] { "ApplicationUser_Id" });
            DropTable("dbo.UserContacts");
        }
    }
}
