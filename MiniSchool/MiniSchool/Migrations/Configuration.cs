﻿namespace MiniSchool.Migrations
{
    using MiniSchool.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MiniSchool.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MiniSchool.Models.ApplicationDbContext context)
        {
            context.Subjects.AddOrUpdate(s => s.Name,
            new Subject { Name = "Mathematics" },
             new Subject { Name = "Science" },
             new Subject { Name = "English" },
             new Subject { Name = "History" });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
