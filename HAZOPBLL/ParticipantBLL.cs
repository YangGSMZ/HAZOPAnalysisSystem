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
        /// <summary>
        /// 添加项目成员信息
        /// </summary>
        /// <param name="participantinfo">项目成员信息</param>
        /// <returns>trueOrfalse</returns>
        public bool Add_Participant(Participant participantinfo)
        {
            return dal.Add_Participant(participantinfo);
        }
        /// <summary>
        /// 根据项目名获取所有参与人员信息
        /// </summary>
        /// <param name="ProName">项目名</param>
        /// <returns>成员信息列表</returns>
        public List<Participant> Get_ParticipantInfoList(string ProName)
        {
            return dal.Get_ParticipantInfoList(ProName);
        }
        /// <summary>
        /// 根据成员的ID删除成员信息
        /// </summary>
        /// <param name="ID">成员的ID</param>
        /// <returns>trueOrfalse</returns>
        public bool Del_ParticipantInfo(int ID)
        {
            return dal.Del_ParticipantInfo(ID);
        }

        public bool Update_ParticipantInfo(List<Participant> ParticipantInfoList)
        {
            return dal.Update_ParticipantInfo(ParticipantInfoList);
        }

        public bool Delete_ProName(string ProName)
        {
            return dal.Delete_ProName(ProName);
        }
    }
}
