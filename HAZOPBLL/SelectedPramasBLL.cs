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

        /// <summary>
        /// 批量添加选择的参数信息
        /// </summary>
        /// <param name="PramasInfoList">选择的参数信息列表</param>
        /// <returns>trueOrfalse</returns>
        public bool Add_SelectedPramasinfo(List<SelectedPramas> PramasInfoList)
        {
            return dal.Add_SelectedPramasinfo(PramasInfoList);
        }
        /// <summary>
        /// 根据参数ID删除已选着的参数
        /// </summary>
        /// <param name="PramasID">参数ID</param>
        /// <returns>trueOrfalse</returns>
        public bool Del_SelectedPramasinfo(List<int> PramasID)
        {
            return dal.Del_SelectedPramasinfo(PramasID);
        }
    }
}
