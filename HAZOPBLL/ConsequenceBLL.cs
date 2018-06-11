using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAZOPCommon;
using HOZAPDAL;
using HOZAPModel;

namespace HAZOPBLL
{
    public class ConsequenceBLL
    {
        ConsequenceDAL dal = new ConsequenceDAL();

        public List<DisplayConsequence> Get_ConsequenceList(int IntroducerId)
        {
            return dal.Get_Consequence(IntroducerId);
        }
        public List<DisplayConsequence> Get_PersonalConsequence(int IntroducerId)
        {
            return dal.Get_PersonalConsequence(IntroducerId);
        }
        public bool Add_Consequence(Conqeq Consequence)
        {
            return dal.Add_Consequence(Consequence);
        }

        public bool DeletePersonalConseqence(int ReasonID)
        {
            return dal.DeletePersonalConsequence(ReasonID);
        }
    }
}
