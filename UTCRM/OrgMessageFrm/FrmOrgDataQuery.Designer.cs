namespace UTCRM.OrgMessageFrm
{
    partial class FrmOrgDataQuery
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
            this.DGVHeard = new System.Windows.Forms.DataGridView();
            this.DGVDetail = new System.Windows.Forms.DataGridView();
            this.QQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrgNameDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AwayTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudyRecord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EnterBatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrgEnterBacthID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrgID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrgTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnterTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHeard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVHeard
            // 
            this.DGVHeard.AllowUserToAddRows = false;
            this.DGVHeard.AllowUserToDeleteRows = false;
            this.DGVHeard.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGVHeard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVHeard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EnterBatchID,
            this.OrgEnterBacthID,
            this.OrgName,
            this.OrgID,
            this.OrgTypeID,
            this.EnterTime,
            this.StudentCount});
            this.DGVHeard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVHeard.Location = new System.Drawing.Point(0, 0);
            this.DGVHeard.Name = "DGVHeard";
            this.DGVHeard.ReadOnly = true;
            this.DGVHeard.RowTemplate.Height = 23;
            this.DGVHeard.Size = new System.Drawing.Size(344, 326);
            this.DGVHeard.TabIndex = 37;
            // 
            // DGVDetail
            // 
            this.DGVDetail.AllowUserToAddRows = false;
            this.DGVDetail.AllowUserToDeleteRows = false;
            this.DGVDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGVDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QQ,
            this.OrgNameDetail,
            this.StudyTime,
            this.StartTime,
            this.AwayTime,
            this.StudyRecord,
            this.dataGridViewTextBoxColumn4});
            this.DGVDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVDetail.Location = new System.Drawing.Point(0, 0);
            this.DGVDetail.Name = "DGVDetail";
            this.DGVDetail.ReadOnly = true;
            this.DGVDetail.RowTemplate.Height = 23;
            this.DGVDetail.Size = new System.Drawing.Size(795, 326);
            this.DGVDetail.TabIndex = 36;
            // 
            // QQ
            // 
            this.QQ.DataPropertyName = "QQ";
            this.QQ.HeaderText = "QQ";
            this.QQ.Name = "QQ";
            this.QQ.ReadOnly = true;
            this.QQ.Width = 80;
            // 
            // OrgNameDetail
            // 
            this.OrgNameDetail.DataPropertyName = "OrgName";
            this.OrgNameDetail.HeaderText = "机构名称";
            this.OrgNameDetail.Name = "OrgNameDetail";
            this.OrgNameDetail.ReadOnly = true;
            // 
            // StudyTime
            // 
            this.StudyTime.DataPropertyName = "StudyTime";
            this.StudyTime.HeaderText = "时长";
            this.StudyTime.Name = "StudyTime";
            this.StudyTime.ReadOnly = true;
            this.StudyTime.Width = 60;
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "进入时间";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // AwayTime
            // 
            this.AwayTime.DataPropertyName = "AwayTime";
            this.AwayTime.HeaderText = "离开时间";
            this.AwayTime.Name = "AwayTime";
            this.AwayTime.ReadOnly = true;
            // 
            // StudyRecord
            // 
            this.StudyRecord.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StudyRecord.DataPropertyName = "StudyRecord";
            this.StudyRecord.HeaderText = "学习课程名";
            this.StudyRecord.Name = "StudyRecord";
            this.StudyRecord.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Remark";
            this.dataGridViewTextBoxColumn4.HeaderText = "备注";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "机构类型";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(446, 374);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(330, 20);
            this.comboBox2.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 40;
            this.label2.Text = "机构名称";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(562, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(447, 339);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(329, 20);
            this.comboBox1.TabIndex = 43;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1142, 326);
            this.panel1.TabIndex = 44;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DGVDetail);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(347, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(795, 326);
            this.panel3.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(344, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 326);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DGVHeard);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 326);
            this.panel2.TabIndex = 0;
            // 
            // EnterBatchID
            // 
            this.EnterBatchID.DataPropertyName = "EnterBatchID";
            this.EnterBatchID.HeaderText = "类型批次";
            this.EnterBatchID.Name = "EnterBatchID";
            this.EnterBatchID.ReadOnly = true;
            this.EnterBatchID.Width = 80;
            // 
            // OrgEnterBacthID
            // 
            this.OrgEnterBacthID.DataPropertyName = "OrgEnterBacthID";
            this.OrgEnterBacthID.HeaderText = "机构批次";
            this.OrgEnterBacthID.Name = "OrgEnterBacthID";
            this.OrgEnterBacthID.ReadOnly = true;
            this.OrgEnterBacthID.Width = 80;
            // 
            // OrgName
            // 
            this.OrgName.DataPropertyName = "OrgName";
            this.OrgName.HeaderText = "机构名称";
            this.OrgName.Name = "OrgName";
            this.OrgName.ReadOnly = true;
            // 
            // OrgID
            // 
            this.OrgID.DataPropertyName = "OrgID";
            this.OrgID.HeaderText = "机构ID";
            this.OrgID.Name = "OrgID";
            this.OrgID.ReadOnly = true;
            this.OrgID.Visible = false;
            // 
            // OrgTypeID
            // 
            this.OrgTypeID.DataPropertyName = "OrgTypeID";
            this.OrgTypeID.HeaderText = "机构类型ID";
            this.OrgTypeID.Name = "OrgTypeID";
            this.OrgTypeID.ReadOnly = true;
            this.OrgTypeID.Visible = false;
            // 
            // EnterTime
            // 
            this.EnterTime.DataPropertyName = "EnterTime";
            this.EnterTime.HeaderText = "录入时间";
            this.EnterTime.Name = "EnterTime";
            this.EnterTime.ReadOnly = true;
            // 
            // StudentCount
            // 
            this.StudentCount.DataPropertyName = "StudentCount";
            this.StudentCount.HeaderText = "本批次人数";
            this.StudentCount.Name = "StudentCount";
            this.StudentCount.ReadOnly = true;
            // 
            // FrmOrgDataQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 474);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmOrgDataQuery";
            this.Text = "机构数据查询";
            this.Load += new System.EventHandler(this.FrmOrgDataQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVHeard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVHeard;
        private System.Windows.Forms.DataGridView DGVDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn QQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrgNameDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudyTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn AwayTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudyRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnterBatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrgEnterBacthID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrgID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrgTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnterTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentCount;
    }
}