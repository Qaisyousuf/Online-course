namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataRemoved : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Message = c.String(),
                        ContactBy = c.String(),
                        ContactEmail = c.String(),
                        ApplicationUsers_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserContacts", "ApplicationUsers_Id");
            AddForeignKey("dbo.UserContacts", "ApplicationUsers_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
