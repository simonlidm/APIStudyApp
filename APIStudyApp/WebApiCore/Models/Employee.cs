using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Employee
    {
        public Employee()
        {
            ItemsSkill = new HashSet<ItemsSkill>();
            Office = new HashSet<Office>();
            WorkExperience = new HashSet<WorkExperience>();
        }

        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public int? DirectNumber { get; set; }

        public ICollection<ItemsSkill> ItemsSkill { get; set; }
        public ICollection<Office> Office { get; set; }
        public ICollection<WorkExperience> WorkExperience { get; set; }
    }
}
