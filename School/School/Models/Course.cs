using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Course
    {
        public int CourseId { get; set; } 
        public string Title { get; set; }

        [ForeignKey("Teacher")]
        // Foreign key pointing to the Teacher
        public int TeacherId { get; set; }

        // Navigation property to Teacher
        public virtual Teacher Teacher { get; set; }
    }
}