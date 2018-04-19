using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Animal
    {
        public Animal()
        {
            AnimalDetail = new HashSet<AnimalDetail>();
        }

        public int AnimalId { get; set; }

        public ICollection<AnimalDetail> AnimalDetail { get; set; }
    }
}
