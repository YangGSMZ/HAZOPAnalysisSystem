using HAZOPBLL;
using HAZOPCommon;
using HOZAPBLL;
using HOZAPDAL;
using HOZAPModel;
using HOZAPWorkStation.ExportExcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace HOZAPWorkStation.UserControls
{
    public partial class UcAnalysis : UserControl
    {
        public UcAnalysis()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 创建TreeView
        /// </summary>
        private void CreateTree()
        {
            TreeNode root = new TreeNode();
            root.Text = InitialInterface.ProName;
            trvUcAnaly.Nodes.Add(root);
            SelectedPramasBLL spbll = new SelectedPramasBLL();
            IntroducerBLL ibll = new IntroducerBLL();
            NodeBLL nbll = new NodeBLL();
            List<Node> nodelist = nbll.Get_NodeList(InitialInterface.ProName);
            List<SelectedPramas> sp = spbll.Get_SelectedPramasList(InitialInterface.ProName);
            if (nodelist != null)
            {
                for (int i = 0; i < nodelist.Count; i++)
                {
                    TreeNode node1 = new TreeNode();
                    node1.Text = nodelist[i].NodeName;
                    node1.Tag = nodelist[i].NodeId;
                    root.Nodes.Add(node1);
                    if (sp != null)
                    {
                        for (int j = 0; j < sp.Count; j++)
                        {
                            TreeNode node2 = new TreeNode();
                            node2.Text = sp[j].PramasText;
                            node2.Tag = sp[j].PramasId;
                            node1.Nodes.Add(node2);
                            List<HOZAPModel.Introducer> Introducerlist = ibll.Get_IntroducerList(sp[j].PramasId);
                            for (int k = 0; k < Introducerlist.Count; k++)
                            {
                                TreeNode node3 = new TreeNode();
                                node3.Text = Introducerlist[k].IntroducerText;
                                node3.Tag = Introducerlist[k].IntroducerId;
                                node2.Nodes.Add(node3);
                            }
                        }
                    }
                }
                this.trvUcAnaly.Nodes[0].Expand();
            }
        }

        private void UcAnalysis_SLRColor()
        {
            int count = 0;
            if (this.trvUcAnaly.SelectedNode.Level == 2)
            {
                count = this.dgvCcAnalys1.RowCount - 1;
            }
            else
            {
                count = this.dgvCcAnalys1.RowCount;
            }
            for (int i = 0; i < count; i++)
            {
                if (dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyRi"].Value.ToString() == "A")
                {
                    dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyRi"].Style.BackColor = Color.Red;
                }

                if (dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyRi"].Value.ToString() == "B")
                {
                    dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyRi"].Style.BackColor = Color.Orange;
                }

                if (dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyRi"].Value.ToString() == "C")
                {
                    dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyRi"].Style.BackColor = Color.Yellow;
                }

                if (dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyRi"].Value.ToString() == "D")
                {
                    dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyRi"].Style.BackColor = Color.LightBlue;
                }

                if (dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyRi"].Value.ToString() == "E")
                {
                    dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyRi"].Style.BackColor = Color.Green;
                }
            }
        }

        private void UcAnalysis_Load(object sender, System.EventArgs e)
        {
            CreateTree();
        }

        private void AfterSaveBinding(object sender, TreeViewEventArgs e)
        {
            TreeView treeView = sender as TreeView;

            AnalyResultBLL analyResultBLL = new AnalyResultBLL();
            dgvCcAnalys1.AutoGenerateColumns = false;
            //记录选择节点的ID，如果是参数ID，在绑定引导词的时候会用到
            if (treeView.SelectedNode.Level > 0)
            {
                this.trvUcAnaly.Tag = treeView.SelectedNode.Tag;
            }
            string selectedParam = treeView.SelectedNode.Text;


            //选中项目名称则清空数据显示，且“参数”列不可见
            if (treeView.SelectedNode.Level == 0)
            {
                dgvCcAnalys1.Columns["dgcCcAnalyParams"].Visible = false;
                if (dgvCcAnalys1.AllowUserToAddRows == true)
                {
                    dgvCcAnalys1.AllowUserToAddRows = false;
                }
                //空数据源
                List<AnalysResultTotal> resultList = new List<AnalysResultTotal>();
                dgvCcAnalys1.DataSource = new BindingList<AnalysResultTotal>(resultList);
                
            }

            //选中节点 节点，绑定节点下所有参数引导词数据，且“参数”列可见
            //此时，“参数+引导词”列只读
            if (treeView.SelectedNode.Level == 1)
            {
                if (dgvCcAnalys1.Columns["dgcCcAnalyParams"].Visible == false)
                {
                    dgvCcAnalys1.Columns["dgcCcAnalyParams"].Visible = true;
                }
                if (dgvCcAnalys1.Columns["dgcCcAnalyParamsAndIntro"].ReadOnly == false)
                {
                    dgvCcAnalys1.Columns["dgcCcAnalyParamsAndIntro"].ReadOnly = true;
                }
                if (dgvCcAnalys1.AllowUserToAddRows == true)
                {
                    dgvCcAnalys1.AllowUserToAddRows = false;
                }
                List<AnalysResultTotal> resultList = analyResultBLL.Get_All(InitialInterface.ProName, this.trvUcAnaly.SelectedNode.Text);
                if (resultList == null)
                {
                    resultList = new List<AnalysResultTotal>();
                }
                dgvCcAnalys1.DataSource = new BindingList<AnalysResultTotal>(resultList);
                UcAnalysis_SLRColor();
            }

            //选中参数节点，绑定参数下所有引导词数据，且“参数”列不可见
            //此时，“参数+引导词”列才能选择，绑定数据源
            if (treeView.SelectedNode.Level == 2)
            {
                if (dgvCcAnalys1.Columns["dgcCcAnalyParamsAndIntro"].ReadOnly == true)
                {
                    dgvCcAnalys1.Columns["dgcCcAnalyParamsAndIntro"].ReadOnly = false;
                }
                if (dgvCcAnalys1.Columns["dgcCcAnalyParams"].Visible == true)
                {
                    dgvCcAnalys1.Columns["dgcCcAnalyParams"].Visible = false;
                }
                if (dgvCcAnalys1.AllowUserToAddRows == false)
                {
                    dgvCcAnalys1.AllowUserToAddRows = true;
                }
                List<AnalysResultTotal> resultList = analyResultBLL.Get_Params(InitialInterface.ProName,selectedParam,this.trvUcAnaly.SelectedNode.Parent.Text);
                if (resultList == null)
                {
                    resultList = new List<AnalysResultTotal>();
                }
                dgvCcAnalys1.DataSource = new BindingList<AnalysResultTotal>(resultList);
                UcAnalysis_SLRColor();
            }
            //选中叶子节点即引导词，绑定引导词数据，且“参数”列不可见
            if (treeView.SelectedNode.Level == 3)
            {
                if (dgvCcAnalys1.Columns["dgcCcAnalyParams"].Visible == true)
                {
                    dgvCcAnalys1.Columns["dgcCcAnalyParams"].Visible = false;
                }
                if (dgvCcAnalys1.AllowUserToAddRows == true)
                {
                    dgvCcAnalys1.AllowUserToAddRows = false;
                }
                dgvCcAnalys1.Columns["dgcCcAnalyParams"].Visible = false;
                dgvCcAnalys1.Columns["dgcCcAnalyParamsAndIntro"].ReadOnly = true;
                List<AnalysResultTotal> resultList = analyResultBLL.Get_Introduces(InitialInterface.ProName, selectedParam,this.trvUcAnaly.SelectedNode.Parent.Parent.Text);
                if (resultList == null)
                {
                    resultList = new List<AnalysResultTotal>();
                }
                dgvCcAnalys1.DataSource = new BindingList<AnalysResultTotal>(resultList);
                UcAnalysis_SLRColor();
            }
        }

        /// <summary>
        /// TreeView选中节点后发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //List<Introducer> dgvComboxDataintroducersList;
        private void trvUcAnaly_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeViewSelected = sender;
            TreeViewSelectedE = e;
            AfterSaveBinding(sender, e);
        }

        private void UcAnalyCombox_TransferToCombox(object sender, DataGridViewCellEventArgs e)
        {
            UcAnalyCombox ucAnalyCombox = (UcAnalyCombox)(sender);
            e = ClickEventE;
            this.dgvCcAnalys1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ucAnalyCombox.GetBoxContext();
        }

        /// <summary>
        ///窗体和用户控件之间传递数据 
        /// </summary>
        /// <param name="sender">需要传递数据的窗体</param>
        private void AnalyInputInterface_RefreshParent(object sender, DataGridViewCellEventArgs e)
        {
            //强制转化传递过来的输入窗体类型
            AnalyInputInterface analyInputInterface = (AnalyInputInterface)(sender);
            e = ClickEventE;
            Refresh(analyInputInterface,e);
        }
        /// <summary>
        /// 实施刷新用户控件中的datagridview数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refresh(object sender, DataGridViewCellEventArgs e)
        {
            AnalyInputInterface analyInputInterface = (AnalyInputInterface)(sender);
            this.dgvCcAnalys1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = analyInputInterface.GetRichTextBoxContext();
        }
        /// <summary>
        /// datagridview双击弹出录入对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCcAnalys1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==3|| e.ColumnIndex == 4|| e.ColumnIndex == 6|| e.ColumnIndex == 10|| e.ColumnIndex == 15|| e.ColumnIndex == 16|| e.ColumnIndex == 17)
            {
                AnalyInputInterface analyInputInterface = new AnalyInputInterface();
                //订阅事件
                analyInputInterface.RefreshParent += new System.Action<object, DataGridViewCellEventArgs>(AnalyInputInterface_RefreshParent);
                ClickEventE = e;
                analyInputInterface.ReceiveEventE = e;
                analyInputInterface.ReceiveSelectedTreeNode = this.trvUcAnaly.SelectedNode;
                analyInputInterface.Show();
            }
        }
        /// <summary>
        /// 获取双击事件e
        /// </summary>
        public DataGridViewCellEventArgs ClickEventE
        {
            set;
            get;
        }

        /// <summary>
        /// datagridview单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCcAnalys1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //选中“参数+引导词”
                if (e.ColumnIndex == 2)
                {
                    if (this.trvUcAnaly != null && this.trvUcAnaly.SelectedNode.Level == 2)
                    {
                        UcAnalyCombox ucAnalyCombox = new UcAnalyCombox();
                        //订阅事件
                        ClickEventE = e;
                        ucAnalyCombox.TransferToCombox += new System.Action<object, DataGridViewCellEventArgs>(UcAnalyCombox_TransferToCombox);
                        ucAnalyCombox.ReceiveSelectedTreeNode = this.trvUcAnaly.Tag.ToString();
                        ucAnalyCombox.Show();
                    } 
                }
                //选中F0
                if (e.ColumnIndex==5)
                {
                    UcAnalyProbility ucAnalyProbility = new UcAnalyProbility();
                    ucAnalyProbility.Text = "F0";
                    //订阅事件
                    ucAnalyProbility.TransferToFx += new System.Action<object, DataGridViewCellEventArgs>(UcAnalyProbility_TranferToFx);
                    ClickEventE = e;
                    ucAnalyProbility.Show();
                }
                //选中Fs
                if (e.ColumnIndex == 11)
                {
                    UcAnalyProbility ucAnalyProbility = new UcAnalyProbility();
                    ucAnalyProbility.Text = "Fs";
                    //订阅事件
                    ucAnalyProbility.TransferToFx += new System.Action<object, DataGridViewCellEventArgs>(UcAnalyProbility_TranferToFx);
                    ClickEventE = e;
                    ucAnalyProbility.Show();
                }
                //选中Si
                if (e.ColumnIndex == 7)
                {
                    UcAnalyLevel ucAnalyLevel = new UcAnalyLevel();
                    ucAnalyLevel.Text = "Si";
                    //订阅事件
                    ucAnalyLevel.TransferToSx += new System.Action<object, DataGridViewCellEventArgs>(UcAnalyLevel_TranferToSx);
                    ClickEventE = e;
                    ucAnalyLevel.Show();
                }
                //选中S
                if (e.ColumnIndex == 12)
                {
                    UcAnalyLevel ucAnalyLevel =new UcAnalyLevel();
                    ucAnalyLevel.Text = "S";
                    //订阅事件
                    ucAnalyLevel.TransferToSx += new System.Action<object, DataGridViewCellEventArgs>(UcAnalyLevel_TranferToSx);
                    ClickEventE = e;
                    ucAnalyLevel.Show();
                }

                //选中Li
                if (e.ColumnIndex == 8)
                {
                    UcAnalsFrequency ucAnalsFrequency = new UcAnalsFrequency();
                    ucAnalsFrequency.Text = "Li";
                    //订阅事件
                    ucAnalsFrequency.TransferToLx += new System.Action<object, DataGridViewCellEventArgs>(UcAnalsFrequency_TranferToLx);
                    ClickEventE = e;
                    ucAnalsFrequency.Show();
                }

                //选中L
                if (e.ColumnIndex == 13)
                {
                    UcAnalsFrequency ucAnalsFrequency = new UcAnalsFrequency();
                    ucAnalsFrequency.Text = "L";
                    //订阅事件
                    ucAnalsFrequency.TransferToLx += new System.Action<object, DataGridViewCellEventArgs>(UcAnalsFrequency_TranferToLx);
                    ClickEventE = e;
                    ucAnalsFrequency.Show();
                }
            }
        }

        private void UcAnalsFrequency_TranferToLx(object sender, DataGridViewCellEventArgs e)
        {
            UcAnalsFrequency ucAnalsFrequency = (UcAnalsFrequency)(sender);
            e = ClickEventE;
            this.dgvCcAnalys1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ucAnalsFrequency.GetSelectedContext();
            if (e.ColumnIndex == 8)
            {
                string SiText = this.dgvCcAnalys1.Rows[e.RowIndex].Cells[7].Value.ToString();
                if (SiText.Length > 0)
                {
                    string slStr ="Ri"+ SiText + this.dgvCcAnalys1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    SetRiValue(slStr, e);
                }
            }
            if (e.ColumnIndex == 13)
            {
                string SText = this.dgvCcAnalys1.Rows[e.RowIndex].Cells[12].Value.ToString();
                if (SText.Length > 0)
                {
                    string slStr ="R"+ SText + this.dgvCcAnalys1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    SetRiValue(slStr, e);
                }
            }
        }

        private void UcAnalyLevel_TranferToSx(object sender, DataGridViewCellEventArgs e)
        {
            UcAnalyLevel ucAnalyLevel = (UcAnalyLevel)(sender);
            e = ClickEventE;
            this.dgvCcAnalys1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ucAnalyLevel.GetSelectedContext();
            if (e.ColumnIndex == 7)
            {
                string liText = this.dgvCcAnalys1.Rows[e.RowIndex].Cells[8].Value.ToString();
                if (liText.Length>0)
                {
                    string slStr = "Ri"+this.dgvCcAnalys1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + liText;
                    SetRiValue(slStr,e);
                }
            }
            if (e.ColumnIndex == 12)
            {
                string lText = this.dgvCcAnalys1.Rows[e.RowIndex].Cells[13].Value.ToString();
                if (lText.Length > 0)
                {
                    string slStr = "R"+this.dgvCcAnalys1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + lText;
                    SetRiValue(slStr, e);
                }
            }
        }

        /// <summary>
        /// 设置Ri
        /// </summary>
        private void SetRiValue(string slStr, DataGridViewCellEventArgs e)
        {
            switch (slStr)
            {
                #region Ri
                //一列一行
                case "Ri11":this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "D";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.LightBlue;
                    break;
                case "Ri21":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "C";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Yellow;
                    break;
                case "Ri31":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "B";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Orange;
                    break;
                case "Ri41":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "B";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Orange;
                    break;
                case "Ri51":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "A";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Red;
                    break;

                //1列2行
                case "Ri12":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Green;
                    break;
                case "Ri22":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "D";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.LightBlue;
                    break;
                case "Ri32":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "C";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Yellow;
                    break;
                case "Ri42":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "B";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Orange;
                    break;
                case "Ri52":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "B";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Orange;
                    break;

                //1列3行
                case "Ri13":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Green;
                    break;
                case "Ri23":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Green;
                    break;
                case "Ri33":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "D";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.LightBlue;
                    break;
                case "Ri43":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "C";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Yellow;
                    break;
                case "Ri53":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "B";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Orange;
                    break;

                //1列4行
                case "Ri14":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Green;
                    break;
                case "Ri24":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Green;
                    break;
                case "Ri34":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Green;
                    break;
                case "Ri44":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "D";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.LightBlue;
                    break;
                case "Ri54":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "C";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Orange;
                    break;

                //5列1行
                case "Ri15":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Green;
                    break;
                case "Ri25":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Green;
                    break;
                case "Ri35":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Green;
                    break;
                case "Ri45":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Green;
                    break;
                case "Ri55":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Value = "D";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.LightBlue;
                    break;
                #endregion

                #region R
                //一列一行
                case "R11":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "D";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.LightBlue;
                    break;
                case "R21":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "C";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Yellow;
                    break;
                case "R31":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "B";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Orange;
                    break;
                case "R41":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "B";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Orange;
                    break;
                case "R51":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "A";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Red;
                    break;

                //1列2行
                case "R12":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Green;
                    break;
                case "R22":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "D";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.LightBlue;
                    break;
                case "R32":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "C";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Yellow;
                    break;
                case "R42":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "B";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Orange;
                    break;
                case "R52":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "B";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Orange;
                    break;

                //1列3行
                case "R13":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Green;
                    break;
                case "R23":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Green;
                    break;
                case "R33":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "D";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.LightBlue;
                    break;
                case "R43":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "C";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Yellow;
                    break;
                case "R53":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "B";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Orange;
                    break;

                //1列4行
                case "R14":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Green;
                    break;
                case "R24":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Green;
                    break;
                case "R34":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Green;
                    break;
                case "R44":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "D";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.LightBlue;
                    break;
                case "R54":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "C";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Orange;
                    break;

                //5列1行
                case "R15":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Green;
                    break;
                case "R25":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Green;
                    break;
                case "R35":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Green;
                    break;
                case "R45":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "E";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Green;
                    break;
                case "R55":
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Value = "D";
                    this.dgvCcAnalys1.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.LightBlue;
                    break;
                #endregion
                default: break;
            }
        }

        private void UcAnalyProbility_TranferToFx(object sender, DataGridViewCellEventArgs e)
        {
            UcAnalyProbility ucAnalyProbility = (UcAnalyProbility)(sender);
            e = ClickEventE;
            this.dgvCcAnalys1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ucAnalyProbility.GetSelectedContext();
        }

        /// <summary>
        /// 解决给combox列绑定数据源报错
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCcAnalys1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        /// <summary>
        ///  /// <summary>
        /// 解决给绑定数据源报错
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rowMergeView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspUcAnalyOutPut_ButtonClick(object sender, EventArgs e)
        {
            ExportToExcel.DataGridViewToExcel(this.dgvCcAnalys1);
        }

        private void tspUcAnalyDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvCcAnalys1.SelectedRows.Count > 0)
            {
                AnalyResultBLL analyResultBLL = new AnalyResultBLL();
                string sqlString = "delete from tb_AnalysisResult where ProName=@ProName and RecordNumver=@RecordNumver;";
                SqlParameter[] pms =
                {
                new SqlParameter("@ProName",SqlDbType.VarChar),
                new SqlParameter("@RecordNumver",SqlDbType.VarChar),
            };
                pms[0].Value = InitialInterface.ProName;
                pms[1].Value = this.dgvCcAnalys1.SelectedRows[0].Cells[0].Value.ToString();
                SqlHelper.ExecuteNonQuery(sqlString, pms);
                List<AnalysResultTotal> analysResultTotals = new List<AnalysResultTotal>();
                analysResultTotals = analyResultBLL.Get_All(InitialInterface.ProName,this.trvUcAnaly.SelectedNode.Text);
                this.dgvCcAnalys1.DataSource = analysResultTotals;
            }  
        }
        public bool SaveContent()
        {
            bool flag = false;
            List<AnalysResultTotal> analysResultTotalsInfo = new List<AnalysResultTotal>();
            List<int> ResuletID = new List<int>(); ;
            AnalyResultBLL analyResultBLL = new AnalyResultBLL();
            if (this.trvUcAnaly.SelectedNode.Level == 2)
            {
                #region 
                if (dgvCcAnalys1.Rows.Count > 1)
                {
                    for (int i = 0; i < dgvCcAnalys1.Rows.Count - 1; i++)
                    {
                        AnalysResultTotal AnalysResultTotal = new AnalysResultTotal();
                        AnalysResultTotal.ProjectName = InitialInterface.ProName;
                        AnalysResultTotal.RecordName = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyNum"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyNum"].Value.ToString();
                        AnalysResultTotal.Pramas = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyParams"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyParams"].Value.ToString();
                        if (AnalysResultTotal.Pramas.Length == 0)
                        {
                            if (this.trvUcAnaly.SelectedNode.Level == 2)
                            {
                                AnalysResultTotal.Pramas = this.trvUcAnaly.SelectedNode.Text;
                            }
                        }
                        AnalysResultTotal.PramasAndIntroduce = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyParamsAndIntro"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyParamsAndIntro"].Value.ToString();
                        AnalysResultTotal.DeviateDescription = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyDesc"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyDesc"].Value.ToString();
                        AnalysResultTotal.Reason = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyReason"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyReason"].Value.ToString();
                        AnalysResultTotal.F0 = "";
                        AnalysResultTotal.Consequence = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyConseq"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyConseq"].Value.ToString();
                        AnalysResultTotal.Si = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalySi"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalySi"].Value.ToString();
                        AnalysResultTotal.Li = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyLi"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyLi"].Value.ToString();
                        AnalysResultTotal.Ri = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyRi"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyRi"].Value.ToString();
                        AnalysResultTotal.Measure = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyMessure"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyMessure"].Value.ToString();
                        AnalysResultTotal.Fs = "";
                        AnalysResultTotal.S = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyS"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyS"].Value.ToString();
                        AnalysResultTotal.L = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyL"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyL"].Value.ToString();
                        AnalysResultTotal.R = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyR"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyR"].Value.ToString();
                        AnalysResultTotal.Suggestion = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalySugges"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalySugges"].Value.ToString();
                        AnalysResultTotal.Company = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyCompany"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyCompany"].Value.ToString();
                        AnalysResultTotal.Mark = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyMark"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyMark"].Value.ToString();
                        //AnalysResultTotal.NodeName
                        if (this.trvUcAnaly.SelectedNode.Level == 1)
                        {
                            AnalysResultTotal.NodeName = this.trvUcAnaly.SelectedNode.Text;
                        }
                        if (this.trvUcAnaly.SelectedNode.Level == 2)
                        {
                            AnalysResultTotal.NodeName = this.trvUcAnaly.SelectedNode.Parent.Text;
                        }
                        if (this.trvUcAnaly.SelectedNode.Level == 3)
                        {
                            AnalysResultTotal.NodeName = this.trvUcAnaly.SelectedNode.Parent.Parent.Text;
                        }
                        analysResultTotalsInfo.Add(AnalysResultTotal);
                        if (dgvCcAnalys1.Rows[i].Cells["ResultID"].Value != null)
                        {
                            if ((int)dgvCcAnalys1.Rows[i].Cells["ResultID"].Value != 0)
                            {
                                ResuletID.Add((int)dgvCcAnalys1.Rows[i].Cells["ResultID"].Value);
                            }

                        }

                    }

                    if (ResuletID.Count > 0)
                    {
                        if (analyResultBLL.Del_AnalysisResult(ResuletID))
                        {
                            if (analyResultBLL.Add_AnalysisResult(analysResultTotalsInfo))
                            {
                                AfterSaveBinding(TreeViewSelected, TreeViewSelectedE);
                                flag = true;
                            }
                            else
                            {
                                MessageBox.Show("保存失败！");
                            }
                        }

                    }
                    else
                    {
                        if (analysResultTotalsInfo != null)
                        {
                            if (analyResultBLL.Add_AnalysisResult(analysResultTotalsInfo))
                            {
                                AfterSaveBinding(TreeViewSelected, TreeViewSelectedE);
                                flag = true;
                            }
                            else
                            {
                                MessageBox.Show("保存失败！");
                            }
                        }
                    }
                }
                #endregion
            }
            else
            {
                if (dgvCcAnalys1.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvCcAnalys1.Rows.Count; i++)
                    {
                        AnalysResultTotal AnalysResultTotal = new AnalysResultTotal();
                        AnalysResultTotal.ProjectName = InitialInterface.ProName;
                        AnalysResultTotal.RecordName = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyNum"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyNum"].Value.ToString();
                        //AnalysResultTotal.Pramas = this.trvUcAnaly.SelectedNode.Text;
                        AnalysResultTotal.Pramas = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyParams"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyParams"].Value.ToString();
                        AnalysResultTotal.PramasAndIntroduce = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyParamsAndIntro"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyParamsAndIntro"].Value.ToString();
                        AnalysResultTotal.DeviateDescription = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyDesc"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyDesc"].Value.ToString();
                        AnalysResultTotal.Reason = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyReason"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyReason"].Value.ToString();
                        AnalysResultTotal.F0 = "";
                        AnalysResultTotal.Consequence = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyConseq"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyConseq"].Value.ToString();
                        AnalysResultTotal.Si = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalySi"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalySi"].Value.ToString();
                        AnalysResultTotal.Li = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyLi"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyLi"].Value.ToString();
                        AnalysResultTotal.Ri = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyRi"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyRi"].Value.ToString();
                        AnalysResultTotal.Measure = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyMessure"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyMessure"].Value.ToString();
                        AnalysResultTotal.Fs = "";
                        AnalysResultTotal.S = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyS"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyS"].Value.ToString();
                        AnalysResultTotal.L = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyL"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyL"].Value.ToString();
                        AnalysResultTotal.R = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyR"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyR"].Value.ToString();
                        AnalysResultTotal.Suggestion = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalySugges"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalySugges"].Value.ToString();
                        AnalysResultTotal.Company = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyCompany"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyCompany"].Value.ToString();
                        AnalysResultTotal.Mark = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyMark"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyMark"].Value.ToString();
                        //AnalysResultTotal.NodeName
                        if (this.trvUcAnaly.SelectedNode.Level == 1)
                        {
                            AnalysResultTotal.NodeName = this.trvUcAnaly.SelectedNode.Text;
                        }
                        if (this.trvUcAnaly.SelectedNode.Level == 2)
                        {
                            AnalysResultTotal.NodeName = this.trvUcAnaly.SelectedNode.Parent.Text;
                        }
                        if (this.trvUcAnaly.SelectedNode.Level == 3)
                        {
                            AnalysResultTotal.NodeName = this.trvUcAnaly.SelectedNode.Parent.Parent.Text;
                        }
                        analysResultTotalsInfo.Add(AnalysResultTotal);
                        if (dgvCcAnalys1.Rows[i].Cells["ResultID"].Value != null)
                        {
                            if ((int)dgvCcAnalys1.Rows[i].Cells["ResultID"].Value != 0)
                            {
                                ResuletID.Add((int)dgvCcAnalys1.Rows[i].Cells["ResultID"].Value);
                            }

                        }

                    }

                    if (ResuletID.Count > 0)
                    {
                        if (analyResultBLL.Del_AnalysisResult(ResuletID))
                        {
                            if (analyResultBLL.Add_AnalysisResult(analysResultTotalsInfo))
                            {
                                AfterSaveBinding(TreeViewSelected, TreeViewSelectedE);
                                flag = true;
                            }
                            else
                            {
                                MessageBox.Show("保存失败！");
                            }
                        }

                    }
                    else
                    {
                        if (analysResultTotalsInfo != null)
                        {
                            if (analyResultBLL.Add_AnalysisResult(analysResultTotalsInfo))
                            {
                                AfterSaveBinding(TreeViewSelected, TreeViewSelectedE);
                                flag = true;
                            }
                            else
                            {
                                MessageBox.Show("保存失败！");
                            }
                        }
                    }
                }
            }

       
            return flag;
            //List<AnalysResultTotal> analysResultTotals = new List<AnalysResultTotal>();
            //analysResultTotals = analyResultBLL.Get_All(InitialInterface.ProName,this.trvUcAnaly.SelectedNode.Text);
            //this.dgvCcAnalys1.DataSource = analysResultTotals;
        }
        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (SaveContent())
            {
                MessageBox.Show("保存成功");
            }
        }

        /// <summary>
        /// 在更改选中节点之前发生，选中的内容还是上一个节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvUcAnaly_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (this.trvUcAnaly.SelectedNode!=null&&this.trvUcAnaly.SelectedNode.Level == 2)
            {
                SaveContent();
            } 
        }

        public object TreeViewSelected
        {
            set;
            get;
        }

        public TreeViewEventArgs TreeViewSelectedE
        {
            set;
            get;
        }

        private void tspUcAnalyOutPut_Click(object sender, EventArgs e)
        {
            ExportToExcel.DataGridViewToExcel(this.dgvCcAnalys1);
        }
    }
}
