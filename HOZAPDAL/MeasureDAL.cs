using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAZOPCommon;

namespace HOZAPDAL
{
    public class MeasureDAL
    {
        /// <summary>
        /// 获取现有措施列表,第一次使用是用于在分析录入框中绑定
        /// </summary>
        /// <param name="ProName"></param>
        /// <returns></returns>
        public List<DisplayMeasure> Get_MeasuresList(int IntroducerId)
        {
            string sql = "select MessureText from tb_Messure where IntroducerID=@IntroducerId";
            List<DisplayMeasure> MeasuresList = null;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@IntroducerID", IntroducerId)))
            {
                if (sdr.HasRows)
                {
                    MeasuresList = new List<DisplayMeasure>();
                    while (sdr.Read())
                    {
                        DisplayMeasure measures = new DisplayMeasure();
                        measures.MeasureText = sdr.GetString(0);
                        MeasuresList.Add(measures);
                    }
                }
            }
            return MeasuresList;
        }
    }
}
