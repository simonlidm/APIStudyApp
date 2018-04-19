using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Detail
    {
        public Detail()
        {
            ItemTags = new HashSet<ItemTags>();
        }

        public int DetailId { get; set; }
        public string Title { get; set; }
        public DateTime? Date { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }

        public ICollection<ItemTags> ItemTags { get; set; }
    }
}
