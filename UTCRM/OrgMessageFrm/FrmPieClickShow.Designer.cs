namespace UTCRM.OrgMessageFrm
{
    partial class FrmPieClickShow
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
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudyCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstStudyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstStudyOrgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstStudyRecord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastStudyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastStudyOrgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastStudyRecord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.QQ,
            this.StudyCount,
            this.StudyTime,
            this.FirstStudyTime,
            this.FirstStudyOrgName,
            this.FirstStudyRecord,
            this.LastStudyTime,
            this.LastStudyOrgName,
            this.LastStudyRecord,
            this.Remark});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1237, 394);
            this.dataGridView1.TabIndex = 1;
            // 
            // StudentID
            // 
            this.StudentID.DataPropertyName = "StudentID";
            this.StudentID.HeaderText = "StudentID";
            this.StudentID.Name = "StudentID";
            this.StudentID.ReadOnly = true;
            this.StudentID.Visible = false;
            // 
            // QQ
            // 
            this.QQ.DataPropertyName = "QQ";
            this.QQ.HeaderText = "QQ";
            this.QQ.Name = "QQ";
            this.QQ.ReadOnly = true;
            this.QQ.Width = 80;
            // 
            // StudyCount
            // 
            this.StudyCount.DataPropertyName = "StudyCount";
            this.StudyCount.HeaderText = "学习总次数";
            this.StudyCount.Name = "StudyCount";
            this.StudyCount.ReadOnly = true;
            // 
            // StudyTime
            // 
            this.StudyTime.DataPropertyName = "StudyTime";
            this.StudyTime.HeaderText = "学习总时长";
            this.StudyTime.Name = "StudyTime";
            this.StudyTime.ReadOnly = true;
            // 
            // FirstStudyTime
            // 
            this.FirstStudyTime.DataPropertyName = "FirstStudyTime";
            this.FirstStudyTime.HeaderText = "第一次学习时间";
            this.FirstStudyTime.Name = "FirstStudyTime";
            this.FirstStudyTime.ReadOnly = true;
            this.FirstStudyTime.Width = 120;
            // 
            // FirstStudyOrgName
            // 
            this.FirstStudyOrgName.DataPropertyName = "FirstStudyOrgName";
            this.FirstStudyOrgName.HeaderText = "第一次学习机构";
            this.FirstStudyOrgName.Name = "FirstStudyOrgName";
            this.FirstStudyOrgName.ReadOnly = true;
            this.FirstStudyOrgName.Width = 120;
            // 
            // FirstStudyRecord
            // 
            this.FirstStudyRecord.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FirstStudyRecord.DataPropertyName = "FirstStudyRecord";
            this.FirstStudyRecord.HeaderText = "第一次学习课程名";
            this.FirstStudyRecord.Name = "FirstStudyRecord";
            this.FirstStudyRecord.ReadOnly = true;
            // 
            // LastStudyTime
            // 
            this.LastStudyTime.DataPropertyName = "LastStudyTime";
            this.LastStudyTime.HeaderText = "最后一次学习时间";
            this.LastStudyTime.Name = "LastStudyTime";
            this.LastStudyTime.ReadOnly = true;
            this.LastStudyTime.Width = 130;
            // 
            // LastStudyOrgName
            // 
            this.LastStudyOrgName.DataPropertyName = "LastStudyOrgName";
            this.LastStudyOrgName.HeaderText = "最后一次学习机构";
            this.LastStudyOrgName.Name = "LastStudyOrgName";
            this.LastStudyOrgName.ReadOnly = true;
            this.LastStudyOrgName.Width = 130;
            // 
            // LastStudyRecord
            // 
            this.LastStudyRecord.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LastStudyRecord.DataPropertyName = "LastStudyRecord";
            this.LastStudyRecord.HeaderText = "最后一次学习课程名";
            this.LastStudyRecord.Name = "LastStudyRecord";
            this.LastStudyRecord.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // FrmPieClickShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 394);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmPieClickShow";
            this.Text = "FrmPieClickShow";
            this.Load += new System.EventHandler(this.FrmPieClickShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn QQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudyCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudyTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstStudyTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstStudyOrgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstStudyRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastStudyTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastStudyOrgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastStudyRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}