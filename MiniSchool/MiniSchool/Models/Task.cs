using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniSchool.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }

        public int ClassId { get; set; }
        public Classe Class { get; set; }
    }
}