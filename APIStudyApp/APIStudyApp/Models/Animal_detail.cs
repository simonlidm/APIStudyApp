using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIStudyApp.Models
{
    public class Animal_detail
    {
        public List<AnimalDetail> animal { get; set; }
        public int AnimalId { get; set; }
        public int? AnimalMaxId { get; set; }
    }
}