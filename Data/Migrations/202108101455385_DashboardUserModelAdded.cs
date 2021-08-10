namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DashboardUserModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DashboardUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        MainTitle = c.String(),
                        Content = c.String(),
                        AnimationLink = c.String(),
                        AdminUsers_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AdminUsers_Id)
                .Index(t => t.AdminUsers_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DashboardUsers", "AdminUsers_Id", "dbo.AspNetUsers");
            DropIndex("dbo.DashboardUsers", new[] { "AdminUsers_Id" });
            DropTable("dbo.DashboardUsers");
        }
    }
}
