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
    public partial class qundongtai : Form
    {
        public qundongtai()
        {
            InitializeComponent();
        }
        DataTable dt_group;
        private void qundongtai_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView_RowPostPaint);
            string sqlstr = string.Format("select  * from groupinfo where manager='{0}'", frmMain.Operator);
            dt_group = DBHelper.ExecuteQuery(sqlstr);
            this.comboBox1.DataSource = dt_group;
            this.comboBox1.ValueMember = "name";
            this.comboBox1.DisplayMember = "name";

            //this.comboBox1.SelectedIndex = 0;
        }

        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush((sender as DataGridView).RowHeadersDefaultCellStyle.ForeColor);
            try
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), (sender as DataGridView).DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)//查询
        {
            string sqlstr = string.Format("select * from CustomerInfo  where  1>0 ");

            if (this.checkBox6.Checked)
                sqlstr += string.Format(" and  friendqq='{0}' ", frmMain.CurQQ);
            else
                sqlstr += string.Format(" and  qq in (select qq from groupmemberinfo where groupnumber='{0}') ",  dt_group.Rows[ this.comboBox1.SelectedIndex][1].ToString());

            if (checkBox1.Checked)
                sqlstr += string.Format(" and  qq in ( select distinct qq from KeQQStudyRecord  group by qq having  count(qq) >= '{0}'  ) ", this.textBox1.Text);
            if (checkBox2.Checked)
                sqlstr += string.Format(" and studytime/60>='{0}'    ", this.textBox2.Text);
            if (checkBox3.Checked)
                sqlstr += string.Format(" and qq in (select distinct qq from KeQQStudyRecord where cometime>='{0}' and cometime <='{1}') ",
                    this.dateTimePicker1.Value.ToString("yyyy-MM-dd"), this.dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            if (checkBox4.Checked)
                sqlstr += string.Format(" and qq in (select distinct qq from KeQQStudyRecord " +
                    "where CONVERT(varchar(100), cometime, 108)>='{0}' and CONVERT(varchar(100), cometime, 108)<='{1}') ",
                    this.dateTimePicker3.Value.ToString("HH:mm:ss"), this.dateTimePicker4.Value.ToString("HH:mm:ss"));
            if (checkBox5.Checked)
                sqlstr += string.Format(" and qq = '{0}' ", this.textBox3.Text);
            //tools.showlog(sqlstr);
            DataTable dt = DBHelper.ExecuteQuery(sqlstr);
            this.label13.Text = "查询到" + dt.Rows.Count + "条记录";
            this.dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选定要跟踪的行");
                return;
            }
            if ((DateTime.Now - (DateTime)this.dataGridView1.SelectedRows[0].Cells[5].Value).Days <= 7
                && this.dataGridView1.SelectedRows[0].Cells[4].Value.ToString() != frmMain.Operator
                && !frmMain.UserGrade.Contains("9"))
            {
                MessageBox.Show("已有人跟踪且不足七天，你还不能跟踪");
                return;
            }
            string sqlstr = string.Format("update CustomerInfo set TraceName='{0}' ,TraceTime='{1}' ,remark='{2}' where qq='{3}' ",
                frmMain.Operator, DateTime.Now, this.textBox4.Text, this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            DBHelper.ExecuteUpdate(sqlstr);
            MessageBox.Show("跟踪标记变更成功");
            button1_Click(null, null);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                if (frmMain.CurQQ == "")
                {
                    MessageBox.Show("请先登录qq");
                    frmMain.qqlogin();
                    return;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.label15.Text = "QQ:"+this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            this.label16.Text = "昵称："+this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            this.textBox4.Text = this.dataGridView1.SelectedRows[0].Cells[17].Value.ToString();
        }

        int select_enable = -1;
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex == -1)
                {
                    select_enable = -1;
                    return;
                }
                select_enable = 1;
                if (dataGridView1.SelectedRows[0] != null)
                    dataGridView1.SelectedRows[0].Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (select_enable < 0) return;
            string str = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (str != "")
                Clipboard.SetDataObject(str); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
