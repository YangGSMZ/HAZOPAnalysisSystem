using HOZAPModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPDAL
{
    public class ProjectDAL
    {
        public bool Add_ProjectInfo(Project ProjectInfo)
        {
            bool IsSuccess = false;
            string sql = "insert into tb_Project values(@ProNumber,@ProName,@Compartment,@ProDic,@ProCoverPic,@ProManager,@ReViewDate,@CreatePer,@PrintState,@PrintDate,@ImportDate,@ProDigest)";
            SqlParameter[] spm =
          {
                new SqlParameter("@ProNumber",SqlDbType.VarChar),
                new SqlParameter("@ProName",SqlDbType.VarChar),
                new SqlParameter("@Compartment",SqlDbType.VarChar),
                new SqlParameter("@ProDic",SqlDbType.VarChar),
                new SqlParameter("@ProCoverPic",SqlDbType.VarChar),
                new SqlParameter("@ProManager",SqlDbType.VarChar),
                new SqlParameter("@ReViewDate",SqlDbType.VarChar),
                new SqlParameter("@CreatePer",SqlDbType.VarChar),
                new SqlParameter("@PrintState",SqlDbType.VarChar),
                new SqlParameter("@PrintDate",SqlDbType.VarChar),
                new SqlParameter("@ImportDate",SqlDbType.VarChar),
                new SqlParameter("@ProDigest",SqlDbType.VarChar)

            };
            spm[0].Value = ProjectInfo.ProNumber;
            spm[1].Value = ProjectInfo.Name;
            spm[2].Value = ProjectInfo.Compartment;
            spm[3].Value = ProjectInfo.ProDic;
            spm[4].Value = ProjectInfo.ProCoverPic;
            spm[5].Value = ProjectInfo.ProManager;
            spm[6].Value = ProjectInfo.ReviewDate;
            spm[7].Value = ProjectInfo.CreatePer;
            spm[8].Value = ProjectInfo.PrintState;
            spm[9].Value = ProjectInfo.PrintDate;
            spm[10].Value = ProjectInfo.ImportDate;
            spm[11].Value = ProjectInfo.ProDigest;
            if (SqlHelper.ExecuteNonQuery(sql, spm) > 0)
            {
                IsSuccess = true;
            }
            return IsSuccess;
        }

        public bool Check_ProjectName(string ProName)
        {
            bool IsSuccess = false;
            string sql = "select count(*) from tb_Project where ProName=@ProName";
            if((int)SqlHelper.ExecuteScalar(sql,new SqlParameter("@ProName", ProName)) > 0)
            {
                IsSuccess = true;
            }
            return IsSuccess;
        }

        public Project Get_ProjectInfo(string ProName)
        {
            string sql = "select * from tb_Project where ProName=@ProName";
            Project ProjectInfo = null;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@ProName", ProName)))
            {
                if (sdr.Read())
                {
                    ProjectInfo = new Project();
                    ProjectInfo.ProNumber = sdr.GetString(0);
                    ProjectInfo.Name = sdr.GetString(1);
                    ProjectInfo.Compartment = sdr.GetString(2);
                    ProjectInfo.ProDic = sdr.GetString(3);
                    ProjectInfo.ProCoverPic = sdr.GetString(4);
                    ProjectInfo.ProManager = sdr.GetString(5);
                    ProjectInfo.ReviewDate = sdr.GetString(6);
                    ProjectInfo.CreatePer = sdr.GetString(7);
                    ProjectInfo.PrintState = sdr.GetString(8);
                    ProjectInfo.PrintDate= sdr.GetString(9);
                    ProjectInfo.ImportDate = sdr.GetString(10);
                    ProjectInfo.ProDigest = sdr.GetString(11);

                }
            }
            return ProjectInfo;
        }

        public bool Update_ProjectInfo(Project ProjectInfo)
        {
            bool IsSuccess = false;
            string sql = "update tb_Project set ProNumber=@ProNumber,Compartment=@Compartment,ProDic=@ProDic,ProCoverPic=@ProCoverPic,ProManager=@ProManager,ReViewDate=@ReViewDate,CreatePer=@CreatePer,PrintState=@PrintState,PrintDate=@PrintDate,ImportDate=@ImportDate,ProDigest=@ProDigest where ProName=@ProName";
            SqlParameter[] spm =
     {
                new SqlParameter("@ProNumber",SqlDbType.VarChar),
                new SqlParameter("@ProName",SqlDbType.VarChar),
                new SqlParameter("@Compartment",SqlDbType.VarChar),
                new SqlParameter("@ProDic",SqlDbType.VarChar),
                new SqlParameter("@ProCoverPic",SqlDbType.VarChar),
                new SqlParameter("@ProManager",SqlDbType.VarChar),
                new SqlParameter("@ReViewDate",SqlDbType.VarChar),
                new SqlParameter("@CreatePer",SqlDbType.VarChar),
                new SqlParameter("@PrintState",SqlDbType.VarChar),
                new SqlParameter("@PrintDate",SqlDbType.VarChar),
                new SqlParameter("@ImportDate",SqlDbType.VarChar),
                new SqlParameter("@ProDigest",SqlDbType.VarChar)

            };
            spm[0].Value = ProjectInfo.ProNumber;
            spm[1].Value = ProjectInfo.Name;
            spm[2].Value = ProjectInfo.Compartment;
            spm[3].Value = ProjectInfo.ProDic;
            spm[4].Value = ProjectInfo.ProCoverPic;
            spm[5].Value = ProjectInfo.ProManager;
            spm[6].Value = ProjectInfo.ReviewDate;
            spm[7].Value = ProjectInfo.CreatePer;
            spm[8].Value = ProjectInfo.PrintState;
            spm[9].Value = ProjectInfo.PrintDate;
            spm[10].Value = ProjectInfo.ImportDate;
            spm[11].Value = ProjectInfo.ProDigest;
            if (SqlHelper.ExecuteNonQuery(sql, spm) > 0)
            {
                IsSuccess = true;
            }
            return IsSuccess;
           
        }

        public SqlDataReader Get_ProNameList()
        {
            string sql = "select ProName from tb_Project;";
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql,null);
            return sdr;
        }

        public bool Delete_ProNameList(string ProName)
        {
            bool IsSuccess = false;
            string sql = "delete from tb_Project where ProName=@ProName;";
            if (SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@ProName", ProName)) > 0)
            {
                IsSuccess = true;
            }
            return IsSuccess;
        }
    }
}
