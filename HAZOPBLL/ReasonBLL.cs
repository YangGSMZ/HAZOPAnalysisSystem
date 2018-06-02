using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HAZOPCommon;
using HOZAPDAL;
using HOZAPModel;

namespace HAZOPBLL
{
    public class ReasonBLL
    {
        ReasonDAL dal = new ReasonDAL();

        public List<DisplayReasons> Get_ReasonsList(int IntroducerId)
        {
            return dal.Get_Reasons(IntroducerId);
        }
    }
}