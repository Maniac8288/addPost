namespace PostModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test311 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "upload", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "upload");
        }
    }
}
