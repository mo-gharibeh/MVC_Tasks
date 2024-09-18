namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToOne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentDetails",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentDetails", "StudentId", "dbo.Students");
            DropIndex("dbo.StudentDetails", new[] { "StudentId" });
            DropTable("dbo.StudentDetails");
        }
    }
}
