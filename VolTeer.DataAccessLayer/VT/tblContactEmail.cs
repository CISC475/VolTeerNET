//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VolTeer.DataAccessLayer.VT
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblContactEmail
    {
        public System.Guid ContactID { get; set; }
        public int EmailID { get; set; }
        public Nullable<bool> PrimaryEmail { get; set; }
    
        public virtual tblContact tblContact { get; set; }
        public virtual tblEmail tblEmail { get; set; }
    }
}
