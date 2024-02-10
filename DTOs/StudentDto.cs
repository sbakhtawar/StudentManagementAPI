using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string? StudentFirstName { get; set; }
        public string? StudentLastName { get; set; }
        public int StudentAge { get; set; }
        public int AcademicPerformance { get; set; }
        public int GroupId { get; set; }
    }
}
