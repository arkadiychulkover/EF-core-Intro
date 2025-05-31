using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core_Intro.Entitys
{
    public class Subject
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Time { get; set; }

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public int TeacherId { get; set; }
        public Cafedra Cafedra { get; set; }
        public int CafedraId { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Time: {Time}";
        }

    }
}
