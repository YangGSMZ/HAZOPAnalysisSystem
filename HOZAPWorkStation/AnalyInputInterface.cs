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
using HAZOPCommon;
using HOZAPModel;
using HOZAPWorkStation.UserControls;

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

        /// <summary>
        /// 获取Richtextbox里的内容
        /// </summary>
        /// <returns></returns>
        public string GetRichTextBoxContext()
        {
            return this.rtbAnaInputInterface.Text;
        }

        private void AnalyInputInterface_Load(object sender, EventArgs e)
        {
            AnalyInputInterface_DataBind();
        }

        /// <summary>
        /// 根据传递过来的列的索引绑定数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnalyInputInterface_DataBind()
        {
            if (ReceiveEventE.ColumnIndex == 3)
            {
                this.Text = "偏离描述录入界面";
            }
            //绑定原因，列表里对应“原因”列
            if (ReceiveEventE.ColumnIndex == 4)
            {
                ReasonDataBind();
                this.Text = "原因录入界面";
            }
            //绑定后果，列表里对应“后果”列
            if (ReceiveEventE.ColumnIndex == 6)
            {
                ConsequenceDataBind();
                this.Text = "后果录入界面";
            }
            //绑定措施，列表里对应“现有措施”列
            if (ReceiveEventE.ColumnIndex == 10)
            {
                MeasureDataBind();
                this.Text = "措施录入界面";
            }

            if (ReceiveEventE.ColumnIndex == 15)
            {
                this.Text = "建议项录入界面";
            }

            if (ReceiveEventE.ColumnIndex == 16)
            {
                this.Text = "负责人录入界面";
                this.tbcAnalyInputInterface.Enabled = false;
                this.btnAnalyInputAdd.Enabled = false;
                this.btnAnalyInputDelete.Enabled = false;
                this.rtbAnaInputInterface.Text = "请在这里录入负责人";
            }

            if (ReceiveEventE.ColumnIndex == 17)
            {
                this.Text = "备注录入界面";
                this.tbcAnalyInputInterface.Enabled = false;
                this.btnAnalyInputAdd.Enabled = false;
                this.btnAnalyInputDelete.Enabled = false;
                this.rtbAnaInputInterface.Text = "请在这里录入备注";
            }
        }

        private void MeasureDataBind()
        {
            MeasureBLL measureBLL = new MeasureBLL();
            if (ReceiveSelectedTreeNode != null)
            {
                int id = Convert.ToInt32(ReceiveSelectedTreeNode.Tag);
                List<DisplayMeasure> measureList = measureBLL.Get_MeasuresList(id);
                this.dgvTbcPageAnaExpert.AutoGenerateColumns = false;
                this.dgvTbcPageAnaExpert.Columns["Records"].DataPropertyName = "MessureText";
                this.dgvTbcPageAnaExpert.DataSource = measureList;
            }
        }

        /// <summary>
        /// 绑定后果数据库
        /// </summary>
        private void ConsequenceDataBind()
        {
            ConsequenceBLL consequenceBLL = new ConsequenceBLL();
            if (ReceiveSelectedTreeNode != null)
            {
                int id = Convert.ToInt32(ReceiveSelectedTreeNode.Tag);
                List<DisplayConsequence> consequenceList = consequenceBLL.Get_ConsequenceList(id);
                this.dgvTbcPageAnaExpert.AutoGenerateColumns = false;
                this.dgvTbcPageAnaExpert.Columns["Records"].DataPropertyName = "ConseqText";
                this.dgvTbcPageAnaExpert.DataSource = consequenceList;
            }
        }

        /// <summary>
        /// 绑定原因库
        /// </summary>
        private void ReasonDataBind()
        {
            IntroducerBLL introducerbll = new IntroducerBLL();
            ReasonBLL reasonBLL = new ReasonBLL();
            if (ReceiveSelectedTreeNode != null)
            {
                int id = Convert.ToInt32(ReceiveSelectedTreeNode.Tag);
                List<DisplayReasons> reasonsList = reasonBLL.Get_ReasonsList(id);
                this.dgvTbcPageAnaExpert.AutoGenerateColumns = false;
                this.dgvTbcPageAnaExpert.Columns["Records"].DataPropertyName = "ReasonText";
                this.dgvTbcPageAnaExpert.DataSource = reasonsList;
            }
        }

        /// <summary>
        /// 获取鼠标在分析表中的选择的表格单元
        /// </summary>
        public DataGridViewCellEventArgs ReceiveEventE
        {
            set;
            get;
        }

        /// <summary>
        /// 接收选中的节点
        /// </summary>
        public TreeNode ReceiveSelectedTreeNode
        {
            set;
            get;
        }

        /// <summary>
        /// 确定按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnalyInputEntry_Click(object sender, EventArgs e)
        {
            if (this.RefreshParent != null)
            {
                //将该窗体传递到用户控件才能捕获该窗体里的数据
                this.RefreshParent(this, null);
            }
            this.Close();
        }

        /// <summary>
        /// 单击选中专家经验库里的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTbcPageAnaExpert_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.rtbAnaInputInterface.Text = this.dgvTbcPageAnaExpert.SelectedCells[0].Value.ToString();
        }
    }
}
