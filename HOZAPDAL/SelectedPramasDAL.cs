using HOZAPModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPDAL
{
    /// <summary>
    /// 操作已选择的参数的数据表，包括添加、删除，读取
    /// </summary>
    public class SelectedPramasDAL
    {
        /// <summary>
        /// 根据项目名获取已选择项目参数列表
        /// </summary>
        /// <param name="ProName">项目名</param>
        /// <param name="SelectedPramas">HOZAPModel命名空间中的SelectedPramas类，已选择参数类</param>
        /// <returns>已选择项目参数列表</returns>
        public List<SelectedPramas> Get_SelectedPramasList(string ProName)
        {
            string sql = "select * from tb_SelectedPramas where ProName=@ProName";
            List<SelectedPramas> SelectedPramasList = null;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@ProName", ProName)))
            {
                if (sdr.HasRows)
                {
                    SelectedPramasList = new List<SelectedPramas>();
                    while (sdr.Read()) //追条读取已选参数数据表中的数据
                    {
                        SelectedPramas selectedpramas = new SelectedPramas();
                        selectedpramas.PramasId = sdr.GetInt32(0);
                        selectedpramas.PramasText = sdr.GetString(1);
                        selectedpramas.ProName = sdr.GetString(2);
                        SelectedPramasList.Add(selectedpramas);
                    }
                }
            }
            return SelectedPramasList;
        }
        /// <summary>
        /// 批量添加选择的参数信息
        /// </summary>
        /// <param name="PramasInfoList">选择的参数信息列表</param>
        /// <param name="SelectedPramas">HOZAPModel命名空间中的SelectedPramas类，已选择参数类</param>
        /// <returns>trueOrfalse</returns>
        public bool Add_SelectedPramasinfo(List<SelectedPramas> PramasInfoList)
        {
            bool IsSuccess = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("BEGIN ");
            for (int i = 0; i < PramasInfoList.Count; i++)
            {
                sb.Append("insert into tb_SelectedPramas values(" + PramasInfoList[i].PramasId + ",'" + PramasInfoList[i].PramasText + "','" + PramasInfoList[i].ProName + "')");        
             }
            sb.Append(" END;");
            if (SqlHelper.ExecuteNonQuery(sb.ToString())>0)
            {
                IsSuccess = true;
            }
            return IsSuccess;
        }
        /// <summary>
        /// 根据参数ID删除已选择的参数
        /// </summary>
        /// <param name="PramasID">参数ID，List类型为要删除的参数的集合</param>
        /// <returns>trueOrfalse</returns>
        public bool Del_SelectedPramasinfo(List<int> PramasID)
        {
            bool IsSuccess = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("BEGIN ");
            for (int i = 0; i < PramasID.Count; i++)
            {
                sb.Append("delete from tb_SelectedPramas where PramasID="+PramasID[i]);
            }
            sb.Append(" END;");
            if (SqlHelper.ExecuteNonQuery(sb.ToString()) > 0)
            {
                IsSuccess = true;
            }
            return IsSuccess;
        }

    }
}
