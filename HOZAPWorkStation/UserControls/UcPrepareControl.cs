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
using HOZAPBLL;
using HAZOPCommon;
using HAZOPBLL;

namespace HOZAPWorkStation.UserControls
{
    public partial class UcPrepareControl : UserControl
    {

        public delegate void LoadNodePartitionPageEvents();
        public event LoadNodePartitionPageEvents MyLoadNodePartitionPageEvents;
        ParticipantBLL pbll = new ParticipantBLL();

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


            ParticipantInfoDataBind();
            PreParamSledDataBind();
            PreParamSelectionDataBind();

        }
        //#region 未引用
        ///// <summary>
        ///// 用于绘制行的序号
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void dgvPreParamSelable_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    SolidBrush b = new SolidBrush(this.dgvPreUcPar.RowHeadersDefaultCellStyle.ForeColor);
        //    e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgvPreUcPar.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        //}
        //#endregion

        private void tspPreNoteSplit_Click(object sender, EventArgs e)
        {
            if (MyLoadNodePartitionPageEvents != null)
            {
               MyLoadNodePartitionPageEvents();
            }
        }

        /// <summary>
        /// 为选择的参数展示表的数据绑定
        /// </summary>
        private void PreParamSelectionDataBind()
        {
            PramasBLL pbll = new PramasBLL();
            IntroducerBLL ibll = new IntroducerBLL();
            string ProName = "111";
            List<Pramas> plist = pbll.Get_PramasList(ProName);
            List<Introducer> introducerlist = new List<Introducer>();
            List<DisplayPramasAndIntroducer> displaylist = new List<DisplayPramasAndIntroducer>();
            for (int i = 0; i < plist.Count; i++)
            {
                DisplayPramasAndIntroducer displayinfo = new DisplayPramasAndIntroducer();
                displayinfo.PramasID = plist[i].PramasID;
                displayinfo.Name = plist[i].Name;
                introducerlist = ibll.Get_IntroducerList(plist[i].PramasID);
                for (int j = 0; j < introducerlist.Count; j++)
                {
                    if (j == introducerlist.Count - 1)
                    {
                        displayinfo.AllIntroducer += introducerlist[j].IntroducerText;
                    }
                    else
                    {
                        displayinfo.AllIntroducer += introducerlist[j].IntroducerText + "、";
                    }

                }
                displaylist.Add(displayinfo);

            }
            dgvPreParamSelection.AutoGenerateColumns = false;
            dgvPreParamSelection.DataSource = displaylist;
           
        }


        /// <summary>
        /// 已选参数展示表的数据绑定
        /// </summary>
        private void PreParamSledDataBind()
        {
            SelectedPramasBLL spbll = new SelectedPramasBLL();
            IntroducerBLL ibll = new IntroducerBLL(); 
            string ProName = "111";
            List<SelectedPramas> splist = spbll.Get_SelectedPramasList(ProName);
            List<Introducer> introducerlist = new List<Introducer>();

            List<DisplayPramasAndIntroducer> displaylist = new List<DisplayPramasAndIntroducer>();
            for (int i = 0; i < splist.Count; i++)
            {
                DisplayPramasAndIntroducer displayinfo = new DisplayPramasAndIntroducer();
                displayinfo.PramasID = splist[i].PramasId;
                displayinfo.Name = splist[i].PramasText;
                introducerlist = ibll.Get_IntroducerList(splist[i].PramasId);
                for (int j = 0; j < introducerlist.Count; j++)
                {
                    if(j == introducerlist.Count - 1)
                    {
                        displayinfo.AllIntroducer += introducerlist[j].IntroducerText;
                    }
                    else
                    {
                        displayinfo.AllIntroducer += introducerlist[j].IntroducerText + "、";
                    }
                    
                }
                displaylist.Add(displayinfo);

             }
            dgvPreParamSled.AutoGenerateColumns = false;
            dgvPreParamSled.DataSource = displaylist;
        }

        private void tspParcipantAdd_Click(object sender, EventArgs e)
        {
            AddParticipant addparticipant = AddParticipant.InstanceObject();
            addparticipant.MyParticipantInfoDataBindEvents += new AddParticipant.ParticipantInfoDataBindEvents(ParticipantInfoDataBind);
            addparticipant.Focus();   //让窗体获得焦点
            addparticipant.Show();    //显示窗体
        }
        /// <summary>
        /// 项目参与人员信息展示表的数据绑定
        /// </summary>
        private void ParticipantInfoDataBind()
        {
          
            List<Participant> ParticipantInfoList = pbll.Get_ParticipantInfoList("111");
            dgvPreUcPar.AutoGenerateColumns = false;
            dgvPreUcPar.DataSource = ParticipantInfoList;
           
        }

        private void tspParcipantDelete_Click(object sender, EventArgs e)
        {

            DialogResult dr= MessageBox.Show("是否删除当前选中行的项目人员信息!","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (dr==DialogResult.Yes)
            {
                
                if (pbll.Del_ParticipantInfo(Convert.ToInt32(dgvPreUcPar.CurrentRow.Cells["ID"].Value)))
                {
                    ParticipantInfoDataBind();
                }
                else
                {
                    MessageBox.Show("删除失败!");
                }
            }
           
        }

        /// <summary>
        /// 绘制参数页可选参数中列表dgvPreParamSelection的行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPreParamSelection_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(this.dgvPreParamSelection.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgvPreParamSelection.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        /// <summary>
        /// 用于改变dgvPreParamSelection复选框的选中状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPreParamSelection_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewCheckBoxCell checkbox =(DataGridViewCheckBoxCell)dgvPreParamSelection.Rows[e.RowIndex].Cells[0];
                if ((int)checkbox.Value == 1)
                {
                    checkbox.Value = 0;
                }
                else
                {
                    checkbox.Value = 1;
                }
            }
        }
        /// <summary>
        /// 用于改变dgvPreParamSled复选框的选中状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPreParamSled_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgvPreParamSled.Rows[e.RowIndex].Cells[0];
                if ((int)checkbox.Value == 1)
                {
                    checkbox.Value = 0;
                }
                else
                {
                    checkbox.Value = 1;
                }
            }
        }

        /// <summary>
        /// 绘制参数页可选参数中列表dgvPreParamSled的行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPreParamSled_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(this.dgvPreParamSelection.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgvPreParamSelection.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
    }
}