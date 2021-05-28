namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusinessPageAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        Content = c.String(),
                        BusinessBannerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessBanners", t => t.BusinessBannerId, cascadeDelete: true)
                .Index(t => t.BusinessBannerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BusinessPages", "BusinessBannerId", "dbo.BusinessBanners");
            DropIndex("dbo.BusinessPages", new[] { "BusinessBannerId" });
            DropTable("dbo.BusinessPages");
        }
    }
}
