namespace HOZAPWorkStation.UserControls
{
    partial class UcNodePartition
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcNodePartition));
            this.tsNodePartition = new System.Windows.Forms.ToolStrip();
            this.tsbHaZop = new System.Windows.Forms.ToolStripButton();
            this.stbHelp = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tcNode = new System.Windows.Forms.TabControl();
            this.tpNode = new System.Windows.Forms.TabPage();
            this.tvNode = new System.Windows.Forms.TreeView();
            this.tcNodeInfo = new System.Windows.Forms.TabControl();
            this.tpNodeInfo = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tsNodeInfo = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdite = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SelectModelbtn = new System.Windows.Forms.Button();
            this.txtSelectModel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CreateNodeDatebtn = new System.Windows.Forms.Button();
            this.txtNodeCreateDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNodeUsage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNodeDesc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNodeName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbInterim = new System.Windows.Forms.RadioButton();
            this.rbContinuous = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNodeId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ofdSelectModel = new System.Windows.Forms.OpenFileDialog();
            this.tsNodePartition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tcNode.SuspendLayout();
            this.tpNode.SuspendLayout();
            this.tcNodeInfo.SuspendLayout();
            this.tpNodeInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tsNodeInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsNodePartition
            // 
            this.tsNodePartition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHaZop,
            this.stbHelp,
            this.tsbClose});
            this.tsNodePartition.Location = new System.Drawing.Point(0, 0);
            this.tsNodePartition.Name = "tsNodePartition";
            this.tsNodePartition.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsNodePartition.Size = new System.Drawing.Size(884, 25);
            this.tsNodePartition.TabIndex = 0;
            this.tsNodePartition.Text = "toolStrip1";
            // 
            // tsbHaZop
            // 
            this.tsbHaZop.Image = ((System.Drawing.Image)(resources.GetObject("tsbHaZop.Image")));
            this.tsbHaZop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHaZop.Name = "tsbHaZop";
            this.tsbHaZop.Size = new System.Drawing.Size(88, 22);
            this.tsbHaZop.Text = "hazop分析";
            // 
            // stbHelp
            // 
            this.stbHelp.Image = ((System.Drawing.Image)(resources.GetObject("stbHelp.Image")));
            this.stbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stbHelp.Name = "stbHelp";
            this.stbHelp.Size = new System.Drawing.Size(64, 22);
            this.stbHelp.Text = "帮助";
            // 
            // tsbClose
            // 
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(52, 22);
            this.tsbClose.Text = "关闭";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tcNode);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcNodeInfo);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(884, 516);
            this.splitContainer1.SplitterDistance = 211;
            this.splitContainer1.TabIndex = 1;
            // 
            // tcNode
            // 
            this.tcNode.Controls.Add(this.tpNode);
            this.tcNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcNode.Location = new System.Drawing.Point(0, 0);
            this.tcNode.Name = "tcNode";
            this.tcNode.SelectedIndex = 0;
            this.tcNode.Size = new System.Drawing.Size(211, 516);
            this.tcNode.TabIndex = 0;
            // 
            // tpNode
            // 
            this.tpNode.Controls.Add(this.tvNode);
            this.tpNode.Location = new System.Drawing.Point(4, 22);
            this.tpNode.Name = "tpNode";
            this.tpNode.Padding = new System.Windows.Forms.Padding(3);
            this.tpNode.Size = new System.Drawing.Size(203, 490);
            this.tpNode.TabIndex = 1;
            this.tpNode.Text = "节点列表";
            this.tpNode.UseVisualStyleBackColor = true;
            // 
            // tvNode
            // 
            this.tvNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvNode.Location = new System.Drawing.Point(3, 3);
            this.tvNode.Name = "tvNode";
            this.tvNode.Size = new System.Drawing.Size(197, 484);
            this.tvNode.TabIndex = 0;
            // 
            // tcNodeInfo
            // 
            this.tcNodeInfo.Controls.Add(this.tpNodeInfo);
            this.tcNodeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcNodeInfo.Location = new System.Drawing.Point(0, 0);
            this.tcNodeInfo.Name = "tcNodeInfo";
            this.tcNodeInfo.SelectedIndex = 0;
            this.tcNodeInfo.Size = new System.Drawing.Size(669, 516);
            this.tcNodeInfo.TabIndex = 0;
            // 
            // tpNodeInfo
            // 
            this.tpNodeInfo.AutoScroll = true;
            this.tpNodeInfo.Controls.Add(this.panel2);
            this.tpNodeInfo.Controls.Add(this.panel1);
            this.tpNodeInfo.Font = new System.Drawing.Font("宋体", 9F);
            this.tpNodeInfo.Location = new System.Drawing.Point(4, 22);
            this.tpNodeInfo.Name = "tpNodeInfo";
            this.tpNodeInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpNodeInfo.Size = new System.Drawing.Size(661, 490);
            this.tpNodeInfo.TabIndex = 1;
            this.tpNodeInfo.Text = "节点基本信息";
            this.tpNodeInfo.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tsNodeInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 462);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(655, 25);
            this.panel2.TabIndex = 23;
            // 
            // tsNodeInfo
            // 
            this.tsNodeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsNodeInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdite,
            this.tsbDel,
            this.tsbCancel,
            this.tsbSave,
            this.tsbNext});
            this.tsNodeInfo.Location = new System.Drawing.Point(0, 0);
            this.tsNodeInfo.Name = "tsNodeInfo";
            this.tsNodeInfo.Size = new System.Drawing.Size(655, 25);
            this.tsNodeInfo.TabIndex = 23;
            this.tsNodeInfo.Text = "toolStrip2";
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(68, 22);
            this.tsbAdd.Tag = "";
            this.tsbAdd.Text = "增加(A)";
            // 
            // tsbEdite
            // 
            this.tsbEdite.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdite.Image")));
            this.tsbEdite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdite.Name = "tsbEdite";
            this.tsbEdite.Size = new System.Drawing.Size(67, 22);
            this.tsbEdite.Text = "编辑(E)";
            // 
            // tsbDel
            // 
            this.tsbDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbDel.Image")));
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(69, 22);
            this.tsbDel.Text = "删除(D)";
            // 
            // tsbCancel
            // 
            this.tsbCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancel.Image")));
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(68, 22);
            this.tsbCancel.Text = "取消(C)";
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(67, 22);
            this.tsbSave.Text = "保存(S)";
            // 
            // tsbNext
            // 
            this.tsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext.Image")));
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(64, 22);
            this.tsbNext.Text = "下一步";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.SelectModelbtn);
            this.panel1.Controls.Add(this.txtSelectModel);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.CreateNodeDatebtn);
            this.panel1.Controls.Add(this.txtNodeCreateDate);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtNodeUsage);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtNodeDesc);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtNodeName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.rbInterim);
            this.panel1.Controls.Add(this.rbContinuous);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNodeId);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 453);
            this.panel1.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(34, 431);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 12);
            this.label11.TabIndex = 42;
            this.label11.Text = "注：带*为必填项目";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(44, 419);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 12);
            this.label10.TabIndex = 41;
            // 
            // SelectModelbtn
            // 
            this.SelectModelbtn.Location = new System.Drawing.Point(318, 354);
            this.SelectModelbtn.Name = "SelectModelbtn";
            this.SelectModelbtn.Size = new System.Drawing.Size(69, 23);
            this.SelectModelbtn.TabIndex = 40;
            this.SelectModelbtn.Text = "浏览模板";
            this.SelectModelbtn.UseVisualStyleBackColor = true;
            // 
            // txtSelectModel
            // 
            this.txtSelectModel.Location = new System.Drawing.Point(136, 356);
            this.txtSelectModel.Name = "txtSelectModel";
            this.txtSelectModel.Size = new System.Drawing.Size(166, 21);
            this.txtSelectModel.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.DarkBlue;
            this.label9.Location = new System.Drawing.Point(70, 359);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 12);
            this.label9.TabIndex = 38;
            this.label9.Text = "选择模板：";
            // 
            // CreateNodeDatebtn
            // 
            this.CreateNodeDatebtn.Location = new System.Drawing.Point(320, 316);
            this.CreateNodeDatebtn.Name = "CreateNodeDatebtn";
            this.CreateNodeDatebtn.Size = new System.Drawing.Size(36, 23);
            this.CreateNodeDatebtn.TabIndex = 37;
            this.CreateNodeDatebtn.Text = "...";
            this.CreateNodeDatebtn.UseVisualStyleBackColor = true;
            // 
            // txtNodeCreateDate
            // 
            this.txtNodeCreateDate.Location = new System.Drawing.Point(136, 316);
            this.txtNodeCreateDate.Name = "txtNodeCreateDate";
            this.txtNodeCreateDate.Size = new System.Drawing.Size(166, 21);
            this.txtNodeCreateDate.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.DarkBlue;
            this.label8.Location = new System.Drawing.Point(50, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 12);
            this.label8.TabIndex = 35;
            this.label8.Text = "节点生成日期：";
            // 
            // txtNodeUsage
            // 
            this.txtNodeUsage.Location = new System.Drawing.Point(136, 226);
            this.txtNodeUsage.Multiline = true;
            this.txtNodeUsage.Name = "txtNodeUsage";
            this.txtNodeUsage.Size = new System.Drawing.Size(263, 70);
            this.txtNodeUsage.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(50, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "节点设计意图：";
            // 
            // txtNodeDesc
            // 
            this.txtNodeDesc.Location = new System.Drawing.Point(136, 136);
            this.txtNodeDesc.Multiline = true;
            this.txtNodeDesc.Name = "txtNodeDesc";
            this.txtNodeDesc.Size = new System.Drawing.Size(263, 70);
            this.txtNodeDesc.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(70, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "节点描述：";
            // 
            // txtNodeName
            // 
            this.txtNodeName.Location = new System.Drawing.Point(136, 96);
            this.txtNodeName.Name = "txtNodeName";
            this.txtNodeName.Size = new System.Drawing.Size(263, 21);
            this.txtNodeName.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(53, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 29;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(70, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "节点名称：";
            // 
            // rbInterim
            // 
            this.rbInterim.AutoSize = true;
            this.rbInterim.Location = new System.Drawing.Point(235, 58);
            this.rbInterim.Name = "rbInterim";
            this.rbInterim.Size = new System.Drawing.Size(71, 16);
            this.rbInterim.TabIndex = 27;
            this.rbInterim.TabStop = true;
            this.rbInterim.Text = "间歇流程";
            this.rbInterim.UseVisualStyleBackColor = true;
            // 
            // rbContinuous
            // 
            this.rbContinuous.AutoSize = true;
            this.rbContinuous.Location = new System.Drawing.Point(138, 58);
            this.rbContinuous.Name = "rbContinuous";
            this.rbContinuous.Size = new System.Drawing.Size(71, 16);
            this.rbContinuous.TabIndex = 26;
            this.rbContinuous.TabStop = true;
            this.rbContinuous.Text = "连续流程";
            this.rbContinuous.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(70, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "节点类别：";
            // 
            // txtNodeId
            // 
            this.txtNodeId.Location = new System.Drawing.Point(136, 16);
            this.txtNodeId.Name = "txtNodeId";
            this.txtNodeId.Size = new System.Drawing.Size(166, 21);
            this.txtNodeId.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(70, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "节点编号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(52, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "*";
            // 
            // ofdSelectModel
            // 
            this.ofdSelectModel.FileName = "openFileDialog1";
            // 
            // UcNodePartition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tsNodePartition);
            this.Name = "UcNodePartition";
            this.Size = new System.Drawing.Size(884, 541);
            this.tsNodePartition.ResumeLayout(false);
            this.tsNodePartition.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tcNode.ResumeLayout(false);
            this.tpNode.ResumeLayout(false);
            this.tcNodeInfo.ResumeLayout(false);
            this.tpNodeInfo.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tsNodeInfo.ResumeLayout(false);
            this.tsNodeInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsNodePartition;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tcNode;
        private System.Windows.Forms.TabPage tpNode;
        private System.Windows.Forms.TabControl tcNodeInfo;
        private System.Windows.Forms.TabPage tpNodeInfo;
        private System.Windows.Forms.ToolStripButton tsbHaZop;
        private System.Windows.Forms.ToolStripSplitButton stbHelp;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.TreeView tvNode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip tsNodeInfo;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdite;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button SelectModelbtn;
        private System.Windows.Forms.TextBox txtSelectModel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button CreateNodeDatebtn;
        private System.Windows.Forms.TextBox txtNodeCreateDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNodeUsage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNodeDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNodeName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbInterim;
        private System.Windows.Forms.RadioButton rbContinuous;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNodeId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofdSelectModel;
    }
}
