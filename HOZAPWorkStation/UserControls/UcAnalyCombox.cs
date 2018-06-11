using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HAZOPBLL;
using HOZAPModel;

namespace HOZAPWorkStation.UserControls
{
    public partial class UcAnalyCombox : Form
    {
        public UcAnalyCombox()
        {
            InitializeComponent();
        }
        private static UcAnalyCombox _instance;
        //创建窗体对象的静态方法
        public static UcAnalyCombox InstanceObject()
        {
            if (_instance == null)
                _instance = new UcAnalyCombox();
            return _instance;
        }
        public event Action<object, DataGridViewCellEventArgs> TransferToCombox;

        /// <summary>
        /// 接收选中的节点
        /// </summary>
        public string ReceiveSelectedTreeNode
        {
            set;
            get;
        }

        public string GetBoxContext()
        {
            return this.dataGridView1.SelectedCells[0].Value.ToString();
        }

        private void UcAnalyCombox_Load(object sender, EventArgs e)
        {
            UcAnalyCombox_DataBind();
        }

        private void UcAnalyCombox_DataBind()
        {
            IntroducerBLL introducerBLL = new IntroducerBLL();
            if (ReceiveSelectedTreeNode!=null)
            {
                int id = Convert.ToInt32(ReceiveSelectedTreeNode);
                List<Introducer> introducerList = introducerBLL.Get_IntroducerList(id);
                this.dataGridView1.Columns["Column1"].DataPropertyName = "IntroducerText";
                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.DataSource = introducerList;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.TransferToCombox != null)
            {
                this.TransferToCombox(this, null);
            }
            this.Close();
        }

        private void UcAnalyCombox_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
    }
}
