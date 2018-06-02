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
    /// 操作可选择的参数的数据表
    /// </summary>
    public class PramasDAL
    {
        /// <summary>
        /// 根据项目名获取未选择的参数列表，读取
        /// </summary>
        /// <param name="ProName">项目名</param>
        /// <param name="Pramas">List<Pramas>中的Pramas是HOZAPModel命名空间中的Pramas类，参数类</param>>
        /// <returns>参数列表</returns>
        public List<Pramas> Get_PramasList(string ProName)
        {
            string sql = " select* from tb_Pramas where PramasID not in(select PramasID from tb_SelectedPramas where ProName =@ProName)";
            List<Pramas> PramasList = null;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@ProName", ProName)))
            {
                if (sdr.HasRows)
                {
                    PramasList = new List<Pramas>();
                    while (sdr.Read())
                    {
                        //一个Pramas类型记录一条参数类型表中的数据
                        Pramas pramas = new Pramas();
                        pramas.PramasID = sdr.GetInt32(0);
                        pramas.Name = sdr.GetString(1);
                        pramas.Type = sdr.GetInt32(2);
                        PramasList.Add(pramas);
                    }
                }
            }
            return PramasList;
        }

        /// <summary>
        /// 添加项目参数到可选参数数据表中，添加
        /// </summary>
        /// <param name="PramasName">参数名</param>
        /// <returns>trueOrfalse</returns>
        public bool Add_Pramas(string PramasName)
        {
            bool IsSuccess = false;
            string sql = "insert into tb_Pramas values(@PramasText,@Type)";
            SqlParameter[] spm =
            {
                new SqlParameter("@PramasText",SqlDbType.VarChar),
                new SqlParameter("@Type",SqlDbType.Int)
            };
            spm[0].Value = PramasName;
            spm[1].Value = 1;
            if (SqlHelper.ExecuteNonQuery(sql, spm) > 0)
            {
                IsSuccess = true;
            }
            return IsSuccess;
        }

        /// <summary>
        /// 获取参数ID，用于添加引导词，一个参数对应多个引导词
        /// </summary>
        /// <param name="PramasName"></param>
        /// <returns></returns>
        public int Get_PramasId(string PramasName)
        {
            //PramasText是数据库中的表的字段，和PramasName是相同的内容
            string sql = "select PramasID from tb_Pramas where PramasText=@PramasText";
            int PramasID = (int)SqlHelper.ExecuteScalar(sql,new SqlParameter("@PramasText",PramasName));
            return PramasID;
        }

    }
}
