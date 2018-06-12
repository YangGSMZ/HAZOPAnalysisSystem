using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAZOPCommon;
using HOZAPDAL;

namespace HAZOPBLL
{
    public class AnalyResultBLL
    {
        AnalyResultDAL dal = new AnalyResultDAL();

        public List<AnalysResultTotal> Get_All(string ProName,string NodeName)
        {
            return dal.Get_All(ProName,NodeName);
        }

        public List<AnalysResultTotal> Get_Params(string ProName, string SelectedParam,string NodeName)
        {
            return dal.Get_Params(ProName,SelectedParam,NodeName);
        }

        public List<AnalysResultTotal> Get_Introduces(string ProName, string SelectedIntroduce,string NodeName)
        {
            return dal.Get_Introduces(ProName, SelectedIntroduce,NodeName);
        }
        public bool Del_AnalysisResult(List<int> AnalysResultID)
        {
            return dal.Del_AnalysisResult(AnalysResultID);
        }
        public bool Add_AnalysisResult(List<AnalysResultTotal> AnalysResultTotalInfo)
        {
            return dal.Add_AnalysisResult(AnalysResultTotalInfo);
        }

        public bool Delete_Result(string ProName)
        {
            return dal.Delete_Result(ProName);
        }

        public DataTable OutAllToExcel(string ProName)
        {
            return dal.OutAllToExcel(ProName);
        }
    }
}
