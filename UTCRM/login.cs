using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices;
using CsharpHttpHelper;
using CsharpHttpHelper.Enum;

namespace UTCRM
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        public static string loginurl = "http://ui.ptlogin2.qq.com/cgi-bin/login?appid=715030901&daid=73&pt_no_auth=1&s_url=http%3A%2F%2Fqun.qq.com%2F";
        public static string incomeDetail = "qun.qq.com#";
        public static int px = 720;
        public static int py = 130;
        CookieCollection cc = new CookieCollection();
        string log = "";
        private void login_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(loginurl);
        }



        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData,
        ref System.UInt32 pcchCookieData, int dwFlags, IntPtr lpReserved);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int InternetSetCookieEx(string lpszURL, string lpszCookieName, string lpszCookieData, int dwFlags,
        IntPtr dwReserved);

        private static string GetCookies(string url)
        {
            uint datasize = 256;
            StringBuilder cookieData = new StringBuilder((int)datasize);
            if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, IntPtr.Zero))
            {
                if (datasize < 0)
                    return null;

                cookieData = new StringBuilder((int)datasize);
                if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, IntPtr.Zero))
                    return null;
            }
            return cookieData.ToString();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            log += e.Url.ToString() + "\r\n"; log += e.Url.ToString() + "\r\n";
            frmMain.CK += GetCookies(e.Url.ToString());
            if (e.Url.ToString() == "http://qun.qq.com/")
            {

                //tools.Writelog(log);
                this.Dispose();
                this.Close();
            }
        }

    }
}
