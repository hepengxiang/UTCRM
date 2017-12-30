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
    public partial class KeTangAccount : Form
    {
        public KeTangAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlstr = string.Format("select subjectname,CONVERT(varchar(100), cometime, 111) as lessondate , count(qq)  as maxcnt, " +
                "sum(case when CONVERT(varchar(100), cometime, 108)<='20:05:00' then 1 else 0 end ) as ontimecnt from KeQQStudyRecord " +
                "where cometime>='{0}' and cometime <='{1}' " +
                "group by subjectname,CONVERT(varchar(100), cometime, 111)",
                this.dateTimePicker1.Value.ToString("yyyyMMdd"), this.dateTimePicker2.Value.ToString("yyyyMMdd"));
            DataTable dt = DBHelper.ExecuteQuery(sqlstr);
            this.label3.Text = "共查询到"+dt.Rows.Count+"条记录";
            this.dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = keqq.StringToHexString(this.textBox1.Text);
        }
    }
}
