using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using CsharpHttpHelper;
using CsharpHttpHelper.Enum;
using MODEL;
//注：需加入Microsoft.JScript

namespace UTCRM
{
    class qqApp
    {
        public string GetSelfNickName()
        {
            string bkn = get_bkn();
            string url = " http://qun.qq.com/manage.html/";
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = url,
                Method = "post",
                Postdata = "bkn=" + bkn,
                Cookie = frmMain.QQCK
            };
            HttpResult result = http.GetHtml(item);
            string htmlText = result.Html;
            //tools.showlog(htmlText);
            string nickname = "";
            return nickname;
        }

        public List<GroupInfo> GetGroupInfos()
        {
            MessageBox.Show("开始获取群信息");
            string bkn = get_bkn();
            //string url = "http://qun.qq.com/cgi-bin/qun_mgr/get_group_list";
            string url = "http://vip.qq.com/client/group/upgrade.html";
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = url,
                Method = "post",
                //Postdata = "bkn=" + bkn,
                Cookie = frmMain.QQCK
            };
            HttpResult result = http.GetHtml(item);
            string htmlText = result.Html;
            //tools.Writelog("bkn="+bkn+htmlText);
            List<GroupInfo> GroupInfos = new List<GroupInfo>();

            Regex reg = new Regex("({\"gc\":.*?})");
            var mats = reg.Matches(htmlText);

            foreach (Match m in mats)
            {
                string mstr = m.Groups[1].Value;
                GroupInfo gi = new GroupInfo();

                reg = new Regex("\"gc\":(.*?),");
                gi.Number = reg.Match(mstr).Groups[1].Value;//群号

                reg = new Regex("\"gn\":\"(.*?)\",");
                gi.Name = reg.Match(mstr).Groups[1].Value;//群名

                reg = new Regex("\"owner\":(.*?)}");
                gi.Owner = reg.Match(mstr).Groups[1].Value;//群主

                //MessageBox.Show("gi.Number=" + gi.Number + "    gi.Name=" + gi.Name + "   gi.Owner=" + gi.Owner + "\n");

                GroupInfos.Add(gi);
            }

