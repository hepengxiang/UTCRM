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
    public partial class QQGroupLessonAccount : Form
    {
        public QQGroupLessonAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( this.dateTimePicker1.Value.ToString("yyyyMMdd")==this.dateTimePicker2.Value.ToString("yyyyMMdd"))
            {
                MessageBox.Show("开始日期不能等于结束日期，如果要查询开始日期当天的数据，结束日期必须是开始日期的下一天");
                return;
            }
            string sqlstr1 = "";
            if (!frmMain.UserGrade.Contains("9"))
                sqlstr1 = string.Format(" and a.manager='{0}' ", frmMain.Operator);

            string sqlstr = string.Format("select a.manager,a.name , '{0}' as begindate,'{1}' as enddate,  "+
            " (select count(*) from KeQQStudyRecord where cometime>='{0}' and cometime <='{1}')/datediff(day,'{0}','{1}') as allcomecnt,"+
            " count(distinct b.qq) as managercnt,   " +
            " count(c.qq)/datediff(day,'{0}','{1}')  as avgketangcnt ,"+
            " cast(round(cast(count(c.qq) as decimal(10,2))/datediff(day,'{0}','{1}')*100/(select count(*) "+
            " from KeQQStudyRecord where cometime>='{0}' and cometime <='{1}')/datediff(day,'{0}','{1}'),2) as decimal(10,2)) as perb,"+
            " cast(round(cast(count(c.qq) as decimal(10,2))/datediff(day,'{0}','{1}')*100/count(b.qq),2) as decimal(10,2))  as perc "+
            " from   GroupInfo a "+
            " left join GroupMemberInfo b on a.number=b.groupnumber "+
            " left join  KeQQStudyRecord c on b.QQ=c.QQ and c.cometime>='{0}' and c.cometime <='{1}'   "+
            " where 1>0  {2}"+
            " group by a.manager,a.name  having count(b.qq)>0 "+
            " union all "+
            " select a.username,'QQ'+b.OwnerQQ+'好友' as name , '{0}' as begindate,'{1}' as enddate,   " +
            " (select count(*) from KeQQStudyRecord where cometime>='{0}' and cometime <='{1}')/datediff(day,'{0}','{1}') as allcomecnt, "+
            " count( b.qq) as managercnt,    " +
            " count(distinct c.qq)/datediff(day,'{0}','{1}')  as avgketangcnt , " +
            " cast(round(cast(count(c.qq) as decimal(10,2))/datediff(day,'{0}','{1}')*100/(select count(*)  "+
            " from KeQQStudyRecord where cometime>='{0}' and cometime <='{1}')/datediff(day,'{0}','{1}'),2) as decimal(10,2)) as perb, "+
            " cast(round(cast(count(c.qq) as decimal(10,2))/datediff(day,'{0}','{1}')*100/count(b.qq),2) as decimal(10,2))  as perc  "+
            " from   userinfo a  " +
            " left join QQFriendInfo b on a.username=b.manager " +
            " left join  KeQQStudyRecord c on b.QQ=c.QQ and c.cometime>='{0}' and c.cometime <='{1}'   "+
            " where 1>0  {2}"+
            " group by a.username,b.OwnerQQ  having count(b.qq)>0  order by manager",

                this.dateTimePicker1.Value.ToString("yyyyMMdd"),this.dateTimePicker2.Value.ToString("yyyyMMdd"),sqlstr1);
            //tools.showlog(sqlstr);
            this.dataGridView1.DataSource = DBHelper.ExecuteQuery(sqlstr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
