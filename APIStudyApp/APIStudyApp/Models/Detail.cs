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
    
    public partial class Detail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Detail()
        {
            this.ItemTags = new HashSet<ItemTags>();
        }
    
        public int DetailId { get; set; }
        public string title { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string text { get; set; }
        public string author { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemTags> ItemTags { get; set; }
    }
}
