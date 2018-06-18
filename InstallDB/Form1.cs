using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InstallDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SoftReg softreg = new SoftReg();//实例化类对象
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = softreg.getMNum();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyCode=textBox2.Text;
            this.Close();
        }

        public string MyCode { set; get; }
    }
}
