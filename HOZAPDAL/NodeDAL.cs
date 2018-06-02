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
    /// 操作节点数据表
    /// </summary>
   public  class NodeDAL
    {
        /// <summary>
        /// 根据项目名称获取节点列表
        /// </summary>
        /// <param name="ProName">项目名称</param>
        /// <returns></returns>
        public List<Node> Get_NodeList(string ProName)
        {
            string sql = " select * from tb_Node where ProName =@ProName";
            List<Node> NodeList = null;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@ProName", ProName)))
            {
                if (sdr.HasRows)
                {
                    NodeList = new List<Node>();
                    while (sdr.Read())
                    {
                       
                        Node node = new Node();
                        node.NodeId = sdr.GetInt32(0);
                        node.NodeSort = sdr.GetString(1);
                        node.NodeName = sdr.GetString(2);
                        node.NodeDesc = sdr.GetString(3);
                        node.NodeIUage = sdr.GetString(4);
                        node.NodeCreateDate = sdr.GetString(5);
                        node.SelectMode= sdr.GetString(6);
                        node.ProName = sdr.GetString(7);
                        NodeList.Add(node);
                    }
                }
            }
            return NodeList;
        }

        /// <summary>
        /// 添加数据到数据库节点表
        /// </summary>
        /// <param name="nodeinfo">要添加的节点对象</param>
        /// <returns></returns>
        public bool Add_Node(Node nodeinfo)
        {
            bool IsSuccess = false;
            string sql = "insert into tb_Node values(@NodeId,@NodeSort,@NodeName,@NodeDesc,@NodeIUsage,@NodeCreateDate,@SelectedModel,@ProName)";
            SqlParameter[] spm =
            {
                new SqlParameter("@NodeId",SqlDbType.Int),
                new SqlParameter("@NodeSort",SqlDbType.VarChar),
                new SqlParameter("@NodeName",SqlDbType.VarChar),
                new SqlParameter("@NodeDesc",SqlDbType.VarChar),
                new SqlParameter("@NodeIUsage",SqlDbType.VarChar),
                new SqlParameter("@NodeCreateDate",SqlDbType.VarChar),
                new SqlParameter("@SelectedModel",SqlDbType.VarChar),
                new SqlParameter("@ProName",SqlDbType.VarChar)
            };
            spm[0].Value = nodeinfo.NodeId;
            spm[1].Value = nodeinfo.NodeSort;
            spm[2].Value = nodeinfo.NodeName;
            spm[3].Value = nodeinfo.NodeDesc;
            spm[4].Value = nodeinfo.NodeIUage;
            spm[5].Value = nodeinfo.NodeCreateDate;
            spm[6].Value = nodeinfo.SelectMode;
            spm[7].Value = nodeinfo.ProName;
            if (SqlHelper.ExecuteNonQuery(sql, spm) > 0)
            {
                IsSuccess = true;
            }
            return IsSuccess;
        }

        /// <summary>
        /// 修改已有的节点信息
        /// </summary>
        /// <param name="nodeinfo"></param>
        /// <returns></returns>
        public bool Alter_Node(Node nodeinfo)
        {
            bool IsSuccess = false;
            string sql = "update tb_Node set NodeDesc=@NodeDesc,NodeIUsage=@NodeIUsage,NodeCreateDate=@NodeCreateDate where NodeID=@NodeID;";
            SqlParameter[] spm =
            {
                new SqlParameter("@NodeDesc",SqlDbType.VarChar),
                new SqlParameter("@NodeIUsage",SqlDbType.VarChar),
                new SqlParameter("@NodeCreateDate",SqlDbType.VarChar),
                new SqlParameter("@NodeId",SqlDbType.Int)
            };
            spm[0].Value = nodeinfo.NodeDesc;
            spm[1].Value = nodeinfo.NodeIUage;
            spm[2].Value = nodeinfo.NodeCreateDate;
            spm[3].Value = nodeinfo.NodeId;
            if (SqlHelper.ExecuteNonQuery(sql, spm) > 0)
            {
                IsSuccess = true;
            }
            return IsSuccess;
        }


        /// <summary>
        /// 检测节点标号是否可用
        /// </summary>
        /// <param name="NodeID"></param>
        /// <returns></returns>
        public bool Check_NodeIdAvailable(int NodeID)
        {
            bool IsSuccess = false;
            string sql = "select count(*) from tb_Node where NodeID = @NodeID;";
            if ((int)SqlHelper.ExecuteScalar(sql, new SqlParameter("@NodeID", NodeID)) > 0)
            {
                //已存在返回false
                return IsSuccess;
            }
            else
            {
                //不存在返回true
                IsSuccess = true;
                return IsSuccess;
            }
        }

        public bool Check_NodeNameAvailable(string NodeName)
        {
            bool IsSuccess = false;
            string sql = "select count(*) from tb_Node where NodeName = @NodeName;";
            if ((int)SqlHelper.ExecuteScalar(sql, new SqlParameter("@NodeName",NodeName)) > 0)
            {
                //已存在返回false
                return IsSuccess;
            }
            else
            {
                //不存在返回true
                IsSuccess = true;
                return IsSuccess;
            }
        }

        public Node Get_SelectedNode(string NodeName)
        {
            string sql = "select * from tb_Node where NodeName =@NodeName";
            Node node = new Node();
            try
            {
                using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@NodeName", NodeName)))
                {
                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        node.NodeId = sdr.GetInt32(0);
                        node.NodeSort = sdr.GetString(1);
                        node.NodeName = sdr.GetString(2);
                        node.NodeDesc = sdr.GetString(3);
                        node.NodeIUage = sdr.GetString(4);
                        node.NodeCreateDate = sdr.GetString(5);
                        node.SelectMode = sdr.GetString(6);
                        node.ProName = sdr.GetString(7);
                        return node;
                    }
                }
            }
            catch
            {
            }
            finally
            {
                node = null; 
            }
            return node;
        }
    }
}
