using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAZOPCommon;

namespace HOZAPDAL
{
    public class ReasonDAL
    {
        public bool Add_Reason(DisplayReasons reason)
        {
            bool IsSuccess = false;
            string sql = "insert into tb_Reason values(@ReasonText,@IntrodrucerID,@Type)";
            SqlParameter[] spm = {
                new SqlParameter("@ReasonText",System.Data.SqlDbType.VarChar),
                new SqlParameter("@IntrodrucerID",System.Data.SqlDbType.Int),
                new SqlParameter("@Type",System.Data.SqlDbType.Int),
            };
            spm[0].Value = reason.ReasonText;
            spm[1].Value = reason.IntroducerId;
            spm[2].Value = reason.Type;
            if (SqlHelper.ExecuteNonQuery(sql, spm)> 0)
            {
                IsSuccess = true;
            }

            return IsSuccess;
        }

        /// <summary>
        /// 获取原因列表,第一次使用是用于在分析录入框中绑定
        /// </summary>
        /// <param name="ProName"></param>
        /// <returns></returns>
        public List<DisplayReasons> Get_Reasons(int IntroducerId)
        {
            string sql = "select ReasonText from tb_Reason where IntroducerID=@IntroducerId and Type=1";
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


        public List<DisplayReasons> Get_personalReasons(int IntroducerId)
        {
            string sql = "select ReasonText from tb_Reason where IntroducerID=@IntroducerId and Type=2";
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
