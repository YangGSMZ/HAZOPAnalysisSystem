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
    public class ConsequenceDAL
    {
        /// <summary>
        /// 获取后果列表,第一次使用是用于在分析录入框中绑定
        /// </summary>
        /// <param name="ProName">项目名称</param>
        /// <returns></returns>
        public List<DisplayConsequence> Get_Consequence(int IntroducerId)
        {
            string sql = "select ConseqText from tb_Conseq where IntrodrucerID=@IntrodrucerId and Type=1";
            List<DisplayConsequence> consequenceList = null;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@IntrodrucerID", IntroducerId)))
            {
                if (sdr.HasRows)
                {
                    consequenceList = new List<DisplayConsequence>();
                    while (sdr.Read())
                    {
                        DisplayConsequence consequences = new DisplayConsequence();
                        consequences.ConsquenceText = sdr.GetString(0);
                        consequenceList.Add(consequences);
                    }
                }
            }
            return consequenceList;
        }
        public List<DisplayConsequence> Get_PersonalConsequence(int IntroducerId)
        {
            string sql = "select ConseqText,ConseqID from tb_Conseq where IntrodrucerID=@IntrodrucerId and Type=2";
            List<DisplayConsequence> consequenceList = null;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@IntrodrucerID", IntroducerId)))
            {
                if (sdr.HasRows)
                {
                    consequenceList = new List<DisplayConsequence>();
                    while (sdr.Read())
                    {
                        DisplayConsequence consequences = new DisplayConsequence();
                        consequences.ConsquenceText = sdr.GetString(0);
                        consequences.RecordID = sdr.GetInt32(1);
                        consequenceList.Add(consequences);
                    }
                }
            }
            return consequenceList;
        }

        public bool Add_Consequence(Conqeq Consequence)
        {
            bool IsSuccess = false;
            string sql = "insert into tb_Conseq values(@ConseqText,@IntrodrucerID,@Type)";
            SqlParameter[] spm = {
                new SqlParameter("@ConseqText",System.Data.SqlDbType.VarChar),
                new SqlParameter("@IntrodrucerID",System.Data.SqlDbType.Int),
                new SqlParameter("@Type",System.Data.SqlDbType.Int),
            };
            spm[0].Value = Consequence.ConseqText;
            spm[1].Value = Consequence.Introdrucer;
            spm[2].Value = Consequence.Type;
            if (SqlHelper.ExecuteNonQuery(sql, spm) > 0)
            {
                IsSuccess = true;
            }

            return IsSuccess;
        }

        public bool DeletePersonalConsequence(int RecordID)
        {
            bool IsSuccess = false;
            string sqlString = "delete from tb_Conseq where ConseqID=@RecordID;";
            if (SqlHelper.ExecuteNonQuery(sqlString, new SqlParameter("@RecordID", RecordID)) > 0)
            {
                IsSuccess = true;
            }
            return IsSuccess;
        }


    }
}
