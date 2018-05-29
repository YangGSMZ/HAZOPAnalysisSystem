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
        public List<Node> Get_NodeList(string ProName)
        {
            return dal.Get_NodeList(ProName);
        }
    }
}
