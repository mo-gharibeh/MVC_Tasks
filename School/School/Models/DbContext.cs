using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace School.Models
{
    
        public class ApplicationDbContext : DbContext
        {
            public DbSet<Student> Students { get; set; }
            public DbSet<Teacher> Teachers { get; set; }
            public DbSet<Assignment> Assignments { get; set; }
            public DbSet<StudentDetails> StudentDetails { get; set; }
            public DbSet<Course> Courses { get; set; }



        public ApplicationDbContext() : base("name=SchoolEntityFrameworke")
            {
            }
           
        }

    
}