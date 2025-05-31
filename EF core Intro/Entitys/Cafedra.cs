using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core_Intro.Entitys
{
    public class Cafedra
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Financing { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Financing: {Financing}";
        }
    }
}
