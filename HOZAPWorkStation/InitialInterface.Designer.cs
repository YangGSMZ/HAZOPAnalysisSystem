namespace HOZAPWorkStation
{
    partial class InitialInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialInterface));
            this.initMenuStrip = new System.Windows.Forms.MenuStrip();
            this.menuSsripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initPanel = new System.Windows.Forms.Panel();
            this.tpSysteamIndex = new System.Windows.Forms.TabPage();
            this.newBtn = new System.Windows.Forms.Button();
            this.preBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.analysisBtn = new System.Windows.Forms.Button();
            this.nodeBtn = new System.Windows.Forms.Button();
            this.openBtn = new System.Windows.Forms.Button();
            this.MainTableControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucPrepareControl2 = new HOZAPWorkStation.UserControls.UcPrepareControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucNodePartition1 = new HOZAPWorkStation.UserControls.UcNodePartition();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ucAnalysis1 = new HOZAPWorkStation.UserControls.UcAnalysis();
            this.initMenuStrip.SuspendLayout();
            this.tpSysteamIndex.SuspendLayout();
            this.MainTableControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // initMenuStrip
            // 
            this.initMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSsripToolStripMenuItem});
            this.initMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.initMenuStrip.Name = "initMenuStrip";
            this.initMenuStrip.Size = new System.Drawing.Size(800, 25);
            this.initMenuStrip.TabIndex = 1;
            // 
            // menuSsripToolStripMenuItem
            // 
            this.menuSsripToolStripMenuItem.Name = "menuSsripToolStripMenuItem";
            this.menuSsripToolStripMenuItem.Size = new System.Drawing.Size(81, 21);
            this.menuSsripToolStripMenuItem.Text = "menuSsrip";
            // 
            // initPanel
            // 
            this.initPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.initPanel.Location = new System.Drawing.Point(0, 25);
            this.initPanel.Margin = new System.Windows.Forms.Padding(0);
            this.initPanel.Name = "initPanel";
            this.initPanel.Size = new System.Drawing.Size(800, 31);
            this.initPanel.TabIndex = 2;
            // 
            // tpSysteamIndex
            // 
            this.tpSysteamIndex.BackColor = System.Drawing.Color.LightGray;
            this.tpSysteamIndex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tpSysteamIndex.Controls.Add(this.newBtn);
            this.tpSysteamIndex.Controls.Add(this.preBtn);
            this.tpSysteamIndex.Controls.Add(this.printBtn);
            this.tpSysteamIndex.Controls.Add(this.analysisBtn);
            this.tpSysteamIndex.Controls.Add(this.nodeBtn);
            this.tpSysteamIndex.Controls.Add(this.openBtn);
            this.tpSysteamIndex.Font = new System.Drawing.Font("宋体", 9F);
            this.tpSysteamIndex.Location = new System.Drawing.Point(4, 29);
            this.tpSysteamIndex.Name = "tpSysteamIndex";
            this.tpSysteamIndex.Padding = new System.Windows.Forms.Padding(3);
            this.tpSysteamIndex.Size = new System.Drawing.Size(792, 361);
            this.tpSysteamIndex.TabIndex = 0;
            this.tpSysteamIndex.Text = "系统首页";
            // 
            // newBtn
            // 
            this.newBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.newBtn.Location = new System.Drawing.Point(94, 211);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(75, 75);
            this.newBtn.TabIndex = 11;
            this.newBtn.Text = "新建";
            this.newBtn.UseVisualStyleBackColor = false;
            // 
            // preBtn
            // 
            this.preBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.preBtn.Location = new System.Drawing.Point(213, 130);
            this.preBtn.Name = "preBtn";
            this.preBtn.Size = new System.Drawing.Size(75, 75);
            this.preBtn.TabIndex = 5;
            this.preBtn.Text = "准备";
            this.preBtn.UseVisualStyleBackColor = false;
            // 
            // printBtn
            // 
            this.printBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.printBtn.Location = new System.Drawing.Point(591, 130);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 75);
            this.printBtn.TabIndex = 8;
            this.printBtn.Text = "打印";
            this.printBtn.UseVisualStyleBackColor = false;
            // 
            // analysisBtn
            // 
            this.analysisBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.analysisBtn.Location = new System.Drawing.Point(453, 130);
            this.analysisBtn.Name = "analysisBtn";
            this.analysisBtn.Size = new System.Drawing.Size(75, 75);
            this.analysisBtn.TabIndex = 7;
            this.analysisBtn.Text = "分析";
            this.analysisBtn.UseVisualStyleBackColor = false;
            // 
            // nodeBtn
            // 
            this.nodeBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.nodeBtn.Location = new System.Drawing.Point(333, 130);
            this.nodeBtn.Name = "nodeBtn";
            this.nodeBtn.Size = new System.Drawing.Size(75, 75);
            this.nodeBtn.TabIndex = 6;
            this.nodeBtn.Text = "节点";
            this.nodeBtn.UseVisualStyleBackColor = false;
            this.nodeBtn.Click += new System.EventHandler(this.nodeBtn_Click);
            // 
            // openBtn
            // 
            this.openBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.openBtn.Location = new System.Drawing.Point(94, 48);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 75);
            this.openBtn.TabIndex = 4;
            this.openBtn.Text = "打开";
            this.openBtn.UseVisualStyleBackColor = false;
            // 
            // MainTableControl
            // 
            this.MainTableControl.Controls.Add(this.tpSysteamIndex);
            this.MainTableControl.Controls.Add(this.tabPage1);
            this.MainTableControl.Controls.Add(this.tabPage2);
            this.MainTableControl.Controls.Add(this.tabPage3);
            this.MainTableControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.MainTableControl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainTableControl.ItemSize = new System.Drawing.Size(70, 25);
            this.MainTableControl.Location = new System.Drawing.Point(0, 56);
            this.MainTableControl.Name = "MainTableControl";
            this.MainTableControl.SelectedIndex = 0;
            this.MainTableControl.Size = new System.Drawing.Size(800, 394);
            this.MainTableControl.TabIndex = 13;
            this.MainTableControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.MainTableControl_DrawItem);
            this.MainTableControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainTableControl_MouseDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucPrepareControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 361);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucPrepareControl2
            // 
            this.ucPrepareControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPrepareControl2.Location = new System.Drawing.Point(3, 3);
            this.ucPrepareControl2.Margin = new System.Windows.Forms.Padding(4);
            this.ucPrepareControl2.Name = "ucPrepareControl2";
            this.ucPrepareControl2.Size = new System.Drawing.Size(786, 355);
            this.ucPrepareControl2.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucNodePartition1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 361);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucNodePartition1
            // 
            this.ucNodePartition1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucNodePartition1.Location = new System.Drawing.Point(3, 3);
            this.ucNodePartition1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucNodePartition1.Name = "ucNodePartition1";
            this.ucNodePartition1.Size = new System.Drawing.Size(786, 355);
            this.ucNodePartition1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ucAnalysis1);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 361);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ucAnalysis1
            // 
            this.ucAnalysis1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAnalysis1.Location = new System.Drawing.Point(3, 3);
            this.ucAnalysis1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucAnalysis1.Name = "ucAnalysis1";
            this.ucAnalysis1.Size = new System.Drawing.Size(786, 355);
            this.ucAnalysis1.TabIndex = 0;
            // 
            // InitialInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainTableControl);
            this.Controls.Add(this.initPanel);
            this.Controls.Add(this.initMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.initMenuStrip;
            this.Name = "InitialInterface";
            this.Text = "InitialInterface";
            this.Load += new System.EventHandler(this.InitialInterface_Load);
            this.Resize += new System.EventHandler(this.InitialInterface_Resize);
            this.initMenuStrip.ResumeLayout(false);
            this.initMenuStrip.PerformLayout();
            this.tpSysteamIndex.ResumeLayout(false);
            this.MainTableControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip initMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuSsripToolStripMenuItem;
        private System.Windows.Forms.Panel initPanel;
        private UserControls.UcPrepareControl ucPrepareControl1;
        private System.Windows.Forms.TabPage tpSysteamIndex;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button preBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button analysisBtn;
        private System.Windows.Forms.Button nodeBtn;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.TabControl MainTableControl;
        private System.Windows.Forms.TabPage tabPage1;
        private UserControls.UcPrepareControl ucPrepareControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private UserControls.UcNodePartition ucNodePartition1;
        private System.Windows.Forms.TabPage tabPage3;
        private UserControls.UcAnalysis ucAnalysis1;
    }
}