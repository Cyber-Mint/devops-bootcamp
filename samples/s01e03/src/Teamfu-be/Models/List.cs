using System;
using System.Collections.Generic;

#nullable disable

namespace Teamfu_be.Models
{
    public partial class List
    {
        public int ListId { get; set; }
        public string ListName { get; set; }
        public int? ListOwnerId { get; set; }
    }
}
