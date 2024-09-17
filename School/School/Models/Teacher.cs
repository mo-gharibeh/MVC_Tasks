using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; } // Primary Key
        [Required]
        public string Name { get; set; }
        public string Department { get; set; }
        // New column
        public string Email { get; set; }
    }
}