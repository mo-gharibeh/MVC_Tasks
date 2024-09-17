namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmailtoTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Email");
        }
    }
}
