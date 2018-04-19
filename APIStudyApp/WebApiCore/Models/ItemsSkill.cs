using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class ItemsSkill
    {
        public int Id { get; set; }
        public int? SkillsId { get; set; }
        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }
        public Skill Skills { get; set; }
    }
}
