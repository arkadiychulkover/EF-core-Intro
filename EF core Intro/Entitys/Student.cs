using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core_Intro.Entitys
{
    public enum StudyFormat
    {
        Online,
        FullTime,
        PartTime,
        Gibrid
    }
    public class Student
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public int Age { get; set; }
        public float? Scolarship { get; set; }
        public int GroupId { get; set; }
        public string Email { get; set; }
        public StudyFormat StudyFormat { get; set; }
        public Group Group { get; set; }

        public Pasport Pasport { get; set; } = null!;

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}, SCH: {Scolarship}, Email: {Email}\nGroup: {Group.Name}";
        }
    }
}
