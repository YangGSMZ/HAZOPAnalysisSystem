using HOZAPModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPDAL
{
    public class SelectedPramasDAL
    {
        /// <summary>
        /// 根据项目名获取已选择项目参数列表
        /// </summary>
        /// <param name="ProName">项目名</param>
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
                    while (sdr.Read())
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




    }
}
