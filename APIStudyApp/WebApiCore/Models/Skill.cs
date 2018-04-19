using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Skill
    {
        public Skill()
        {
            ItemsSkill = new HashSet<ItemsSkill>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<ItemsSkill> ItemsSkill { get; set; }
    }
}
