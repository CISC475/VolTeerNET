﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DataAccessLayer.VT.Vol;
using VolTeer.Contracts.VT.Vol;


namespace VolTeer.BusinessLogicLayer.VT.Vol
{
    public class sp_GroupVol_BLL: sp_GroupVol_CON 
    {
        sp_GroupVol_DAL DAL = new sp_GroupVol_DAL();

        public List<sp_Vol_GroupVol_DM> ListGroupVols(sp_Vol_GroupVol_DM GroupVol)
        {
            return DAL.ListGroupVols(GroupVol); 
        }

        //TODO: Create an insert method passing in domain model
        public sp_Vol_GroupVol_DM InsertGroupContext(ref sp_Vol_GroupVol_DM _cGroup)
        {
            return DAL.InsertGroupContext(ref _cGroup);
        }

        //TODO: Create a delete all method passing in VolID
        public void DeleteGroupContext(sp_Vol_GroupVol_DM _cVolID)
        {
            DAL.DeleteGroupContext(_cVolID);
        }

        public void LeaveGroup(sp_Vol_GroupVol_DM GroupVol)
        {
            DAL.LeaveGroup(GroupVol);
        }


        //TODO: Create a MakePrimary method passing in VolID
        public void MakePrimaryVolID(sp_Vol_GroupVol_DM _cGroup)
        {
            DAL.MakeAdminVolID(_cGroup);
        }

        //TODO: Create a Make Admin method passing in VolID
        public void MakeAdminVolID(sp_Vol_GroupVol_DM _cGroup)
        {
            DAL.MakeAdminVolID(_cGroup);
        }


        public List<sp_Volunteer_DM> ListGroupFindVols(sp_Group_DM Group)
        {
            return DAL.ListGroupFindVols(Group);
        }
    }
}