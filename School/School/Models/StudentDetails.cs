using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class StudentDetails
    {
        [Key]
        [ForeignKey("Student")]  // StudentId will also be the Primary Key in StudentDetails
        public int StudentId { get; set; }  // Primary Key and Foreign Key

        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }

        // Navigation property for the related Student
        public virtual Student Student { get; set; }
    }
}