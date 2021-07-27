namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuizBannerAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuizBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                        JoinButton = c.String(),
                        JoinButtonUrl = c.String(),
                        DiscoverButton = c.String(),
                        DiscoverButtonTUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QuizBanners");
        }
    }
}
