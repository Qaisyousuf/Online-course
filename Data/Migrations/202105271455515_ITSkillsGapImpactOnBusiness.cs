namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ITSkillsGapImpactOnBusiness : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ITSkillsGapImpactsOnBusinesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        Button = c.String(),
                        ButtonUrl = c.String(),
                        AnimationUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ITSkillsGapImpactsOnBusinesses");
        }
    }
}
