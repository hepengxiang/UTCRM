using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODEL;

namespace UTCRM
{
    public partial class GroupManage : Form
    {
        public GroupManage()
        {
            InitializeComponent();
        }

        qqApp qqapp = new qqApp();
        DataTable dt;
        private void GroupManage_Load(object sender, EventArgs e)
        {
            this.dataGridView2.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView_RowPostPaint);

            //this.dataGridView1.DataSource = qqapp.GetGroupInfos();
            string sqlstr = "";

            if (frmMain.UserGrade.Contains("9"))
            {
                sqlstr = "select * from GroupInfo";
                this.comboBox1.DataSource = DBHelper.ExecuteQuery("select username from userinfo ");
                this.comboBox1.DisplayMember = "UserName";
                this.comboBox1.ValueMember = "UserName";
            }
            else
            {
                sqlstr = string.Format("select * from GroupInfo where manager='{0}' ", frmMain.Operator);
                this.comboBox1.Text = frmMain.Operator;
            }
            dt = DBHelper.ExecuteQuery(sqlstr);
            this.dataGridView2.DataSource = dt;

            
        }
        // this.dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView_RowPostPaint);
        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush((sender as DataGridView).RowHeadersDefaultCellStyle.ForeColor);
            try
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), (sender as DataGridView).DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)//增加
        {
            if (this.comboBox1.Text.Length == 0)
            {
                MessageBox.Show("请选定责任人");
                return;
            }


            string sqlstr1 = string.Format("select * from groupinfo where number='{0}' ", this.textBox2.Text);
            DataTable dt1 = DBHelper.ExecuteQuery(sqlstr1);
            if (dt1.Rows.Count>0)
            {
                MessageBox.Show("该QQ群已存在");
                return;
            }


            GroupInfo gi = new GroupInfo();
            gi.Name = this.textBox1.Text;
            gi.Number = this.textBox2.Text;
            gi.Owner = this.textBox3.Text;
            gi.Manager = this.comboBox1.Text;
            gi.Grade = this.comboBox2.Text;

            string sqlstr = string.Format("insert into GroupInfo select '{0}','{1}','{2}','{3}','{4}' ", gi.Name, gi.Number, gi.Owner, gi.Manager,gi.Grade);
            DBHelper.ExecuteUpdate(sqlstr);

            string sqlstr2 = string.Format("update customerinfo  set manager='{0}' ,grade='{1}' where groupnumber='{2}' ",
              gi.Manager, gi.Grade, gi.Number);
            DBHelper.ExecuteUpdate(sqlstr2);

            GroupManage_Load(null, null);
            MessageBox.Show("增加成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("请选定要修改的数据行");
                return;
            }

            string sqlstr1 = string.Format("update groupinfo  set Name='{0}',Number='{1}',Owner='{2}', manager='{3}' ,grade='{4}' where number='{5}' ",
                this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.comboBox1.Text, this.comboBox2.Text, this.dataGridView2.SelectedRows[0].Cells[1].Value.ToString());
            DBHelper.ExecuteUpdate(sqlstr1);

            string sqlstr2 = string.Format("update customerinfo  set manager='{0}', grade='{1}' where groupnumber='{2}' ",
               this.comboBox1.Text, this.comboBox2.Text, this.dataGridView2.SelectedRows[0].Cells[1].Value.ToString());

            //tools.showlog(sqlstr1 + "\r\n" + sqlstr2);

            DBHelper.ExecuteUpdate(sqlstr2);

            GroupManage_Load(null, null);
            MessageBox.Show("修改成功");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.SelectedRows[0].Cells[1].Value == null)
                return;
            string sqlstr1 = string.Format("delete groupinfo   where number='{0}' ",
                this.dataGridView2.SelectedRows[0].Cells[1].Value.ToString());
            DBHelper.ExecuteUpdate(sqlstr1);

            string sqlstr2 = string.Format("update customerinfo  set manager=''  where groupnumber='{0}' ",
              this.dataGridView2.SelectedRows[0].Cells[1].Value.ToString());
            DBHelper.ExecuteUpdate(sqlstr2);

            GroupManage_Load(null, null);
            MessageBox.Show("删除成功");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.textBox1.Text = this.dataGridView2.SelectedRows[0].Cells[0].Value.ToString();//群名
            this.textBox2.Text = this.dataGridView2.SelectedRows[0].Cells[1].Value.ToString();//群号
            this.textBox3.Text = this.dataGridView2.SelectedRows[0].Cells[2].Value.ToString();//群主号
            this.comboBox1.Text = this.dataGridView2.SelectedRows[0].Cells[3].Value.ToString();//责任人
            this.comboBox2.Text = this.dataGridView2.SelectedRows[0].Cells[4].Value.ToString();//群成员等级
        }

        private void button5_Click(object sender, EventArgs e)//导出所有VIP群内会员
        {
            button5.Text = "正在导出......";
            button5.Enabled = false;

            string sqlstr = "select * from GroupMemberInfo where groupnumber in (select Number from GroupInfo where Grade='VIP') ";
            DataTable dt = DBHelper.ExecuteQuery(sqlstr);
            List<QQGroupMemberInfo> lstgmifile = new List<QQGroupMemberInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                QQGroupMemberInfo qmi = new QQGroupMemberInfo();
                qmi.QQ = dt.Rows[i][0].ToString();
                qmi.NickName = dt.Rows[i][1].ToString();
                qmi.GroupNumber = dt.Rows[i][2].ToString();
                qmi.GroupCard = dt.Rows[i][3].ToString();
                qmi.GroupGrade = dt.Rows[i][4].ToString();
                qmi.join_time = dt.Rows[i][5].ToString();
                qmi.last_speak_time = dt.Rows[i][6].ToString();
                lstgmifile.Add(qmi);
            }

            tools.ListToXmlFile1(typeof(List<QQGroupMemberInfo>), lstgmifile, "vipdata.xml");

            button5.Text = "导出所有VIP群会员";
            button5.Enabled = true;
            MessageBox.Show("导出成功");
        }

    }
}
