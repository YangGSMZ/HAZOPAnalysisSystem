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
            root.Text = "111";
            trvUcAnaly.Nodes.Add(root);
            SelectedPramasBLL spbll = new SelectedPramasBLL();
            IntroducerBLL ibll = new IntroducerBLL();
            NodeBLL nbll = new NodeBLL();
            List<Node> nodelist = nbll.Get_NodeList("111");
            List<SelectedPramas> sp = spbll.Get_SelectedPramasList("111");
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
    }
}
