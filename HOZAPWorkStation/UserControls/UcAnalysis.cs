using HAZOPBLL;
using HAZOPCommon;
using HOZAPBLL;
using HOZAPModel;
using System;
using System.Collections.Generic;
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
                            List<Introducer> Introducerlist = ibll.Get_IntroducerList(sp[j].PramasId);
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
            }
        }

        private void UcAnalysis_Load(object sender, System.EventArgs e)
        {
            CreateTree();
        }

        /// <summary>
        /// TreeView选中节点后发生，子节点数为0，判断为叶子节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        List<Introducer> dgvComboxDataintroducersList;
        private void trvUcAnaly_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView treeView = sender as TreeView;
            //记录选择节点的ID，如果是参数ID，在绑定引导词的时候会用到
            this.dgvCcAnalys1.Tag = treeView.SelectedNode.Tag;
            //选中项目名称则清空数据显示，且“参数”列不可见
            if (treeView!=null&&treeView.SelectedNode.Level == 0)
            {
                dgvCcAnalys1.Columns["dgcCcAnalyParams"].Visible = false;
                dgvCcAnalys1.DataSource = null;
            }
            //选中叶子节点即引导词，绑定引导词数据，且“参数”列不可见
            if (treeView != null && treeView.SelectedNode.Level == 3)
            {
                dgvCcAnalys1.Columns["dgcCcAnalyParams"].Visible = false;
                //绑定除combox之外的列
                dgvCcAnalys1.DataSource = DataBindIntroduce();
                //单独绑定会变化的combox，选项固定的combox固定

            }
            //选中参数节点，绑定参数下所有引导词数据，且“参数”列不可见
            //此时，“参数+引导词”列才能选择，绑定数据源
            if (treeView != null && treeView.SelectedNode.Level == 2)
            {
                dgvCcAnalys1.Columns["dgcCcAnalyParamsAndIntro"].ReadOnly = false;
                dgvCcAnalys1.Columns["dgcCcAnalyParams"].Visible = false;
                //绑定“参数+引导词”列
                IntroducerBLL introducerBLL = new IntroducerBLL();
                int id = Convert.ToInt32(this.dgvCcAnalys1.Tag);
                dgvComboxDataintroducersList = introducerBLL.Get_IntroducerList(id);
                //绑定除combox之外的列

            }
            else
            {
                dgvCcAnalys1.Columns["dgcCcAnalyParamsAndIntro"].ReadOnly = false;
            }
            //选中节点 节点，绑定节点下所有参数引导词数据，且“参数”列可见
            if (treeView != null && treeView.SelectedNode.Level == 1)
            {
                dgvCcAnalys1.Columns["dgcCcAnalyParams"].Visible = true;
                //绑定除combox之外的列

                //单独绑定会变化的combox，选项固定的combox固定

            }
        }

        /// <summary>
        /// 绑定选择叶子节点引导词的数据,但是不包括combox的绑定
        /// </summary>
        /// <returns></returns>
        private List<DisplayAnalysisResult> DataBindIntroduce()
        {
            List<DisplayAnalysisResult> list = new List<DisplayAnalysisResult>();
            list = null;
            return list;
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
                    DataGridViewComboBoxCell combox = this.dgvCcAnalys1.Rows[e.RowIndex].Cells["dgcCcAnalyParamsAndIntro"] as DataGridViewComboBoxCell;
                    combox.Items.Clear();
                    if (dgvComboxDataintroducersList!=null&&dgvComboxDataintroducersList.Count>0)
                    {
                        for (int i = 0; i < dgvComboxDataintroducersList.Count; i++)
                        {
                            combox.Items.Add(dgvComboxDataintroducersList[i].IntroducerText);
                        }
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
        }

        private void UcAnalyLevel_TranferToSx(object sender, DataGridViewCellEventArgs e)
        {
            UcAnalyLevel ucAnalyLevel = (UcAnalyLevel)(sender);
            e = ClickEventE;
            this.dgvCcAnalys1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ucAnalyLevel.GetSelectedContext();
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
    }
}
