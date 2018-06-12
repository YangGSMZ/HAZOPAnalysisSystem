using HOZAPDAL;
using HOZAPModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public bool Update_ProjectInfo(Project ProjectInfo)
        {
            return dal.Update_ProjectInfo(ProjectInfo);
        }
        public bool Check_ProjectName(string ProName)
        {
            return dal.Check_ProjectName(ProName);
        }

        public SqlDataReader Get_ProNameList()
        {
            return dal.Get_ProNameList();
        }

        public bool Delete_ProNameList(string ProName)
        {
            return dal.Delete_ProNameList(ProName);
        }
    }
}
