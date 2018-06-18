using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPDAL
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public static class SqlHelper
    {
        #region 获取配置文件中的连接字符串
       //private static readonly string ConnStr = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;

       static string ConnStr = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog = HAZOPAnalysisDB; Integrated Security = true; Connect Timeout = 30;";
        #endregion

        #region 用于数据的增删改
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="pms">SQL语句中使用的参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql,params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region 返回单个数据值
        /// <summary>
        /// 执行SQL语句并返回单个数据值
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="pms">执行SQL语句使用的参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql,con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open(); 
                    return cmd.ExecuteScalar();;
                }
            }
        }
        #endregion

        #region 返回DataReader
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(ConnStr);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch (Exception)
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }
        #endregion

        #region 返回DataTable
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] pms)
        {
            //DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(ConnStr);
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql,con))
            {
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                // adapter.Fill(ds, "Tb");
                // dt = ds.Tables["Tb"];
                adapter.Fill(dt);
            }
            return dt;
        }
        #endregion

    }
}
