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
    public partial class NewProjectInterface : Form
    {
        public NewProjectInterface()
        {
            InitializeComponent();
        }

        private static NewProjectInterface _instance;
        //创建窗体对象的静态方法
        public static NewProjectInterface InstanceObject()
        {
            if (_instance == null)
                _instance = new NewProjectInterface();
            return _instance;
        }

        //窗体关闭事件
        private void NewProjectInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
