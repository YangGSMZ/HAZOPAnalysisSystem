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
                this.tbcAnalyInputInterface.Enabled = false;
                this.btnAnalyInputAdd.Enabled = false;
                this.btnAnalyInputDelete.Enabled = false;
                this.rtbAnaInputInterface.Text = "请在这里录入偏离描述";
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
                this.tbcAnalyInputInterface.Enabled = false;
                this.btnAnalyInputAdd.Enabled = false;
                this.btnAnalyInputDelete.Enabled = false;
                this.rtbAnaInputInterface.Text = "请在这里录入建议项";
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
                this.dgvTbcPageAnaExpert.Columns["Records"].DataPropertyName = "MeasureText";
                this.dgvTbcPageAnaExpert.DataSource = measureList;

                List<DisplayMeasure> personalMeasureList = measureBLL.Get_PersonalMeasure(id);
                this.dgvTbcPageAnaPersonal.AutoGenerateColumns = false;
                this.dgvTbcPageAnaPersonal.Columns["RecordPersonal"].DataPropertyName = "MeasureText";
                this.dgvTbcPageAnaPersonal.DataSource = personalMeasureList;
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
                this.dgvTbcPageAnaExpert.Columns["Records"].DataPropertyName = "ConsquenceText";
                this.dgvTbcPageAnaExpert.DataSource = consequenceList;

                List<DisplayConsequence> personalconsequenceList = consequenceBLL.Get_PersonalConsequence(id);
                this.dgvTbcPageAnaPersonal.AutoGenerateColumns = false;
                this.dgvTbcPageAnaPersonal.Columns["RecordPersonal"].DataPropertyName = "ConsquenceText";
                this.dgvTbcPageAnaPersonal.DataSource = personalconsequenceList;

            }
        }

        /// <summary>
        /// 绑定原因库
        /// </summary>
        private void ReasonDataBind()
        {
            ReasonBLL reasonBLL = new ReasonBLL();
            if (ReceiveSelectedTreeNode != null)
            {
                int id = Convert.ToInt32(ReceiveSelectedTreeNode.Tag);
                if (id == 2)
                {
                    id = 1;
                }
                List<DisplayReasons> reasonsList = reasonBLL.Get_ReasonsList(id);
                this.dgvTbcPageAnaExpert.AutoGenerateColumns = false;
                this.dgvTbcPageAnaExpert.Columns["Records"].DataPropertyName = "ReasonText";
                this.dgvTbcPageAnaExpert.DataSource = reasonsList;

                List<DisplayReasons> personalreasonsList = reasonBLL.Get_personalReasons(id);
                this.dgvTbcPageAnaPersonal.AutoGenerateColumns = false;
                this.dgvTbcPageAnaPersonal.Columns["RecordPersonal"].DataPropertyName = "ReasonText";
                this.dgvTbcPageAnaPersonal.DataSource = personalreasonsList;
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
        /// <summary>
        /// 添加到个人经验库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnalyInputAdd_Click(object sender, EventArgs e)
        {
            if (this.Text == "后果录入界面")
            {
                ConsequenceBLL bll = new ConsequenceBLL();
                Conqeq conseq = new Conqeq();
                conseq.ConseqText = this.rtbAnaInputInterface.Text.Trim();
                conseq.Type = 2;
                conseq.Introdrucer = Convert.ToInt32(ReceiveSelectedTreeNode.Tag);
                bll.Add_Consequence(conseq);
                this.rtbAnaInputInterface.Text = String.Empty;
                ConsequenceDataBind();
            }

            if (this.Text == "原因录入界面")
            {
                ReasonBLL bll = new ReasonBLL();
                DisplayReasons reason = new DisplayReasons();
                reason.ReasonText= this.rtbAnaInputInterface.Text.Trim();
                reason.Type = 2;
                reason.IntroducerId= Convert.ToInt32(ReceiveSelectedTreeNode.Tag);
                bll.Add_Reason(reason);
                this.rtbAnaInputInterface.Text = String.Empty;
                ReasonDataBind();
            }

            if (this.Text == "措施录入界面")
            {
                MeasureBLL bll = new MeasureBLL();
                Messure messure = new Messure();
                messure.MessureText = this.rtbAnaInputInterface.Text.Trim();
                messure.Type = 2;
                messure.IntroducerId = Convert.ToInt32(ReceiveSelectedTreeNode.Tag);
                bll.Add_Messure(messure);
                this.rtbAnaInputInterface.Text = String.Empty;
                MeasureDataBind();
            }
        }

        private void dgvTbcPageAnaPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.rtbAnaInputInterface.Text = this.dgvTbcPageAnaPersonal.SelectedCells[0].Value.ToString();
        }
        /// <summary>
        /// 删除个人经验库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnalyInputDelete_Click(object sender, EventArgs e)
        {
            if (this.Text == "后果录入界面")
            {
                ConsequenceBLL bll = new ConsequenceBLL();
                if (this.dgvTbcPageAnaPersonal.SelectedRows.Count > 0)
                {
                    bll.DeletePersonalConseqence(Convert.ToInt32(this.dgvTbcPageAnaPersonal.SelectedRows[0].Cells[1].Value));
                    this.rtbAnaInputInterface.Text = String.Empty;
                    ConsequenceDataBind();
                }
            }

            if (this.Text == "原因录入界面")
            {
                ReasonBLL bll = new ReasonBLL();
                if (this.dgvTbcPageAnaPersonal.SelectedRows.Count > 0)
                {
                    bll.DeletePersonalReason(Convert.ToInt32(this.dgvTbcPageAnaPersonal.SelectedRows[0].Cells[1].Value));
                    this.rtbAnaInputInterface.Text = String.Empty;
                    ReasonDataBind();
                }
            }

            if (this.Text == "措施录入界面")
            {
                MeasureBLL bll = new MeasureBLL();
                if (this.dgvTbcPageAnaPersonal.SelectedRows.Count > 0)
                {
                    bll.DeletePersonalMeasure(Convert.ToInt32(this.dgvTbcPageAnaPersonal.SelectedRows[0].Cells[1].Value));
                    this.rtbAnaInputInterface.Text = String.Empty;
                    MeasureDataBind();
                }
            }
        }
    }
}
