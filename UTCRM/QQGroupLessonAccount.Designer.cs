namespace UTCRM
{
    partial class QQGroupLessonAccount
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.责任人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.群名或好友QQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.开始日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.结束日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.总到课人数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.负责人数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.责任内到课人数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.到课人数总占比 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.责任内到课人数占比 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.责任人,
            this.群名或好友QQ,
            this.开始日期,
            this.结束日期,
            this.总到课人数,
            this.负责人数,
            this.责任内到课人数,
            this.到课人数总占比,
            this.责任内到课人数占比});
            this.dataGridView1.Location = new System.Drawing.Point(1, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1118, 368);
            this.dataGridView1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker1.Location = new System.Drawing.Point(332, 474);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(107, 21);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker2.Location = new System.Drawing.Point(527, 474);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(107, 21);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(729, 471);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 476);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "开始日期";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 480);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "结束日期";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(830, 471);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // 责任人
            // 
            this.责任人.DataPropertyName = "manager";
            this.责任人.HeaderText = "责任人";
            this.责任人.Name = "责任人";
            this.责任人.ReadOnly = true;
            // 
            // 群名或好友QQ
            // 
            this.群名或好友QQ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.群名或好友QQ.DataPropertyName = "name";
            this.群名或好友QQ.HeaderText = "群名或好友QQ";
            this.群名或好友QQ.Name = "群名或好友QQ";
            this.群名或好友QQ.ReadOnly = true;
            // 
            // 开始日期
            // 
            this.开始日期.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.开始日期.DataPropertyName = "begindate";
            this.开始日期.HeaderText = "开始日期";
            this.开始日期.Name = "开始日期";
            this.开始日期.ReadOnly = true;
            // 
            // 结束日期
            // 
            this.结束日期.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.结束日期.DataPropertyName = "enddate";
            this.结束日期.HeaderText = "结束日期";
            this.结束日期.Name = "结束日期";
            this.结束日期.ReadOnly = true;
            // 
            // 总到课人数
            // 
            this.总到课人数.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.总到课人数.DataPropertyName = "allcomecnt";
            this.总到课人数.HeaderText = "总到课人数";
            this.总到课人数.Name = "总到课人数";
            this.总到课人数.ReadOnly = true;
            // 
            // 负责人数
            // 
            this.负责人数.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.负责人数.DataPropertyName = "managercnt";
            this.负责人数.HeaderText = "负责人数";
            this.负责人数.Name = "负责人数";
            this.负责人数.ReadOnly = true;
            // 
            // 责任内到课人数
            // 
            this.责任内到课人数.DataPropertyName = "avgketangcnt";
            this.责任内到课人数.HeaderText = "责任内到课人数";
            this.责任内到课人数.Name = "责任内到课人数";
            this.责任内到课人数.ReadOnly = true;
            this.责任内到课人数.Width = 200;
            // 
            // 到课人数总占比
            // 
            this.到课人数总占比.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.到课人数总占比.DataPropertyName = "perb";
            this.到课人数总占比.HeaderText = "责任内到课人数总占比";
            this.到课人数总占比.Name = "到课人数总占比";
            this.到课人数总占比.ReadOnly = true;
            // 
            // 责任内到课人数占比
            // 
            this.责任内到课人数占比.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.责任内到课人数占比.DataPropertyName = "perc";
            this.责任内到课人数占比.HeaderText = "责任内到课人数占比";
            this.责任内到课人数占比.Name = "责任内到课人数占比";
            this.责任内到课人数占比.ReadOnly = true;
            // 
            // QQGroupLessonAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 557);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "QQGroupLessonAccount";
            this.Text = "QQ群课堂统计";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 责任人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 群名或好友QQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 开始日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 结束日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 总到课人数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 负责人数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 责任内到课人数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 到课人数总占比;
        private System.Windows.Forms.DataGridViewTextBoxColumn 责任内到课人数占比;
    }
}