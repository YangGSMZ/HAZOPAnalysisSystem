using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPModel
{
    public class Pramas
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
        int _Type;
        public int Type
        {
            set { this._Type = value; }
            get { return this._Type; }
        }

             
    }
}
