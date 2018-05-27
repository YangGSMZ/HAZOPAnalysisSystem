using HOZAPDAL;
using HOZAPModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAZOPBLL
{
    public class PramasBLL
    {
        PramasDAL dal = new PramasDAL();
        public List<Pramas> Get_PramasList(string ProName)
        {
            return dal.Get_PramasList(ProName);
         
        }
    }
}
