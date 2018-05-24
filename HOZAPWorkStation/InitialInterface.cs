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
    public partial class InitialInterface : Form
    {
        public InitialInterface()
        {
            InitializeComponent();
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
        }
        private void InitialInterface_Load(object sender, EventArgs e)
        {
            X = this.Width;
            Y = this.Height;
            setTag(this);
        }

        private void InitialInterface_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;
            float newy = (this.Height) / Y;
            setControls(newx, newy, this);
        }

        private void baseUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void nodeBtn_Click(object sender, EventArgs e)
        {
           
            if (!MainTableControl.Controls.ContainsKey("tpNodePartition"))
            {
                UcNodePartition uc = new UcNodePartition();
                TabPage tp = new TabPage();
                uc.Dock = DockStyle.Fill;
                tp.Controls.Add(uc);
                tp.Name = "tpNodePartition";
                tp.Text = "节点划分";
                this.MainTableControl.Controls.Add(tp);
                this.MainTableControl.SelectTab("tpNodePartition");
                setTag(this);
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
                    , this.Font, SystemBrushes.ControlText, myTabRect.X+8 , myTabRect.Y+8 );
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

            }
           
        }

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

        private void preBtn_Click(object sender, EventArgs e)
        {
            if (!MainTableControl.Controls.ContainsKey("tpPrepare"))
            {
                UcPrepareControl uc = new UcPrepareControl();
                TabPage tp = new TabPage();
                uc.Dock = DockStyle.Fill;
                tp.Controls.Add(uc);
                tp.Name = "tpPrepare";
                tp.Text = "项目准备";
                this.MainTableControl.Controls.Add(tp);
                this.MainTableControl.SelectTab("tpPrepare");
                setTag(this);
            }
            else
            {
                this.MainTableControl.SelectTab("tpPrepare");

            }
        }
    }
}
