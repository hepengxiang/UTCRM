using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UTCRM.OrgMessageFrm
{
    public partial class FrmOutTypeData : Form
    {
        private OrgMessageBLL BLL;

        private string
            OrgTypeID = "", OrgTypeName = "", MinStudyCount = "",
            MaxStudyCount = "", MinStudyTime = "", MaxStudyTime = "",
            OrgID = "", OrgName = "", StartEnterTime, EndEnterTime;

        private int PageNum = 1;
        public FrmOutTypeData()
        {
            InitializeComponent();
            if (BLL == null)
                BLL = new OrgMessageBLL();
        }

        private void FrmOutTypeData_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowPostPaint += tools.dataGridView_RowPostPaint ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmPieClickShow fcs = new FrmPieClickShow();
            fcs.OrgTypeID = 2;
            fcs.OrgID = 1;
            fcs.StartStudyCount = 1;
            fcs.EndStudyCount = 4;
            fcs.StartStudyTime = 0;
            fcs.EndStudyTime = 5;
            fcs.EnterTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            fcs.MethodID = 1;
            fcs.Show();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            try
            {
                DataTable orgTypeTable = BLL.SelectOrgTypeTable();
                if (orgTypeTable.Rows.Count == 0)
                    return;
                this.comboBox1.DisplayMember = "OrgTypeName";
                this.comboBox1.ValueMember = "OrgTypeID";
                this.comboBox1.DataSource = orgTypeTable;
                this.comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBox1.SelectedValue == null || this.comboBox1.Text == "" || this.comboBox1.SelectedValue == null)
                    return;
                DataTable dtOrgTypeTable = BLL.SelectOrgMessage(int.Parse(this.comboBox1.SelectedValue.ToString()));//传入表名称
                if (dtOrgTypeTable.Rows.Count == 0)
                    return;
                this.comboBox2.ValueMember = "OrgID";
                this.comboBox2.DisplayMember = "OrgName";
                this.comboBox2.DataSource = dtOrgTypeTable.Copy();
                this.comboBox2.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBox1.SelectedValue == null || this.comboBox1.Text == "" || this.comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("必须选定机构类型");
                    return;
                }
                OrgTypeID = this.comboBox1.SelectedValue.ToString(); 
                if (this.checkBox1.Checked)
                {
                    if (this.textBox1.Text.Trim() == "" || this.textBox2.Text.Trim() == "")
                    {
                        MessageBox.Show("在勾选情况下，学习次数不能为空");
                        return;
                    }
                    MinStudyCount = this.textBox1.Text.Trim();
                    MaxStudyCount = this.textBox2.Text.Trim();
                }
                if (this.checkBox2.Checked)
                {
                    if (this.textBox3.Text.Trim() == "" || this.textBox4.Text.Trim() == "")
                    {
                        MessageBox.Show("在勾选情况下，学习时长不能为空");
                        return;
                    }
                    MinStudyTime = this.textBox3.Text.Trim();
                    MaxStudyTime = this.textBox4.Text.Trim();
                }
                if (this.checkBox3.Checked)
                {
                    if (this.comboBox2.SelectedValue == null || this.comboBox2.Text == "" || this.comboBox2.SelectedValue == null)
                    {
                        MessageBox.Show("在勾选情况下，必须选定机构");
                        return;
                    }
                    OrgID = this.comboBox2.SelectedValue.ToString();
                }
                else
                {
                    OrgID = "";
                }
                if (this.checkBox4.Checked)
                {
                    if (this.dateTimePicker1.Value>this.dateTimePicker2.Value)
                    {
                        MessageBox.Show("时间范围有误");
                        return;
                    }
                    StartEnterTime = this.dateTimePicker1.Value.ToShortDateString();
                    EndEnterTime = this.dateTimePicker2.Value.ToShortDateString();
                }
                DataTable dtResult = BLL.SelectOutDataPage(PageNum, OrgTypeID, MinStudyCount, MaxStudyCount, MinStudyTime, MaxStudyTime, 
                    StartEnterTime, EndEnterTime, OrgID);
                int intResult = BLL.SelectOutDataAllCount(OrgTypeID, MinStudyCount, MaxStudyCount, MinStudyTime, MaxStudyTime, 
                    StartEnterTime, EndEnterTime, OrgID);
                this.dataGridView1.DataSource = dtResult;
                this.label13.Text = "查询到 "+ intResult + " 条记录";
                PageNum = 1;
                this.label7.Text = "当前页码："+PageNum;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (OrgTypeID == "" || OrgTypeID == null)
                    return;
                PageNum--;
                DataTable dtResult = BLL.SelectOutDataPage(PageNum, OrgTypeID, MinStudyCount, MaxStudyCount, MinStudyTime, MaxStudyTime, 
                    StartEnterTime, EndEnterTime, OrgID);
                if (dtResult.Rows.Count==0)
                {
                    MessageBox.Show("无数据");
                    PageNum++;
                    return;
                }
                this.dataGridView1.DataSource = dtResult;
                this.label7.Text = "当前页码：" + PageNum;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (OrgTypeID == "" || OrgTypeID == null)
                    return;
                if (this.dataGridView1.Rows.Count<999)
                {
                    MessageBox.Show("无数据");
                    return;
                }
                PageNum++;
                DataTable dtResult = BLL.SelectOutDataPage(PageNum, OrgTypeID, MinStudyCount, MaxStudyCount, MinStudyTime, MaxStudyTime, 
                    StartEnterTime, EndEnterTime, OrgID);
                if (dtResult.Rows.Count == 0)
                {
                    MessageBox.Show("无数据");
                    PageNum--;
                    return;
                }
                this.dataGridView1.DataSource = dtResult;
                this.label7.Text = "当前页码：" + PageNum;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要导出数据到excel吗？", "导出提醒", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            this.progressBar1.Value = 0;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Step = 1;
            this.button5.Enabled = false;
            ThreadWriteToTXTSharp threadWriteToTXT = threadWriteToTXTSharp;
            IAsyncResult thread1SharpResult = threadWriteToTXT.BeginInvoke( null, null);
        }

        private delegate void ThreadWriteToTXTSharp();
        private void threadWriteToTXTSharp()
        {
            try
            {
                DataTable dtResult = BLL.SelectOutDataAll(OrgTypeID, MinStudyCount, MaxStudyCount, MinStudyTime, MaxStudyTime, 
                    StartEnterTime, EndEnterTime, OrgID);
                string txtfilename = DateTime.Now.ToString("yyyyMMdd") + "监控数据导出";
                if (this.progressBar1.InvokeRequired)//找到创建此控件的线程
                {
                    this.progressBar1.Invoke(new Action<int>(s => { this.progressBar1.Maximum = s; }), dtResult.Rows.Count);
                }
                dataTableToCsv(dtResult, @"D:\" + txtfilename + ".xls");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataTableToCsv(DataTable table, string file)
        {
            try
            {
                string title = "";
                FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
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

                //DialogResult RSS = MessageBox.Show(this, "导出完毕，导出路径为：" + file + "，是否打开此文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //switch (RSS)
                //{
                //    case DialogResult.Yes:
                //        System.Diagnostics.Process.Start(@"D:\" + file + ".xls"); //打开excel文件
                //        break;
                //    case DialogResult.No:
                //        break;
                //}
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
