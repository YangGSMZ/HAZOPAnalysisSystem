using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPModel
{
    class Project
    {
        /// <summary>
        /// 工程编号
        /// </summary>
        int _ProNumber;
        public int ProNumber
        {
            set
            {
                this._ProNumber = value;
            }
            get
            {
                return this._ProNumber;
            }
        }

        /// <summary>
        /// 工程名称
        /// </summary>
        string _ProName;
        public string Name
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

        /// <summary>
        /// 工程所属单位
        /// </summary>
        string _Compartment;
        public string Compartment
        {
            set
            {
                this._Compartment = value;
            }
            get
            {
                return this._Compartment;
            }
        }

        /// <summary>
        /// 工程描述
        /// </summary>
        string _ProDic;
        public string ProDic
        {
            set
            {
                this._ProDic = value;
            }
            get
            {
                return this._ProDic;
            }
        }

        /// <summary>
        /// 工程封面照片
        /// </summary>
        string _ProCoverPic;
        public string ProCoverPic
        {
            set
            {
                this._ProCoverPic = value;
            }
            get
            {
                return this._ProCoverPic;
            }
        }

        /// <summary>
        /// 工程负责人
        /// </summary>
        string _ProManager;
        public string ProManager
        {
            set
            {
                this._ProManager = value;
            }
            get
            {
                return this._ProManager;
            }
        }

        /// <summary>
        /// 复审日期
        /// </summary>
        string _ReviewDate;
        public string ReviewDate
        {
            set
            {
                this._ReviewDate = value;
            }
            get
            {
                return this._ReviewDate;
            }
        }

        /// <summary>
        /// 创建日期
        /// </summary>
        string _CreatePer;
        public string CreatePer
        {
            set
            {
                this._CreatePer = value;
            }
            get
            {
                return this._CreatePer;
            }
        }

        /// <summary>
        /// 打印状态
        /// </summary>
        string _PrintState;
        public string PrintState
        {
            set
            {
                this._PrintState = value;
            }
            get
            {
                return this._PrintState;
            }
        }
         /// <summary>
         /// 打印日期
         /// </summary>
        string _PrintDate;
        public string PrintDate
        {
            set
            {
                this._PrintDate = value;
            }
            get
            {
                return this._PrintDate;
            }
        }

        /// <summary>
        /// 导出日期
        /// </summary>
        string _ImportDate;
        public string ImportDate
        {
            set
            {
                this._ImportDate = value;
            }
            get
            {
                return this._ImportDate;
            }
        }

        /// <summary>
        /// 工程概述
        /// </summary>
        string _ProDigest;
        public string ProDigest
        {
            set
            {
                this._ProDigest = value;
            }
            get
            {
                return this._ProDigest;
            }
        }
    }
}
