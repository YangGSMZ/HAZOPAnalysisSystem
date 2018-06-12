using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAZOPCommon;

namespace HOZAPDAL
{
    public class AnalyResultDAL
    {
        public List<AnalysResultTotal> Get_All(string ProName,string NodeName)
        {
            string sql = "select * from tb_AnalysisResult where ProName=@ProName and NodeName=@NodeName order by Pramas";
            List<AnalysResultTotal> AnalysResultTotalList = null;
            SqlParameter[] spm =
            {
                new SqlParameter("@ProName",SqlDbType.VarChar),
                new SqlParameter("@NodeName",SqlDbType.VarChar)
            };
            spm[0].Value = ProName;
            spm[1].Value = NodeName;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, spm))
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
                        analysResult.ResultID = sdr.GetInt32(19);
                        AnalysResultTotalList.Add(analysResult);
                    }
                }
            }
            return AnalysResultTotalList;
        }

        public List<AnalysResultTotal> Get_Params(string ProName,string SelectedParam,string NodeName)
        {
            string sql = "select * from tb_AnalysisResult where ProName=@ProName and Pramas=@SelectedParam and NodeName=@NodeName ";
            List<AnalysResultTotal> AnalysResultTotalList = null;
            SqlParameter[] sqlParameter =
                {
                    new SqlParameter("@ProName", SqlDbType.VarChar),
                    new SqlParameter("@SelectedParam",SqlDbType.VarChar),
                    new SqlParameter("@NodeName",SqlDbType.VarChar)
                 };
            sqlParameter[0].Value = ProName;
            sqlParameter[1].Value = SelectedParam;
            sqlParameter[2].Value = NodeName;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, sqlParameter))
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
                        analysResult.Reason = sdr.GetString(5);
                        analysResult.F0 = sdr.GetString(6);
                        analysResult.Consequence = sdr.GetString(7);
                        analysResult.Si = sdr.GetString(8);
                        analysResult.Li = sdr.GetString(9);
                        analysResult.Ri = sdr.GetString(10);
                        analysResult.Measure = sdr.GetString(11);
                        analysResult.Fs = sdr.GetString(12);
                        analysResult.S = sdr.GetString(13);
                        analysResult.L = sdr.GetString(14);
                        analysResult.R = sdr.GetString(15);
                        analysResult.Suggestion = sdr.GetString(16);
                        analysResult.Company = sdr.GetString(17);
                        analysResult.Mark = sdr.GetString(18);
                        analysResult.ResultID = sdr.GetInt32(19);
                        AnalysResultTotalList.Add(analysResult);
                    }
                }
            }
            return AnalysResultTotalList;
        }

        public List<AnalysResultTotal> Get_Introduces(string ProName, string SelectedIntroduce,string NodeName)
        {
            string sql = "select * from tb_AnalysisResult where ProName=@ProName and PramasAndIntroduce=@SelectedIntroduce and NodeName=@NodeName";
            List<AnalysResultTotal> AnalysResultTotalList = null;
            SqlParameter[] sqlParameter =
                {
                    new SqlParameter("@ProName", SqlDbType.VarChar),
                    new SqlParameter("@SelectedIntroduce",SqlDbType.VarChar),
                    new SqlParameter("@NodeName",SqlDbType.VarChar)
                 };
            sqlParameter[0].Value = ProName;
            sqlParameter[1].Value = SelectedIntroduce;
            sqlParameter[2].Value = NodeName;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, sqlParameter))
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
                        analysResult.Reason = sdr.GetString(5);
                        analysResult.F0 = sdr.GetString(6);
                        analysResult.Consequence = sdr.GetString(7);
                        analysResult.Si = sdr.GetString(8);
                        analysResult.Li = sdr.GetString(9);
                        analysResult.Ri = sdr.GetString(10);
                        analysResult.Measure = sdr.GetString(11);
                        analysResult.Fs = sdr.GetString(12);
                        analysResult.S = sdr.GetString(13);
                        analysResult.L = sdr.GetString(14);
                        analysResult.R = sdr.GetString(15);
                        analysResult.Suggestion = sdr.GetString(16);
                        analysResult.Company = sdr.GetString(17);
                        analysResult.Mark = sdr.GetString(18);
                        analysResult.ResultID = sdr.GetInt32(19);
                        AnalysResultTotalList.Add(analysResult);
                    }
                }
            }
            return AnalysResultTotalList;
        }

        public bool Add_AnalysisResult(List<AnalysResultTotal> AnalysResultTotalInfo)
        {
            bool IsSuccess = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("BEGIN ");
            for (int i = 0; i < AnalysResultTotalInfo.Count; i++)
            {
                sb.Append("insert into tb_AnalysisResult values('" 
                    + AnalysResultTotalInfo[i].ProjectName+ "','" + AnalysResultTotalInfo[i].RecordName 
                    +"','"+ AnalysResultTotalInfo[i].Pramas + "','" + AnalysResultTotalInfo[i].PramasAndIntroduce
                    + "','" +AnalysResultTotalInfo[i].DeviateDescription+ "','" +AnalysResultTotalInfo[i].Reason
                    + "','" +AnalysResultTotalInfo[i].F0+ "','" +AnalysResultTotalInfo[i].Consequence+ "','" 
                    +AnalysResultTotalInfo[i].Si+ "','" +AnalysResultTotalInfo[i].Li+ "','" 
                    +AnalysResultTotalInfo[i].Ri+ "','" +AnalysResultTotalInfo[i].Measure+ "','" 
                    +AnalysResultTotalInfo[i].Fs+ "','" + AnalysResultTotalInfo[i].S+ "','" 
                    + AnalysResultTotalInfo[i].L+ "','" +AnalysResultTotalInfo[i].R+ "','" 
                    +AnalysResultTotalInfo[i].Suggestion+ "','" +AnalysResultTotalInfo[i].Company+ "','" 
                    +AnalysResultTotalInfo[i].Mark + "','" + AnalysResultTotalInfo[i].NodeName+ "')");
            }
            sb.Append(" END;");
            if (SqlHelper.ExecuteNonQuery(sb.ToString()) > 0)
            {
                IsSuccess = true;
            }
            return IsSuccess;
                 
        }

        public bool Del_AnalysisResult(List<int> AnalysResultID)
        {
            bool IsSuccess = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("BEGIN ");
            for (int i = 0; i < AnalysResultID.Count; i++)
            {
                sb.Append("delete from tb_AnalysisResult where ResultID=" + AnalysResultID[i]);
            }
            sb.Append(" END;");
            if (SqlHelper.ExecuteNonQuery(sb.ToString()) > 0)
            {
                IsSuccess = true;
            }
            return IsSuccess;
        }

        public bool Delete_Result(string ProName)
        {
            bool IsSuccess = false;
            string sql = "delete from tb_AnalysisResult where ProName=@ProName;";
            if (SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@ProName", ProName)) > 0)
            {
                IsSuccess = true;
            }
            return IsSuccess;
        }

        public DataTable OutAllToExcel(string ProName)
        {
            string sql = "select * from tb_AnalysisResult order by NodeName,Pramas;";
            SqlParameter pms = new SqlParameter("@ProName", ProName);
            DataTable dt = SqlHelper.ExecuteDataTable(sql, pms);
            return dt;
        }
    }
}
