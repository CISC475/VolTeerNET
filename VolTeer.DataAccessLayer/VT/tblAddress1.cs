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
    
    public partial class tblAddress1
    {
        public tblAddress1()
        {
            this.tblGroups = new HashSet<tblGroup>();
            this.tblVolunteers = new HashSet<tblVolunteer>();
        }
    
        public int AddrID { get; set; }
        public Nullable<bool> ActiveFlg { get; set; }
        public string AddrLine1 { get; set; }
        public string AddrLine2 { get; set; }
        public string AddrLine3 { get; set; }
        public string City { get; set; }
        public string St { get; set; }
        public Nullable<int> Zip { get; set; }
        public Nullable<int> Zip4 { get; set; }
    
        public virtual ICollection<tblGroup> tblGroups { get; set; }
        public virtual ICollection<tblVolunteer> tblVolunteers { get; set; }
    }
}
