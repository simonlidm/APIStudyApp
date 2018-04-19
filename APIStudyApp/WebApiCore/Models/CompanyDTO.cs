using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCore.Models
{
    public class CompanyDTO
    {
        public object[] company { get; set; }
        public object[] employees { get; set; }
    }
}