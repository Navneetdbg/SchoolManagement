namespace School.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Images : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parents", "ImageUrl", c => c.String());
            AddColumn("dbo.Students", "ImageUrl", c => c.String());
            AddColumn("dbo.Teachers", "ImageUrl", c => c.String());
            AddColumn("dbo.Grades", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Grades", "ImageUrl");
            DropColumn("dbo.Teachers", "ImageUrl");
            DropColumn("dbo.Students", "ImageUrl");
            DropColumn("dbo.Parents", "ImageUrl");
        }
    }
}
