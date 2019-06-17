namespace School.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedAll : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "Class_Id", "dbo.Classes");
            DropIndex("dbo.Subjects", new[] { "Class_Id" });
            CreateTable(
                "dbo.SubjectClasses",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        Class_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Class_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .ForeignKey("dbo.Classes", t => t.Class_Id)
                .Index(t => t.Subject_Id)
                .Index(t => t.Class_Id);
            
            AddColumn("dbo.Parents", "ContactNo", c => c.String());
            AddColumn("dbo.Students", "ContactNo", c => c.String());
            AddColumn("dbo.Classes", "Teacher_Id", c => c.Int());
            AddColumn("dbo.Teachers", "SubjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Teachers", "ContactNo", c => c.String());
            AddColumn("dbo.Teachers", "Class_Id", c => c.Int());
            AddColumn("dbo.Grades", "ContactNo", c => c.String());
            CreateIndex("dbo.Classes", "Teacher_Id");
            CreateIndex("dbo.Teachers", "Class_Id");
            AddForeignKey("dbo.Classes", "Teacher_Id", "dbo.Teachers", "Id");
            AddForeignKey("dbo.Teachers", "Class_Id", "dbo.Classes", "Id");
            DropColumn("dbo.Subjects", "Class_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "Class_Id", c => c.Int());
            DropForeignKey("dbo.Teachers", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.Classes", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.SubjectClasses", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.SubjectClasses", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.SubjectClasses", new[] { "Class_Id" });
            DropIndex("dbo.SubjectClasses", new[] { "Subject_Id" });
            DropIndex("dbo.Teachers", new[] { "Class_Id" });
            DropIndex("dbo.Classes", new[] { "Teacher_Id" });
            DropColumn("dbo.Grades", "ContactNo");
            DropColumn("dbo.Teachers", "Class_Id");
            DropColumn("dbo.Teachers", "ContactNo");
            DropColumn("dbo.Teachers", "SubjectId");
            DropColumn("dbo.Classes", "Teacher_Id");
            DropColumn("dbo.Students", "ContactNo");
            DropColumn("dbo.Parents", "ContactNo");
            DropTable("dbo.SubjectClasses");
            CreateIndex("dbo.Subjects", "Class_Id");
            AddForeignKey("dbo.Subjects", "Class_Id", "dbo.Classes", "Id");
        }
    }
}
