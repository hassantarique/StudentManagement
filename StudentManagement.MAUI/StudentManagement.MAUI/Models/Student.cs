using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.MAUI.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int GenderID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public int Weight { get; set; }

        //For Displaying Gender Name Instead Of ID
        public string Gender => GenderID == 1 ? "Male" : "Female";
    }
}
