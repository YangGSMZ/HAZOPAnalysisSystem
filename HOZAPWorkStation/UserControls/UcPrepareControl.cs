using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOZAPWorkStation.UserControls
{
    public partial class UcPrepareControl : UserControl
    {
        public UcPrepareControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 风险矩阵不变化，保证可以选取到单元格中的值就可以，这里采用固定值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcPrepareControl_Load(object sender, EventArgs e)
        {
            //添加第一行数据，修改单元格背景颜色，有关单元格大小等在是属性窗口设置
            int index = this.dgvPreUcRisk.Rows.Add();
            this.dgvPreUcRisk.Rows[index].HeaderCell.Value = "1";
            this.dgvPreUcRisk.Rows[index].Cells[0].Value = "1.较多发生";
            this.dgvPreUcRisk.Rows[index].Cells[1].Value = "(10年1次,1E-1)";
            this.dgvPreUcRisk.Rows[index].Cells[2].Value = "D";
            this.dgvPreUcRisk.Rows[index].Cells[2].Style.BackColor = Color.LightBlue;
            this.dgvPreUcRisk.Rows[index].Cells[3].Value = "C";
            this.dgvPreUcRisk.Rows[index].Cells[3].Style.BackColor = Color.Yellow;
            this.dgvPreUcRisk.Rows[index].Cells[4].Value = "B";
            this.dgvPreUcRisk.Rows[index].Cells[4].Style.BackColor = Color.Orange;
            this.dgvPreUcRisk.Rows[index].Cells[5].Value = "B";
            this.dgvPreUcRisk.Rows[index].Cells[5].Style.BackColor = Color.Orange;
            this.dgvPreUcRisk.Rows[index].Cells[6].Value = "A";
            this.dgvPreUcRisk.Rows[index].Cells[6].Style.BackColor = Color.Red;

            //添加第二行数据
            index = this.dgvPreUcRisk.Rows.Add();
            this.dgvPreUcRisk.Rows[index].HeaderCell.Value = "2";
            this.dgvPreUcRisk.Rows[index].Cells[0].Value = "2.偶尔发生";
            this.dgvPreUcRisk.Rows[index].Cells[1].Value = "(100年1次,1E-2)";
            this.dgvPreUcRisk.Rows[index].Cells[2].Value = "E";
            this.dgvPreUcRisk.Rows[index].Cells[2].Style.BackColor = Color.Green;
            this.dgvPreUcRisk.Rows[index].Cells[3].Value = "D";
            this.dgvPreUcRisk.Rows[index].Cells[3].Style.BackColor = Color.LightBlue;
            this.dgvPreUcRisk.Rows[index].Cells[4].Value = "C";
            this.dgvPreUcRisk.Rows[index].Cells[4].Style.BackColor = Color.Yellow;
            this.dgvPreUcRisk.Rows[index].Cells[5].Value = "B";
            this.dgvPreUcRisk.Rows[index].Cells[5].Style.BackColor = Color.Orange;
            this.dgvPreUcRisk.Rows[index].Cells[6].Value = "B";
            this.dgvPreUcRisk.Rows[index].Cells[6].Style.BackColor = Color.Orange;

            //添加第三行数据
            index = this.dgvPreUcRisk.Rows.Add();
            this.dgvPreUcRisk.Rows[index].HeaderCell.Value = "3";
            this.dgvPreUcRisk.Rows[index].Cells[0].Value = "3.很少发生";
            this.dgvPreUcRisk.Rows[index].Cells[1].Value = "(1000年1次,1E-3)";
            this.dgvPreUcRisk.Rows[index].Cells[2].Value = "E";
            this.dgvPreUcRisk.Rows[index].Cells[2].Style.BackColor = Color.Green;
            this.dgvPreUcRisk.Rows[index].Cells[3].Value = "E";
            this.dgvPreUcRisk.Rows[index].Cells[3].Style.BackColor = Color.Green;
            this.dgvPreUcRisk.Rows[index].Cells[4].Value = "D";
            this.dgvPreUcRisk.Rows[index].Cells[4].Style.BackColor = Color.LightBlue;
            this.dgvPreUcRisk.Rows[index].Cells[5].Value = "C";
            this.dgvPreUcRisk.Rows[index].Cells[5].Style.BackColor = Color.Yellow;
            this.dgvPreUcRisk.Rows[index].Cells[6].Value = "B";
            this.dgvPreUcRisk.Rows[index].Cells[6].Style.BackColor = Color.Orange;

            //添加第四行数据
            index = this.dgvPreUcRisk.Rows.Add();
            this.dgvPreUcRisk.Rows[index].HeaderCell.Value = "4";
            this.dgvPreUcRisk.Rows[index].Cells[0].Value = "4.不太可能";
            this.dgvPreUcRisk.Rows[index].Cells[1].Value = "(10000年1次,1E-4)";
            this.dgvPreUcRisk.Rows[index].Cells[2].Value = "E";
            this.dgvPreUcRisk.Rows[index].Cells[2].Style.BackColor = Color.Green;
            this.dgvPreUcRisk.Rows[index].Cells[3].Value = "E";
            this.dgvPreUcRisk.Rows[index].Cells[3].Style.BackColor = Color.Green;
            this.dgvPreUcRisk.Rows[index].Cells[4].Value = "E";
            this.dgvPreUcRisk.Rows[index].Cells[4].Style.BackColor = Color.Green;
            this.dgvPreUcRisk.Rows[index].Cells[5].Value = "D";
            this.dgvPreUcRisk.Rows[index].Cells[5].Style.BackColor = Color.LightBlue;
            this.dgvPreUcRisk.Rows[index].Cells[6].Value = "C";
            this.dgvPreUcRisk.Rows[index].Cells[6].Style.BackColor = Color.Orange;

            //添加第五行数据
            index = this.dgvPreUcRisk.Rows.Add();
            this.dgvPreUcRisk.Rows[index].HeaderCell.Value = "5";
            this.dgvPreUcRisk.Rows[index].Cells[0].Value = "5.极不可能";
            this.dgvPreUcRisk.Rows[index].Cells[1].Value = "(100000年1次,1E-5)";
            this.dgvPreUcRisk.Rows[index].Cells[2].Value = "E";
            this.dgvPreUcRisk.Rows[index].Cells[2].Style.BackColor = Color.Green;
            this.dgvPreUcRisk.Rows[index].Cells[3].Value = "E";
            this.dgvPreUcRisk.Rows[index].Cells[3].Style.BackColor = Color.Green;
            this.dgvPreUcRisk.Rows[index].Cells[4].Value = "E";
            this.dgvPreUcRisk.Rows[index].Cells[4].Style.BackColor = Color.Green;
            this.dgvPreUcRisk.Rows[index].Cells[5].Value = "E";
            this.dgvPreUcRisk.Rows[index].Cells[5].Style.BackColor = Color.Green;
            this.dgvPreUcRisk.Rows[index].Cells[6].Value = "D";
            this.dgvPreUcRisk.Rows[index].Cells[6].Style.BackColor = Color.LightBlue;
        }
    }
}
