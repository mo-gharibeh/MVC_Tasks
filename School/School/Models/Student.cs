using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Student
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] // Disable auto-increment
        public int StudentId { get; set; } // Primary Key
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        //[ForeignKey("Course")]

        // Navigation property for StudentDetails (1-1 relationship)
        public virtual StudentDetails StudentDetails { get; set; }
        public int CourseId { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

    }
}