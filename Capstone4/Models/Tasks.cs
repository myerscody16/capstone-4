using System;
using System.Collections.Generic;

namespace Capstone4.Models
{
    public partial class Tasks
    {
        public int TaskId { get; set; }
        public string UserId { get; set; }
        public string TaskDesc { get; set; }
        public DateTime? DueDate { get; set; }
        public string CompleteStatus { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
