using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst_EF.Models
{
    public partial class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public string FathersName { get; set; }
        public string Address { get; set; }

        public virtual Mark Mark { get; set; }
    }
}
