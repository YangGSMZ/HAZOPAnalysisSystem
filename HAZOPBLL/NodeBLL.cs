using HOZAPDAL;
using HOZAPModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAZOPBLL
{
    public class NodeBLL
    {
        NodeDAL dal = new NodeDAL();

        /// <summary>
        /// 获取节点列表
        /// </summary>
        /// <param name="ProName"></param>
        /// <returns></returns>
        public List<Node> Get_NodeList(string ProName)
        {
            return dal.Get_NodeList(ProName);
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="participantinfo"></param>
        /// <returns></returns>
        public bool Add_Node(Node nodeinfo)
        {
            return dal.Add_Node(nodeinfo);
        }

        /// <summary>
        /// 修改节点信息
        /// </summary>
        /// <param name="nodeinfo"></param>
        /// <returns></returns>
        public bool Alter_Node(Node nodeinfo)
        {
            return dal.Alter_Node(nodeinfo);
        }

        public bool Check_NodeIDIsAvailable(int NodeID)
        {
            return dal.Check_NodeIdAvailable(NodeID);
        }

        public bool Check_NodeNameIsAvailable(string NodeName)
        {
            return dal.Check_NodeNameAvailable(NodeName);
        }

        public Node Get_NodeInfo(string NodeName)
        {
            return dal.Get_SelectedNode(NodeName);
        }
    }
}
