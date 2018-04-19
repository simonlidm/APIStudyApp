using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class AnimalDetail
    {
        public int AnimalDetailId { get; set; }
        public int? AnimalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public Animal Animal { get; set; }
    }
}
