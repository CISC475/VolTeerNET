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
    
    public partial class tblVolPhone
    {
        public int PhoneID { get; set; }
        public System.Guid VolID { get; set; }
        public string PhoneNbr { get; set; }
        public Nullable<bool> ActiveFlg { get; set; }
        public bool PrimaryFlg { get; set; }
    
        public virtual tblVolunteer tblVolunteer { get; set; }
    }
}
