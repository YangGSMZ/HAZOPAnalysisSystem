using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAZOPCommon;
using HOZAPDAL;
using HOZAPModel;

namespace HAZOPBLL
{
    public class MeasureBLL
    {
        MeasureDAL dal = new MeasureDAL();

        public List<DisplayMeasure> Get_MeasuresList(int IntroducerId)
        {
            return dal.Get_MeasuresList(IntroducerId);
        }

        public List<DisplayMeasure> Get_PersonalMeasure(int IntroducerId)
        {
            return dal.Get_PersonalMeasuresList(IntroducerId);
        }

        public bool Add_Messure(Messure messure)
        {
            return dal.Add_Measure(messure);
        }
    }
}
