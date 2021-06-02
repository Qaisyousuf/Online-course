namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuSearchBoxModelAddedTotheDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuSearchBoxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MenuSearchBoxes");
        }
    }
}
