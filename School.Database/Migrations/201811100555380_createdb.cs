namespace School.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Details = c.String(),
                        CityId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        Grade_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Grades", t => t.Grade_Id)
                .Index(t => t.CityId)
                .Index(t => t.Grade_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateofBirth = c.DateTime(nullable: false),
                        ClassId = c.Int(nullable: false),
                        Name = c.String(),
                        Gender = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        Section = c.String(),
                        SchoolId = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                        Name = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        SchoolClass_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SchoolClasses", t => t.SchoolClass_Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.SchoolClass_Id);
            
            CreateTable(
                "dbo.SchoolClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddressId = c.Int(nullable: false),
                        Principal = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolId = c.Int(nullable: false),
                        SubjectName = c.String(),
                        Name = c.String(),
                        Gender = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        SchoolClass_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SchoolClasses", t => t.SchoolClass_Id)
                .Index(t => t.SchoolClass_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Homework",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Content = c.String(),
                        GradeId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        GradeId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Image = c.Binary(),
                        UserType = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParentAddresses",
                c => new
                    {
                        Parent_Id = c.Int(nullable: false),
                        Address_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Parent_Id, t.Address_Id })
                .ForeignKey("dbo.Parents", t => t.Parent_Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Parent_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.StudentAddresses",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Address_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Address_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.TeacherAddresses",
                c => new
                    {
                        Teacher_Id = c.Int(nullable: false),
                        Address_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_Id, t.Address_Id })
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Teacher_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.StudentParents",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Parent_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Parent_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Parents", t => t.Parent_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Parent_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Reports", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.Homework", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Homework", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.Addresses", "Grade_Id", "dbo.Grades");
            DropForeignKey("dbo.StudentParents", "Parent_Id", "dbo.Parents");
            DropForeignKey("dbo.StudentParents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "SchoolClass_Id", "dbo.SchoolClasses");
            DropForeignKey("dbo.TeacherAddresses", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.TeacherAddresses", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Classes", "SchoolClass_Id", "dbo.SchoolClasses");
            DropForeignKey("dbo.SchoolClasses", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.StudentAddresses", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.StudentAddresses", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.ParentAddresses", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.ParentAddresses", "Parent_Id", "dbo.Parents");
            DropForeignKey("dbo.Addresses", "CityId", "dbo.Cities");
            DropIndex("dbo.StudentParents", new[] { "Parent_Id" });
            DropIndex("dbo.StudentParents", new[] { "Student_Id" });
            DropIndex("dbo.TeacherAddresses", new[] { "Address_Id" });
            DropIndex("dbo.TeacherAddresses", new[] { "Teacher_Id" });
            DropIndex("dbo.StudentAddresses", new[] { "Address_Id" });
            DropIndex("dbo.StudentAddresses", new[] { "Student_Id" });
            DropIndex("dbo.ParentAddresses", new[] { "Address_Id" });
            DropIndex("dbo.ParentAddresses", new[] { "Parent_Id" });
            DropIndex("dbo.Reports", new[] { "GradeId" });
            DropIndex("dbo.Reports", new[] { "StudentId" });
            DropIndex("dbo.Homework", new[] { "GradeId" });
            DropIndex("dbo.Homework", new[] { "StudentId" });
            DropIndex("dbo.Teachers", new[] { "SchoolClass_Id" });
            DropIndex("dbo.SchoolClasses", new[] { "AddressId" });
            DropIndex("dbo.Classes", new[] { "SchoolClass_Id" });
            DropIndex("dbo.Classes", new[] { "TeacherId" });
            DropIndex("dbo.Students", new[] { "ClassId" });
            DropIndex("dbo.Addresses", new[] { "Grade_Id" });
            DropIndex("dbo.Addresses", new[] { "CityId" });
            DropTable("dbo.StudentParents");
            DropTable("dbo.TeacherAddresses");
            DropTable("dbo.StudentAddresses");
            DropTable("dbo.ParentAddresses");
            DropTable("dbo.Users");
            DropTable("dbo.Subjects");
            DropTable("dbo.Reports");
            DropTable("dbo.Homework");
            DropTable("dbo.Grades");
            DropTable("dbo.Countries");
            DropTable("dbo.Teachers");
            DropTable("dbo.SchoolClasses");
            DropTable("dbo.Classes");
            DropTable("dbo.Students");
            DropTable("dbo.Parents");
            DropTable("dbo.Cities");
            DropTable("dbo.Addresses");
        }
    }
}
