using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class AnimalText
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string AnimalDetails { get; set; }
        public string Url { get; set; }
        public string LoremText { get; set; }
    }
}
