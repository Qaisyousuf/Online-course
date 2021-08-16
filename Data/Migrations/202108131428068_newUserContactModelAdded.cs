namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newUserContactModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Message = c.String(),
                        ContactBy = c.String(),
                        ContactEmail = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserContacts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserContacts", new[] { "UserId" });
            DropTable("dbo.UserContacts");
        }
    }
}
