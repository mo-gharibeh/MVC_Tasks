using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiniSchool.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Admin> Admins { get; set; }



        public ApplicationDbContext() : base("name=MiniSchoolEntityFrameworke")
        {
        }

    }
}