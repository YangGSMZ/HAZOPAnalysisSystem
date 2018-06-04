using HOZAPDAL;
using HOZAPModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAZOPBLL
{
    public class PramasBLL
    {
        PramasDAL dal = new PramasDAL();
        /// <summary>
        /// 根据项目名获取未选择的参数列表
        /// </summary>
        /// <param name="ProName">项目名</param>
        /// <returns>参数列表</returns>
        public List<Pramas> Get_PramasList(string ProName)
        {
            return dal.Get_PramasList(ProName);
         
        }
        /// <summary>
        /// 添加项目参数
        /// </summary>
        /// <param name="PramasName">参数名</param>
        /// <returns>trueOrfalse</returns>
        public bool Add_Pramas(string PramasName)
        {
            return dal.Add_Pramas(PramasName);
        }

        public int Get_PramasId(string PramasName)
        {
            return dal.Get_PramasId(PramasName);
        }
        public bool Del_PramasById(List<int> PramasIDList)
        {
            return dal.Del_PramasById(PramasIDList);
        }
        public Pramas Get_PramasInfo(int PramasID)
        {
            return dal.Get_PramasInfo(PramasID);
        }
        public bool Update_Pramas(Pramas PramasInfo)
        {
            return dal.Update_Pramas(PramasInfo);
        }
      
    }
}
