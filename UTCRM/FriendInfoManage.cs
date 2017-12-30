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
    public partial class FriendInfoManage : Form
    {
        public FriendInfoManage()
        {
            InitializeComponent();
        }

        qqApp qqapp = new qqApp();
        List<QQFriendInfo> lstfi;
        private void FriendInfoManage_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView_RowPostPaint);
            lstfi = qqapp.GetFriendInfos();
            this.dataGridView1.DataSource = lstfi;
            foreach (QQFriendInfo gm in lstfi)
            {
                if (gm.QQ == frmMain.CurQQ)
                    frmMain.CurQQName = gm.NickName;
            }
            this.textBox1.Text = frmMain.Operator;
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

        private void button1_Click(object sender, EventArgs e)//好友导入
        {
            if (frmMain.CurQQ == "")
            {
                MessageBox.Show("获取管理qq号失败,请再次登录");
                return;
            }
            DataTable dt = DBHelper.ExecuteQuery("select * from QQFriendInfo where OwnerQQ= "+frmMain.CurQQ);
            int n = 0, err = 0,cnt=0;
            string errqq = "";
            foreach (QQFriendInfo gm in lstfi)
            {
                int flag = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() == gm.QQ)
                            flag = 1;
                }
                if (flag == 0)//新增
                {
                    string sqlstr = string.Format("insert into QQFriendInfo select  '{0}',  '{1}',  '{2}', '{3}', '{4}'  ",
                        gm.QQ, gm.NickName.Replace("&nbsp;", ""),  frmMain.CurQQ,frmMain.CurQQName,frmMain.Operator);

                    if (DBHelper.ExecuteUpdate(sqlstr) > 0)
                        n++;
                    else
                    {
                        errqq += gm.QQ + "  ";
                        err++;
                    }
                }

                cnt++;
            }
            MessageBox.Show("当前好友个数为："+cnt+"个，好友信息成功导入数据库" + n + "条");
            if (err > 0)
                MessageBox.Show("导入好友信息失败qq号是：" + errqq);

            int m = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int flag = 0;
                foreach (QQFriendInfo gm in lstfi)
                {
                    if (gm.QQ == dt.Rows[i][0].ToString())
                        flag = 1;
                }
                if (flag == 0)
                {
                    DBHelper.ExecuteUpdate("delete QQFriendInfo where qq=" + dt.Rows[i][0].ToString() + " and OwnerQQ=" + frmMain.CurQQ);

                    string sqlstr2 = string.Format(" update CustomerInfo set Manager='',FriendQQ=''  where qq='{0}'  and Manager='{1}'  and GroupNumber='' ", dt.Rows[i][0].ToString(), frmMain.Operator);
                    DBHelper.ExecuteUpdate(sqlstr2);
                    m++;
                }
            }
            

            string sqlstr1 = string.Format(" update CustomerInfo set Manager='{0}',FriendQQ='{1}'  where qq in (select qq from QQFriendInfo where OwnerQQ='{1}') ", frmMain.Operator, frmMain.CurQQ);
            DBHelper.ExecuteUpdate(sqlstr1);

            if (m > 0)
                MessageBox.Show("删除好友信息" + m + "条");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
