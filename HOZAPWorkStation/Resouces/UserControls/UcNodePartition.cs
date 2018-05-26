using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOZAPWorkStation.UserControls
{
    public partial class UcNodePartition : UserControl
    {
        public delegate void LoadAnalysisPageEvents();
        public event LoadAnalysisPageEvents MyLoadAnalysisPageEvents;
        public delegate void CloseNodePartitionPageEvents();
        public event CloseNodePartitionPageEvents MyCloseNodePartitionPageEvents;
        public UcNodePartition()
        {
            InitializeComponent();
        }

        private void tsbHaZop_Click(object sender, EventArgs e)
        {
            if (MyLoadAnalysisPageEvents != null)
            {
                MyLoadAnalysisPageEvents();
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            if (MyCloseNodePartitionPageEvents != null)
            {
                MyCloseNodePartitionPageEvents();
            }
        }
    }
}
