using HAZOPBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HOZAPModel;

namespace HOZAPWorkStation
{
    public partial class AddPramas : Form
    {

        public delegate void PreParamSelectionDataBindEvents();
        public event PreParamSelectionDataBindEvents MyPreParamSelectionDataBindEvents;
        public AddPramas()
        {
            InitializeComponent();
        }

        private static AddPramas _instance;
        //创建窗体对象的静态方法
        public static AddPramas InstanceObject()
        {
            if (_instance == null)
                _instance = new AddPramas();
            return _instance;
        }

        //窗体关闭事件
        private void AddPramas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            int index=this.dgvIntroducer.Rows.Add();
            this.dgvIntroducer.Rows[index].Cells[0].Value = index+1;
          
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
                pbll.Add_Pramas(PramasName);
                int pramasid = pbll.Get_PramasId(PramasName);
                if (dgvIntroducer.Rows.Count > 0)
                {
                    IntroducerList = new List<HOZAPModel.Introducer>();
                    foreach (DataGridViewRow row in dgvIntroducer.Rows)
                    {
                        HOZAPModel.Introducer IntroducerInfo = new HOZAPModel.Introducer();
                        IntroducerInfo.IntroducerText = row.Cells[1].Value.ToString();
                        IntroducerInfo.PramasId = pramasid;
                        IntroducerList.Add(IntroducerInfo);
                    }
                }
                if (ibll.Add_Introducerinfo(IntroducerList))
                {
                    if (MyPreParamSelectionDataBindEvents != null)
                    {
                        MyPreParamSelectionDataBindEvents();
                    }
                    MessageBox.Show("添加成功!");
                    this.Close();
                }
            }

        }
    }
}
