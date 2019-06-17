namespace School.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "Class_Id", c => c.Int());
            CreateIndex("dbo.Subjects", "Class_Id");
            AddForeignKey("dbo.Subjects", "Class_Id", "dbo.Classes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "Class_Id", "dbo.Classes");
            DropIndex("dbo.Subjects", new[] { "Class_Id" });
            DropColumn("dbo.Subjects", "Class_Id");
        }
    }
}
