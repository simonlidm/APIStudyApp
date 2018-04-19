using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCore.Models
{
    public class Blog_post_detail
    {
        public int? detailId { get; set; }
        public string title { get; set; }

        public DateTime? date { get; set; }
        public string text { get; set; }
        public List<Tags> tags { get; set; }

    }

    public class Blog_post_detail2
    {
        public int? detailId { get; set; }
        public string title { get; set; }
        public string author { get; set; }

        public DateTime? date { get; set; }
        public string text { get; set; }
        public List<Tags> tags { get; set; }
    }
}