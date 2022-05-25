using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst_EF.Models
{
    public partial class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherAddress { get; set; }
        public string Qualification { get; set; }
        public string Parentage { get; set; }
    }
}
