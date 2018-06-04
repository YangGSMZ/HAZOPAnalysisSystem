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
        public Action<List<int>> SendPramasID;
        ParticipantBLL pbll = new ParticipantBLL();
        SelectedPramasBLL spbll = new SelectedPramasBLL();

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

            #region 暂时不用的元素
            txtCoverPic.Enabled = false;
            txtImportDate.Enabled = false;
            txtPrintDate.Enabled = false;
            txtPrintState.Enabled = false;
            txtReDate.Enabled = false;
            txtProDic.Enabled = false;
            txtCreateDate.Enabled = false;
            radioNo.Enabled = false;
            radioYes.Enabled = false;
            #endregion
            #region 用到的元素
            txtProNumber.Enabled = false;
            txtProName.Enabled = false;
            txtProCompany.Enabled = false;
            txtManager.Enabled = false;
            txtCreatePer.Enabled = false;
            rtxtDigest.Enabled = false;
            #endregion
            ProjectInfoBind();

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

        /// <summary>
        /// 节点划分按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            string ProName = InitialInterface.ProName;
            List<Pramas> plist = pbll.Get_PramasList(ProName);
            List<DisplayPramasAndIntroducer> displaylist = null;
            if (plist != null)
            {
                List<Introducer> introducerlist = new List<Introducer>();
                displaylist = new List<DisplayPramasAndIntroducer>();
                for (int i = 0; i < plist.Count; i++)
                {
                    DisplayPramasAndIntroducer displayinfo = new DisplayPramasAndIntroducer();
                    displayinfo.PramasID = plist[i].PramasID;
                    displayinfo.Name = plist[i].Name;
                    displayinfo.Type = plist[i].Type;
                    introducerlist = ibll.Get_IntroducerList(plist[i].PramasID);
                    if (introducerlist != null)
                    {
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
                    }
                    displaylist.Add(displayinfo);

                }
            }
            dgvPreParamSelection.AutoGenerateColumns = false;
            dgvPreParamSelection.DataSource = displaylist;
           
        }


        /// <summary>
        /// 已选参数展示表的数据绑定
        /// </summary>
        private void PreParamSledDataBind()
        {
          
            IntroducerBLL ibll = new IntroducerBLL(); 
            string ProName = InitialInterface.ProName;
            List<SelectedPramas> splist = spbll.Get_SelectedPramasList(ProName);
            List<DisplayPramasAndIntroducer> displaylist = null;
            if (splist != null)
            {
                List<Introducer> introducerlist = new List<Introducer>();
                displaylist = new List<DisplayPramasAndIntroducer>();
                for (int i = 0; i < splist.Count; i++)
                {
                    DisplayPramasAndIntroducer displayinfo = new DisplayPramasAndIntroducer();
                    displayinfo.PramasID = splist[i].PramasId;
                    displayinfo.Name = splist[i].PramasText;
                    introducerlist = ibll.Get_IntroducerList(splist[i].PramasId);
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
            List<Participant> ParticipantInfoList = pbll.Get_ParticipantInfoList(InitialInterface.ProName);
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
                if (checkbox.Value == null)
                {
                    checkbox.Value = 0;
                }
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
                if (checkbox.Value == null)
                {
                    checkbox.Value = 0;
                }
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
       
        /// <summary>
        /// 参数选择按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreParaSelect_Click(object sender, EventArgs e)
        {
            List<SelectedPramas> SelectedPramasInfoList = new List<SelectedPramas>();
            foreach (DataGridViewRow row in dgvPreParamSelection.Rows)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)row.Cells[0];
                if (checkbox.Value == null)
                {
                    checkbox.Value = 0;
                }
                if ((int)checkbox.Value == 1)
                {
                    SelectedPramas SelectedPramasInfo = new SelectedPramas();
                    SelectedPramasInfo.PramasId =Convert.ToInt32(row.Cells["PramasID"].Value);
                    SelectedPramasInfo.PramasText = row.Cells["ParamNameSelection"].Value.ToString();
                    SelectedPramasInfo.ProName = InitialInterface.ProName;
                    SelectedPramasInfoList.Add(SelectedPramasInfo);
                }
            }
            if (SelectedPramasInfoList.Count > 0)
            {
                if (spbll.Add_SelectedPramasinfo(SelectedPramasInfoList))
                {
                    PreParamSledDataBind();
                    PreParamSelectionDataBind();
                }
            }
            else
            {
                MessageBox.Show("请选择参数!");                
            }             
        }

        private void btnPreParaCancel_Click(object sender, EventArgs e)
        {
            List<int> PramasID = new List<int>();
            foreach (DataGridViewRow row in dgvPreParamSled.Rows)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)row.Cells[0];
                if (checkbox.Value == null)
                {
                    checkbox.Value = 0;
                }
                if ((int)checkbox.Value == 1)
                {

                    PramasID.Add(Convert.ToInt32(row.Cells["SelectedPramasID"].Value));
                }
            }
            if (PramasID.Count > 0)
            {
                if (spbll.Del_SelectedPramasinfo(PramasID))
                {
                    PreParamSledDataBind();
                    PreParamSelectionDataBind();
                }
            }
            else
            {
                MessageBox.Show("请选择需要取消的参数!");
            }
        }

        /// <summary>
        /// 可选择参数全部选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspPreParamSelAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPreParamSelection.Rows)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)row.Cells[0];
                if (checkbox.Value == null)
                {
                    checkbox.Value = 0;
                }
                if ((int)checkbox.Value ==0)
                {

                    checkbox.Value = 1;
                }
            }
        }
        /// <summary>
        /// 可选择参数全部不选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspPreParamSelNoAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPreParamSelection.Rows)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)row.Cells[0];
                if (checkbox.Value == null)
                {
                    checkbox.Value = 0;
                }
                if ((int)checkbox.Value == 1)
                {

                    checkbox.Value = 0;
                }
            }
        }
        /// <summary>
        /// 已选参数全部选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspPreParamSeledAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPreParamSled.Rows)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)row.Cells[0];
                if (checkbox.Value == null)
                {
                    checkbox.Value = 0;
                }
                if ((int)checkbox.Value == 0)
                {

                    checkbox.Value = 1;
                }
            }
        }
        /// <summary>
        /// 已选参数全部不选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspPreParamSeledNoAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPreParamSled.Rows)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)row.Cells[0];
                if (checkbox.Value == null)
                {
                    checkbox.Value = 0;
                }
                if ((int)checkbox.Value == 1)
                {

                    checkbox.Value = 0;
                }
            }
        }

        private void tspPreParamSelNext_Click(object sender, EventArgs e)
        {
            tspPreNoteSplit_Click(sender,e);
        }

        private void tspPreParamSelAdd_Click(object sender, EventArgs e)
        {
            AddPramas addpramas =AddPramas.InstanceObject();
            addpramas.Focus();
            addpramas.MyPreParamSelectionDataBindEvents += new AddPramas.PreParamSelectionDataBindEvents(PreParamSelectionDataBind);
            addpramas.Show();

        }
        /// <summary>
        /// 修改参数信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspPreParamSelEdit_Click(object sender, EventArgs e)
        {
            List<int> PramasIdList = new List<int>();
            foreach (DataGridViewRow row in dgvPreParamSelection.Rows)
            {

                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)row.Cells[0];
                if (checkbox.Value == null)
                {
                    checkbox.Value = 0;
                }
                if ((int)checkbox.Value == 1)
                {
                    if ((int)row.Cells["Type"].Value == 0)
                    {
                        MessageBox.Show("选项为系统参数，无法修改！");
                        return;
                    }
                    else
                    {
                        PramasIdList.Add(Convert.ToInt32(row.Cells["PramasID"].Value));
                    }
                }

            }
            if (PramasIdList.Count == 1)
            {
               
                UpdataPramasInfo updatapramasinfo = UpdataPramasInfo.InstanceObject();
                updatapramasinfo.Focus();
                SendPramasID += updatapramasinfo.SetInfo ;
                updatapramasinfo.MyPreParamSelectionDataBindEvents += new UpdataPramasInfo.PreParamSelectionDataBindEvents(PreParamSelectionDataBind);
                updatapramasinfo.Show();
                if (SendPramasID != null)
                {
                    SendPramasID(PramasIdList);
                }
                else
                {
                    return;
                }
              

            }
            else
            {
                if (PramasIdList.Count > 1)
                {
                    MessageBox.Show("一次只能修改一个参数信息！");
                }
                else
                {
                    MessageBox.Show("请选择所需修改的参数信息！");
                }
            }
           
        }

        private void tspParcipantNext_Click(object sender, EventArgs e)
        {
            PrepareTabControl.SelectedIndex = 2;
        }

        private void tspBaseInfoNext_Click(object sender, EventArgs e)
        {
            PrepareTabControl.SelectedIndex = 1;
        }

        private void tsbBaseInfoEdit_Click(object sender, EventArgs e)
        {
            txtProNumber.Enabled = true;
            //txtProName.Enabled = true;//项目名不允许修改
            txtProCompany.Enabled = true;
            txtManager.Enabled = true;
            txtCreatePer.Enabled = true;
            rtxtDigest.Enabled = true;
        }

        private void tspParcipantEdit_Click(object sender, EventArgs e)
        {
            this.dgvPreUcPar.ReadOnly = false;
        }
        /// <summary>
        /// 默认选中系统提供的参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreParaDafult_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPreParamSelection.Rows)
            {
                if ((int)row.Cells["Type"].Value==0)
                {
                    DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (checkbox.Value == null)
                    {
                        checkbox.Value = 1;
                    }
                    if ((int)checkbox.Value == 0)
                    {

                        checkbox.Value = 1;
                    }
                }
              
            }
        }
        /// <summary>
        ///取消参与人员编辑内容，不保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspParcipantCancel_Click(object sender, EventArgs e)
        {
            ParticipantInfoDataBind();
            this.dgvPreUcPar.ReadOnly = true;
        }

        private void tspParcipantSave_Click(object sender, EventArgs e)
        {
            List<Participant> ParticipantInfoList = new List<Participant>();
            foreach (DataGridViewRow row in dgvPreUcPar.Rows)
            {
                Participant ParticipantInfo = new Participant();
                ParticipantInfo.ID = (int)row.Cells["ID"].Value;
                ParticipantInfo.Name = row.Cells["dgvPreParticipantName"].Value.ToString() ;
                ParticipantInfo.Majary = row.Cells["dgvPreParticipantMajor"].Value.ToString();
                ParticipantInfo.Postion = row.Cells["dgvPreParticipantDuty"].Value.ToString();
                ParticipantInfo.Company = row.Cells["dgvPreParticipantCompany"].Value.ToString();
                ParticipantInfo.Department = row.Cells["dgvPreParticipantDepartment"].Value.ToString();
                ParticipantInfo.RolePlay = row.Cells["dgvPreParticipantRole"].Value.ToString();
                ParticipantInfo.ProName = InitialInterface.ProName;
                ParticipantInfoList.Add(ParticipantInfo);
            }
            if (pbll.Update_ParticipantInfo(ParticipantInfoList))
            {
               MessageBox.Show("保存成功！");
               ParticipantInfoDataBind();
            }
        }

        private void tsbBaseInfoCancel_Click(object sender, EventArgs e)
        {
            ProjectInfoBind();
            #region 用到的元素
            txtProNumber.Enabled = false;
            txtProName.Enabled = false;
            txtProCompany.Enabled = false;
            txtManager.Enabled = false;
            txtCreatePer.Enabled = false;
            rtxtDigest.Enabled = false;
            #endregion 
        }

        private void ProjectInfoBind()
        {
            Project ProjectInfo = new Project();
            ProjectBLL projectbll = new ProjectBLL();
            ProjectInfo = projectbll.Get_ProjectInfo(InitialInterface.ProName);
            txtProNumber.Text = ProjectInfo.ProNumber;
            txtProName.Text = ProjectInfo.Name;
            txtProCompany.Text = ProjectInfo.Compartment;
            txtProDic.Text = ProjectInfo.ProDic;
            txtCoverPic.Text = ProjectInfo.ProCoverPic;
            txtManager.Text = ProjectInfo.ProManager;
            txtReDate.Text = ProjectInfo.ReviewDate;
            txtCreatePer.Text = ProjectInfo.CreatePer;
            txtPrintDate.Text = ProjectInfo.PrintState;
            txtPrintState.Text = ProjectInfo.PrintState;
            txtImportDate.Text = ProjectInfo.ImportDate;
            rtxtDigest.Text = ProjectInfo.ProDigest;
        }

        private void tsbBaseInfoSave_Click(object sender, EventArgs e)
        {
            string ProName = txtProName.Text.Trim();
            string Manager = txtManager.Text.Trim();
            Project ProjectInfo = new Project();
            ProjectBLL pbll = new ProjectBLL();
            if (!string.IsNullOrEmpty(Manager))
            {
                ProjectInfo.ProNumber = txtProNumber.Text;
                ProjectInfo.Name = ProName;
                ProjectInfo.Compartment = txtProCompany.Text;
                ProjectInfo.ProDic = txtProDic.Text;
                ProjectInfo.ProCoverPic = txtCoverPic.Text;
                ProjectInfo.ProManager = txtManager.Text;
                ProjectInfo.ReviewDate = txtReDate.Text;
                ProjectInfo.CreatePer = txtCreatePer.Text;
                ProjectInfo.PrintState = txtPrintState.Text;
                ProjectInfo.PrintDate = txtPrintState.Text;
                ProjectInfo.ImportDate = txtImportDate.Text;
                ProjectInfo.ProDigest = rtxtDigest.Text;
                if (pbll.Update_ProjectInfo(ProjectInfo))
                {

                    MessageBox.Show("修改成功！");
                    ProjectInfoBind();
                    #region 用到的元素
                    txtProNumber.Enabled = false;
                    txtProName.Enabled = false;
                    txtProCompany.Enabled = false;
                    txtManager.Enabled = false;
                    txtCreatePer.Enabled = false;
                    rtxtDigest.Enabled = false;
                    #endregion
                }

            }
            else
            {
                MessageBox.Show("请输入必要的信息！");
            }
        }


        /// <summary>
        /// 删除参数及相关信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspPreParamSelDel_Click(object sender, EventArgs e)
        {
           
            List<int> PramasIdList = new List<int>();
            foreach (DataGridViewRow row in dgvPreParamSelection.Rows)
            {
               
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)row.Cells[0];
                if (checkbox.Value == null)
                {
                    checkbox.Value = 0;
                }
                if ((int)checkbox.Value == 1)
                {
                    if ((int)row.Cells["Type"].Value == 0)
                    {
                        MessageBox.Show("选项中有系统参数，无法删除！");
                        return;
                    }
                    else
                    {
                        PramasIdList.Add(Convert.ToInt32(row.Cells["PramasID"].Value));
                    }
                }
              
            }
            if (PramasIdList.Count>0)
            {
                PramasBLL pbll = new PramasBLL();
                IntroducerBLL ibll = new IntroducerBLL();
                if (pbll.Del_PramasById(PramasIdList))
                {
                    ibll.Del_IntroducerByPramasID(PramasIdList);
                    MessageBox.Show("删除成功！");
                    PreParamSelectionDataBind();

                }

            }
            else
            {
                MessageBox.Show("请选择要删除的参数信息！");
            }
        }
    }
}