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
    
    public partial class tblContact
    {
        public tblContact()
        {
            this.tblContactEmails = new HashSet<tblContactEmail>();
            this.tblProjectEventContacts = new HashSet<tblProjectEventContact>();
            this.tblVendContacts = new HashSet<tblVendContact>();
            this.tblVendorProjContacts = new HashSet<tblVendorProjContact>();
        }
    
        public System.Guid ContactID { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactMiddleName { get; set; }
        public string ContactLastName { get; set; }
        public bool ActiveFlg { get; set; }
    
        public virtual ICollection<tblContactEmail> tblContactEmails { get; set; }
        public virtual ICollection<tblProjectEventContact> tblProjectEventContacts { get; set; }
        public virtual ICollection<tblVendContact> tblVendContacts { get; set; }
        public virtual ICollection<tblVendorProjContact> tblVendorProjContacts { get; set; }
    }
}
