using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPModel
{
    public class Introducer
    {
        /// <summary>
        /// 引导词ID，自增长
        /// </summary>
        int _IntroducerId;
        public int IntroducerId
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
        /// 引导词
        /// </summary>
        string _IntroducerText;
        public string IntroducerText
        {
            set
            {
                this._IntroducerText = value;
            }
            get
            {
                return this._IntroducerText;
            }
        }

        /// <summary>
        /// 参数ID，根据参数查询对应的引导词
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
    }
}
