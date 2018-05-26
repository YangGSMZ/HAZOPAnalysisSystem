using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPModel
{
    class Node
    {
        /// <summary>
        /// 节点编号
        /// </summary>
        int _NodeId;
        public int NodeId
        {
            set
            {
                this._NodeId = value;
            }
            get
            {
                return this._NodeId;
            }
        }

        /// <summary>
        /// 节点分类
        /// </summary>
        string _NodeSort;
        public string NodeSort
        {
            set
            {
                this._NodeSort = value;
            }
            get
            {
                return this._NodeSort;
            }
        }

        /// <summary>
        /// 节点名称
        /// </summary>
        string _NodeName;
        public string NodeName
        {
            set
            {
                this._NodeName = value;
            }
            get
            {
                return this._NodeName;
            }
        }

        /// <summary>
        /// 节点描述
        /// </summary>
        string _NodeDesc;
        public string NodeDesc
        {
            set
            {
                this._NodeDesc = value;
            }
            get
            {
                return this._NodeDesc;
            }
        }

        /// <summary>
        /// 节点设置有意图
        /// </summary>
        string _NodeIUage;
        public string NodeIUage
        {
            set
            {
                this._NodeIUage = value;
            }
            get
            {
                return this._NodeIUage;
            }
        }

        /// <summary>
        /// 创建日期，暂定为datatime类型，不行改为string
        /// </summary>
        DateTime _NodeCreateDate;
        public DateTime NodeCreateDate
        {
            set
            {
                this._NodeCreateDate = value;
            }
            get
            {
                return this._NodeCreateDate;
            }
        }

        /// <summary>
        /// 选择模型
        /// </summary>
        string _SelectModel;
        public string SelectMode
        {
            set
            {
                this._SelectModel = value;
            }
            get
            {
                return this._SelectModel;
            }
        }

        /// <summary>
        /// 项目工程名称
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
