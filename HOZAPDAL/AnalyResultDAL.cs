using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAZOPCommon;

namespace HOZAPDAL
{
    public class AnalyResultDAL
    {
        public List<AnalysResultTotal> Get_All(string ProName)
        {
            string sql = "select * from tb_AnalysisResult where ProName=@ProName ";
            List<AnalysResultTotal> AnalysResultTotalList = null;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@ProName", ProName)))
            {
                if (sdr.HasRows)
                {
                    AnalysResultTotalList = new List<AnalysResultTotal>();
                    while (sdr.Read())
                    {
                        AnalysResultTotal analysResult = new AnalysResultTotal();
                        //analysResult.ProjectName = sdr.GetString(0);
                        analysResult.RecordName = sdr.GetString(1);
                        analysResult.Pramas = sdr.GetString(2);
                        analysResult.PramasAndIntroduce = sdr.GetString(3);
                        analysResult.DeviateDescription = sdr.GetString(4);
                        analysResult.Reason= sdr.GetString(5);
                        analysResult.F0= sdr.GetString(6);
                        analysResult.Consequence= sdr.GetString(7);
                        analysResult.Si= sdr.GetString(8);
                        analysResult.Li= sdr.GetString(9);
                        analysResult.Ri= sdr.GetString(10);
                        analysResult.Measure= sdr.GetString(11);
                        analysResult.Fs= sdr.GetString(12);
                        analysResult.S= sdr.GetString(13);
                        analysResult.L= sdr.GetString(14);
                        analysResult.R= sdr.GetString(15);
                        analysResult.Suggestion= sdr.GetString(16);
                        analysResult.Company= sdr.GetString(17);
                        analysResult.Mark= sdr.GetString(18);
                        AnalysResultTotalList.Add(analysResult);
                    }
                }
            }
            return AnalysResultTotalList;
        }
    }
}
