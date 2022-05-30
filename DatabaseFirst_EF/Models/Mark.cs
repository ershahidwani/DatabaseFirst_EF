using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst_EF.Models
{
    public partial class Mark
    {
        public int Rollno { get; set; }
        public int Totalmarks { get; set; }

        public virtual Student RollnoNavigation { get; set; }
    }
}
