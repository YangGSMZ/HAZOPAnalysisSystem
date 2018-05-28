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
    public class ParticipantDAL
    {
        /// <summary>
        /// 添加参与项目人员信息
        /// </summary>
        /// <param name="participantinfo">项目人员信息类</param>
        /// <returns></returns>
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


    }
}
