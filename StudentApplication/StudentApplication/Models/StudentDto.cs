using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApplication.Models
{
    public class StudentDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public String RollNumber { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public String City { get; set; }
    }
}
