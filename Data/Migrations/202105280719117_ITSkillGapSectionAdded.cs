namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ITSkillGapSectionAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ITSkillGapSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Subcontent = c.String(),
                        AnimationUrl = c.String(),
                        Button = c.String(),
                        ButtonUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ITSkillGapSections");
        }
    }
}
