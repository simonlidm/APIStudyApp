using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class ItemTags
    {
        public int ItemTag { get; set; }
        public int? DetailId { get; set; }
        public int? TagId { get; set; }

        public Detail Detail { get; set; }
        public Tags Tag { get; set; }
    }
}
