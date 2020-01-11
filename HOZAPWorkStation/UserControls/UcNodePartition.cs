using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HOZAPModel;
using HAZOPBLL;

namespace HOZAPWorkStation.UserControls
{
    public partial class UcNodePartition : UserControl
    {
        public delegate void LoadAnalysisPageEvents();
        public event LoadAnalysisPageEvents MyLoadAnalysisPageEvents;
        public delegate void CloseNodePartitionPageEvents();
        public event CloseNodePartitionPageEvents MyCloseNodePartitionPageEvents;

        //创捷节点类的逻辑操作类对象
        NodeBLL nodeBLL = new NodeBLL();
        //用于判断是否是修改节点的事件
        bool isAlter=false;
        public UcNodePartition()
        {
            InitializeComponent();
        }

        private void tsbHaZop_Click(object sender, EventArgs e)
        {
            if (MyLoadAnalysisPageEvents != null)
            {
                MyLoadAnalysisPageEvents();
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            if (MyCloseNodePartitionPageEvents != null)
            {
                MyCloseNodePartitionPageEvents();
            }
        }

        /// <summary>
        /// 保存/删除 节点后刷新TreeView
        /// </summary>
        private void AddOrDeleteNode_TreeViewRefresh()
        {
            TreeNode root = new TreeNode();
            root.Text = HAZOP分析系统.ProName;
            //清空当前TreeView的全部节点，重新绑定
            this.trvUcNodePart.Nodes.Clear();
            //添加根节点，根节点名称为项目名称
            this.trvUcNodePart.Nodes.Add(root);
            //将节点添加到根节点下
            NodeBLL nodebll = new NodeBLL();
            List<Node> nodelist = nodebll.Get_NodeList(HAZOP分析系统.ProName);
            if (nodelist != null)
            {
                for (int i = 0; i < nodelist.Count; i++)
                {
                    TreeNode treenode = new TreeNode();
                    treenode.Text = nodelist[i].NodeName;
                    root.Nodes.Add(treenode);
                }
                this.trvUcNodePart.ExpandAll();
            }
        }

        /// <summary>
        /// 保存添加的节点到数据库中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSave_Click(object sender, EventArgs e)
        {
            //创建节点类对象
            Node nodeInfo = new Node();
            string nodeId = this.txtNodeId.Text.Trim();
            string nodeName = this.txtNodeName.Text.Trim();
            if (!string.IsNullOrEmpty(nodeId) && !string.IsNullOrEmpty(nodeName))
            {
                nodeInfo.ProName = HAZOP分析系统.ProName;
                nodeInfo.NodeId = Convert.ToInt32(this.txtNodeId.Text.Trim());
                nodeInfo.NodeSort = this.rbContinuous.Text;
                nodeInfo.NodeName = this.txtNodeName.Text.Trim();
                nodeInfo.NodeDesc = this.txtNodeDesc.Text.Trim();
                nodeInfo.NodeIUage = this.txtNodeUsage.Text.Trim();
                nodeInfo.SelectMode = "";
                if (this.txtNodeCreateDate.Text.Trim() == String.Empty)
                {
                    nodeInfo.NodeCreateDate = System.DateTime.Now.ToShortDateString();
                }
                else
                {
                    nodeInfo.NodeCreateDate = this.txtNodeCreateDate.Text.Trim();
                }
                if (!isAlter)
                {
                    if (nodeBLL.Add_Node(nodeInfo))
                    {
                        MessageBox.Show("添加节点成功");
                        AddOrDeleteNode_TreeViewRefresh(); //刷新TreeView
                    }
                    else
                    {
                        MessageBox.Show("添加节点失败");
                    }
                }
                else if(isAlter)
                {
                    isAlter = false;
                    if (nodeBLL.Alter_Node(nodeInfo))
                    {
                        MessageBox.Show("修改成功");
                        AddOrDeleteNode_TreeViewRefresh(); //刷新TreeView
                    }
                    else
                    {
                        MessageBox.Show("修改失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("'*'为必填项目");
            }

            #region 设置控件可用性
            this.lblUcNodeNewNodeTip.Visible = false;
            this.txtNodeId.BackColor = Color.White;
            this.txtNodeName.BackColor = Color.White;
            foreach (Control control in this.panel1.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    control.Enabled = false;
                    control.Text = String.Empty;
                }
                else if (control.GetType() == typeof(Button))
                {
                    control.Enabled = false;
                }
            }
            #endregion
        }

        /// <summary>
        /// “增加”按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            this.lblUcNodeNewNodeTip.Visible = true;
            #region 控制面板控件的可用性
            foreach (Control control in this.panel1.Controls)
            {
                control.Enabled = true;
                if (control.GetType() == typeof(TextBox))
                {
                    control.Text = String.Empty;
                }
            }
            this.rbInterim.Enabled = false; //间歇流程不可用
            this.txtSelectModel.Enabled = false;//选择模板不可用
            this.SelectModelbtn.Enabled = false;
            #endregion
        }
        /// <summary>
        /// 当编号节点的文本框失去焦点后，检测节点编号是否可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNodeId_Leave(object sender, EventArgs e)
        {
            if (this.txtNodeId.Text.Trim().Length > 0)
            {
                if (nodeBLL.Check_NodeIDIsAvailable(Convert.ToInt32(this.txtNodeId.Text.Trim())))
                {
                    this.txtNodeId.BackColor = Color.LightGreen;
                }
                else
                {
                    this.txtNodeId.BackColor = Color.Red;
                    MessageBox.Show("该节点编号已存在");
                }
            }
        }

        /// <summary>
        /// 这里让节点名称也唯一，为了方便点击treeview节点时在右侧栏显示相应节点信息时方便
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNodeName_Leave(object sender, EventArgs e)
        {
            if (this.txtNodeName.Text.Trim().Length > 0)
            {
                if (nodeBLL.Check_NodeNameIsAvailable(this.txtNodeName.Text.Trim()))
                {
                    this.txtNodeName.BackColor = Color.LightGreen;
                }
                else
                {
                    this.txtNodeName.BackColor = Color.Red;
                    MessageBox.Show("该节点名称已存在");
                }
            }
        }

        /// <summary>
        /// 选择节点创建的日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateNodeDatebtn_Click(object sender, EventArgs e)
        {
            this.calCreateNodeDate.Visible = true;
        }

        /// <summary>
        /// 获取日期控件选择的日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calCreateNodeDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.txtNodeCreateDate.Text = e.Start.ToShortDateString();
            this.calCreateNodeDate.Visible = false;
        }

        private void UcNodePartition_Load(object sender, EventArgs e)
        {
            //初次加载时，初始化TreeView
            AddOrDeleteNode_TreeViewRefresh();
        }

        /// <summary>
        /// 选择节点后，把相应节点信息显示在右侧栏里
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvUcNodePart_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.trvUcNodePart.SelectedNode.Nodes.Count > 0)
            {
                this.panel1.Visible = false;
            }
            else
            {
                this.panel1.Visible = true;
                Node node = nodeBLL.Get_NodeInfo(this.trvUcNodePart.SelectedNode.Text);
                if (node != null)
                {
                    this.txtNodeId.Text = node.NodeId.ToString();
                    this.txtNodeName.Text = node.NodeName;
                    this.txtNodeDesc.Text = node.NodeDesc;
                    this.txtNodeUsage.Text = node.NodeIUage;
                    this.txtNodeCreateDate.Text = node.NodeCreateDate;
                }
            }       
        }

