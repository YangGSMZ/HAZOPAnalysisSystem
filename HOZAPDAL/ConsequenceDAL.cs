using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAZOPCommon;

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
            string sql = "select ConseqText from tb_Conseq where IntrodrucerID=@IntrodrucerId";
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
    }
}
