using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAZOPCommon;
using HOZAPDAL;

namespace HAZOPBLL
{
    public class MeasureBLL
    {
        MeasureDAL dal = new MeasureDAL();

        public List<DisplayMeasure> Get_MeasuresList(int IntroducerId)
        {
            return dal.Get_MeasuresList(IntroducerId);
        }
    }
}
