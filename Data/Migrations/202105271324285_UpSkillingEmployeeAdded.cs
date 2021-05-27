namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpSkillingEmployeeAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UpskillingEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        TalkToExpertButton = c.String(),
                        TalkToExpertButtonUrl = c.String(),
                        IllstrationUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UpskillingEmployees");
        }
    }
}
