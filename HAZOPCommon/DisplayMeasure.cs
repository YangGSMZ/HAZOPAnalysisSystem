using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAZOPCommon
{
    public class DisplayMeasure
    {
        public int RecordID
        {
            set;
            get;
        }

        string _measureText;
        public string MeasureText
        {
            set
            {
                this._measureText = value;
            }
            get
            {
                return this._measureText;
            }
        }
    }
}
