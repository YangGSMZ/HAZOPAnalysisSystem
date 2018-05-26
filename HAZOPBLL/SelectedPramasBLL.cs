using HOZAPDAL;
using HOZAPModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPBLL
{
    public class SelectedPramasBLL
    {
        SelectedPramasDAL dal = new SelectedPramasDAL();
        public List<SelectedPramas> Get_SelectedPramasList(string ProName)
        {
            return dal.Get_SelectedPramasList(ProName);
        }
    }
}
