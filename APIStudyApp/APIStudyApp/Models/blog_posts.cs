using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIStudyApp.Models
{
    public class Blog_posts
    {
        public object[] blog_posts{ get; set; }
        public string About { get; set; }
        public string Author { get; set; }

    }
    public class Blog_posts2
    {
        public object[] blog_posts { get; set; }
        public string About { get; set; }
        public string Contact { get; set; }
    }
}