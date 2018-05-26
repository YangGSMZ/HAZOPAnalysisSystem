using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPModel
{
    class Messure
    {

        /// <summary>
        /// 措施ID
        /// </summary>
        int _MessureId;
        public int MessureID
        {
            set
            {
                this._MessureId = value;
            }
            get
            {
                return this._MessureId;
            }
        }

        /// <summary>
        /// 措施
        /// </summary>
        string _MessureText;
        public string MessureText
        {
            set
            {
                this._MessureText = value;
            }
            get
            {
                return this._MessureText;
            }
        }

        /// <summary>
        /// 引导词ID
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
        /// 类型，1.专家库；2.个人经验库；3.用户自定义输入
        /// </summary>
        int _type;
        public int Type
        {
            set
            {
                this._type = value;
            }
            get
            {
                return this._type;
            }
        }
    }
}
