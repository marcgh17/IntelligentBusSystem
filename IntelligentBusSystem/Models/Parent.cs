//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntelligentBusSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parent
    {
        public Parent()
        {
            this.Students = new HashSet<Student>();
        }
    
        public string ParentID { get; set; }
        public string ParentPassword { get; set; }
        public string ParentFirstName { get; set; }
        public string ParentLastName { get; set; }
        public string ParentNumber { get; set; }
    
        public virtual ICollection<Student> Students { get; set; }
    }
}
