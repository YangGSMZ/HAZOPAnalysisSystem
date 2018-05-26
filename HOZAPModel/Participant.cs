using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOZAPModel
{
    class Participant
    {
        /// <summary>
        /// 参与人员ID
        /// </summary>
        int _ID;
        public int ID
        {
            set
            {
                this._ID = value;
            }
            get
            {
                return this._ID;
            }
        }

        /// <summary>
        /// 参与人员姓名
        /// </summary>
        string _Name;
        public string Name
        {
            set
            {
                this._Name = value;
            }
            get
            {
                return this._Name;
            }
        }

        /// <summary>
        /// 参与人员专业
        /// </summary>
        string _Majary;
        public string Majary
        {
            set
            {
                this._Majary = value;
            }
            get
            {
                return this._Majary;
            }
        }

        /// <summary>
        /// 职位
        /// </summary>
        string _Postion;
        public string Postion
        {
            set
            {
                this._Postion = value;
            }
            get
            {
                return this._Postion;
            }
        }

        /// <summary>
        /// 所属公司
        /// </summary>
        string _Company;
        public string Company
        {
            set
            {
                this._Company = value;
            }
            get
            {
                return this._Company;
            }
        }

        /// <summary>
        /// 所属部门
        /// </summary>
        string _Department;
        public string Department
        {
            set
            {
                this._Department = value;
            }
            get
            {
                return this._Department;
            }
        }

        /// <summary>
        /// 角色
        /// </summary>
        string _RolePlay;
        public string RolePlay
        {
            set
            {
                this._RolePlay = value;
            }
            get
            {
                return this._RolePlay;
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
