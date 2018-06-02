using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAZOPCommon
{
    public class DisplayReasons
    {
        string _ReasonText;
        public string ReasonText
        {
            set
            {
                this._ReasonText = value;
            }
            get
            {
                return this._ReasonText;
            }
        }
    }
}
