using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public class People
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Country { get; set; }
        public string? School { get; set; }

        public static int PersonCount;

        public People(string name, int age, string gender, string country, string school)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Country = country;
            School = school;
        }
    }
}
