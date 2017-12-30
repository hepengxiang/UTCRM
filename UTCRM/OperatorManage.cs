using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UTCRM
{
    public partial class OperatorManage : Form
    {
        public OperatorManage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//增加
        {
            if (this.textBox1.Text.Length == 0 || this.textBox2.Text.Length == 0)
            {
                MessageBox.Show("操作员和密码不能为空");
                return;
            }

            string sqlstr1 = string.Format("select * from  userinfo where UserName='{0}' ", this.textBox1.Text);
            if (DBHelper.ExecuteQuery(sqlstr1).Rows.Count > 0)
            {
                MessageBox.Show("操作员重复");
                return;
            }

            string sqlstr = string.Format("insert into userinfo select '{0}','{1}','{2}' ", this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);
            DBHelper.ExecuteUpdate(sqlstr);
            MessageBox.Show("增加操作员成功");
            this.dataGridView1.DataSource = DBHelper.ExecuteQuery("select * from userinfo");
        }

        private void button2_Click(object sender, EventArgs e)//删除
        {
            if (this.textBox1.Text.Length == 0 || this.textBox2.Text.Length == 0)
            {
                MessageBox.Show("操作员和密码不能为空");
                return;
            }

            string sqlstr1 = string.Format("select * from  userinfo where UserName='{0}' ", this.textBox1.Text);
            if (DBHelper.ExecuteQuery(sqlstr1).Rows.Count == 0)
            {
                MessageBox.Show("操作员不存在");
                return;
            }

            string sqlstr = string.Format("delete userinfo where   UserName='{0}' ", this.textBox1.Text);
            DBHelper.ExecuteUpdate(sqlstr);
            MessageBox.Show("删操作员成功");
            this.dataGridView1.DataSource = DBHelper.ExecuteQuery("select * from userinfo");
        }

        private void button3_Click(object sender, EventArgs e)//修改
        {
            if (this.textBox1.Text.Length == 0 || this.textBox2.Text.Length == 0)
            {
                MessageBox.Show("操作员和密码不能为空");
                return;
            }

            string sqlstr1 = string.Format("select * from  userinfo where UserName='{0}' ", this.textBox1.Text);
            if (DBHelper.ExecuteQuery(sqlstr1).Rows.Count == 0)
            {
                MessageBox.Show("操作员不存在");
                return;
            }

            string sqlstr = string.Format("update userinfo set  UserPwd='{0}',UserGrade='{1}'   where   UserName='{2}' ", this.textBox2.Text,this.textBox3.Text, this.textBox1.Text);
            DBHelper.ExecuteUpdate(sqlstr);
            MessageBox.Show("修改作员成功");
            this.dataGridView1.DataSource = DBHelper.ExecuteQuery("select * from userinfo");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OperatorManage_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = DBHelper.ExecuteQuery("select * from userinfo");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.textBox1.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            this.textBox2.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            this.textBox3.Text = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
