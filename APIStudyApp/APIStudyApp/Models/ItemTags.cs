//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIStudyApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemTags
    {
        public int ItemTag { get; set; }
        public Nullable<int> DetailId { get; set; }
        public Nullable<int> TagId { get; set; }
    
        public virtual Detail Detail { get; set; }
        public virtual Tags Tags { get; set; }
    }
}
