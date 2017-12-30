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
    public partial class GroupMemberManage : Form
    {
        public GroupMemberManage()
        {
            InitializeComponent();
        }

        qqApp qqapp = new qqApp();
        //List<GroupInfo> lstqgi;
        //List<GroupInfo> lstgiOK = new List<GroupInfo>();
        List<QQGroupMemberInfo> lstqgmi;
        DataTable dt_groupinfo = null;
        private void GroupMemberManage_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView_RowPostPaint);

            string sqlstr = "";
            if(frmMain.UserGrade.Contains("9"))
                sqlstr="select * from groupinfo ";
            else
                sqlstr=string.Format("select * from groupinfo where manager='{0}' ", frmMain.Operator);

            dt_groupinfo = DBHelper.ExecuteQuery(sqlstr);

            this.comboBox1.DataSource = dt_groupinfo;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Name";
            if (dt_groupinfo.Rows.Count > 0)
                 this.comboBox1.SelectedIndex = 0;
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

        private void button1_Click(object sender, EventArgs e)//群成员查询
        {
            if (this.comboBox1.SelectedIndex < 0 || this.comboBox1.Text=="")
                return;
            string sqlstr = "select * from GroupMemberInfo where GroupNumber='" + this.textBox1.Text+"'";
            this.dataGridView1.DataSource = DBHelper.ExecuteQuery(sqlstr);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = dt_groupinfo.Rows[this.comboBox1.SelectedIndex][1].ToString();
            this.textBox2.Text = dt_groupinfo.Rows[this.comboBox1.SelectedIndex][3].ToString();
            this.textBox3.Text = dt_groupinfo.Rows[this.comboBox1.SelectedIndex][4].ToString();
        }

        private void button2_Click(object sender, EventArgs e)//更新数据库
        {
            this.button2.Text = "正在更新数据库......";
            this.button2.Enabled = false;
            lstqgmi = qqapp.GetMemberInfo(this.textBox1.Text);

            if (lstqgmi == null || lstqgmi.Count == 0)
            {
                MessageBox.Show("获取的群成员数据为空，请确实当前登录的QQ是否为该群成员");
                this.button2.Text = "更新数据库";
                this.button2.Enabled = true;
                return;
            }

            string sqlstr0 = string.Format("select * from GroupMemberInfo where GroupNumber='{0}' ", this.textBox1.Text);

            DataTable dt = DBHelper.ExecuteQuery(sqlstr0);

            int n = 0, err=0;
            string errqq = "";
            foreach (QQGroupMemberInfo gm in lstqgmi)
            {
                int flag = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() == gm.QQ)
                    {
                            flag = 1;//已加群
                    }
                }
                if (flag == 0)//新增
                {
                    string sqlstr = string.Format("insert into GroupMemberInfo select  '{0}',  '{1}', '{2}', '{3}', '{4}','{5}','{6}' ",
                        gm.QQ, gm.NickName.Replace("&nbsp;", "").Replace("\\u003", ""), this.textBox1.Text, gm.GroupCard.Replace("&nbsp;", "").Replace("\\u003", ""), gm.GroupGrade,
                        gm.join_time, gm.last_speak_time);

                    if (DBHelper.ExecuteUpdate(sqlstr) < 1)
                    {
                        errqq += gm.QQ + "\r\n  ";
                        err++;
                    }
                    else
                        n++;
                    
                }//QQ号 昵称 等级 责任人 (跟踪人 跟踪时间) 群号 群名称 群等级 加群时间 群最后发言时间 (好友QQ号 好友昵称 学习时长 学习次数 学习科目 课堂聊天记录 备注)
            }
            string sqlstr5 = string.Format("insert into CustomerInfo select qq,nickname,'{0}','{1}','','',groupnumber,'{2}',groupcard,groupgrade,join_time,last_speak_time,'','','','','','',''  " +
            " from groupmemberinfo where qq not in(select distinct qq from CustomerInfo )", this.textBox3.Text, this.textBox2.Text, this.comboBox1.Text );
            DBHelper.ExecuteUpdate(sqlstr5);

            string sqlstr6 = string.Format("update  a set a.nickname=b.nickname,a.groupname='{0}',a.grade='{1}',a.groupgrade=b.groupgrade,a.manager='{2}'  "+
            " from CustomerInfo a,groupmemberinfo b where a.groupnumber=b.groupnumber and a.qq=b.qq and a.groupnumber='{3}' ",
            this.comboBox1.Text, this.textBox3.Text, this.textBox2.Text, this.textBox1.Text);
            DBHelper.ExecuteUpdate(sqlstr6);

            MessageBox.Show("群成员信息成功导入数据库"+n+"条");
            if (err > 0)
                MessageBox.Show("导入失败"+err+"条，qq号是：" + errqq);
                //tools.showlog(errqq);

            //已经没有在群里的成员，在群成员信息表中去掉群信息
            n = 0;
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int flag = 0;
                foreach (QQGroupMemberInfo gm in lstqgmi)
                {
                    if (dt.Rows[i][0].ToString() == gm.QQ  )
                    {
                            flag = 1;
                    }
                }
                if (flag == 0)//qq号已不在该群
                {
                    string sqlstr2 = string.Format("delete GroupMemberInfo where GroupNumber='{0}'  and qq='{1}' ", this.textBox1.Text,dt.Rows[i][0].ToString());
                    DBHelper.ExecuteUpdate(sqlstr2);
                    n++;
                }
            }
            string sqlstr1 = string.Format(" update CustomerInfo set Manager='{0}',GroupNumber='{1}'  where qq in (select qq from GroupMemberInfo where GroupNumber='{1}') ", 
                frmMain.Operator, this.textBox1.Text);
            DBHelper.ExecuteUpdate(sqlstr1);

            if(n>0)
                MessageBox.Show("从数据库中去掉群成员信息" + n + "条");


            this.button2.Text = "更新数据库";
            this.button2.Enabled = true;
            MessageBox.Show("更新数据库成功");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
