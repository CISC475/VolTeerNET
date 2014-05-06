﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Telerik.Web.UI;
using VolTeer.App_Code;
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Other;
using VolTeer.Cache.VT.Vol;
using VolTeer.GoogleAPI;
using System.Web.ApplicationServices;
using System.Web.Security;

using VolTeer.DomainModels.Service;
using VolTeer.GoogleAPI;
using System.IO;



namespace VolTeer.Common.WebControls
{
    public partial class ucGroups : System.Web.UI.UserControl
    {
        sp_GroupVol_BLL GroupVolBLL = new sp_GroupVol_BLL();
        MembershipUser currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = Membership.GetUser();

        }

        protected void rGridGroupVol_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                sp_Vol_GroupVol_DM GroupVol = new sp_Vol_GroupVol_DM();

                GroupVol.VolID = (Guid)currentUser.ProviderUserKey;
                rGridGroupVol.DataSource = GroupVolBLL.ListGroupVols(GroupVol);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.

            }
        }

        protected void rGridGroupVol_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {

        }

        protected void rGridGroupVol_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            sp_Vol_GroupVol_DM GroupVol = new sp_Vol_GroupVol_DM();

            try
            {
                GroupVol.VolID = (Guid)currentUser.ProviderUserKey;
                GroupVol.GroupID = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["GroupID"];

                GroupVolBLL.LeaveGroup(GroupVol);
                
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.

            }
        }
    }
}