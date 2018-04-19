using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
    }
}
