using HOZAPModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPDAL
{
    public class PramasDAL
    {
        /// <summary>
        /// 查询不在已经选择的参数表中的参数数据
        /// </summary>
        /// <param name="ProName">项目名</param>
        /// <returns></returns>
        public List<Pramas> Get_PramasList(string ProName)
        {
            string sql = " select* from tb_Pramas where PramasID not in(select PramasID from tb_SelectedPramas where ProName =@ProName)";
            List<Pramas> PramasList = null;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@ProName", ProName)))
            {
                if (sdr.HasRows)
                {
                    PramasList = new List<Pramas>();
                    while (sdr.Read())
                    {
                        Pramas pramas = new Pramas();
                        pramas.PramasID = sdr.GetInt32(0);
                        pramas.Name = sdr.GetString(1);
                        PramasList.Add(pramas);
                    }
                }
            }
            return PramasList;
        }

    }
}
