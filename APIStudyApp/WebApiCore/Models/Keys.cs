using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Keys
    {
        public int ApikeyId { get; set; }
        public string ApikeyHash { get; set; }
        public bool? Status { get; set; }
    }
}
