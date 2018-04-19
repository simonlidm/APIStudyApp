using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class WorkExperience
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
