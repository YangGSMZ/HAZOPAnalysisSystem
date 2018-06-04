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
        /// <summary>
        ///为参数添加引导词
        /// </summary>
        /// <param name="IntroducerList">引导词信息列表</param>
        /// <returns>trueOrfalse</returns>
        public bool Add_Introducerinfo(List<Introducer> IntroducerList)
        {
            return dal.Add_Introducerinfo(IntroducerList);
        }
        public bool Del_IntroducerByPramasID(List<int> PramasIDList)
        {
            return dal.Del_IntroducerByPramasID(PramasIDList);
        }
        public bool Check_IntroducerByPramasID(int PramasId)
        {
            return dal.Check_IntroducerByPramasID(PramasId);
        }
    }
}
