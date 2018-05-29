using HOZAPModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPDAL
{
   public  class NodeDAL
    {
        public List<Node> Get_NodeList(string ProName)
        {
            string sql = " select* from tb_Node where  ProName =@ProName";
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
                        node.NodeCreateDate = sdr.GetDateTime(5);
                        node.SelectMode= sdr.GetString(6);
                        node.ProName = sdr.GetString(7);
                        NodeList.Add(node);
                    }
                }
            }
            return NodeList;
        }
    }
}
