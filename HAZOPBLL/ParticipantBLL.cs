using HOZAPDAL;
using HOZAPModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAZOPBLL
{
    public class ParticipantBLL
    {
        ParticipantDAL dal = new ParticipantDAL();
        public bool Add_Participant(Participant participantinfo)
        {
            return dal.Add_Participant(participantinfo);
        }
        public List<Participant> Get_ParticipantInfoList(string ProName)
        {
            return dal.Get_ParticipantInfoList(ProName);
        }
        public bool Del_ParticipantInfo(int ID)
        {
            return dal.Del_ParticipantInfo(ID);
        }
    }
}
