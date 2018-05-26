using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPModel
{
    public class Conseq
    {
        /// <summary>
        /// 后果ID，自增长
        /// </summary>
        int _conseqId;
        public int ConseqID
        {
            set
            {
                this._conseqId = value;
            }
            get
            {
                return this._conseqId;
            }
        }

        /// <summary>
        /// 后果文本，由用户选择后果
        /// </summary>
        string _conseqText;
        public string ConseqText
        {
            set
            {
                this._conseqText = value;
            }
            get
            {
                return this._conseqText;
            }
        }

        /// <summary>
        /// 外键引导词ID，根据引导词查询后果
        /// </summary>
        string _introdrucerId;
        public string Introdrucer
        {
            set
            {
                this._introdrucerId = value;
            }
            get
            {
                return this._introdrucerId;
            }

        }

        /// <summary>
        /// 后果的类型，1.专家库；2.个人库；3.用户自定义输入
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
