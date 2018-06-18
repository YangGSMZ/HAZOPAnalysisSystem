using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstallDB
{
    [RunInstaller(true)]
    public partial class InstallDB : System.Configuration.Install.Installer
    {
        public InstallDB()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 附加数据库方法
        /// </summary>
        /// <param name="strSql">连接数据库字符串，连接master系统数据库</param>
        /// <param name="DataName">数据库名字</param>
        /// <param name="strMdf">数据库文件MDF的路径</param>
        /// <param name="strLdf">数据库文件LDF的路径</param>
        /// <param name="path">安装目录</param>
        private void CreateDataBase(string strSql, string DataName, string strMdf, string strLdf, string path)
        {
            SqlConnection myConn = new SqlConnection(strSql);
          
            String str = null;
            try
            {
                //开启服务  
                using (Process mypr = new Process())
                {
                    mypr.StartInfo.FileName = "cmd.exe";
                    mypr.StartInfo.UseShellExecute = false;
                    mypr.StartInfo.RedirectStandardInput = true;
                    mypr.StartInfo.RedirectStandardOutput = true;
                    mypr.StartInfo.RedirectStandardError = true;
                    mypr.StartInfo.CreateNoWindow = true;
                    mypr.Start();
                    mypr.StandardInput.WriteLine("sqllocaldb stop MSSQLLocalDB");
                    mypr.StandardInput.WriteLine("sqllocaldb delete MSSQLLocalDB");
                    mypr.StandardInput.WriteLine("sqllocaldb create MSSQLLocalDB");
                    mypr.StandardInput.WriteLine("sqllocaldb start MSSQLLocalDB");
                    mypr.StandardInput.WriteLine("exit");
                    mypr.StandardInput.AutoFlush = true;
                    String output = mypr.StandardOutput.ReadToEnd();
                    mypr.WaitForExit();
                    mypr.Close();
                }
                str = "EXEC sp_attach_db @dbname='" + DataName + "',@filename1='" + strMdf + "',@filename2='" + strLdf + "'";
        
                SqlCommand myCommand = new SqlCommand(str, myConn);
           
                myConn.Open();
               
                myCommand.ExecuteNonQuery();
               // MessageBox.Show("数据库安装成功！点击确定继续");//需Using System.Windows.Forms
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库安装失败！" + e.Message + "\n\n" + "您可以手动附加数据");
                System.Diagnostics.Process.Start(path);//打开安装目录
            }
            finally
            {
                myConn.Close();
            }
        }
        public override void Install(System.Collections.IDictionary stateSaver)
        {

            //string server = this.Context.Parameters["server"];//服务器名称
            //string uid = this.Context.Parameters["user"];//SQlServer用户名
            //string pwd = this.Context.Parameters["pwd"];//密码
            string path = this.Context.Parameters["targetdir"];//安装目录
                                                               //string strSql = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=master";//连接数据库字符串
                                                               ///string strSql = "Data Source=" + server + ";Initial Catalog=master;Integrated Security=true;";//连接数据库字符串
            string strSql = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=true; Connect Timeout = 30;";
            string DataName = "HAZOPAnalysisDB";//数据库名
            string strMdf = path + @"HAZOPAnalysisDB.mdf";//MDF文件路径，这里需注意文件名要与刚添加的数据库文件名一样！
            string strLdf = path + @"HAZOPAnalysisDB_log.ldf";//LDF文件路径
            


            base.Install(stateSaver);
            //给mdf文件添加"Everyone,Users"用户组的完全控制权限  
            //FileInfo fi = new FileInfo(strMdf);
            //System.Security.AccessControl.FileSecurity fileSecurity = fi.GetAccessControl();
            //fileSecurity.AddAccessRule(new FileSystemAccessRule("Authenticated Users", FileSystemRights.FullControl, AccessControlType.Allow));
            ////fileSecurity.AddAccessRule(new FileSystemAccessRule("Users", FileSystemRights.FullControl, AccessControlType.Allow));
            //fi.SetAccessControl(fileSecurity);

            //FileInfo fi1 = new FileInfo(strLdf);
            //System.Security.AccessControl.FileSecurity fileSecurity1 = fi1.GetAccessControl();
            //fileSecurity1.AddAccessRule(new FileSystemAccessRule("Authenticated Users", FileSystemRights.FullControl, AccessControlType.Allow));
            ////fileSecurity.AddAccessRule(new FileSystemAccessRule("Users", FileSystemRights.FullControl, AccessControlType.Allow));
           // fi1.SetAccessControl(fileSecurity1);
            this.CreateDataBase(strSql, DataName, strMdf, strLdf, path);//开始创建数据库
        }

    }
}
