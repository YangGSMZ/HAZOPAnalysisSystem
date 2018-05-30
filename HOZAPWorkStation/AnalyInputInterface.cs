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
    public partial class AnalyInputInterface : Form
    {
        public AnalyInputInterface()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 声明一个事件，用于把该窗体的数据传到用户控件中
        /// </summary>
        public event Action<object, DataGridViewCellEventArgs> RefreshParent;

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            if (this.RefreshParent != null)
            {
                //将该窗体传递到用户控件才能捕获该窗体里的数据
                this.RefreshParent(this,null);
            }
            this.Close();
        }

        public string GetRichTextBoxContext()
        {
            return this.rtbAnaInputInterface.Text;
        }
    }
}
