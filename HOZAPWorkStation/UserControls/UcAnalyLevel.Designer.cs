namespace HOZAPWorkStation.UserControls
{
    partial class UcAnalyLevel
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "1 轻微 误工伤害，不会导致残疾，泄露至收集系统以内的地方，设备损失<=10万元，设备或车间停产<=1天"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "2 较重 厂外人员需要就医，泄露收集系统以外的地方(数量较少并不超出工厂街衢)，设备损失1>=10万元，<=100万元，设备或车间停产>=1天，<=1周，不影响销" +
                "售"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))));
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("3 严重 3 严重 厂内1人死亡，厂外人员残疾伤害，明显泄露至厂外，影响周围邻居，可能遭到投诉，会受到当地媒体关注，设备损失>100万元，<1000万元，严重影响" +
        "对特定客户的销售");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("4 重大 厂外人员1人死亡，明显影响环境，但短期内可以恢复，并会造成公众健康和就医，会受到省级媒体关注，设备损失>1000万元，<=5000万元，设备或车间停产>" +
        "1个月，<=6个月，影响市场份额");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("5 灾难性 厂外人员多人死亡，对周围社区造成长期的影响，导制厂外居民大面积疏散或严重健康影响，收到国家级媒体关注，设备损失>5000万元，设备或车间停产>6个月，" +
        "可能是失去市场");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcAnalyLevel));
            this.listView1 = new System.Windows.Forms.ListView();
            this.SelectionItems = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SelectionItems});
            this.listView1.GridLines = true;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.listView1.Location = new System.Drawing.Point(-7, -1);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1104, 123);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // SelectionItems
            // 
            this.SelectionItems.Text = "";
            this.SelectionItems.Width = 1100;
            // 
            // UcAnalyLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 119);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1097, 158);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1097, 158);
            this.Name = "UcAnalyLevel";
            this.Opacity = 0.8D;
            this.Text = "UcAnalyLevel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UcAnalyLevel_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader SelectionItems;
    }
}