namespace School.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "SubjectsId", c => c.Int(nullable: false));
            AddColumn("dbo.Teachers", "subject_Id", c => c.Int());
            CreateIndex("dbo.Teachers", "subject_Id");
            AddForeignKey("dbo.Teachers", "subject_Id", "dbo.Subjects", "Id");
            DropColumn("dbo.Teachers", "SubjectName");
            DropColumn("dbo.Teachers", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "SubjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Teachers", "SubjectName", c => c.String());
            DropForeignKey("dbo.Teachers", "subject_Id", "dbo.Subjects");
            DropIndex("dbo.Teachers", new[] { "subject_Id" });
            DropColumn("dbo.Teachers", "subject_Id");
            DropColumn("dbo.Teachers", "SubjectsId");
        }
    }
}
