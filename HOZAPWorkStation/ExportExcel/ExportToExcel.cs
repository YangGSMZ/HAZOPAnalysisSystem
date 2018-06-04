using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using ExcelApp = Microsoft.Office.Interop.Excel;

namespace HOZAPWorkStation.ExportExcel
{
    class ExportToExcel
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
            dlg.Filter = "Excel文件(*.xlsx)|*.xlsx ";
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
            ExcelApp.Application objExcel = null;
            ExcelApp.Workbook objWorkbook = null;
            ExcelApp.Worksheet objsheet = null;
            try
            {
                //申明对象    
                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(true);
                objsheet = (Worksheet)objWorkbook.Worksheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);

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
                //设置自适应行高
                Range range = objsheet.Range[objsheet.Cells[1, 1], objsheet.Cells[rowscount, colscount]];
                range.WrapText = true;
                range.EntireRow.AutoFit();
                //保存文件    
                objWorkbook.SaveAs(fileNameString, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
