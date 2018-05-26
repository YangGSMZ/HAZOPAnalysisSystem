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
        /// 用于查询项目选择的参数
        /// </summary>
        /// <param name="ProName">项目名称</param>
        /// <returns></returns>
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
