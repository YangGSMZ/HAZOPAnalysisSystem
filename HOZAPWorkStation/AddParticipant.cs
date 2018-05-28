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
        public AddParticipant()
        {
            InitializeComponent();
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
                participantinfo.ProName = "111";
                if (pbll.Add_Participant(participantinfo))
                {
                    MessageBox.Show("添加成功!");
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
    }
}
