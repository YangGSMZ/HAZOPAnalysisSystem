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
            if (dgvCcAnalys1.Rows.Count > 1)
            {
                for (int i = 0; i < dgvCcAnalys1.Rows.Count - 1; i++)
                {
                    AnalysResultTotal AnalysResultTotal = new AnalysResultTotal();
                    AnalysResultTotal.ProjectName = InitialInterface.ProName;
                    AnalysResultTotal.RecordName = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyNum"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyNum"].Value.ToString();
                    AnalysResultTotal.Pramas = this.trvUcAnaly.SelectedNode.Text;
                    //AnalysResultTotal.Pramas = dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyParams"].Value == null ? "" : dgvCcAnalys1.Rows[i].Cells["dgcCcAnalyParams"].Value.ToString();
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
                    AnalysResultTotal.NodeName = this.trvUcAnaly.SelectedNode.Parent.Text;
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
                        AfterSaveBinding(TreeViewSelected,TreeViewSelectedE);
                        flag=true;
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
                            flag=true;
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
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
