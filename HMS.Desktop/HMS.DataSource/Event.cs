//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMS.DataSource
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public int EventID { get; set; }
        public Nullable<int> DisciplineID { get; set; }
        public string Event1 { get; set; }
    
        public virtual Discipline Discipline { get; set; }
    }
}
