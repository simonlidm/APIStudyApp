using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Office
    {
        public int Id { get; set; }
        public int? Number { get; set; }
        public int? Floor { get; set; }
        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
