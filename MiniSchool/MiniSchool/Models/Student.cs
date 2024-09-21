﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniSchool.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int ClassId { get; set; }
        public Classe Class { get; set; }
    }
}