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
            foreach (Control control in controls.Controls)
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
            foreach (Control control in controls.Controls)
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
    }
}
