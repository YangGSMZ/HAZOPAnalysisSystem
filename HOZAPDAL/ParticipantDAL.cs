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
    /// <summary>
    /// 操作项目成员信息表
    /// </summary>
    public class ParticipantDAL
    {
        /// <summary>
        /// 添加项目成员信息
        /// </summary>
        /// <param name="participantinfo">项目成员信息</param>
        /// <returns>trueOrfalse</returns>
        public bool Add_Participant(Participant participantinfo)
        {
            bool IsSuccess = false;
            string sql = "insert into tb_Participant values(@Name,@Majary,@Postion,@Company,@Department,@RolePlay,@ProName)";
            SqlParameter[] spm =
            {
                new SqlParameter("@Name",SqlDbType.VarChar),
                new SqlParameter("@Majary",SqlDbType.VarChar),
                new SqlParameter("@Postion",SqlDbType.VarChar),
                new SqlParameter("@Company",SqlDbType.VarChar),
                new SqlParameter("@Department",SqlDbType.VarChar),
                new SqlParameter("@RolePlay",SqlDbType.VarChar),
                new SqlParameter("@ProName",SqlDbType.VarChar)
            };
            spm[0].Value = participantinfo.Name;
            spm[1].Value = participantinfo.Majary;
            spm[2].Value = participantinfo.Postion;
            spm[3].Value = participantinfo.Company;
            spm[4].Value = participantinfo.Department;
            spm[5].Value = participantinfo.RolePlay;
            spm[6].Value = participantinfo.ProName;
            if (SqlHelper.ExecuteNonQuery(sql, spm) > 0)
            {
                IsSuccess = true;
            }
            return IsSuccess;
        }
        /// <summary>
        /// 根据项目名获取所有参与人员信息
        /// </summary>
        /// <param name="ProName">项目名</param>
        /// <returns>成员信息列表</returns>
        public List<Participant> Get_ParticipantInfoList(string ProName)
        {
            string sql = "select * from tb_Participant where ProName=@ProName";
            List<Participant> participantinfolist = null;
            using (SqlDataReader sdr=SqlHelper.ExecuteReader(sql,new SqlParameter("@ProName", ProName)))
            {
                if (sdr.HasRows)
                {
                    participantinfolist = new List<Participant>();
                    while (sdr.Read())
                    {
                        Participant participantinfo = new Participant();
                        participantinfo.ID = sdr.GetInt32(0);
                        participantinfo.Name = sdr.GetString(1);
                        participantinfo.Majary= sdr.GetString(2);
                        participantinfo.Postion = sdr.GetString(3);
                        participantinfo.Company = sdr.GetString(4);
                        participantinfo.Department = sdr.GetString(5);
                        participantinfo.RolePlay = sdr.GetString(6);
                        participantinfo.ProName = sdr.GetString(7);
                        participantinfolist.Add(participantinfo);
                    }
                }
            }
            return participantinfolist;
        }

        /// <summary>
        /// 根据成员的ID删除成员信息
        /// </summary>
        /// <param name="ID">成员的ID</param>
        /// <returns>trueOrfalse</returns>
        public bool Del_ParticipantInfo(int ID)
        {
            bool IsSuccess = false;
            string sql = "delete from tb_Participant where ID=@ID";
            if (SqlHelper.ExecuteNonQuery(sql,new SqlParameter("@ID", ID)) > 0)
            {
                IsSuccess = true;
            }
            return IsSuccess;
        }

    }
}
