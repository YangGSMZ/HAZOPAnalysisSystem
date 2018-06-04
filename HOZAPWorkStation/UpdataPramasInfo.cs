using HAZOPBLL;
using HOZAPModel;
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

 
    public partial class UpdataPramasInfo : Form
    {
        public delegate void PreParamSelectionDataBindEvents();
        public event PreParamSelectionDataBindEvents MyPreParamSelectionDataBindEvents;
        private static List<int> PramasIDList;
        

      
        public UpdataPramasInfo()
        {
            InitializeComponent();
        }

    
        private static UpdataPramasInfo _instance;
        //创建窗体对象的静态方法
        public static UpdataPramasInfo InstanceObject()
        {
            if (_instance == null)
                _instance = new UpdataPramasInfo();
            return _instance;
        }

        //窗体关闭事件
        private void UpdataPramasInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            _instance = null;
            
        }
        public void SetInfo(List<int> PramasIDlist)
        {
            PramasBLL pbll = new PramasBLL();
            IntroducerBLL ibll = new IntroducerBLL();
            PramasIDList = PramasIDlist;
            Pramas PramasInfo = pbll.Get_PramasInfo(PramasIDlist[0]);
            txtPramasName.Text = PramasInfo.Name;
            List<Introducer> Introducerlist = ibll.Get_IntroducerList(PramasIDlist[0]);
            if (Introducerlist != null)
            {
               dgvIntroducer.Columns.Clear();
               DataGridViewTextBoxColumn a = new DataGridViewTextBoxColumn();
                a.HeaderText = "序号";
                dgvIntroducer.Columns.Add(a);
                DataGridViewTextBoxColumn b = new DataGridViewTextBoxColumn();
                b.HeaderText = "引导词";
                dgvIntroducer.Columns.Add(b);
                DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
                c.HeaderText = "偏离描述";
                dgvIntroducer.Columns.Add(c);
                for (int i = 0; i < Introducerlist.Count; i++)
                {
                    int index = this.dgvIntroducer.Rows.Add();
                    this.dgvIntroducer.Rows[index].Cells[0].Value = index + 1;
                    this.dgvIntroducer.Rows[index].Cells[1].Value = Introducerlist[i].IntroducerText;
                    this.dgvIntroducer.Rows[index].Cells[2].Value = "";
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            int index = this.dgvIntroducer.Rows.Add();
            this.dgvIntroducer.Rows[index].Cells[0].Value = index + 1;
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            if (dgvIntroducer.Rows.Count > 0)
            {
                this.dgvIntroducer.Rows.RemoveAt(dgvIntroducer.Rows.Count - 1);
            }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            PramasBLL pbll = new PramasBLL();
            IntroducerBLL ibll = new IntroducerBLL();
            List<HOZAPModel.Introducer> IntroducerList = null;
            string PramasName = txtPramasName.Text.Trim();
            if (!string.IsNullOrEmpty(PramasName))
            {
                Pramas PramasInfo = new Pramas();
                PramasInfo.PramasID = PramasIDList[0];
                PramasInfo.Name = PramasName;
                PramasInfo.Type = 1;
                if (pbll.Update_Pramas(PramasInfo))
                {
                    if (dgvIntroducer.Rows.Count > 0)
                    {
                        IntroducerList = new List<HOZAPModel.Introducer>();
                        foreach (DataGridViewRow row in dgvIntroducer.Rows)
                        {
                            HOZAPModel.Introducer IntroducerInfo = new HOZAPModel.Introducer();
                            IntroducerInfo.IntroducerText = row.Cells[1].Value.ToString();
                            IntroducerInfo.PramasId = PramasIDList[0];
                            IntroducerList.Add(IntroducerInfo);
                        }
                    }
                    if (IntroducerList!=null)
                    {
                        if (ibll.Check_IntroducerByPramasID(PramasIDList[0]))
                        {
                            if (ibll.Del_IntroducerByPramasID(PramasIDList))
                            {
                                if (ibll.Add_Introducerinfo(IntroducerList))
                                {
                                    if (MyPreParamSelectionDataBindEvents != null)
                                    {
                                        MyPreParamSelectionDataBindEvents();
                                    }
                                    MessageBox.Show("更新成功!");
                                    this.Close();
                                }
                            }
                        }
                        else
                        {
                            if (ibll.Add_Introducerinfo(IntroducerList))
                            {
                                if (MyPreParamSelectionDataBindEvents != null)
                                {
                                    MyPreParamSelectionDataBindEvents();
                                }
                                MessageBox.Show("更新成功!");
                                this.Close();
                            }
                        }
                        
                    }
                    else
                    {
                        if (ibll.Del_IntroducerByPramasID(PramasIDList))
                        {
                                if (MyPreParamSelectionDataBindEvents != null)
                                {
                                    MyPreParamSelectionDataBindEvents();
                                }
                                MessageBox.Show("更新成功!");
                                this.Close();

                        }
                    }
                }

            }

        }
    }
}
