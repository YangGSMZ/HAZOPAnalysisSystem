namespace HOZAPWorkStation
{
    partial class ProNameList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProNameList));
            this.tspProNameList = new System.Windows.Forms.ToolStrip();
            this.tspOpenProNameList = new System.Windows.Forms.ToolStripButton();
            this.tspDeleteProNameList = new System.Windows.Forms.ToolStripButton();
            this.lvProNameList = new System.Windows.Forms.ListView();
            this.tspProNameList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tspProNameList
            // 
            this.tspProNameList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tspProNameList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspOpenProNameList,
            this.tspDeleteProNameList});
            this.tspProNameList.Location = new System.Drawing.Point(0, 235);
            this.tspProNameList.Name = "tspProNameList";
            this.tspProNameList.Size = new System.Drawing.Size(440, 25);
            this.tspProNameList.TabIndex = 0;
            this.tspProNameList.Text = "toolStrip1";
            // 
            // tspOpenProNameList
            // 
            this.tspOpenProNameList.Image = ((System.Drawing.Image)(resources.GetObject("tspOpenProNameList.Image")));
            this.tspOpenProNameList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspOpenProNameList.Name = "tspOpenProNameList";
            this.tspOpenProNameList.Size = new System.Drawing.Size(52, 22);
            this.tspOpenProNameList.Text = "打开";
            this.tspOpenProNameList.Click += new System.EventHandler(this.tspOpenProNameList_Click);
            // 
            // tspDeleteProNameList
            // 
            this.tspDeleteProNameList.Image = ((System.Drawing.Image)(resources.GetObject("tspDeleteProNameList.Image")));
            this.tspDeleteProNameList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspDeleteProNameList.Name = "tspDeleteProNameList";
            this.tspDeleteProNameList.Size = new System.Drawing.Size(52, 22);
            this.tspDeleteProNameList.Text = "删除";
            this.tspDeleteProNameList.Click += new System.EventHandler(this.tspDeleteProNameList_Click);
            // 
            // lvProNameList
            // 
            this.lvProNameList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvProNameList.AutoArrange = false;
            this.lvProNameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProNameList.GridLines = true;
            this.lvProNameList.Location = new System.Drawing.Point(0, 0);
            this.lvProNameList.MultiSelect = false;
            this.lvProNameList.Name = "lvProNameList";
            this.lvProNameList.Size = new System.Drawing.Size(440, 235);
            this.lvProNameList.TabIndex = 1;
            this.lvProNameList.UseCompatibleStateImageBehavior = false;
            this.lvProNameList.View = System.Windows.Forms.View.SmallIcon;
            // 
            // ProNameList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(440, 260);
            this.Controls.Add(this.lvProNameList);
            this.Controls.Add(this.tspProNameList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(456, 299);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(456, 299);
            this.Name = "ProNameList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "已创建项目";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProNameList_FormClosing);
            this.Load += new System.EventHandler(this.ProNameList_Load);
            this.tspProNameList.ResumeLayout(false);
            this.tspProNameList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspProNameList;
        private System.Windows.Forms.ToolStripButton tspOpenProNameList;
        private System.Windows.Forms.ToolStripButton tspDeleteProNameList;
        private System.Windows.Forms.ListView lvProNameList;
    }
}