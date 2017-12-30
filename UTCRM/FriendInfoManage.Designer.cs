namespace UTCRM
{
    partial class FriendInfoManage
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
            this.QQ号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.昵称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.所属QQ号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QQ主人昵称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.责任人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.QQ号,
            this.昵称,
            this.所属QQ号,
            this.QQ主人昵称,
            this.责任人});
            this.dataGridView1.Location = new System.Drawing.Point(227, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(646, 284);
            this.dataGridView1.TabIndex = 0;
            // 
            // QQ号
            // 
            this.QQ号.DataPropertyName = "QQ";
            this.QQ号.HeaderText = "QQ号";
            this.QQ号.Name = "QQ号";
            this.QQ号.ReadOnly = true;
            this.QQ号.Width = 200;
            // 
            // 昵称
            // 
            this.昵称.DataPropertyName = "NickName";
            this.昵称.HeaderText = "昵称";
            this.昵称.Name = "昵称";
            this.昵称.ReadOnly = true;
            this.昵称.Width = 200;
            // 
            // 所属QQ号
            // 
            this.所属QQ号.DataPropertyName = "SelfQQ";
            this.所属QQ号.HeaderText = "所属QQ号";
            this.所属QQ号.Name = "所属QQ号";
            this.所属QQ号.ReadOnly = true;
            this.所属QQ号.Width = 200;
            // 
            // QQ主人昵称
            // 
            this.QQ主人昵称.DataPropertyName = "OwnerNickName";
            this.QQ主人昵称.HeaderText = "QQ主人昵称";
            this.QQ主人昵称.Name = "QQ主人昵称";
            this.QQ主人昵称.ReadOnly = true;
            this.QQ主人昵称.Visible = false;
            // 
            // 责任人
            // 
            this.责任人.DataPropertyName = "Manager";
            this.责任人.HeaderText = "责任人";
            this.责任人.Name = "责任人";
            this.责任人.ReadOnly = true;
            this.责任人.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(525, 389);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "导入数据库";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "责任人";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(746, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(339, 391);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 21);
            this.textBox1.TabIndex = 6;
            // 
            // FriendInfoManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 557);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FriendInfoManage";
            this.Text = "好友管理";
            this.Load += new System.EventHandler(this.FriendInfoManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn QQ号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 昵称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 所属QQ号;
        private System.Windows.Forms.DataGridViewTextBoxColumn QQ主人昵称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 责任人;
    }
}