namespace PostModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tmp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        NamePost = c.String(),
                        selectedCategory = c.String(),
                        contentPost = c.String(),
                        Tags = c.String(),
                        dateAddPost = c.String(),
                    })
                .PrimaryKey(t => t.PostID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "Category_Id" });
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
