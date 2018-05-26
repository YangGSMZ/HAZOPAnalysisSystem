using HOZAPDAL;
using HOZAPModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAZOPBLL
{
    public class IntroducerBLL
    {
        IntroducerDAL dal = new IntroducerDAL();
        public List<Introducer> Get_IntroducerList(int PramasId)
        {
            return dal.Get_IntroducerList(PramasId);
        }
    }
}
