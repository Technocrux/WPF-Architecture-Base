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
    
    public partial class Culture
    {
        public Culture()
        {
            this.ProductModelProductDescriptionCultures = new HashSet<ProductModelProductDescriptionCulture>();
        }
    
        public string CultureID { get; set; }
        public string Name { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }
    }
}
