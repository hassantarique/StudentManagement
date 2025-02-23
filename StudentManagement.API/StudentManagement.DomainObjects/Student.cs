using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DomainObjects
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int GenderID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public int Weight { get; set; }
    }
}
