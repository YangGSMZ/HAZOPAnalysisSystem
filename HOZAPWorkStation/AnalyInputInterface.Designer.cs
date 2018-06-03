namespace HOZAPWorkStation
{
    partial class AnalyInputInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalyInputInterface));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbcAnalyInputInterface = new System.Windows.Forms.TabControl();
            this.tbcPageExpert = new System.Windows.Forms.TabPage();
            this.dgvTbcPageAnaExpert = new System.Windows.Forms.DataGridView();
            this.Records = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbcPagePersonal = new System.Windows.Forms.TabPage();
            this.dgvTbcPageAnaPersonal = new System.Windows.Forms.DataGridView();
            this.RecordPersonal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtbAnaInputInterface = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tspAnaInputInterface = new System.Windows.Forms.ToolStrip();
            this.btnAnalyInputAdd = new System.Windows.Forms.ToolStripButton();
            this.btnAnalyInputDelete = new System.Windows.Forms.ToolStripButton();
            this.btnAnalyInputEntry = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.tbcAnalyInputInterface.SuspendLayout();
            this.tbcPageExpert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTbcPageAnaExpert)).BeginInit();
            this.tbcPagePersonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTbcPageAnaPersonal)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tspAnaInputInterface.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tbcAnalyInputInterface);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 239);
            this.panel1.TabIndex = 0;
            // 
            // tbcAnalyInputInterface
            // 
            this.tbcAnalyInputInterface.Controls.Add(this.tbcPageExpert);
            this.tbcAnalyInputInterface.Controls.Add(this.tbcPagePersonal);
            this.tbcAnalyInputInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcAnalyInputInterface.Location = new System.Drawing.Point(0, 0);
            this.tbcAnalyInputInterface.Name = "tbcAnalyInputInterface";
            this.tbcAnalyInputInterface.SelectedIndex = 0;
            this.tbcAnalyInputInterface.Size = new System.Drawing.Size(482, 235);
            this.tbcAnalyInputInterface.TabIndex = 0;
            // 
            // tbcPageExpert
            // 
            this.tbcPageExpert.AutoScroll = true;
            this.tbcPageExpert.Controls.Add(this.dgvTbcPageAnaExpert);
            this.tbcPageExpert.Location = new System.Drawing.Point(4, 22);
            this.tbcPageExpert.Name = "tbcPageExpert";
            this.tbcPageExpert.Padding = new System.Windows.Forms.Padding(3);
            this.tbcPageExpert.Size = new System.Drawing.Size(474, 209);
            this.tbcPageExpert.TabIndex = 0;
            this.tbcPageExpert.Text = "专家经验库";
            this.tbcPageExpert.UseVisualStyleBackColor = true;
            // 
            // dgvTbcPageAnaExpert
            // 
            this.dgvTbcPageAnaExpert.AllowUserToDeleteRows = false;
            this.dgvTbcPageAnaExpert.AllowUserToResizeRows = false;
            this.dgvTbcPageAnaExpert.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dgvTbcPageAnaExpert.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTbcPageAnaExpert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTbcPageAnaExpert.ColumnHeadersVisible = false;
            this.dgvTbcPageAnaExpert.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Records});
            this.dgvTbcPageAnaExpert.Location = new System.Drawing.Point(3, 3);
            this.dgvTbcPageAnaExpert.MultiSelect = false;
            this.dgvTbcPageAnaExpert.Name = "dgvTbcPageAnaExpert";
            this.dgvTbcPageAnaExpert.RowHeadersWidth = 30;
            this.dgvTbcPageAnaExpert.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTbcPageAnaExpert.RowTemplate.Height = 23;
            this.dgvTbcPageAnaExpert.Size = new System.Drawing.Size(468, 203);
            this.dgvTbcPageAnaExpert.TabIndex = 0;
            this.dgvTbcPageAnaExpert.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTbcPageAnaExpert_CellClick);
            // 
            // Records
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Records.DefaultCellStyle = dataGridViewCellStyle4;
            this.Records.FillWeight = 1F;
            this.Records.HeaderText = "记录";
            this.Records.Name = "Records";
            this.Records.ReadOnly = true;
            this.Records.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Records.Width = 465;
            // 
            // tbcPagePersonal
            // 
            this.tbcPagePersonal.AutoScroll = true;
            this.tbcPagePersonal.Controls.Add(this.dgvTbcPageAnaPersonal);
            this.tbcPagePersonal.Location = new System.Drawing.Point(4, 22);
            this.tbcPagePersonal.Name = "tbcPagePersonal";
            this.tbcPagePersonal.Padding = new System.Windows.Forms.Padding(3);
            this.tbcPagePersonal.Size = new System.Drawing.Size(474, 209);
            this.tbcPagePersonal.TabIndex = 1;
            this.tbcPagePersonal.Text = "个人经验库";
            this.tbcPagePersonal.UseVisualStyleBackColor = true;
            // 
            // dgvTbcPageAnaPersonal
            // 
            this.dgvTbcPageAnaPersonal.AllowUserToDeleteRows = false;
            this.dgvTbcPageAnaPersonal.AllowUserToResizeRows = false;
            this.dgvTbcPageAnaPersonal.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dgvTbcPageAnaPersonal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTbcPageAnaPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTbcPageAnaPersonal.ColumnHeadersVisible = false;
            this.dgvTbcPageAnaPersonal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RecordPersonal});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTbcPageAnaPersonal.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTbcPageAnaPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTbcPageAnaPersonal.Location = new System.Drawing.Point(3, 3);
            this.dgvTbcPageAnaPersonal.Name = "dgvTbcPageAnaPersonal";
            this.dgvTbcPageAnaPersonal.RowHeadersVisible = false;
            this.dgvTbcPageAnaPersonal.RowTemplate.Height = 23;
            this.dgvTbcPageAnaPersonal.Size = new System.Drawing.Size(468, 203);
            this.dgvTbcPageAnaPersonal.TabIndex = 0;
            // 
            // RecordPersonal
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RecordPersonal.DefaultCellStyle = dataGridViewCellStyle5;
            this.RecordPersonal.FillWeight = 1F;
            this.RecordPersonal.HeaderText = "记录";
            this.RecordPersonal.Name = "RecordPersonal";
            this.RecordPersonal.ReadOnly = true;
            this.RecordPersonal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RecordPersonal.Width = 465;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "内容：";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.rtbAnaInputInterface);
            this.panel2.Location = new System.Drawing.Point(-2, 258);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(486, 167);
            this.panel2.TabIndex = 2;
            // 
            // rtbAnaInputInterface
            // 
            this.rtbAnaInputInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbAnaInputInterface.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbAnaInputInterface.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rtbAnaInputInterface.Location = new System.Drawing.Point(0, 0);
            this.rtbAnaInputInterface.Name = "rtbAnaInputInterface";
            this.rtbAnaInputInterface.Size = new System.Drawing.Size(482, 163);
            this.rtbAnaInputInterface.TabIndex = 0;
            this.rtbAnaInputInterface.Text = "";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tspAnaInputInterface);
            this.panel3.Location = new System.Drawing.Point(4, 429);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(480, 30);
            this.panel3.TabIndex = 4;
            // 
            // tspAnaInputInterface
            // 
            this.tspAnaInputInterface.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tspAnaInputInterface.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAnalyInputAdd,
            this.btnAnalyInputDelete,
            this.btnAnalyInputEntry});
            this.tspAnaInputInterface.Location = new System.Drawing.Point(0, 3);
            this.tspAnaInputInterface.Name = "tspAnaInputInterface";
            this.tspAnaInputInterface.Size = new System.Drawing.Size(478, 25);
            this.tspAnaInputInterface.TabIndex = 0;
            this.tspAnaInputInterface.Text = "toolStrip1";
            // 
            // btnAnalyInputAdd
            // 
            this.btnAnalyInputAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAnalyInputAdd.Image")));
            this.btnAnalyInputAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnalyInputAdd.Name = "btnAnalyInputAdd";
            this.btnAnalyInputAdd.Size = new System.Drawing.Size(124, 22);
            this.btnAnalyInputAdd.Text = "添加到个人经验库";
            // 
            // btnAnalyInputDelete
            // 
            this.btnAnalyInputDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnAnalyInputDelete.Image")));
            this.btnAnalyInputDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnalyInputDelete.Name = "btnAnalyInputDelete";
            this.btnAnalyInputDelete.Size = new System.Drawing.Size(112, 22);
            this.btnAnalyInputDelete.Text = "删除个人经验库";
            // 
            // btnAnalyInputEntry
            // 
            this.btnAnalyInputEntry.Image = ((System.Drawing.Image)(resources.GetObject("btnAnalyInputEntry.Image")));
            this.btnAnalyInputEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnalyInputEntry.Name = "btnAnalyInputEntry";
            this.btnAnalyInputEntry.Size = new System.Drawing.Size(52, 22);
            this.btnAnalyInputEntry.Text = "确定";
            this.btnAnalyInputEntry.Click += new System.EventHandler(this.btnAnalyInputEntry_Click);
            // 
            // AnalyInputInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "AnalyInputInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AnalyInputInterface";
            this.Load += new System.EventHandler(this.AnalyInputInterface_Load);
            this.panel1.ResumeLayout(false);
            this.tbcAnalyInputInterface.ResumeLayout(false);
            this.tbcPageExpert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTbcPageAnaExpert)).EndInit();
            this.tbcPagePersonal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTbcPageAnaPersonal)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tspAnaInputInterface.ResumeLayout(false);
            this.tspAnaInputInterface.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip tspAnaInputInterface;
        private System.Windows.Forms.TabControl tbcAnalyInputInterface;
        private System.Windows.Forms.TabPage tbcPageExpert;
        private System.Windows.Forms.DataGridView dgvTbcPageAnaExpert;
        private System.Windows.Forms.TabPage tbcPagePersonal;
        private System.Windows.Forms.DataGridView dgvTbcPageAnaPersonal;
        private System.Windows.Forms.RichTextBox rtbAnaInputInterface;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordPersonal;
        private System.Windows.Forms.ToolStripButton btnAnalyInputAdd;
        private System.Windows.Forms.ToolStripButton btnAnalyInputDelete;
        private System.Windows.Forms.ToolStripButton btnAnalyInputEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn Records;
    }
}