using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOZAPWorkStation
{

 
    public partial class UpdataPramasInfo : Form
    {
        public delegate void PreParamSelectionDataBindEvents();
        public event PreParamSelectionDataBindEvents MyPreParamSelectionDataBindEvents;
        public UpdataPramasInfo()
        {
            InitializeComponent();
        }

        private static UpdataPramasInfo _instance;
        //创建窗体对象的静态方法
        public static UpdataPramasInfo InstanceObject()
        {
            if (_instance == null)
                _instance = new UpdataPramasInfo();
            return _instance;
        }

        //窗体关闭事件
        private void UpdataPramasInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
