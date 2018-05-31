using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace HOZAPWorkStation.ExportExcel
{
    class ExportExcel
    { 
        /// <summary>    
        ///导出DataGridView中的数据到Excel文件    
        /// </summary>    
        /// <remarks>   
        /// add com "Microsoft Excel 14.0 Object Library"   
        /// using Excel=Microsoft.Office.Interop.Excel;   
        /// using System.Reflection;   
        /// </remarks>   
        /// <param name= "dgv"> DataGridView </param>    
        public static void DataGridViewToExcel(DataGridView dgv)
        {
            //申明保存对话框    
            SaveFileDialog dlg = new SaveFileDialog();
            //默然文件后缀    
            dlg.DefaultExt = "xlsx ";
            //文件后缀列表    
            dlg.Filter = "EXCEL文件(*.XLSX)|*.xlsx ";
            //默然路径是系统当前路径    
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框    
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            //返回文件路径    
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效    
            if (fileNameString.Trim() == " ")
            { return; }
            //定义表格内数据的行数和列数    
            int rowscount = dgv.Rows.Count;
            int colscount = dgv.Columns.Count;
            //行数必须大于0    
            if (rowscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数必须大于0    
            if (colscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //行数不可以大于65536    
            if (rowscount > 65536)
            {
                MessageBox.Show("数据记录数太多(最多不能超过65536条)，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数不可以大于255    
            if (colscount > 255)
            {
                MessageBox.Show("数据记录行数太多，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //验证以fileNameString命名的文件是否存在，如果存在删除它    
            FileInfo file = new FileInfo(fileNameString);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "删除失败 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            Excel.Application objExcel = null;
            Excel.Workbook objWorkbook = null;
            Excel.Worksheet objsheet = null;
            try
            {
                //申明对象    
                objExcel = new Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(Missing.Value);
                objsheet = (Excel.Worksheet)objWorkbook.ActiveSheet;
                //设置EXCEL不可见    
                objExcel.Visible = true;

                //向Excel中写入表格的表头    
                int displayColumnsCount = 1;
                for (int i = 0; i <= dgv.ColumnCount - 1; i++)
                {
                    if (dgv.Columns[i].Visible == true)
                    {
                        objExcel.Cells[1, displayColumnsCount] = dgv.Columns[i].HeaderText.Trim();
                        displayColumnsCount++;
                    }
                }    
                //向Excel中逐行逐列写入表格中的数据    
                for (int row = 0; row <= dgv.RowCount - 1; row++)
                {
                    //tempProgressBar.PerformStep();    

                    displayColumnsCount = 1;
                    for (int col = 0; col < colscount; col++)
                    {
                        if (dgv.Columns[col].Visible == true)
                        {
                            try
                            {
                                objExcel.Cells[row + 2, displayColumnsCount] = dgv.Rows[row].Cells[col].Value.ToString().Trim();
                                displayColumnsCount++;
                            }
                            catch (Exception)
                            {

                            }

                        }
                    }
                }   
                //保存文件    
                objWorkbook.SaveAs(fileNameString, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                //关闭Excel应用    
                if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
                if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
                if (objExcel != null) objExcel.Quit();

                objsheet = null;
                objWorkbook = null;
                objExcel = null;
            }
            MessageBox.Show(fileNameString + "/n/n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
