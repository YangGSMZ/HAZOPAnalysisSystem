using System;
using System.Collections.Generic;
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

        public List<AnalysResultTotal> Get_All(string ProName)
        {
            return dal.Get_All(ProName);
        }

        public List<AnalysResultTotal> Get_Params(string ProName, string SelectedParam)
        {
            return dal.Get_Params(ProName,SelectedParam);
        }

        public List<AnalysResultTotal> Get_Introduces(string ProName, string SelectedIntroduce)
        {
            return dal.Get_Introduces(ProName, SelectedIntroduce);
        }
        public bool Del_AnalysisResult(List<int> AnalysResultID)
        {
            return dal.Del_AnalysisResult(AnalysResultID);
        }
        public bool Add_AnalysisResult(List<AnalysResultTotal> AnalysResultTotalInfo)
        {
            return dal.Add_AnalysisResult(AnalysResultTotalInfo);
        }
    }
}
