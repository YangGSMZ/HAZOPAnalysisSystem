using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPModel
{
    class Reason
    {
        /// <summary>
        /// 原因ID，自增长
        /// </summary>
        int _ReasonId;
        public int ReasonId
        {
            set
            {
                this._ReasonId = value;
            }
            get
            {
                return this._ReasonId;
            }
        }

        /// <summary>
        /// 原因
        /// </summary>
        string _ReasonText;
        public string IntroducerText
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

        /// <summary>
        /// 引导词ID
        /// </summary>
        int _IntroducerId;
        public int PramasId
        {
            set
            {
                this._IntroducerId = value;
            }
            get
            {
                return this._IntroducerId;
            }
        }

        /// <summary>
        /// 原因类型，1.专家库；2.个人经验库；3.用户自定义输入
        /// </summary>
        int _Type;
        public int Type
        {
            set
            {
                this._Type = value;
            }
            get
            {
                return this._Type;
            }
        }
    }
}
