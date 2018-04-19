using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Tags
    {
        public Tags()
        {
            ItemTags = new HashSet<ItemTags>();
        }

        public int TagId { get; set; }
        public string TagName { get; set; }

        public ICollection<ItemTags> ItemTags { get; set; }
    }
}