        /// <summary>
        /// 点击编辑按钮让文本框和选择日期的按钮可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbEdite_Click(object sender, EventArgs e)
        {
            isAlter = true;
            foreach (Control control in this.panel1.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    control.Enabled = true;
                }
                else if (control.GetType() == typeof(Button))
                {
                    control.Enabled = true;
                }
            }
            this.txtNodeId.Enabled = false;
            this.txtNodeName.Enabled = false;
            this.txtSelectModel.Enabled = false;//选择模板不可用
            this.SelectModelbtn.Enabled = false;
        }

       
        /// <summary>
        /// 取消添加或修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbCancel_Click(object sender, EventArgs e)
        {
            this.lblUcNodeNewNodeTip.Visible = false;
            this.txtNodeId.BackColor = Color.White;
            foreach (Control control in this.panel1.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    control.Enabled = false;
                    control.Text = String.Empty;
                }
                else if (control.GetType() == typeof(Button))
                {
                    control.Enabled = false;
                }
            }
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (MyLoadAnalysisPageEvents != null)
            {
                MyLoadAnalysisPageEvents();
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (nodeBLL.Delect_SelectedNode(HAZOP分析系统.ProName, this.trvUcNodePart.SelectedNode.Text))
            {
                AddOrDeleteNode_TreeViewRefresh();
            }
        }

        private void txtNodeId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
