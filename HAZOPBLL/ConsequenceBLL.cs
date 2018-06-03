using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAZOPCommon;
using HOZAPDAL;

namespace HAZOPBLL
{
    public class ConsequenceBLL
    {
        ConsequenceDAL dal = new ConsequenceDAL();

        public List<DisplayConsequence> Get_ConsequenceList(int IntroducerId)
        {
            return dal.Get_Consequence(IntroducerId);
        }
    }
}
