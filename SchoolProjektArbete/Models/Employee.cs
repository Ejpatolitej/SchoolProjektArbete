using System;
using System.Collections.Generic;

namespace SchoolProjektArbete.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Grades = new HashSet<Grade>();
        }

        public int EmployeeId { get; set; }
        public string? EmpFirstName { get; set; }
        public string? EmpLastName { get; set; }
        public string? EmpPosition { get; set; }
        public int? EmpPhone { get; set; }
        public DateTime? StartingYear { get; set; }
        public int? Salary { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
