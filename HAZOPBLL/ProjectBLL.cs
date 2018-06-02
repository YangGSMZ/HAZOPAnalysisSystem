using HOZAPDAL;
using HOZAPModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAZOPBLL
{
    public class ProjectBLL
    {
        ProjectDAL dal = new ProjectDAL();
        public bool Add_ProjectInfo(Project ProjectInfo)
        {
            return dal.Add_ProjectInfo(ProjectInfo);
        }
        public Project Get_ProjectInfo(string ProName)
        {
            return dal.Get_ProjectInfo(ProName);
        }
    }
}
