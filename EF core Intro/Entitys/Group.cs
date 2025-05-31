using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core_Intro.Entitys
{
    public class Group
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Students Count: {Students.Count}";
        }
    }
}
