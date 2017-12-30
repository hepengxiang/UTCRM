using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODEL;
using System.Data.SqlClient;

namespace UTCRM
{
    public partial class MonitorOfQQKeTang : Form
    {
        public MonitorOfQQKeTang()
        {
            InitializeComponent();
        }

        private void MonitorOfQQKeTang_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView_RowPostPaint);
            this.dateTimePicker1.Value = DateTime.Parse(DateTime.Now.ToShortDateString());
            button1_Click(null, null);
            this.button1.Enabled = false;
            this.button2.Enabled = true;
        }

        List<KeQQStudyRecord> lstksr = new List<KeQQStudyRecord>();
        keqq kq;
        int cnt = 0;
        int maxPerNum = 0;
        int maxPerNum_tem = 0;
        DateTime maxNumDate = System.DateTime.Now;
        public void t_Tick(object sender, EventArgs e)
        {
            #region -- 开启监控，读取内存数据 --
            kq = new keqq();
            string qqstr = "";

            //qqstr = kq.GetKeQQ_1(frmMain.pid);//QQForTeacher2.9版本
            qqstr = kq.GetKeQQ_2(frmMain.pid);//QQ8.9.3版本
            //qqstr = kq.GetKeQQ_3(frmMain.pid);//QQ8.9.4版本

            if (qqstr == "")
            {
                if (cnt % 2 == 0)
                    this.label1.Text = "关闭QQ课堂客户端后必须重登QQ才能正确读取数据";
                return;
            }

            cnt++;//刷新次数
            #endregion

            #region -- 内存数据处理 --
            string[] qqs = qqstr.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string qq in qqs)
            {
                int in_flag = 0;
                foreach (KeQQStudyRecord ksr in lstksr)
                {
                    if (ksr.QQ == qq)
                    {
                        in_flag = 1;
                        break;
                    }
                }
                if (in_flag == 0)//新进课堂
                {
                    KeQQStudyRecord new_students = new KeQQStudyRecord();
                    new_students.QQ = qq;
                    new_students.ComeTime = DateTime.Now;
                    new_students.SubjectName = frmMain.Subject;
                    lstksr.Add(new_students);
                }
            }
            foreach (KeQQStudyRecord ksr in lstksr)//刷新离开时间
            {
                int in_flag = 0;
                foreach (string qq in qqs)
                {
                    if (ksr.QQ == qq)
                        in_flag = 1;
                }
                if (in_flag == 1)
                    ksr.LeavetTime = DateTime.Now;
                ksr.StudyTime = (ksr.LeavetTime - ksr.ComeTime).Minutes;
            }
            this.dataGridView1.DataSource = new List<KeQQStudyRecord>();
            this.dataGridView1.DataSource = lstksr;
            #endregion

            try
            {
                if (lstksr.Count - 10 > 0)
                    this.dataGridView1.FirstDisplayedScrollingRowIndex = lstksr.Count - 10;
            }
            catch { }
            //qqs.length课替换为基址查找到的准确人数
            maxPerNum_tem = qqs.Length;
            if (maxPerNum_tem > maxPerNum)
            {
                maxPerNum = maxPerNum_tem;
                maxNumDate = System.DateTime.Now;
            }
            this.label1.Text = "当前窗口在线人数：" + qqs.Length + "    此时到课人数：" + lstksr.Count + "      最高人数：" + maxPerNum + "      最高人数产生时间：" + maxNumDate + "      刷新次数=" + cnt;
            //GetChatRecord();//获取聊天记录
        }

        Timer t = new Timer();
        private void button1_Click(object sender, EventArgs e)//监控开启
        {
            t_Tick(sender, e);
            t.Enabled = true;
            t.Interval = 1000;//刷新时间为2秒
            t.Tick += new EventHandler(t_Tick);
            t.Start();
            this.button1.Enabled = false;
            this.button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)//停止监控
        {
            t.Stop();
            t.Enabled = false;
            this.button1.Enabled = true;
            this.button2.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }


        List<KeQQChatRecord> lstkcr = new List<KeQQChatRecord>();//获取聊天记录参数
        int inflag = 0; //获取聊天记录参数
        private void GetChatRecord()//获取聊天记录
        {
            string chats = kq.ChatRecord();
            
            string[] chatstrs = chats.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string str in chatstrs)
            {
                if (str.Contains(":") || str.Contains("ϚਸϚ") || str.Length > 500)
                    continue;
                inflag = 0;

                string[] talk = str.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            
                foreach (KeQQChatRecord cr in lstkcr)
                {
                    if (talk.Length<=1 || talk[0] == cr.NickName && talk[1] == cr.TalkRecord)
                        inflag = 1;
                }
                if (inflag == 0)
                {
                    KeQQChatRecord newkcr = new KeQQChatRecord();
                    newkcr.NickName = talk[0];
                    newkcr.TalkTime = DateTime.Now;
                    if (talk.Length <=1)
                        newkcr.TalkRecord = "";
                    else
                        newkcr.TalkRecord = talk[1];
                    lstkcr.Add(newkcr);
                }
                inflag = 0;
            }
            string disp_chatrecord = "";
            int ts = lstkcr.Count > 5 ? 5 : lstkcr.Count;
            
            for (int i = lstkcr.Count - ts; i < lstkcr.Count; i++)
            {
                disp_chatrecord += lstkcr[i].NickName + " : " + lstkcr[i].TalkRecord + "\r\n";
            }
            //tools.showlog(disp_chatrecord.Replace("\0"," "));
            this.textBox3.Text = disp_chatrecord.Replace("\0", " ");
            this.label3.Text = lstkcr.Count+"条";
        }

        private void button6_Click(object sender, EventArgs e)//查看聊天记录
        {
            
            DateTime bg = DateTime.Now;
            GetChatRecord();
            
            DateTime end = DateTime.Now;
            MessageBox.Show("耗时："+(end-bg));
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

        #region -- 旧版本导入数据库 --
        private void button3_Click(object sender, EventArgs e)//导入内部数据库
        {
            insertDateToTable("CustomerInfo", "KeQQStudyRecord");
        }

        private void button5_Click(object sender, EventArgs e)//导入外部数据库
        {
            insertDateToTable("ForeignCustomerInfo", "KeQQForeignRecord");
        }

        private void button7_Click(object sender, EventArgs e)//导入美工库
        {
            insertDateToTable("ArtistCustomerInfo", "KeQQArtistRecord");
        }

        private void insertDateToTable(string customerInfoTable, string recordTable)
        {
            string date = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            //if (MessageBox.Show("你确定将本次听课记录作为" + date + "日的唯一记录导入到外部库吗？", "导入提示", MessageBoxButtons.YesNo) == DialogResult.No)
            //    return;
            this.button3.Enabled = false;
            this.button4.Enabled = false;
            this.button5.Enabled = false;
            this.label1.Text = "正在导入数据，请稍候......";
            int allcount = 0;
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                string sqlstr = string.Format("insert into {7} select '{0}','{1}','{2}',datediff(minute,'{1}','{2}'),'{4}','{5}','{6}' ",
                    this.dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    this.dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    this.dataGridView1.Rows[i].Cells[2].Value.ToString(),
                    this.dataGridView1.Rows[i].Cells[3].Value.ToString(),
                    this.dataGridView1.Rows[i].Cells[4].Value.ToString(),
                    "",
                    this.textBox3.Text, recordTable);

                allcount += DBHelper.ExecuteUpdate(sqlstr);
            }
            //将记录插入外部资源总库
            //foreach (KeQQStudyRecord ksr in lstksr)
            //{
            //    string sqlstr = string.Format("insert into {7} select '{0}','{1}','{2}',datediff(minute,'{1}','{2}'),'{4}','{5}','{6}' ",
            //        ksr.QQ, ksr.ComeTime, ksr.LeavetTime, ksr.StudyTime, ksr.SubjectName, ksr.TalkRecord, ksr.Remark, recordTable);

            //    allcount += DBHelper.ExecuteUpdate(sqlstr);
            //}
            //插入外部资源去重库中没有的记录
            string sqlstr1 = string.Format("insert into {0} select  qq,'','','','','','','','','','','',''," +
                "sum(studytime),count(qq),'','',''  from {1}  " +
                "where qq not in (select qq from {0}) group by qq ", customerInfoTable, recordTable);
            int filtercount = DBHelper.ExecuteUpdate(sqlstr1);
            //更新外部资源去重库的记录q
            string sqlstr2 = string.Format("update a set a.StudyNumber=b.StudyNumber,a.studytime=b.studytime, " +
                " a.join_time=b.lastcometime from {0} a, " +
                " (select qq,count(qq) as StudyNumber,sum(studytime) as studytime, max(cometime) as lastcometime " +
                " from {1} group by qq )  b " +
                "where a.qq=b.qq", customerInfoTable, recordTable);
            DBHelper.ExecuteUpdate(sqlstr2);
            //更新学习课程名
            string sqlstr3 = string.Format("update a set a.StudyObject=b.subjectname,a.TalkRecord=b.TalkRecord " +
                " from {1} a,{2} b " +
                " where a.qq=b.qq and b.cometime>='{0}' ", date, customerInfoTable, recordTable);
            DBHelper.ExecuteUpdate(sqlstr3);

            this.button3.Enabled = true;
            this.button4.Enabled = true;
            this.button5.Enabled = true;
            this.label1.Text = "";
            MessageBox.Show("导入不去除重复数据：" + allcount + "条！\r\n 导入去除重复后数据：" + filtercount + "条！");
        }
        #endregion

        #region -- 新版本导入数据库 --
        private void button8_Click(object sender, EventArgs e)
        {
            //旧版本-导入内部资源   insertDateToTable("CustomerInfo", "KeQQStudyRecord");
            //旧版本-导入外部资源   insertDateToTable("ForeignCustomerInfo", "KeQQForeignRecord");
            //旧版本-导入美工资源   insertDateToTable("ArtistCustomerInfo", "KeQQArtistRecord");
            try
            {
                OrgMessageBLL BLL = new OrgMessageBLL();
                SelectTypeAndOrg stao = new SelectTypeAndOrg();
                stao.ShowDialog();
                if (stao.DialogResult == DialogResult.OK)
                {
                    string OrgTypeName = stao.OrgTypeName;
                    string OrgName = stao.OrgName;
                    if (MessageBox.Show("确定要将数据导入【"+ OrgTypeName + "】类型下的【"+ OrgName + "】机构中吗？", "导入提示", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                    int OrgTypeID = stao.OrgTypeID;
                    int orgID = stao.OrgID;
                    DataTable dt = GetDgvToTable(this.dataGridView1, stao.StudentMessageTableName);
                    string datetimeStr = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    int intResult = BLL.InsertCRMStudengData(dt, OrgTypeID, orgID, datetimeStr);
                    //MessageBox.Show("成功导入：" + intResult + "条记录");
                    #region -- 调用旧版本的数据录入功能 --
                    if (intResult>0)
                    {
                        if (OrgTypeID == 1)//机构类型为：优梯资源
                            insertDateToTable("CustomerInfo", "KeQQStudyRecord");//导入内部资源
                        else if (OrgTypeID == 2 || OrgTypeID == 3 || OrgTypeID == 4)
                            insertDateToTable("ForeignCustomerInfo", "KeQQForeignRecord");//导入外部资源
                        else
                            MessageBox.Show("导入成功");
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable GetDgvToTable(DataGridView dgv, string tablename)
        {
            DataTable dt = new DataTable(tablename);//"StudentDetail_1"
            List<string> notExist = new List<string>();
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                string tableChildName = colNameToTableName(dgv.Columns[count].Name.ToString());
                if (tableChildName == dgv.Columns[count].Name.ToString())
                    notExist.Add(tableChildName);
                DataColumn dc = new DataColumn(tableChildName);
                dt.Columns.Add(dc);
            }
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            foreach (string ootex in notExist)
                dt.Columns.Remove(ootex);
            return dt;
        }

        public string colNameToTableName(string colName)
        {
            if (colName == "QQ号")
                return "QQ";
            else if (colName == "到课时间")
                return "StartTime";
            else if (colName == "离开时间")
                return "AwayTime";
            else if (colName == "学习时长")
                return "StudyTime";
            else if (colName == "课程名称")
                return "StudyRecord";
            else if (colName == "备注")
                return "Remark";
            else
                return colName;
        }
        #endregion
    }
}
