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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != frmMain.Password)
            {
                MessageBox.Show("旧密码错误");
                return;
            }

            if (this.textBox2.Text != this.textBox3.Text)
            {
                MessageBox.Show("两次输入的新密码不一致");
                return;
            }

            string sqlstr = string.Format("update userinfo set UserPwd='{0}'  where UserName='{1}'", this.textBox3.Text,frmMain.Operator);
            DBHelper.ExecuteUpdate(sqlstr);
            MessageBox.Show("修改密码成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
