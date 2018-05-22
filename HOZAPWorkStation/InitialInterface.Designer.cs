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
            this.openBtn = new System.Windows.Forms.Button();
            this.preBtn = new System.Windows.Forms.Button();
            this.nodeBtn = new System.Windows.Forms.Button();
            this.analysisBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.newBtn = new System.Windows.Forms.Button();
            this.initMenuStrip.SuspendLayout();
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
            // openBtn
            // 
            this.openBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.openBtn.Location = new System.Drawing.Point(640, 268);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 75);
            this.openBtn.TabIndex = 4;
            this.openBtn.Text = "打开";
            this.openBtn.UseVisualStyleBackColor = false;
            // 
            // preBtn
            // 
            this.preBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.preBtn.Location = new System.Drawing.Point(640, 363);
            this.preBtn.Name = "preBtn";
            this.preBtn.Size = new System.Drawing.Size(75, 75);
            this.preBtn.TabIndex = 5;
            this.preBtn.Text = "准备";
            this.preBtn.UseVisualStyleBackColor = false;
            // 
            // nodeBtn
            // 
            this.nodeBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.nodeBtn.Location = new System.Drawing.Point(500, 268);
            this.nodeBtn.Name = "nodeBtn";
            this.nodeBtn.Size = new System.Drawing.Size(75, 75);
            this.nodeBtn.TabIndex = 6;
            this.nodeBtn.Text = "节点";
            this.nodeBtn.UseVisualStyleBackColor = false;
            // 
            // analysisBtn
            // 
            this.analysisBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.analysisBtn.Location = new System.Drawing.Point(500, 163);
            this.analysisBtn.Name = "analysisBtn";
            this.analysisBtn.Size = new System.Drawing.Size(75, 75);
            this.analysisBtn.TabIndex = 7;
            this.analysisBtn.Text = "分析";
            this.analysisBtn.UseVisualStyleBackColor = false;
            // 
            // printBtn
            // 
            this.printBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.printBtn.Location = new System.Drawing.Point(640, 163);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 75);
            this.printBtn.TabIndex = 8;
            this.printBtn.Text = "打印";
            this.printBtn.UseVisualStyleBackColor = false;
            // 
            // newBtn
            // 
            this.newBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.newBtn.Location = new System.Drawing.Point(500, 82);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(75, 75);
            this.newBtn.TabIndex = 11;
            this.newBtn.Text = "新建";
            this.newBtn.UseVisualStyleBackColor = false;
            // 
            // InitialInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.newBtn);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.analysisBtn);
            this.Controls.Add(this.nodeBtn);
            this.Controls.Add(this.preBtn);
            this.Controls.Add(this.openBtn);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip initMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuSsripToolStripMenuItem;
        private System.Windows.Forms.Panel initPanel;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button preBtn;
        private System.Windows.Forms.Button nodeBtn;
        private System.Windows.Forms.Button analysisBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button newBtn;
    }
}