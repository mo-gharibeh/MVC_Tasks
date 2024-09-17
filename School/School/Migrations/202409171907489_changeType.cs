namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assignments", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Assignments", "DueDate", c => c.DateTime());
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "EnrollmentDate", c => c.DateTime());
            AlterColumn("dbo.Teachers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "Name", c => c.String());
            AlterColumn("dbo.Students", "EnrollmentDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            AlterColumn("dbo.Assignments", "DueDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Assignments", "Title", c => c.String());
        }
    }
}
