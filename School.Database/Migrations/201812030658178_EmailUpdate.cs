namespace School.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parents", "EmailId", c => c.String());
            AddColumn("dbo.Students", "EmailId", c => c.String());
            AddColumn("dbo.Teachers", "EmailId", c => c.String());
            AddColumn("dbo.Grades", "EmailId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Grades", "EmailId");
            DropColumn("dbo.Teachers", "EmailId");
            DropColumn("dbo.Students", "EmailId");
            DropColumn("dbo.Parents", "EmailId");
        }
    }
}
