//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedicalDb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class gender
    {
        public gender()
        {
            this.entrymodels = new HashSet<entrymodel>();
        }
    
        public int gender_id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<entrymodel> entrymodels { get; set; }
    }
}
