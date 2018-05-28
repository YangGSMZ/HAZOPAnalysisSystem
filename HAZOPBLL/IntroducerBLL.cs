using HOZAPDAL;
using HOZAPModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAZOPBLL
{
    public class IntroducerBLL
    {
        IntroducerDAL dal = new IntroducerDAL();
        /// <summary>
        /// 根据参数ID获取所有引导词列表
        /// </summary>
        /// <param name="PramasId">参数ID</param>
        /// <returns>引导词列表</returns>
        public List<Introducer> Get_IntroducerList(int PramasId)
        {
            return dal.Get_IntroducerList(PramasId);
        }
    }
}
