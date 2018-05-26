using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPModel
{
    public class SelectedPramas
    {

        /// <summary>
        /// 参数ID
        /// </summary>
        int _PramasId;
        public int PramasId
        {
            set
            {
                this._PramasId = value;
            }
            get
            {
                return this._PramasId;
            }
        }

        /// <summary>
        /// 参数
        /// </summary>
        string _PramasText;
        public string PramasText
        {
            set
            {
                this._PramasText = value;
            }
            get
            {
                return this._PramasText;
            }
        }

        /// <summary>
        /// 工程名称
        /// </summary>
        string _ProName;
        public string ProName
        {
            set
            {
                this._ProName = value;
            }
            get
            {
                return this._ProName;
            }
        }
    }
}
