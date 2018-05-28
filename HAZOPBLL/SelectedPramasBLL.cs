using HOZAPDAL;
using HOZAPModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPBLL
{
    public class SelectedPramasBLL
    {
        SelectedPramasDAL dal = new SelectedPramasDAL();
        /// <summary>
        /// 根据项目名获取已选择项目参数列表
        /// </summary>
        /// <param name="ProName">项目名</param>
        /// <returns>已选择项目参数列表</returns>
        public List<SelectedPramas> Get_SelectedPramasList(string ProName)
        {
            return dal.Get_SelectedPramasList(ProName);
        }
    }
}
