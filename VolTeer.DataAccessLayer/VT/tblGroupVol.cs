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
    
    public partial class tblGroupVol
    {
        public int GroupID { get; set; }
        public System.Guid VolID { get; set; }
        public Nullable<bool> PrimaryVolID { get; set; }
        public Nullable<bool> Admin { get; set; }
    
        public virtual tblVolunteer tblVolunteer { get; set; }
        public virtual tblGroup tblGroup { get; set; }
    }
}
