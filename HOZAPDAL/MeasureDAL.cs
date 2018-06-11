using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAZOPCommon;
using HOZAPModel;

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
            string sql = "select MessureText from tb_Messure where IntroducerID=@IntroducerId and Type=1";
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


        public List<DisplayMeasure> Get_PersonalMeasuresList(int IntroducerId)
        {
            string sql = "select MessureText from tb_Messure where IntroducerID=@IntroducerId and Type=2";
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

        public bool Add_Measure(Messure messure)
        {
            bool IsSuccess = false;
            string sql = "insert into tb_Messure values(@ConseqText,@IntrodrucerID,@Type)";
            SqlParameter[] spm = {
                new SqlParameter("@ConseqText",System.Data.SqlDbType.VarChar),
                new SqlParameter("@IntrodrucerID",System.Data.SqlDbType.Int),
                new SqlParameter("@Type",System.Data.SqlDbType.Int),
            };
            spm[0].Value = messure.MessureText;
            spm[1].Value = messure.IntroducerId;
            spm[2].Value = messure.Type;
            if (SqlHelper.ExecuteNonQuery(sql, spm) > 0)
            {
                IsSuccess = true;
            }

            return IsSuccess;
        }
    }
}
