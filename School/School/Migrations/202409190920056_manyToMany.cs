﻿namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manyToMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Course_CourseId })
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Course_CourseId);
            
            AddColumn("dbo.Courses", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "CourseId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.StudentCourses", new[] { "Course_CourseId" });
            DropIndex("dbo.StudentCourses", new[] { "Student_StudentId" });
            DropColumn("dbo.Students", "CourseId");
            DropColumn("dbo.Courses", "StudentId");
            DropTable("dbo.StudentCourses");
        }
    }
}
