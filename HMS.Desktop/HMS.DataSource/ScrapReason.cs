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
    
    public partial class ScrapReason
    {
        public ScrapReason()
        {
            this.WorkOrders = new HashSet<WorkOrder>();
        }
    
        public short ScrapReasonID { get; set; }
        public string Name { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
