using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HAZOPBLL;
using HOZAPDAL;
using HOZAPModel;
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
            dlg.DefaultExt = "xls";
            //文件后缀列表    
            dlg.Filter = "Excel文件(*.xls)|*.xls";
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

                //设置EXCEL可见    
                objExcel.Visible = true;

                //向Excel中写入表格的表头    
                CombineTransverse(1,1,12,"分析项目：", objExcel, objsheet);
                CombineTransverse(1, 13, 16, "表页：", objExcel, objsheet);
                CombineTransverse(2, 1, 3, "图纸编号：", objExcel, objsheet);
                CombineTransverse(2, 4, 12, "版本号：", objExcel, objsheet);
                CombineTransverse(2, 13, 16, "日期：", objExcel, objsheet);

                ParticipantBLL participantBLL = new ParticipantBLL();
                List<Participant> list = participantBLL.Get_ParticipantInfoList(HAZOP分析系统.ProName);
                string participantList = String.Empty;
                if (list != null)
                {
                    foreach (Participant p in list)
                    {
                        participantList = participantList + p.Name + " ";
                    }
                }
              
                CombineTransverse(3, 1, 3, "小组成员："+ participantList, objExcel, objsheet);
                CombineTransverse(3, 4, 12, "", objExcel, objsheet);
                CombineTransverse(3, 13, 16, "会议时间：", objExcel, objsheet);
                CombineTransverse(4, 1, 12, "节点：", objExcel, objsheet);
                CombineTransverse(4, 13,16, "", objExcel, objsheet);
                CombineTransverse(5, 1, 3, "设计意图：", objExcel, objsheet);
                CombineTransverse(5, 4, 16, "", objExcel, objsheet);

                Range range = objsheet.Range[objsheet.Cells[1, 1], objsheet.Cells[5, 16]];
                //range.WrapText = true;
                range.Font.Color=Color.Black;//字体颜色
                range.Font.Name = "宋体";//字体
                //range.Font.Bold = true; //设置为粗体
                range.Font.Size = 14;//字体大小            
                range.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                range.ColumnWidth = 12;//列宽
                range.RowHeight = 22;//行高
                //range.EntireRow.AutoFit();//添加到行高设置之后才有效
                //range.Borders.ColorIndex = 2;//边框颜色
                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;//边框线类型

                Range TitleRange = objsheet.Range[objsheet.Cells[6, 1], objsheet.Cells[6, 16]];
                TitleRange.Font.Color = Color.Black;//字体颜色
                TitleRange.Font.Name = "宋体";//字体
                TitleRange.Font.Size = 12;//字体大小            
                TitleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                TitleRange.RowHeight = 20;//行高   

                int displayColumnsCount = 1;
                for (int i = 0; i <= dgv.ColumnCount-1 ; i++)
                {
                    if (dgv.Columns[i].Visible==true)
                    {
                        objExcel.Cells[6, displayColumnsCount] = dgv.Columns[i].HeaderText.Trim();
                        displayColumnsCount++;
                    }
                    else
                    {
                       
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
                                objExcel.Cells[row + 7, displayColumnsCount] = "'"+dgv.Rows[row].Cells[col].Value.ToString().Trim();
                                displayColumnsCount++;
                            }
                            catch (Exception)
                            {

                            }
                        }
                        else
                        {
                            
                        }
                      
                    }
                }
                //设置自适应行高
                Range endrange = objsheet.Range[objsheet.Cells[1, 1], objsheet.Cells[rowscount+6, colscount-3]];
                endrange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                endrange.WrapText = true;
                endrange.EntireRow.AutoFit();
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

        public static void CombineTransverse(int row, int begin, int end, string text, ExcelApp.Application excel, ExcelApp.Worksheet xSt)
        {
            excel.Cells[row, begin] = text;
            //设置整个报表的标题为跨列居中 
            xSt.Range[excel.Cells[row, begin], excel.Cells[row, end]].Select();
            xSt.Range[excel.Cells[row, begin], excel.Cells[row, end]].HorizontalAlignment = XlHAlign.xlHAlignLeft;
            xSt.Range[excel.Cells[row, begin], excel.Cells[row, end]].MergeCells = true;
            xSt.Range[excel.Cells[row, begin], excel.Cells[row, end]].WrapText = true;

        }



        public static void DataBaseToExcel()
        {
            AnalyResultBLL analyResultBLL = new AnalyResultBLL();
            System.Data.DataTable dt = analyResultBLL.OutAllToExcel(HAZOP分析系统.ProName);

            //申明保存对话框    
            SaveFileDialog dlg = new SaveFileDialog();
            //默然文件后缀    
            dlg.DefaultExt = "xls";
            //文件后缀列表    
            dlg.Filter = "Excel文件(*.xls)|*.xls";
            //默然路径是系统当前路径    
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框    
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            //返回文件路径    
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效    
            if (fileNameString.Trim() == " ")
            {
                return;
            }

            //定义表格内数据的行数和列数    
            int rowscount = dt.Rows.Count;
            int colscount = dt.Columns.Count;
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

                //设置EXCEL可见    
                objExcel.Visible = true;

                //向Excel中写入表格的表头    
                CombineTransverse(1, 1, 12, "分析项目：", objExcel, objsheet);
                CombineTransverse(1, 13, 16, "表页：", objExcel, objsheet);
                CombineTransverse(2, 1, 3, "图纸编号：", objExcel, objsheet);
                CombineTransverse(2, 4, 12, "版本号：", objExcel, objsheet);
                CombineTransverse(2, 13, 16, "日期：", objExcel, objsheet);

                ParticipantBLL participantBLL = new ParticipantBLL();
                List<Participant> list = participantBLL.Get_ParticipantInfoList(HAZOP分析系统.ProName);
                string participantList = String.Empty;
                if(list!=null)
                {
                    foreach (Participant p in list)
                    {
                        participantList = participantList + p.Name + " ";
                    }
                }
               

                CombineTransverse(3, 1, 3, "小组成员：" + participantList, objExcel, objsheet);
                CombineTransverse(3, 4, 12, "", objExcel, objsheet);
                CombineTransverse(3, 13, 16, "会议时间：", objExcel, objsheet);
                CombineTransverse(4, 1, 12, "节点：", objExcel, objsheet);
                CombineTransverse(4, 13, 16, "", objExcel, objsheet);
                CombineTransverse(5, 1, 3, "设计意图：", objExcel, objsheet);
                CombineTransverse(5, 4, 16, "", objExcel, objsheet);

                Range range = objsheet.Range[objsheet.Cells[1, 1], objsheet.Cells[5, 16]];
                //range.WrapText = true;
                range.Font.Color = Color.Black;//字体颜色
                range.Font.Name = "宋体";//字体
                //range.Font.Bold = true; //设置为粗体
                range.Font.Size = 14;//字体大小            
                range.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                range.ColumnWidth = 12;//列宽
                range.RowHeight = 22;//行高
                //range.EntireRow.AutoFit();//添加到行高设置之后才有效
                //range.Borders.ColorIndex = 2;//边框颜色
                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;//边框线类型

                Range TitleRange = objsheet.Range[objsheet.Cells[6, 1], objsheet.Cells[6, 16]];
                TitleRange.Font.Color = Color.Black;//字体颜色
                TitleRange.Font.Name = "宋体";//字体
                TitleRange.Font.Size = 12;//字体大小            
                TitleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                TitleRange.RowHeight = 20;//行高   

                int displayColumnsCount = 1;
                for (int i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    if (dt.Columns[i].ColumnName != "F0"&& dt.Columns[i].ColumnName != "Fs" && dt.Columns[i].ColumnName != "ProName" &&
                        dt.Columns[i].ColumnName != "ResultID" && dt.Columns[i].ColumnName != "NodeName" )
                    {
                        string colunmName = String.Empty;
                        if (dt.Columns[i].ColumnName == "RecordNumver")
                        {
                            colunmName = "编号";
                        }
                        if (dt.Columns[i].ColumnName == "Pramas")
                        {
                            colunmName = "参数";
                        }
                        if (dt.Columns[i].ColumnName == "PramasAndIntroduce")
                        {
                            colunmName = "参数+引导词";
                        }
                        if (dt.Columns[i].ColumnName == "DeviateDescription")
                        {
                            colunmName = "偏离描述";
                        }
                        if (dt.Columns[i].ColumnName == "Reason")
                        {
                            colunmName = "原因";
                        }
                        if (dt.Columns[i].ColumnName == "Consequence")
                        {
                            colunmName = "后果";
                        }
                        if (dt.Columns[i].ColumnName == "Measure")
                        {
                            colunmName = "现有措施";
                        }
                        if (dt.Columns[i].ColumnName == "Suggestion")
                        {
                            colunmName = "建议项";
                        }
                        if (dt.Columns[i].ColumnName == "Company")
                        {
                            colunmName = "负责单位/人";
                        }
                        if (dt.Columns[i].ColumnName == "Mark")
                        {
                            colunmName = "备注";
                        }
                        if (dt.Columns[i].ColumnName == "Si")
                        {
                            colunmName = "S";
                        }
                        if (dt.Columns[i].ColumnName == "Li")
                        {
                            colunmName = "L";
                        }
                        if (dt.Columns[i].ColumnName == "Ri")
                        {
                            colunmName = "R";
                        }
                        if (dt.Columns[i].ColumnName == "S")
                        {
                            colunmName = "Sr";
                        }
                        if (dt.Columns[i].ColumnName == "L")
                        {
                            colunmName = "Lr";
                        }
                        if (dt.Columns[i].ColumnName == "R")
                        {
                            colunmName = "Rr";
                        }
                        objExcel.Cells[6, displayColumnsCount] = colunmName;
                        displayColumnsCount++;
                    }
                    else
                    {

                    }
                }
                //向Excel中逐行逐列写入表格中的数据    
                for (int row = 0; row <= dt.Rows.Count - 1; row++)
                {
                    displayColumnsCount = 1;
                    for (int col = 0; col < colscount; col++)
                    {
                        if (dt.Columns[col].ColumnName != "F0" && dt.Columns[col].ColumnName != "Fs" && dt.Columns[col].ColumnName != "ProName" &&
                        dt.Columns[col].ColumnName != "ResultID" && dt.Columns[col].ColumnName != "NodeName")
                        {
                            try
                            {
                                objExcel.Cells[row + 7, displayColumnsCount] = "'" + dt.Rows[row].ItemArray[col].ToString();
                                displayColumnsCount++;
                            }
                            catch (Exception)
                            {

                            }
                        }
                        else
                        {

                        }

                    }
                }
                //设置自适应行高
                Range endrange = objsheet.Range[objsheet.Cells[1, 1], objsheet.Cells[rowscount + 6, colscount - 5]];
                endrange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                endrange.WrapText = true;
                endrange.EntireRow.AutoFit();
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
