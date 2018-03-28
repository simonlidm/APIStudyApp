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
    /// <summary>
    /// Represents an animal.
    /// </summary>
    public partial class AnimalText
    {
        /// <summary>
        /// The identifier of an animal
        /// </summary>
        public int AnimalId { get; set; }
        /// <summary>
        /// Name of the animal
        /// </summary>
        public string AnimalName { get; set; }
        /// <summary>
        /// Details about the animal
        /// </summary>
        public string AnimalDetails { get; set; }
        /// <summary>
        /// Url to animal picture
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Sample data Lorem text
        /// </summary>
        public string LoremText { get; set; }
    }
}
