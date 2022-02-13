using System;
using System.Collections.Generic;

namespace SchoolProjektArbete.Models
{
    public partial class Grade
    {
        public int GradesId { get; set; }
        public int? GempId { get; set; }
        public int? GstudId { get; set; }
        public int? GclassId { get; set; }
        public int? Grade1 { get; set; }
        public DateTime? Date { get; set; }

        public virtual Class? Gclass { get; set; }
        public virtual Employee? Gemp { get; set; }
        public virtual Student? Gstud { get; set; }
    }
}
