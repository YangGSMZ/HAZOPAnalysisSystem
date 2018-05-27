using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAZOPCommon
{
    public class DisplayPramasAndIntroducer
    {
        /// <summary>
        /// 参数ID
        /// </summary>
        int _PramasID;
        public int PramasID
        {
            set
            {
                this._PramasID = value;
            }
            get
            {
                return this._PramasID;
            }
        }

        /// <summary>
        /// 参数名称
        /// </summary>
        string _PramasName;
        public string Name
        {
            set
            {
                this._PramasName = value;
            }
            get
            {
                return this._PramasName;
            }
        }

        string _AllIntroducer;
        public string AllIntroducer
        {
            set { this._AllIntroducer = value; }
            get { return this._AllIntroducer; }
        }

    }
}
