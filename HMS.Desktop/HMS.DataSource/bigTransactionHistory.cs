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
    
    public partial class bigTransactionHistory
    {
        public long TransactionID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> ActualCost { get; set; }
    }
}