using System;
using System.Collections.Generic;

namespace SchoolProjektArbete.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
            StudClasses = new HashSet<StudClass>();
        }

        public int StudentId { get; set; }
        public string? StudFirstName { get; set; }
        public string? StudLastName { get; set; }
        public string? Ssn { get; set; }
        public int? StudPhone { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<StudClass> StudClasses { get; set; }
    }
}
