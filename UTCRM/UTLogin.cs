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
    public partial class UTLogin : Form
    {
        public UTLogin()
        {
            InitializeComponent();
        }

        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            string userName = this.textBox1.Text;
            string passWord = this.textBox2.Text;
            if (userName.Contains("or") || passWord.Contains("or"))
            {
                MessageBox.Show("用户名或密码错误！");
                Application.Exit();
            }
            string sqlstr = string.Format("select * from userinfo where UserName='{0}' and UserPwd='{1}' ", userName, passWord);
            DataTable dt = DBHelper.ExecuteQuery(sqlstr);
            if (dt.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                frmMain.Operator = dt.Rows[0][0].ToString();
                frmMain.Password = dt.Rows[0][1].ToString();
                frmMain.UserGrade = dt.Rows[0][2].ToString();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
                i++;
                if (i > 2)
                    Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(null, null);
            }
        }

        private void UTLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
