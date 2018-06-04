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
    }
}
