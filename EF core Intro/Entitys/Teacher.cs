﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core_Intro.Entitys
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public Cafedra Cafedra { get; set; }
        public int CafedraId { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}";
        }
    }
}