            return GroupInfos;
        }

        public List<QQFriendInfo> GetFriendInfos()
        {
            string bkn = get_bkn();
            string url = "http://qun.qq.com/cgi-bin/qun_mgr/get_friend_list";
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = url,
                Method = "post",
                Postdata = "bkn=" + bkn,
                Cookie = frmMain.QQCK
            };
            HttpResult result = http.GetHtml(item);
            string htmlText = result.Html;
            //tools.showlog(htmlText);
            List<QQFriendInfo> FriendInfos = new List<QQFriendInfo>();

            Regex reg = new Regex("({\"name\":.*?})");
            var mats = reg.Matches(htmlText);

            foreach (Match m in mats)
            {
                string mstr = m.Groups[1].Value;
                QQFriendInfo fi = new QQFriendInfo();

                reg = new Regex("\"uin\":(.*?)}");
                fi.QQ = reg.Match(mstr).Groups[1].Value;//QQ号

                reg = new Regex("\"name\":\"(.*?)\",");
                fi.NickName = reg.Match(mstr).Groups[1].Value;//昵称
                fi.SelfQQ = frmMain.CurQQ;

                //MessageBox.Show("fi.QQ=" + fi.QQ + "    fi.NickName=" + fi.NickName + "\n");

                FriendInfos.Add(fi);
            }

            return FriendInfos;
        }

        public List<QQGroupMemberInfo> GetMemberInfo(string groupnumber )
        {

            string url0 = "http://qun.qq.com/member.html#gid=" + groupnumber;
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = url0,
                Cookie = frmMain.CK,
            };
            HttpResult result = http.GetHtml(item);
            string ck = frmMain.CK + result.Cookie;
            //tools.Writelog(url0+"\r\n"+ result.Html);

            string bkn = get_bkn();
            string url = "http://qun.qq.com/cgi-bin/qun_mgr/search_group_members";
            List<QQGroupMemberInfo> gmis = new List<QQGroupMemberInfo>();

            http = new HttpHelper();
            item = new HttpItem()
                {
                    URL = url,
                    Method = "post",
                    Postdata = "bkn=" + bkn + "&end=" + 20 + "&gc=" + groupnumber + "&sort=0&st=0",
                    Cookie = ck,
                    Referer = "http://qun.qq.com/member.html#gid=" + groupnumber
                };
            result = http.GetHtml(item);
            string htmlText = result.Html;
            //tools.Writelog("ck="+ ck+"\r\n"+ "    bkn" + bkn+"  url"+url + "\r\n" + result.Html);
            Regex reg = new Regex("\"count\":(.*?),");
            string count = reg.Match(htmlText).Groups[1].Value;

            //MessageBox.Show("count=" + count);


            http = new HttpHelper();
            item = new HttpItem()
            {
                URL = url,
                Method = "post",
                Postdata = "bkn=" + bkn + "&end=" + count + "&gc=" + groupnumber + "&sort=0&st=0",
                Cookie = ck,
                Referer = "http://qun.qq.com/member.html#gid=" + groupnumber
            };

            result = http.GetHtml(item);
            htmlText = result.Html;
            //tools.showlog(htmlText);
            //MessageBox.Show("count=" + count);
            reg = new Regex("({\"card\":.*?\"uin\":.*?})");
            var mats = reg.Matches(htmlText);
            foreach (Match m in mats)
            {
                QQGroupMemberInfo gmi = new QQGroupMemberInfo();
                gmi.GroupNumber = groupnumber;

                string mstr = m.Groups[1].Value;
                //MessageBox.Show(mstr);
                reg = new Regex("\"card\":\"(.*?)\",");
                gmi.GroupCard = reg.Match(mstr).Groups[1].Value;

                reg = new Regex("join_time\":(.*?),");
                gmi.join_time = reg.Match(mstr).Groups[1].Value;
                gmi.join_time = tools.StampToDateTime(gmi.join_time).ToString("yyyyMMdd");

                reg = new Regex("last_speak_time\":(.*?),");
                gmi.last_speak_time = reg.Match(mstr).Groups[1].Value;
                gmi.last_speak_time = tools.StampToDateTime(gmi.last_speak_time).ToString("yyyyMMdd");

                reg = new Regex("nick\":\"(.*?)\",");
                gmi.NickName = reg.Match(mstr).Groups[1].Value;

                reg = new Regex("role\":(.*?),");
                gmi.GroupGrade = reg.Match(mstr).Groups[1].Value;
                if (gmi.GroupGrade == "0") gmi.GroupGrade = "群主";
                if (gmi.GroupGrade == "1") gmi.GroupGrade = "管理";
                if (gmi.GroupGrade == "2") gmi.GroupGrade = "成员";

                reg = new Regex("uin\":(.*?)}");
                gmi.QQ = reg.Match(mstr).Groups[1].Value;

                //MessageBox.Show("gmi.Card =" + gmi.Card + "  gmi.join_time =" + gmi.join_time + "  gmi.last_speak_time ="+gmi.last_speak_time +"  gmi.NickName ="+gmi.NickName
                //   + "   gmi.grade =" + gmi.grade + "    gmi.QQ ="+gmi.QQ);
                gmis.Add(gmi);

            }


            return gmis;
        }


        /// <summary>
        /// 执行js代码
        /// </summary>
        /// <param name="sExpression">函数</param>
        /// <param name="sCode">代码</param>
        /// <returns></returns>
        private static string ExecuteScript(string sExpression, string sCode)
        {
            MSScriptControl.ScriptControl scriptControl = new MSScriptControl.ScriptControl();
            scriptControl.UseSafeSubset = true;
            scriptControl.Language = "JScript";
            scriptControl.AddCode(sCode);
            try
            {
                string str = scriptControl.Eval(sExpression).ToString();
                return str;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return null;
        }

        /// <summary>
        /// 密码RSA加密
        /// </summary>
        /// <param name="Puin">QQ号码</param>
        /// <param name="Ppass">QQ密码</param>
        /// <param name="Pcode">验证码</param>
        /// <returns></returns>
        public static string ToRSA(string Puin, string Ppass, string Pcode)
        {
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(typeof(Properties.Resources));
            string str = rm.GetString("QQRSA");

            string fun = string.Format(@"getEncryption('{0}','{1}','{2}')", Ppass, Puin, Pcode);
            return ExecuteScript(fun, str);
        }

        public string get_bkn()
        {
            Regex reg = new Regex(" skey=(.*?);");
            string t = reg.Match(frmMain.CK).Groups[1].Value;
            int r = 5381;
            if (t.Length > 0)
            {
                for (int n = 0, o = t.Length; o > n; ++n)
                {
                    r += (r << 5) + (int)t[n];
                }
            }
            return (2147483647 & r).ToString();
        }
    }
}
