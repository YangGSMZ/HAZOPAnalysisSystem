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
    public partial class AddParticipant : Form
    {
        public delegate void ParticipantInfoDataBindEvents();
        public event ParticipantInfoDataBindEvents MyParticipantInfoDataBindEvents;
        public AddParticipant()
        {
            InitializeComponent();
        }

        private static AddParticipant _instance;
        //创建窗体对象的静态方法
        public static AddParticipant InstanceObject()
        {
            if (_instance == null)
                _instance = new AddParticipant();
            return _instance;
        }

        //窗体关闭事件
        private void AddParticipant_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
      

        private void btnSave_Click(object sender, EventArgs e)
        {
            Participant participantinfo = new Participant();
            ParticipantBLL pbll = new ParticipantBLL();
            string Name = txtName.Text.Trim();
            string RolePlay = cbRolePlay.Text;
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(RolePlay))
            {
                participantinfo.Name = Name;
                participantinfo.Majary = txtMajary.Text.Trim();
                participantinfo.Postion = txtPostion.Text.Trim();
                participantinfo.Company = txtCompany.Text.Trim();
                participantinfo.Department = txtDepartment.Text.Trim();
                participantinfo.RolePlay = RolePlay;
                participantinfo.ProName = HAZOP分析系统.ProName;
                if (pbll.Add_Participant(participantinfo))
                {
                    MessageBox.Show("添加成功!");
                    MyParticipantInfoDataBindEvents();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("失败成功!");
                }

            }
            else
            {
                MessageBox.Show("人员名和项目角色不能为空!");
            }
           
        }

        private void btnConcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
