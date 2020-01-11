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
    public partial class NewProjectInterface : Form
    {
        public delegate void LoadPreparePageEvents();
        public event LoadPreparePageEvents MyLoadPreparePageEvents;
        public event Action<object> SetInitBtn;
        public bool IsNew = false;
        public NewProjectInterface()
        {
            InitializeComponent();
        }

        private static NewProjectInterface _instance;
        //创建窗体对象的静态方法
        public static NewProjectInterface InstanceObject()
        {
            if (_instance == null)
                _instance = new NewProjectInterface();
            return _instance;
        }

        //窗体关闭事件
        private void NewProjectInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            string ProName = txtProName.Text.Trim();
            string Manager = txtManager.Text.Trim();
            Project ProjectInfo = new Project();
            ProjectBLL pbll = new ProjectBLL();

            if (!string.IsNullOrEmpty(ProName) && !string.IsNullOrEmpty(Manager))
            {
                if (!pbll.Check_ProjectName(ProName))
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
                    if (pbll.Add_ProjectInfo(ProjectInfo))
                    {
                        HAZOP分析系统.ProName = ProName;
                        IsNew = true;
                        if (this.SetInitBtn != null)
                        {
                            this.SetInitBtn(this);
                        }
                        MessageBox.Show("新建成功！");
                        if (MyLoadPreparePageEvents != null)
                        {
                            MyLoadPreparePageEvents();

                        }
                        this.Close();
                    }
                }
                else
                {
                 
                    MessageBox.Show("该项目名已存在，请重新输入！");
                    txtProName.Text = null;
                }
              

            }
            else
            {
                MessageBox.Show("请输入必要的信息！");
            }

        }

        private void NewProjectInterface_Load(object sender, EventArgs e)
        {
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
        }
    }
}
