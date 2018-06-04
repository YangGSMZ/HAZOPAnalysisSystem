using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HOZAPModel;
using HAZOPCommon;

namespace HOZAPDAL
{
    public class ReasonDAL
    {
        /// <summary>
        /// 获取原因列表,第一次使用是用于在分析录入框中绑定
        /// </summary>
        /// <param name="ProName"></param>
        /// <returns></returns>
        public List<DisplayReasons> Get_Reasons(int IntroducerId)
        {
            string sql = "select ReasonText from tb_Reason where IntroducerID=@IntroducerId";
            List<DisplayReasons> ReasonList = null;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@IntroducerID", IntroducerId)))
            {
                if (sdr.HasRows)
                {
                    ReasonList = new List<DisplayReasons>();
                    while (sdr.Read()) 
                    {
                        DisplayReasons reasons = new DisplayReasons();
                        reasons.ReasonText = sdr.GetString(0);
                        ReasonList.Add(reasons);
                    }
                }
            }
            return ReasonList;
        }
    }
}
