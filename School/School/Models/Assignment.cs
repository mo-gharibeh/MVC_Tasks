using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; } // Primary Key
        [Required]
        public string Title { get; set; }
        public DateTime? DueDate { get; set; }
    }
}