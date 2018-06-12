using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HAZOPBLL;
using HOZAPBLL;
using HOZAPDAL;

namespace HOZAPWorkStation
{
    public partial class ProNameList : Form
    {
        public ProNameList()
        {
            InitializeComponent();
        }

        private void ProNameList_Load(object sender, EventArgs e)
        {
            ProNameDataBind();
        }

        private static ProNameList _instance;
        //创建窗体对象的静态方法
        public static ProNameList InstanceObject()
        {
            if (_instance == null)
                _instance = new ProNameList();
            return _instance;
        }

        private void ProNameDataBind()
        {
            this.lvProNameList.Items.Clear();
            ProjectBLL bLL = new ProjectBLL();
            SqlDataReader sqlDataReader = bLL.Get_ProNameList();
            ImageList SmallImageList = new ImageList();
            SmallImageList.ImageSize = new Size(30, 30);
            SmallImageList.Images.Add(Image.FromFile(@"Images\Folder.JPG"));
            while (sqlDataReader.Read())
            {
                ListViewItem lv = new ListViewItem();
                lv.SubItems.Add(sqlDataReader["ProName"].ToString());
                lv.ImageIndex = 0;
                lv.Text = sqlDataReader["ProName"].ToString();
                this.lvProNameList.Items.Add(lv);
            }
            this.lvProNameList.SmallImageList = SmallImageList;
        }

        private void ProNameList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
        public event Action<object> SetInitBtn;
        public bool IsOpen = false;
        private void tspOpenProNameList_Click(object sender, EventArgs e)
        {
            InitialInterface.ProName = this.lvProNameList.SelectedItems[0].Text;
            if (this.lvProNameList.SelectedItems.Count > 0)
            {
                IsOpen = true;
                if (this.SetInitBtn != null)
                {
                    this.SetInitBtn(this);
                }
            }
            this.Close();
        }

        private void tspDeleteProNameList_Click(object sender, EventArgs e)
        {
            string ProName = this.lvProNameList.SelectedItems[0].Text;

            ProjectBLL bll = new ProjectBLL();
            bll.Delete_ProNameList(ProName);

            AnalyResultBLL analyResultBLL = new AnalyResultBLL();
            analyResultBLL.Delete_Result(ProName);

            NodeBLL nodeBLL = new NodeBLL();
            nodeBLL.Delete_ProName(ProName);

            ParticipantBLL participantBLL = new ParticipantBLL();
            participantBLL.Delete_ProName(ProName);

            SelectedPramasBLL selectedPramasBLL = new SelectedPramasBLL();
            selectedPramasBLL.Delete_ProName(ProName);

            ProNameDataBind();
        }
    }
}
