using HAZOPBLL;
using HOZAPWorkStation.ExportExcel;
using HOZAPWorkStation.UserControls;
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
    public partial class HAZOP分析系统 : Form
    {
        public static string ProName = "";
        public HAZOP分析系统()
        {
            InitializeComponent();

            #region 网上案例，本项目效果不明显，依然闪屏
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            //SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            #endregion

            this.preBtn.Enabled = false;
            this.preBtn.BackColor = Color.LightGray;
            this.nodeBtn.Enabled = false;
            this.nodeBtn.BackColor = Color.LightGray;
            this.analysisBtn.Enabled = false;
            this.analysisBtn.BackColor = Color.LightGray;
            this.printBtn.Enabled = false;
            this.printBtn.BackColor = Color.LightGray;
        }

        /// <summary>
        /// 解决闪屏问题
        /// 1.当一个控件需要绘制时，Windows会向此窗体发送两条消息：
        /// 第一条是：WM_ERASEBKGND，这条消息使得背景得以绘制；
        /// 第二条消息是：WM_PAINT，使得前景被绘制，首先背景色是简单的，
        /// 所以速度较快，前景色较为耗时（相对），所以就产生了这种闪烁现象，
        /// 这是问题的根源，Winform为此提供了一个解决方案：双缓冲（OptimizedDoubleBuffer）。
        /// 设置了这个值之后会把窗体和它的子窗体都开启双缓冲。
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        /// <summary>
        /// 设置按钮是否可用 ，打开文件前，部分按钮不可用
        /// </summary>
        /// <param name="sender"></param>
        private void InitialInterface_SetBtn(object sender)
        {
            if (sender is ProNameList)
            {
                ProNameList proNameList = (ProNameList)sender;
                if (proNameList.IsOpen)
                {
                    MessageBox.Show("成功载入文件，选项已解锁，请继续操作");
                    this.preBtn.Enabled = true;
                    this.preBtn.BackColor = SystemColors.ActiveCaption;
                    this.nodeBtn.Enabled = true;
                    this.nodeBtn.BackColor = SystemColors.ActiveCaption;
                    this.analysisBtn.Enabled = true;
                    this.analysisBtn.BackColor = SystemColors.ActiveCaption;
                    this.printBtn.Enabled = true;
                    this.printBtn.BackColor = SystemColors.ActiveCaption;
                    this.导出ToolStripMenuItem1.Enabled = true;
                    this.节点划分ToolStripMenuItem1.Enabled = true;
                    this.项目准备ToolStripMenuItem1.Enabled = true;
                    this.hazop分析ToolStripMenuItem1.Enabled = true;
                }
            }
            if (sender is NewProjectInterface)
            {
                NewProjectInterface proNameList = (NewProjectInterface)sender;
                if (proNameList.IsNew)
                {
                    this.preBtn.Enabled = true;
                    this.preBtn.BackColor = SystemColors.ActiveCaption;
                    this.nodeBtn.Enabled = true;
                    this.nodeBtn.BackColor = SystemColors.ActiveCaption;
                    this.analysisBtn.Enabled = true;
                    this.analysisBtn.BackColor = SystemColors.ActiveCaption;
                    this.printBtn.Enabled = true;
                    this.printBtn.BackColor = SystemColors.ActiveCaption;
                    this.导出ToolStripMenuItem1.Enabled = true;
                    this.节点划分ToolStripMenuItem1.Enabled = true;
                    this.项目准备ToolStripMenuItem1.Enabled = true;
                    this.hazop分析ToolStripMenuItem1.Enabled = true;
               
                }
            }

        }

        /// <summary>
        /// XY用于窗体上的控件自适应大小的调整
        /// </summary>
        private float X;
        private float Y;

        /// <summary>
        /// 获取控件的宽高和边距等，存放在Tag属性中
        /// </summary>
        /// <param name="controls">窗体上的控件集</param>
        private void setTag(Control controls)
        {
            foreach (Control control in this.tpSysteamIndex.Controls)
            {
                control.Tag = control.Width + ":" + control.Height + ":" + control.Left + ":" + control.Top + ":" + control.Font.Size;
                if (control.Controls.Count > 0)
                {
                    setTag(control);
                }
            }
        }

        /// <summary>
        /// 根据窗体大小调整控件大小
        /// </summary>
        /// <param name="newx">宽参数</param>
        /// <param name="newy">高参数</param>
        /// <param name="controls">控件集合</param>
        private void setControls(float newx, float newy, Control controls)
        {
           
            this.tpSysteamIndex.BackgroundImage = null;
            this.openBtn.BackgroundImage = null;
            this.newBtn.BackgroundImage = null;
            this.preBtn.BackgroundImage = null;
            this.nodeBtn.BackgroundImage = null;
            this.analysisBtn.BackgroundImage = null;
            this.printBtn.BackgroundImage = null;
            //foreach遍历控件集，重新设定控件值
            foreach (Control control in this.tpSysteamIndex.Controls)
            {
                string[] contag = control.Tag.ToString().Split(new char[] { ':' });
                float param = System.Convert.ToSingle(contag[0]) * newx; //根据窗体缩放比例确定控件属性值
                control.Width = (int)param;
                param = System.Convert.ToSingle(contag[1]) * newy;
                control.Height = (int)param;
                param = System.Convert.ToSingle(contag[2]) * newx;
                control.Left = (int)param;
                param = System.Convert.ToSingle(contag[3]) * newy;
                control.Top = (int)param;
                Single currentSize = System.Convert.ToSingle(contag[4]) * Math.Min(newx, newy);
                control.Font = new Font(control.Font.Name, currentSize, control.Font.Style, control.Font.Unit);
                if (control.Controls.Count > 0)
                {
                    setControls(newx, newy, control);
                }
            }
            //Image image = Image.FromFile("Images/background.jpg")
                Image image = Image.FromFile("Images/bg.png");
            this.tpSysteamIndex.BackgroundImage = image;
            image = Image.FromFile("Images/OpenProject‘.png");
            this.openBtn.BackgroundImage = image;
            image = Image.FromFile("Images/NewProject.png");
            this.newBtn.BackgroundImage = image;
            image = Image.FromFile("Images/PrePro.png");
            this.preBtn.BackgroundImage = image;
            image = Image.FromFile("Images/Node.png");
            this.nodeBtn.BackgroundImage = image;
            image = Image.FromFile("Images/analysis.png");
            this.analysisBtn.BackgroundImage = image;
            image = Image.FromFile("Images/Print.png");
            this.printBtn.BackgroundImage = image;
        }
        private void InitialInterface_Load(object sender, EventArgs e)
        {

            X = this.Width;
            Y = this.Height;
            setTag(this);
        }

        private void InitialInterface_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X; //窗体宽度缩放比例
            float newy = (this.Height) / Y;//窗体高度缩放比例
            setControls(newx, newy, this);//随窗体改变控件大小
        }


        private void baseUserControl1_Load(object sender, EventArgs e)
        {

        }


        private void nodeBtn_Click(object sender, EventArgs e)
        {

            LoadNodePartitionPage();

        }

        /// <summary>
        /// 节点划分功能页的加载
        /// </summary>
        /// <param name="e"></param>
        private void LoadNodePartitionPage()
        {
            if (!MainTableControl.Controls.ContainsKey("tpNodePartition"))
            {
                UcNodePartition uc = new UcNodePartition();
                TabPage tp = new TabPage();
                uc.Dock = DockStyle.Fill;
                uc.MyLoadAnalysisPageEvents += new UcNodePartition.LoadAnalysisPageEvents(LoadAnalysisPage);
                uc.MyCloseNodePartitionPageEvents += new UcNodePartition.CloseNodePartitionPageEvents(CloseCurrentPage);
                tp.Controls.Add(uc);
                tp.Name = "tpNodePartition";
                tp.Text = "节点划分";
                tp.Font = new Font("宋体", 9);
                this.MainTableControl.Controls.Add(tp);
                this.MainTableControl.SelectTab("tpNodePartition");

            }
            else
            {
                this.MainTableControl.SelectTab("tpNodePartition");

            }
        }



        const int CLOSE_SIZE = 18;//关闭按钮大小
        private void MainTableControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                Rectangle myTabRect = this.MainTableControl.GetTabRect(e.Index);

                if (e.Index == 0)//系统首页不画关闭按钮
                {
                    //先添加TabPage属性   
                    e.Graphics.DrawString(this.MainTableControl.TabPages[e.Index].Text
                    , this.Font, SystemBrushes.ControlText, myTabRect.X + 8, myTabRect.Y + 8);
                    return;
                }
                e.Graphics.DrawString(this.MainTableControl.TabPages[e.Index].Text
                  , this.Font, SystemBrushes.ControlText, myTabRect.X + 2, myTabRect.Y + 8);
                //再画一个矩形框
                using (Pen p = new Pen(Color.Black))
                {
                    myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                    myTabRect.Width = CLOSE_SIZE;
                    myTabRect.Height = CLOSE_SIZE;
                    e.Graphics.DrawRectangle(p, myTabRect);
                }

                //填充矩形框
                Color recColor = e.State == DrawItemState.Selected ? Color.DarkRed : Color.DarkGray;
                using (Brush b = new SolidBrush(recColor))
                {
                    e.Graphics.FillRectangle(b, myTabRect);
                }
                //画关闭符号
                using (Pen p = new Pen(Color.White))
                {
                    //画"/"线
                    Point p1 = new Point(myTabRect.X + 3, myTabRect.Y + 3);
                    Point p2 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + myTabRect.Height - 3);
                    e.Graphics.DrawLine(p, p1, p2);
                    //画"/"线
                    Point p3 = new Point(myTabRect.X + 3, myTabRect.Y + myTabRect.Height - 3);
                    Point p4 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + 3);
                    e.Graphics.DrawLine(p, p3, p4);
                }
                e.Graphics.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// 功能页的关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTableControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X, y = e.Y;
                //计算关闭区域   
                if (this.MainTableControl.SelectedIndex == 0)//系统首页不关闭
                {
                    return;
                }
                Rectangle myTabRect = this.MainTableControl.GetTabRect(this.MainTableControl.SelectedIndex);
                myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                myTabRect.Width = CLOSE_SIZE;
                myTabRect.Height = CLOSE_SIZE;
                //如果鼠标在区域内就关闭选项卡   
                bool isClose = x > myTabRect.X && x < myTabRect.Right
                 && y > myTabRect.Y && y < myTabRect.Bottom;
                if (isClose == true)
                {
                    this.MainTableControl.TabPages.Remove(this.MainTableControl.SelectedTab);
                }
            }
        }

        /// <summary>
        /// 关闭当前展示的功能页
        /// </summary>
        private void CloseCurrentPage()
        {
            this.MainTableControl.TabPages.Remove(this.MainTableControl.SelectedTab);
        }

        private void preBtn_Click(object sender, EventArgs e)
        {
            LoadPreparePage();
        }

        /// <summary>
        /// 项目准备功能页的加载
        /// </summary>   
        private void LoadPreparePage()
        {
            if (!MainTableControl.Controls.ContainsKey("tpPrepare"))
            {
                UcPrepareControl uc = new UcPrepareControl();
                TabPage tp = new TabPage();
                uc.Dock = DockStyle.Fill;
                uc.MyCloseUcPrepareControlPageEvents += new UcPrepareControl.CloseUcPrepareControlPageEvents(CloseCurrentPage);
                uc.MyLoadNodePartitionPageEvents += new UcPrepareControl.LoadNodePartitionPageEvents(LoadNodePartitionPage);
                tp.Controls.Add(uc);
                tp.Name = "tpPrepare";
                tp.Text = "项目准备";
                tp.Font = new Font("宋体", 9);
                this.MainTableControl.Controls.Add(tp);
                this.MainTableControl.SelectTab("tpPrepare");

            }
            else
            {
                this.MainTableControl.SelectTab("tpPrepare");

            }
        }


        private void LoadPrintViewPage(object o,int Report)
        {
            if (!MainTableControl.Controls.ContainsKey("tpPrintView"))
            {
                PrintView uc = new PrintView();
                TabPage tp = new TabPage();
                uc.Dock = DockStyle.Fill;
                uc.datasource = o;
                uc.Report = Report;
                tp.Controls.Add(uc);
                tp.Name = "tpPrintView";
                tp.Text = "打印预览";
                tp.Font = new Font("宋体", 9);
                this.MainTableControl.Controls.Add(tp);
                this.MainTableControl.SelectTab("tpPrintView");

            }
            else
            {
                this.MainTableControl.SelectTab("tpPrintView");

            }
        }


        private void analysisBtn_Click(object sender, EventArgs e)
        {
            LoadAnalysisPage();
        }


        /// <summary>
        /// hazop分析的功能页加载
        /// </summary>     
        private void LoadAnalysisPage()
        {
            if (!MainTableControl.Controls.ContainsKey("tpAnalysis"))
            {
                UcAnalysis uc = new UcAnalysis();
                TabPage tp = new TabPage();
                uc.Dock = DockStyle.Fill;
                uc.MyLoadPrintViewPage += new UcAnalysis.LoadPrintViewPage(LoadPrintViewPage);
                tp.Controls.Add(uc);
                tp.Name = "tpAnalysis";
                tp.Text = "hazop分析";
                tp.Font = new Font("宋体", 9);
                this.MainTableControl.Controls.Add(tp);
                this.MainTableControl.SelectTab("tpAnalysis");

            }
            else
            {
                this.MainTableControl.SelectTab("tpAnalysis");

            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            NewProjectInterface NewProject = NewProjectInterface.InstanceObject();
            NewProject.Focus();
            NewProject.MyLoadPreparePageEvents += new NewProjectInterface.LoadPreparePageEvents(LoadPreparePage);
            NewProject.SetInitBtn += new System.Action<object>(InitialInterface_SetBtn);
            NewProject.Show();
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            ProNameList proNameList = ProNameList.InstanceObject();
            proNameList.SetInitBtn += new System.Action<object>(InitialInterface_SetBtn);
            proNameList.Focus();
            proNameList.Show();
       
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            AnalyResultBLL analyResultBLL = new AnalyResultBLL();
            System.Data.DataTable dt = analyResultBLL.OutAllToExcel(HAZOP分析系统.ProName);
            LoadPrintViewPage(dt,1);

           // ExportToExcel.DataBaseToExcel();

        }

        private void 新建ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            newBtn_Click(sender, e);
        }

        private void 打开ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openBtn_Click(sender, e);
        }

        private void 导出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            printBtn_Click(sender, e);
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 项目准备ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            preBtn_Click(sender, e);
        }

        private void 节点划分ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            nodeBtn_Click(sender, e);

        }

        private void hazop分析ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            analysisBtn_Click(sender, e);
        }
    }
}

