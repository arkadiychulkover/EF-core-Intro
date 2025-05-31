using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core_Intro.Entitys
{
    public class Pasport
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
