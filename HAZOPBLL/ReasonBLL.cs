using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HAZOPCommon;
using HOZAPDAL;

namespace HAZOPBLL
{
    public class ReasonBLL
    {
        ReasonDAL dal = new ReasonDAL();

        public List<DisplayReasons> Get_ReasonsList(int IntroducerId)
        {
            return dal.Get_Reasons(IntroducerId);
        }

        public List<DisplayReasons> Get_personalReasons(int IntroducerId)
        {
            return dal.Get_personalReasons(IntroducerId);
        }
        public bool Add_Reason(DisplayReasons reason)
        {
            return dal.Add_Reason(reason);
        }

        public bool DeletePersonalReason(int ReasonID)
        {
            return dal.DeletePersonalReason(ReasonID);
        }
    }
}