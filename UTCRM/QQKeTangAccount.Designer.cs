namespace UTCRM
{
    partial class QQKeTangAccount
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
            this.课程名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.开始时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.结束时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.教师 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.最大人数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.平均人数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.开始人数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.结束人数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.课程名称,
            this.开始时间,
            this.结束时间,
            this.教师,
            this.最大人数,
            this.平均人数,
            this.开始人数,
            this.结束人数});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1045, 400);
            this.dataGridView1.TabIndex = 0;
            // 
            // 课程名称
            // 
            this.课程名称.DataPropertyName = "SubjectName";
            this.课程名称.HeaderText = "课程名称";
            this.课程名称.Name = "课程名称";
            this.课程名称.Width = 300;
            // 
            // 开始时间
            // 
            this.开始时间.DataPropertyName = "SubjectBeginTime";
            this.开始时间.HeaderText = "开始时间";
            this.开始时间.Name = "开始时间";
            // 
            // 结束时间
            // 
            this.结束时间.DataPropertyName = "SubjectEndTime";
            this.结束时间.HeaderText = "结束时间";
            this.结束时间.Name = "结束时间";
            // 
            // 教师
            // 
            this.教师.DataPropertyName = "Teacher";
            this.教师.HeaderText = "教师";
            this.教师.Name = "教师";
            // 
            // 最大人数
            // 
            this.最大人数.DataPropertyName = "MaxCnt";
            this.最大人数.HeaderText = "最大人数";
            this.最大人数.Name = "最大人数";
            // 
            // 平均人数
            // 
            this.平均人数.DataPropertyName = "AVGCnt";
            this.平均人数.HeaderText = "平均人数";
            this.平均人数.Name = "平均人数";
            // 
            // 开始人数
            // 
            this.开始人数.DataPropertyName = "BeginCnt";
            this.开始人数.HeaderText = "开始人数";
            this.开始人数.Name = "开始人数";
            // 
            // 结束人数
            // 
            this.结束人数.DataPropertyName = "EndCnt";
            this.结束人数.HeaderText = "结束人数";
            this.结束人数.Name = "结束人数";
            // 
            // QQKeTangAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 557);
            this.Controls.Add(this.dataGridView1);
            this.Name = "QQKeTangAccount";
            this.Text = "QQ课堂统计";
            this.Load += new System.EventHandler(this.QQKeTangAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 课程名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 开始时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 结束时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 教师;
        private System.Windows.Forms.DataGridViewTextBoxColumn 最大人数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 平均人数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 开始人数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 结束人数;
    }
}