using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UTCRM
{
    public partial class SearchStudents : Form
    {
        public SearchStudents()
        {
            InitializeComponent();
        }


        string Customer = "CustomerInfo";
        string Record = "KeQQStudyRecord";



        private void button1_Click(object sender, EventArgs e)//查询
        {
            //查询满足条件的前5000条记录
            string sqlstr = "select top(1000)* from "+ Customer + "  where  1>0 ";

            if (checkBox3.Checked || checkBox4.Checked || checkBox9.Checked)
            {
                sqlstr += string.Format(" and  qq in ( select distinct qq from " + Record + " where ");
                if (checkBox3.Checked)
                    sqlstr += string.Format(" cometime>='{0}' and cometime <='{1}' and ",
                        this.dateTimePicker1.Value.ToString("yyyy-MM-dd"), this.dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                if (checkBox4.Checked)
                    sqlstr += string.Format(" CONVERT(varchar(100), cometime, 108)>='{0}' and CONVERT(varchar(100), cometime, 108)<='{1}' and ",
                        this.dateTimePicker3.Value.ToString("HH:mm:ss"), this.dateTimePicker4.Value.ToString("HH:mm:ss"));
                if (checkBox9.Checked)
                    sqlstr += string.Format(" subjectname  like '%{0}%' and ", textBox7.Text);
                sqlstr = sqlstr.Substring(0, sqlstr.Length - 4) + ")";
            }

            if (checkBox1.Checked)
                sqlstr += string.Format(" and  qq in ( select distinct qq from " + Record + "  group by qq having  count(qq) >= '{0}'  ) ",
                    this.textBox1.Text);
            if (checkBox2.Checked)
                sqlstr += string.Format(" and studytime/60>='{0}'    ", this.textBox2.Text);
            if (checkBox5.Checked)
                sqlstr += string.Format(" and qq = '{0}' ", this.textBox3.Text);
            if (checkBox6.Checked)
                sqlstr += string.Format(" and groupnumber = '{0}' ", this.textBox5.Text);
            if (checkBox7.Checked)
                sqlstr += string.Format(" and friendqq = '{0}' ", this.textBox6.Text);
            if (checkBox8.Checked)
            { sqlstr += string.Format(" and manager <> '' "); }
            else
            { sqlstr += string.Format(" and manager = '' "); }

            //查询满足条件的所有人数
            string sqlstrcount = "select count(*) from " + Customer + "  where  1>0 ";
            if (checkBox3.Checked || checkBox4.Checked || checkBox9.Checked)
            {
                sqlstrcount += string.Format(" and  qq in ( select distinct qq from " + Record + " where ");
                if (checkBox3.Checked)
                    sqlstrcount += string.Format(" cometime>='{0}' and cometime <='{1}' and ",
                        this.dateTimePicker1.Value.ToString("yyyy-MM-dd"), this.dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                if (checkBox4.Checked)
                    sqlstrcount += string.Format(" CONVERT(varchar(100), cometime, 108)>='{0}' and CONVERT(varchar(100), cometime, 108)<='{1}' and ",
                        this.dateTimePicker3.Value.ToString("HH:mm:ss"), this.dateTimePicker4.Value.ToString("HH:mm:ss"));
                if (checkBox9.Checked)
                    sqlstrcount += string.Format(" subjectname  like '%{0}%' and ", textBox7.Text);
                sqlstrcount = sqlstrcount.Substring(0, sqlstrcount.Length - 4) + ")";
            }

            if (checkBox1.Checked)
                sqlstrcount += string.Format(" and  qq in ( select distinct qq from " + Record + "  group by qq having  count(qq) >= '{0}'  ) ",
                    this.textBox1.Text);
            if (checkBox2.Checked)
                sqlstrcount += string.Format(" and studytime/60>='{0}'    ", this.textBox2.Text);
            if (checkBox5.Checked)
                sqlstrcount += string.Format(" and qq = '{0}' ", this.textBox3.Text);
            if (checkBox6.Checked)
                sqlstrcount += string.Format(" and groupnumber = '{0}' ", this.textBox5.Text);
            if (checkBox7.Checked)
                sqlstrcount += string.Format(" and friendqq = '{0}' ", this.textBox6.Text);
            if (checkBox8.Checked)
            { sqlstrcount += string.Format(" and manager <> '' "); }
            else
            { sqlstrcount += string.Format(" and manager = '' "); }

            sqlstr = "select * from (" + sqlstr + ") a" + " order by join_time desc ";
            DataTable dtsearch = DBHelper.ExecuteQuery(sqlstr);
            if (dtsearch.Rows.Count == 5000)
            {
                DataTable dtcount = DBHelper.ExecuteQuery(sqlstrcount);
                if (dtcount.Rows.Count == 0)
                {
                    MessageBox.Show("查询超时！");
                    return;
                }
                this.label13.Text = "查询到" + dtcount.Rows[0][0].ToString() + "条记录";
                this.dataGridView1.DataSource = dtsearch;
            }
            else
            {
                this.label13.Text = "查询到" + dtsearch.Rows.Count + "条记录";
                this.dataGridView1.DataSource = dtsearch;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.label14.Text = "QQ号  "+this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            this.label15.Text = "昵称    " + this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            this.textBox4.Text = this.dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)//跟踪
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选定要跟踪的行");
                return;
            }
            if ((DateTime.Now - (DateTime)this.dataGridView1.SelectedRows[0].Cells[5].Value).Days <= 7 
                && this.dataGridView1.SelectedRows[0].Cells[4].Value.ToString()!=frmMain.Operator
                && !frmMain.UserGrade.Contains("9"))
            {
                MessageBox.Show("已有人跟踪且不足七天，你还不能跟踪");
                return;
            }
            string sqlstr = string.Format("update "+Customer+" set TraceName='{0}' ,TraceTime='{1}' ,remark='{2}' where qq='{3}' ",
                frmMain.Operator, DateTime.Now, this.textBox4.Text, this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            DBHelper.ExecuteUpdate(sqlstr);
            MessageBox.Show("跟踪标记变更成功");
            button1_Click(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.Text == "内部资源")
            {
                Customer = "CustomerInfo";
                Record = "KeQQStudyRecord";
            }
            else if (this.comboBox1.Text == "外部资源")
            {
                Customer = "ForeignCustomerInfo";
                Record = "KeQQForeignRecord";
            }
            else if (this.comboBox1.Text == "美工资源")
            {
                Customer = "ArtistCustomerInfo";
                Record = "KeQQArtistRecord";
            }
        }

        private void SearchStudents_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
            this.dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView_RowPostPaint);

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

        private void 复制QQ号toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (select_enable < 0) return;
            string str = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (str != "")
                Clipboard.SetDataObject(str); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选定要取消跟踪的行");
                return;
            }
            if ((DateTime.Now - (DateTime)this.dataGridView1.SelectedRows[0].Cells[5].Value).Days <= 7
                && this.dataGridView1.SelectedRows[0].Cells[4].Value.ToString() != frmMain.Operator
                && !frmMain.UserGrade.Contains("9"))
            {
                MessageBox.Show("已有人跟踪且不足七天，你不能取消跟踪");
                return;
            }
            string sqlstr = string.Format("update " + Customer + " set TraceName='' where qq='{0}' ",
                this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            DBHelper.ExecuteUpdate(sqlstr);
            MessageBox.Show("跟踪标记变更成功");
            button1_Click(null, null);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要导出数据到excel吗？", "导出提醒", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            this.progressBar1.Value = 0;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Step = 1;
            string tablename = "";
            this.button5.Enabled = false;
            if (this.checkBox10.Checked)//去重
            {
                if (this.comboBox1.Text == "外部资源")
                {
                    tablename = "ForeignCustomerInfo";
                }
                else
                {
                    tablename = "CustomerInfo";
                }
                ThreadWriteToTXTSharp threadWriteToTXT = threadWriteToTXTSharp;
                IAsyncResult thread1SharpResult = threadWriteToTXT.BeginInvoke(tablename, this.dateTimePicker1.Value, this.dateTimePicker2.Value, true, null, null);
            }
            else //不去重
            {
                if (this.comboBox1.Text == "外部资源")
                {
                    tablename = "KeQQForeignRecord";
                }
                else
                {
                    tablename = "KeQQStudyRecord";
                }
                ThreadWriteToTXTSharp threadWriteToTXT = threadWriteToTXTSharp;
                IAsyncResult thread1SharpResult = threadWriteToTXT.BeginInvoke(tablename, this.dateTimePicker1.Value, this.dateTimePicker2.Value, false, null, null);
            }
        }
        public delegate void ThreadWriteToTXTSharp(string tablename, DateTime starttime, DateTime endtime, bool distinct);
        public void threadWriteToTXTSharp(string tablename, DateTime starttime, DateTime endtime, bool distinct) 
        {
            string fimebefore = "";
            if (tablename.Contains("Foreign"))
            {
                fimebefore = "外部资源";
            }
            else 
            {
                fimebefore = "内部资源";
            }
            if (distinct)
            {
                string txtfilename = fimebefore+ "去重" + starttime.ToString("yyyyMMdd") + "至" + endtime.ToString("yyyyMMdd");
                string sqlstr = "select QQ as QQ号码,StudyTime as 学习时长,StudyNumber as 到课次数,studyobject as 课程名称 from " + Customer + "  where  1>0";
                if (checkBox1.Checked)
                    sqlstr += string.Format(" and  qq in ( select distinct qq from " + Record + "  group by qq having  count(qq) >= '{0}'  ) ", this.textBox1.Text);
                if (checkBox2.Checked)
                    sqlstr += string.Format(" and studytime/60>='{0}'    ", this.textBox2.Text);
                if (checkBox3.Checked)
                    sqlstr += string.Format(" and qq in (select distinct qq from " + Record + " where cometime>='{0}' and cometime <='{1}') ",
                        this.dateTimePicker1.Value.ToString("yyyy-MM-dd"), this.dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                if (checkBox4.Checked)
                    sqlstr += string.Format(" and qq in (select distinct qq from " + Record +
                        " where CONVERT(varchar(100), cometime, 108)>='{0}' and CONVERT(varchar(100), cometime, 108)<='{1}') ",
                        this.dateTimePicker3.Value.ToString("HH:mm:ss"), this.dateTimePicker4.Value.ToString("HH:mm:ss"));
                if (checkBox5.Checked)
                    sqlstr += string.Format(" and qq = '{0}' ", this.textBox3.Text);
                if (checkBox6.Checked)
                    sqlstr += string.Format(" and groupnumber = '{0}' ", this.textBox5.Text);
                if (checkBox7.Checked)
                    sqlstr += string.Format(" and friendqq = '{0}' ", this.textBox6.Text);
                if (checkBox8.Checked)
                    sqlstr += string.Format(" and manager <> '' ");
                else
                    sqlstr += string.Format(" and manager = '' ");
                if (checkBox9.Checked)
                {
                    sqlstr += string.Format(" and qq in (select distinct qq from " + Record +
                       "  where subjectname  like '%{0}%' ) ", textBox7.Text);
                }
                DataTable dt1 = DBHelper.ExecuteQuery(sqlstr);
                if (this.progressBar1.InvokeRequired)//找到创建此控件的线程
                {
                    this.progressBar1.Invoke(new Action<int>(s => { this.progressBar1.Maximum = s; }), dt1.Rows.Count);
                }
                dataTableToCsv(dt1, @"D:\" + txtfilename + ".xls");
                //dataTableToCsv(dt1, @"c:\" + txtfilename + ".xls");
            }
            else 
            {
                string txtfilename = fimebefore + "不去重" + starttime.ToString("yyyyMMdd") + "至" + endtime.ToString("yyyyMMdd");
                string sql1 = string.Format("select QQ as QQ号码,cometime as 进入课堂时间,leavetime as 离开课堂时间,studytime as 学习分钟数,subjectname as 课程名称 from {0} where cometime between '{1}' and '{2}' order by cometime desc",
                    tablename,
                    starttime.ToShortDateString(),
                    endtime.ToShortDateString());
                DataTable dt1 = DBHelper.ExecuteQuery(sql1);
                if (this.progressBar1.InvokeRequired)//找到创建此控件的线程
                {
                    this.progressBar1.Invoke(new Action<int>(s => { this.progressBar1.Maximum = s; }), dt1.Rows.Count);
                }
                dataTableToCsv(dt1, @"D:\" + txtfilename + ".xls");
            }
        }
        public void writeToTxtPro(DataTable dt, string txtfilename)//写入TXT
        {
            string pathout = "D:\\" + txtfilename + ".txt";
            StreamWriter sw = new StreamWriter(pathout, true);
            for (int rows = 0; rows < dt.Rows.Count; rows++)
            {
                for (int cols = 0; cols < dt.Columns.Count; cols++)
                {
                    sw.WriteLine(dt.Rows[rows][cols].ToString() + "|");
                }
                sw.WriteLine("\r\n");
                if (this.progressBar1.InvokeRequired)//找到创建此控件的线程
                {
                    this.progressBar1.Invoke(new Action<int>(s => { this.progressBar1.Value += s; }), 1);
                }
            }
            sw.Close();
            sw.Dispose();
            MessageBox.Show("导出完毕，导出路径为：D:\\" + txtfilename + ".txt");
        }
        public void dataTableToCsv(DataTable table, string file)
        {
            string title = "";
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
            //FileStream fs1 = File.Open(file, FileMode.Open, FileAccess.Read);
            StreamWriter sw = new StreamWriter(new BufferedStream(fs), System.Text.Encoding.Default);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                title += table.Columns[i].ColumnName + "\t"; //栏位：自动跳到下一单元格
            }
            if (title != "")
            {
                title = title.Substring(0, title.Length - 1) + "\n";
                sw.Write(title);
                foreach (DataRow row in table.Rows)
                {
                    string line = "";
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        line += row[i].ToString().Trim() + "\t"; //内容：自动跳到下一单元格
                    }
                    line = line.Substring(0, line.Length - 1) + "\n";
                    sw.Write(line);
                    if (this.progressBar1.InvokeRequired)//找到创建此控件的线程
                    {
                        this.progressBar1.Invoke(new Action<int>(s => { this.progressBar1.Value += s; }), 1);
                    }
                }
            }
            sw.Close();
            fs.Close();
            if (this.progressBar1.InvokeRequired)//找到创建此控件的线程
            {
                this.progressBar1.Invoke(new Action<int>(s => { this.progressBar1.Value = this.progressBar1.Maximum; }), 1);
            }
            if (this.button5.InvokeRequired)//找到创建此控件的线程
            {
                this.button5.Invoke(new Action<bool>(s => { this.button5.Enabled = s; }), true);
            }
            /*
            DialogResult RSS = MessageBox.Show(this, "导出完毕，导出路径为：D:\\" + file + ".xls，是否打开此文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (RSS)
            {
                case DialogResult.Yes:
                    System.Diagnostics.Process.Start(@"D:\" + file + ".xls"); //打开excel文件
                    break;
                case DialogResult.No:
                    break;
            }*/
        }
    }
}
