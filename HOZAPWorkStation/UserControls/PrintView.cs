using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using HAZOPBLL;

namespace HOZAPWorkStation.UserControls
{
    public partial class PrintView : UserControl
    {
  
        public PrintView()
        {
            InitializeComponent();
        }

        public object datasource { set; get; }
        public int Report { set; get; }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            BindingSource bd = new BindingSource();
            ReportDataSource rds = new ReportDataSource();
            bd.DataSource= datasource;
            rds.Name = "Data";
            rds.Value = bd;
            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.DataSources.Clear();

            if (Report == 1)
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "HOZAPWorkStation.ReportUI.Report1.rdlc";
            }
            else
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "HOZAPWorkStation.ReportUI.Report2.rdlc";
            }
            

            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] {
                 new ReportParameter("ProName",HAZOP分析系统.ProName)
                    });

            this.reportViewer1.RefreshReport();
        }


    }
}
