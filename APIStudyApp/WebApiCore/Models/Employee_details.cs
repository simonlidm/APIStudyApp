using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCore.Models
{
    public class Employee_details
    {
        public string name { get; set; }
        public int? employee_id { get; set; }
        public string department { get; set; }
        public string email { get; set; }
        public int? direct_number { get; set; }
        public List<Skill> skills { get; set; }
        public List<WorkExperience> work_experience { get; set; }
        public List<Office> office { get; set; }
    }
}