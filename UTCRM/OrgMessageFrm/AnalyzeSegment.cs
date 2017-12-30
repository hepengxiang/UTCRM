using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UTCRM.OrgMessageFrm
{
    public partial class AnalyzeSegment : Form
    {
        private OrgMessageBLL BLL;
        public AnalyzeSegment()
        {
            InitializeComponent();
            if (BLL == null)
                BLL = new OrgMessageBLL();
        }

        private void AnalyzeSegment_Load(object sender, EventArgs e)
        {
            dataLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.AllTimeCount1.Text.Trim() == "" || this.AllTimeCount1.Text.Trim() == "0" ||
                    this.AllTimeCount2.Text.Trim() == "" || this.AllTimeCount2.Text.Trim() == "0" ||
                    this.AllTimeCount3.Text.Trim() == "" || this.AllTimeCount3.Text.Trim() == "0" ||
                    this.AllTimeCount4.Text.Trim() == "" || this.AllTimeCount4.Text.Trim() == "0" ||
                    this.AllTimeCount5.Text.Trim() == "" || this.AllTimeCount5.Text.Trim() == "0" ||

                    this.AllStudyCount1.Text.Trim() == "" || this.AllStudyCount1.Text.Trim() == "0" ||
                    this.AllStudyCount2.Text.Trim() == "" || this.AllStudyCount2.Text.Trim() == "0" ||
                    this.AllStudyCount3.Text.Trim() == "" || this.AllStudyCount3.Text.Trim() == "0" ||
                    this.AllStudyCount4.Text.Trim() == "" || this.AllStudyCount4.Text.Trim() == "0" ||
                    this.AllStudyCount5.Text.Trim() == "" || this.AllStudyCount5.Text.Trim() == "0" ||

                    this.OrgTimeCount1.Text.Trim() == "" || this.OrgTimeCount1.Text.Trim() == "0" ||
                    this.OrgTimeCount2.Text.Trim() == "" || this.OrgTimeCount2.Text.Trim() == "0" ||
                    this.OrgTimeCount3.Text.Trim() == "" || this.OrgTimeCount3.Text.Trim() == "0" ||
                    this.OrgTimeCount4.Text.Trim() == "" || this.OrgTimeCount4.Text.Trim() == "0" ||
                    this.OrgTimeCount5.Text.Trim() == "" || this.OrgTimeCount5.Text.Trim() == "0" ||

                    this.OrgStudyCount1.Text.Trim() == "" || this.OrgStudyCount1.Text.Trim() == "0" ||
                    this.OrgStudyCount2.Text.Trim() == "" || this.OrgStudyCount2.Text.Trim() == "0" ||
                    this.OrgStudyCount3.Text.Trim() == "" || this.OrgStudyCount3.Text.Trim() == "0" ||
                    this.OrgStudyCount4.Text.Trim() == "" || this.OrgStudyCount4.Text.Trim() == "0" ||
                    this.OrgStudyCount5.Text.Trim() == "" || this.OrgStudyCount5.Text.Trim() == "0" ||

                    this.OrgDayTimeCount1.Text.Trim() == "" || this.OrgDayTimeCount1.Text.Trim() == "0" ||
                    this.OrgDayTimeCount2.Text.Trim() == "" || this.OrgDayTimeCount2.Text.Trim() == "0" ||
                    this.OrgDayTimeCount3.Text.Trim() == "" || this.OrgDayTimeCount3.Text.Trim() == "0" ||
                    this.OrgDayTimeCount4.Text.Trim() == "" || this.OrgDayTimeCount4.Text.Trim() == "0" ||
                    this.OrgDayTimeCount5.Text.Trim() == "" || this.OrgDayTimeCount5.Text.Trim() == "0" ||

                    this.OrgDayStudyCount1.Text.Trim() == "" || this.OrgDayStudyCount1.Text.Trim() == "0" ||
                    this.OrgDayStudyCount2.Text.Trim() == "" || this.OrgDayStudyCount2.Text.Trim() == "0" ||
                    this.OrgDayStudyCount3.Text.Trim() == "" || this.OrgDayStudyCount3.Text.Trim() == "0" ||
                    this.OrgDayStudyCount4.Text.Trim() == "" || this.OrgDayStudyCount4.Text.Trim() == "0" ||
                    this.OrgDayStudyCount5.Text.Trim() == "" || this.OrgDayStudyCount5.Text.Trim() == "0")
                {
                    MessageBox.Show("只能填写数字，且不能为0");
                    return;
                }
                else
                {
                    this.Close();
                    ((AnalyzeOfPie)Owner).loadSegmeng(
                            int.Parse(this.AllTimeCount1.Text.Trim()), int.Parse(this.AllTimeCount2.Text.Trim()), int.Parse(this.AllTimeCount3.Text.Trim()), int.Parse(this.AllTimeCount4.Text.Trim()), int.Parse(this.AllTimeCount5.Text.Trim()),
                            int.Parse(this.AllStudyCount1.Text.Trim()), int.Parse(this.AllStudyCount2.Text.Trim()), int.Parse(this.AllStudyCount3.Text.Trim()), int.Parse(this.AllStudyCount4.Text.Trim()), int.Parse(this.AllStudyCount5.Text.Trim()),
                            int.Parse(this.OrgTimeCount1.Text.Trim()), int.Parse(this.OrgTimeCount2.Text.Trim()), int.Parse(this.OrgTimeCount3.Text.Trim()), int.Parse(this.OrgTimeCount4.Text.Trim()), int.Parse(this.OrgTimeCount5.Text.Trim()),
                            int.Parse(this.OrgStudyCount1.Text.Trim()), int.Parse(this.OrgStudyCount2.Text.Trim()), int.Parse(this.OrgStudyCount3.Text.Trim()), int.Parse(this.OrgStudyCount4.Text.Trim()), int.Parse(this.OrgStudyCount5.Text.Trim()),
                            int.Parse(this.OrgDayTimeCount1.Text.Trim()), int.Parse(this.OrgDayTimeCount2.Text.Trim()), int.Parse(this.OrgDayTimeCount3.Text.Trim()), int.Parse(this.OrgDayTimeCount4.Text.Trim()), int.Parse(this.OrgDayTimeCount5.Text.Trim()),
                            int.Parse(this.OrgDayStudyCount1.Text.Trim()), int.Parse(this.OrgDayStudyCount2.Text.Trim()), int.Parse(this.OrgDayStudyCount3.Text.Trim()), int.Parse(this.OrgDayStudyCount4.Text.Trim()), int.Parse(this.OrgDayStudyCount5.Text.Trim()));
                }
            }
            catch //(Exception ex)
            {
                MessageBox.Show("只能填写数字，且不能为0");
            }
            bool bResult = BLL.AnalyzeSegmeng(
            int.Parse(this.AllTimeCount1.Text.Trim()), int.Parse(this.AllTimeCount2.Text.Trim()), int.Parse(this.AllTimeCount3.Text.Trim()), int.Parse(this.AllTimeCount4.Text.Trim()), int.Parse(this.AllTimeCount5.Text.Trim()),
            int.Parse(this.AllStudyCount1.Text.Trim()), int.Parse(this.AllStudyCount2.Text.Trim()), int.Parse(this.AllStudyCount3.Text.Trim()), int.Parse(this.AllStudyCount4.Text.Trim()), int.Parse(this.AllStudyCount5.Text.Trim()),
            int.Parse(this.OrgTimeCount1.Text.Trim()), int.Parse(this.OrgTimeCount2.Text.Trim()), int.Parse(this.OrgTimeCount3.Text.Trim()), int.Parse(this.OrgTimeCount4.Text.Trim()), int.Parse(this.OrgTimeCount5.Text.Trim()),
            int.Parse(this.OrgStudyCount1.Text.Trim()), int.Parse(this.OrgStudyCount2.Text.Trim()), int.Parse(this.OrgStudyCount3.Text.Trim()), int.Parse(this.OrgStudyCount4.Text.Trim()), int.Parse(this.OrgStudyCount5.Text.Trim()),
            int.Parse(this.OrgDayTimeCount1.Text.Trim()), int.Parse(this.OrgDayTimeCount2.Text.Trim()), int.Parse(this.OrgDayTimeCount3.Text.Trim()), int.Parse(this.OrgDayTimeCount4.Text.Trim()), int.Parse(this.OrgDayTimeCount5.Text.Trim()),
            int.Parse(this.OrgDayStudyCount1.Text.Trim()), int.Parse(this.OrgDayStudyCount2.Text.Trim()), int.Parse(this.OrgDayStudyCount3.Text.Trim()), int.Parse(this.OrgDayStudyCount4.Text.Trim()), int.Parse(this.OrgDayStudyCount5.Text.Trim()));
            if (bResult)
            {
                MessageBox.Show("提交成功");
                dataLoad();
            }
            else
            {
                MessageBox.Show("提交失败");
            }
        }

        private void dataLoad()
        {
            try
            {
                DataTable dtResult = BLL.AnalyzeSegmengSelect();
                if (dtResult.Rows.Count > 0)
                {
                    this.AllTimeCount1.Text = dtResult.Rows[0]["AllTimeCount1"].ToString();
                    this.AllTimeCount2.Text = dtResult.Rows[0]["AllTimeCount2"].ToString();
                    this.AllTimeCount3.Text = dtResult.Rows[0]["AllTimeCount3"].ToString();
                    this.AllTimeCount4.Text = dtResult.Rows[0]["AllTimeCount4"].ToString();
                    this.AllTimeCount5.Text = dtResult.Rows[0]["AllTimeCount5"].ToString();

                    this.AllStudyCount1.Text = dtResult.Rows[0]["AllStudyCount1"].ToString();
                    this.AllStudyCount2.Text = dtResult.Rows[0]["AllStudyCount2"].ToString();
                    this.AllStudyCount3.Text = dtResult.Rows[0]["AllStudyCount3"].ToString();
                    this.AllStudyCount4.Text = dtResult.Rows[0]["AllStudyCount4"].ToString();
                    this.AllStudyCount5.Text = dtResult.Rows[0]["AllStudyCount5"].ToString();

                    this.OrgTimeCount1.Text = dtResult.Rows[0]["OrgTimeCount1"].ToString();
                    this.OrgTimeCount2.Text = dtResult.Rows[0]["OrgTimeCount2"].ToString();
                    this.OrgTimeCount3.Text = dtResult.Rows[0]["OrgTimeCount3"].ToString();
                    this.OrgTimeCount4.Text = dtResult.Rows[0]["OrgTimeCount4"].ToString();
                    this.OrgTimeCount5.Text = dtResult.Rows[0]["OrgTimeCount5"].ToString();

                    this.OrgStudyCount1.Text = dtResult.Rows[0]["OrgStudyCount1"].ToString();
                    this.OrgStudyCount2.Text = dtResult.Rows[0]["OrgStudyCount2"].ToString();
                    this.OrgStudyCount3.Text = dtResult.Rows[0]["OrgStudyCount3"].ToString();
                    this.OrgStudyCount4.Text = dtResult.Rows[0]["OrgStudyCount4"].ToString();
                    this.OrgStudyCount5.Text = dtResult.Rows[0]["OrgStudyCount5"].ToString();

                    this.OrgDayTimeCount1.Text = dtResult.Rows[0]["OrgDayTimeCount1"].ToString();
                    this.OrgDayTimeCount2.Text = dtResult.Rows[0]["OrgDayTimeCount2"].ToString();
                    this.OrgDayTimeCount3.Text = dtResult.Rows[0]["OrgDayTimeCount3"].ToString();
                    this.OrgDayTimeCount4.Text = dtResult.Rows[0]["OrgDayTimeCount4"].ToString();
                    this.OrgDayTimeCount5.Text = dtResult.Rows[0]["OrgDayTimeCount5"].ToString();

                    this.OrgDayStudyCount1.Text = dtResult.Rows[0]["OrgDayStudyCount1"].ToString();
                    this.OrgDayStudyCount2.Text = dtResult.Rows[0]["OrgDayStudyCount2"].ToString();
                    this.OrgDayStudyCount3.Text = dtResult.Rows[0]["OrgDayStudyCount3"].ToString();
                    this.OrgDayStudyCount4.Text = dtResult.Rows[0]["OrgDayStudyCount4"].ToString();
                    this.OrgDayStudyCount5.Text = dtResult.Rows[0]["OrgDayStudyCount5"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getAnalyzeSegmeng(
        int AllTimeCount1, int AllTimeCount2, int AllTimeCount3, int AllTimeCount4, int AllTimeCount5,
        int AllStudyCount1, int AllStudyCount2, int AllStudyCount3, int AllStudyCount4, int AllStudyCount5,
        int OrgTimeCount1, int OrgTimeCount2, int OrgTimeCount3, int OrgTimeCount4, int OrgTimeCount5,
        int OrgStudyCount1, int OrgStudyCount2, int OrgStudyCount3, int OrgStudyCount4, int OrgStudyCount5,
        int OrgDayTimeCount1, int OrgDayTimeCount2, int OrgDayTimeCount3, int OrgDayTimeCount4, int OrgDayTimeCount5,
        int OrgDayStudyCount1, int OrgDayStudyCount2, int OrgDayStudyCount3, int OrgDayStudyCount4, int OrgDayStudyCount5)
        {
            try
            {
                DataTable dtResult = BLL.AnalyzeSegmengSelect();
                if (dtResult.Rows.Count > 0)
                {
                    AllTimeCount1 = int.Parse(dtResult.Rows[0]["AllTimeCount1"].ToString());
                    AllTimeCount2 = int.Parse(dtResult.Rows[0]["AllTimeCount2"].ToString());
                    AllTimeCount3 = int.Parse(dtResult.Rows[0]["AllTimeCount3"].ToString());
                    AllTimeCount4 = int.Parse(dtResult.Rows[0]["AllTimeCount4"].ToString());
                    AllTimeCount5 = int.Parse(dtResult.Rows[0]["AllTimeCount5"].ToString());

                    AllStudyCount1 = int.Parse(dtResult.Rows[0]["AllStudyCount1"].ToString());
                    AllStudyCount2 = int.Parse(dtResult.Rows[0]["AllStudyCount2"].ToString());
                    AllStudyCount3 = int.Parse(dtResult.Rows[0]["AllStudyCount3"].ToString());
                    AllStudyCount4 = int.Parse(dtResult.Rows[0]["AllStudyCount4"].ToString());
                    AllStudyCount5 = int.Parse(dtResult.Rows[0]["AllStudyCount5"].ToString());

                    OrgTimeCount1 = int.Parse(dtResult.Rows[0]["OrgTimeCount1"].ToString());
                    OrgTimeCount2 = int.Parse(dtResult.Rows[0]["OrgTimeCount2"].ToString());
                    OrgTimeCount3 = int.Parse(dtResult.Rows[0]["OrgTimeCount3"].ToString());
                    OrgTimeCount4 = int.Parse(dtResult.Rows[0]["OrgTimeCount4"].ToString());
                    OrgTimeCount5 = int.Parse(dtResult.Rows[0]["OrgTimeCount5"].ToString());

                    OrgStudyCount1 = int.Parse(dtResult.Rows[0]["OrgStudyCount1"].ToString());
                    OrgStudyCount2 = int.Parse(dtResult.Rows[0]["OrgStudyCount2"].ToString());
                    OrgStudyCount3 = int.Parse(dtResult.Rows[0]["OrgStudyCount3"].ToString());
                    OrgStudyCount4 = int.Parse(dtResult.Rows[0]["OrgStudyCount4"].ToString());
                    OrgStudyCount5 = int.Parse(dtResult.Rows[0]["OrgStudyCount5"].ToString());

                    OrgDayTimeCount1 = int.Parse(dtResult.Rows[0]["OrgDayTimeCount1"].ToString());
                    OrgDayTimeCount2 = int.Parse(dtResult.Rows[0]["OrgDayTimeCount2"].ToString());
                    OrgDayTimeCount3 = int.Parse(dtResult.Rows[0]["OrgDayTimeCount3"].ToString());
                    OrgDayTimeCount4 = int.Parse(dtResult.Rows[0]["OrgDayTimeCount4"].ToString());
                    OrgDayTimeCount5 = int.Parse(dtResult.Rows[0]["OrgDayTimeCount5"].ToString());

                    OrgDayStudyCount1 = int.Parse(dtResult.Rows[0]["OrgDayStudyCount1"].ToString());
                    OrgDayStudyCount2 = int.Parse(dtResult.Rows[0]["OrgDayStudyCount2"].ToString());
                    OrgDayStudyCount3 = int.Parse(dtResult.Rows[0]["OrgDayStudyCount3"].ToString());
                    OrgDayStudyCount4 = int.Parse(dtResult.Rows[0]["OrgDayStudyCount4"].ToString());
                    OrgDayStudyCount5 = int.Parse(dtResult.Rows[0]["OrgDayStudyCount5"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
