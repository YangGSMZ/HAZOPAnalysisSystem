using HAZOPBLL;
using HOZAPBLL;
using HOZAPModel;
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
                    root.Nodes.Add(node1);
                    if (sp != null)
                    {
                        for (int j = 0; j < sp.Count; j++)
                        {
                            TreeNode node2 = new TreeNode();
                            node2.Text = sp[j].PramasText;
                            node1.Nodes.Add(node2);
                            List<Introducer> Introducerlist = ibll.Get_IntroducerList(sp[j].PramasId);
                            for (int k = 0; k < Introducerlist.Count; k++)
                            {
                                TreeNode node3 = new TreeNode();
                                node3.Text = Introducerlist[k].IntroducerText;
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
        /// 选中节点后发生，子节点数为0，判断为叶子节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvUcAnaly_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if ((sender as TreeView).SelectedNode != null&& (sender as TreeView).SelectedNode.Nodes.Count==0)
            {
                MessageBox.Show(trvUcAnaly.SelectedNode.Text);
            }
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
            //this.dgvCcAnalys1.Rows[0].Cells[1].Value = analyInputInterface.GetRichTextBoxContext();
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
        /// 双击弹出录入对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCcAnalys1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AnalyInputInterface analyInputInterface = new AnalyInputInterface();
            //订阅事件
            analyInputInterface.RefreshParent += new System.Action<object, DataGridViewCellEventArgs>(AnalyInputInterface_RefreshParent);
            ClickEventE = e;
            analyInputInterface.Show();
        }
        /// <summary>
        /// 获取双击事件e
        /// </summary>
        public DataGridViewCellEventArgs ClickEventE
        {
            set;
            get;
        }
    }
}
