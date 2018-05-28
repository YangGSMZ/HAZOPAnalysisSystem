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
    }
}
