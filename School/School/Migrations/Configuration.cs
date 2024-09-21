namespace School.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BookService.Models;
    using School.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<School.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(School.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Students.AddOrUpdate(x => x.StudentId,
            new Student() { StudentId = 1, FirstName = "Jane Austen" },
            new Student() { StudentId = 2, FirstName = "Charles Dickens" },
            new Student() { StudentId = 3, FirstName = "Miguel de Cervantes" }
            );

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
