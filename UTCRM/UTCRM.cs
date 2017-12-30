using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MODEL;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace UTCRM
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public static string CK = "";//默认cookie
        public static string QQCK = "";//默认QQcookie
        public static CookieCollection CC = new CookieCollection();//默认CookieCollection
        public static string CurQQ = "";
        public static string CurQQName = "";
        public static string Operator = "";
        public static string Password = "";
        public static string UserGrade = "";
        public static string Subject = "";
        public static string ObjectTitle = "";
        public static int pid;

        public static List<GroupInfo> lstgi;

         qqApp qqapp = new qqApp();

         Form current, f;
         public void AddWindows()
         {
             foreach (Button btn1 in this.flowLayoutPanel1.Controls)
             {
                 if (btn1.Text == f.Text)
                 {
                     btn1.PerformClick();

                     f.Close();
                     return;
                 }
             }

             current = f;
             current.MdiParent = this;
             current.WindowState = FormWindowState.Maximized;

             Button btn = new Button();
             btn.Height = 25;
             btn.Width = 110;
             btn.Margin = btn.Padding = new System.Windows.Forms.Padding(0);
             btn.Text = current.Text;
             btn.Font = new System.Drawing.Font("宋体", 9);
             this.flowLayoutPanel1.Controls.Add(btn);
             btn.Click += new EventHandler(btn_Click);
             current.FormClosing += new FormClosingEventHandler(f_close);
             btn.Tag = current;
             current.Tag = btn;
             current.Show();
             btn.PerformClick();
         }
         void btn_Click(object sender, EventArgs e)
         {

             current = (sender as Button).Tag as Form;
             current.Activate();

             foreach (Button btn in this.flowLayoutPanel1.Controls)
             {
                 btn.FlatStyle = FlatStyle.System;
             }
             (sender as Button).FlatStyle = FlatStyle.Flat;
         }


         void f_close(object sender, EventArgs e)
         {
             Button navbtn = (sender as Form).Tag as Button;
             this.flowLayoutPanel1.Controls.Remove(navbtn);
             if (this.flowLayoutPanel1.Controls.Count > 0)
                 (this.flowLayoutPanel1.Controls[0] as Button).PerformClick();
         }


        public static void qqlogin()//登录qq群管理
        {
            login ff = new login();
            ff.ShowDialog();
            QQCK = CK;
            Regex reg = new Regex("pt2gguin=o0(.*?);");
            CurQQ = reg.Match(QQCK).Groups[1].Value;
            for (int i = 0; i < 10; i++)
            {
                if (CurQQ.Length > 0 && CurQQ[0] == '0')
                    CurQQ = CurQQ.Substring(1, CurQQ.Length - 1);
            }

           //tools.Writelog("cookie="+CK+"\r\ncurqq=" + CurQQ);
            
        }

        private void qQToolStripMenuItem1_Click(object sender, EventArgs e)//QQ登录
        {

            //Process.Start(@"C:\Program Files (x86)\Tencent\QQ\Bin\QQScLauncher.exe", "");
            login ff = new login();
            ff.ShowDialog();
            frmMain.QQCK = frmMain.CK;
            login.loginurl = "http://ke.qq.com/user/tasks/index.html?cid=57050&tid=100079090";
            login f1 = new login();
            f1.WindowState = FormWindowState.Maximized;
            f1.ShowDialog();
            Regex reg = new Regex("uin_cookie=(.*?);");
            CurQQ = reg.Match(QQCK).Groups[1].Value;
            
        }

        private void 开始监控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!UserGrade.Contains("8"))
            {
                MessageBox.Show("权限不足");
                return;
            }
            if (frmMain.ObjectTitle == "")
            {
                MessageBox.Show("请先选定监控目标");
                SelectObject ff = new SelectObject();
                ff.ShowDialog();
                if (ff.DialogResult == DialogResult.No)
                    return;
            }
            else
            {
                DialogResult dr = MessageBox.Show("当前监控目标为：【" + ObjectTitle + "】，   是否需要重新选定监控目标？", "监控目标提示：", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    SelectObject ff = new SelectObject();
                    ff.ShowDialog();
                }
            }
            keqq kq = new keqq();
            pid = kq.GetKePid(frmMain.ObjectTitle);
            if (pid == 0)
                return;
            f = new MonitorOfQQKeTang();
            AddWindows();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 教学统计ToolStripMenuItem_Click(object sender, EventArgs e)//教学统计
        {
            if (CK == "")
                qqlogin();
            f = new QQKeTangAccount();
            AddWindows();
        }

        private void 群数据导入ToolStripMenuItem_Click(object sender, EventArgs e)//群信息管理
        {

            f = new GroupManage();
            AddWindows();

        }

        private void 群成员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (QQCK == "")
                qqlogin();
            f = new GroupMemberManage();
            AddWindows();
        }

        private void qQToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (QQCK == "")
                qqlogin();
            f = new FriendInfoManage();
            AddWindows();
        }

        private void 学员查询跟踪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!UserGrade.Contains("9"))
            {
                MessageBox.Show("权限不足");
                return;
            }
            f = new SearchStudents();
            AddWindows();
        }

        private void qQToolStripMenuItem3_Click(object sender, EventArgs e)//QQ群上课占比
        {
            f = new QQGroupLessonAccount();
            AddWindows();
        }

        private void 课程数据统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!UserGrade.Contains("9"))
            {
                MessageBox.Show("权限不足");
                return;
            }
            f = new KeTangAccount();
            AddWindows();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f = new ChangePassword();
            AddWindows();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "操作员："+Operator;
        }

        private void 操作员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!UserGrade.Contains("9"))
            {
                MessageBox.Show("权限不足");
                return;
            }
            f = new OperatorManage();
            AddWindows();
        }

        private void 群动态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f = new qundongtai();
            AddWindows();
        }

        private void 机构信息维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f = new OrgMessageFrm.FrmOrgManager();
            f.Text = (sender as ToolStripMenuItem).Text;
            AddWindows();
        }

        private void 机构数据查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f = new OrgMessageFrm.FrmOrgDataQuery();
            f.Text = (sender as ToolStripMenuItem).Text;
            AddWindows();
        }

        private void 机构数据分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f = new OrgMessageFrm.FrmOrgDataAnalyze();
            f.Text = (sender as ToolStripMenuItem).Text;
            AddWindows();
        }

        private void 机构数据导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f = new OrgMessageFrm.FrmOutTypeData();
            f.Text = (sender as ToolStripMenuItem).Text;
            AddWindows();
        }

        private void qQToolStripMenuItem3_Click_1(object sender, EventArgs e)//群上课占比
        {
            f = new QQGroupLessonAccount();
            AddWindows();
        }

    }
}
