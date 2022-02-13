using System;
using System.Collections.Generic;

namespace SchoolProjektArbete.Models
{
    public partial class Class
    {
        public Class()
        {
            Grades = new HashSet<Grade>();
            StudClasses = new HashSet<StudClass>();
        }

        public int ClassId { get; set; }
        public string? ClassName { get; set; }
        public string? ClassActive { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<StudClass> StudClasses { get; set; }
    }
}
