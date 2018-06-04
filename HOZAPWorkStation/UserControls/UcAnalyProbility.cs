using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOZAPWorkStation.UserControls
{
    public partial class UcAnalyProbility : Form
    {
        public UcAnalyProbility()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 声明一个事件，用于把该窗体的数据传到用户控件中
        /// </summary>
        public event Action<object, DataGridViewCellEventArgs> TransferToFx;

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.TransferToFx != null)
            {
                this.TransferToFx(this,null);
            }
            this.Close();
        }

        public string GetSelectedContext()
        {
            if (listView1.SelectedItems[0].Index == 0)
            {
                return "0";
            }
            if (listView1.SelectedItems[0].Index == 1)
            {
                return "1";
            }
            if (listView1.SelectedItems[0].Index == 2)
            {
                return "2";
            }
            if (listView1.SelectedItems[0].Index == 3)
            {
                return "3";
            }
            if (listView1.SelectedItems[0].Index == 4)
            {
                return "4";
            }
            if (listView1.SelectedItems[0].Index == 5)
            {
                return "5";
            }
            return String.Empty;
        }
    }
}
