using System;
using System.Collections.Generic;

#nullable disable

namespace Teamfu_be.Models
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int? OwnerId { get; set; }
        public byte? PercentComplete { get; set; }
    }
}
