namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        ClassName = c.String(),
                        ClassStartData = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TotalCourseDays = c.String(),
                        ClassDescription = c.String(),
                        contactedBy = c.String(),
                        UserName = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassDatas", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ClassDatas", new[] { "UserId" });
            DropTable("dbo.ClassDatas");
        }
    }
}
