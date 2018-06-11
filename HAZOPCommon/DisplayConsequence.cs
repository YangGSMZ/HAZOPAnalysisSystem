using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAZOPCommon
{
    public class DisplayConsequence
    {
        string _consquenceText;
        public string ConsquenceText
        {
            set
            {
                this._consquenceText = value;
            }
            get
            {
                return this._consquenceText;
            }
        }
        public int RecordID
        {
            set;
            get;
        }
    }
}
