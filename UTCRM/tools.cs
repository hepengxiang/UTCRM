using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Text.RegularExpressions;

namespace UTCRM
{
    public class ExtendedWebBrowser : System.Windows.Forms.WebBrowser
    {
        System.Windows.Forms.AxHost.ConnectionPointCookie cookie;
        WebBrowserExtendedEvents events;

        //This method will be called to give you a chance to create your own event sink

        protected override void CreateSink()
        {
            //MAKE SURE TO CALL THE BASE or the normal events won't fire

            base.CreateSink();
            events = new WebBrowserExtendedEvents(this);
            cookie = new System.Windows.Forms.AxHost.ConnectionPointCookie(this.ActiveXInstance, events, typeof(DWebBrowserEvents2));
        }

        protected override void DetachSink()
        {
            if (null != cookie)
            {
                cookie.Disconnect();
                cookie = null;
            }
            base.DetachSink();
        }

        //This new event will fire when the page is navigating

        public event EventHandler<WebBrowserExtendedNavigatingEventArgs> BeforeNavigate;
        public event EventHandler<WebBrowserExtendedNavigatingEventArgs> BeforeNewWindow;

        protected void OnBeforeNewWindow(string url, out bool cancel)
        {
            EventHandler<WebBrowserExtendedNavigatingEventArgs> h = BeforeNewWindow;
            WebBrowserExtendedNavigatingEventArgs args = new WebBrowserExtendedNavigatingEventArgs(url, null);
            if (null != h)
            {
                h(this, args);
            }
            cancel = args.Cancel;
        }

        protected void OnBeforeNavigate(string url, string frame, out bool cancel)
        {
            EventHandler<WebBrowserExtendedNavigatingEventArgs> h = BeforeNavigate;
            WebBrowserExtendedNavigatingEventArgs args = new WebBrowserExtendedNavigatingEventArgs(url, frame);
            if (null != h)
            {
                h(this, args);
            }
            //Pass the cancellation chosen back out to the events

            cancel = args.Cancel;
        }
        //This class will capture events from the WebBrowser

        class WebBrowserExtendedEvents : System.Runtime.InteropServices.StandardOleMarshalObject, DWebBrowserEvents2
        {
            ExtendedWebBrowser _Browser;
            public WebBrowserExtendedEvents(ExtendedWebBrowser browser) { _Browser = browser; }

            //Implement whichever events you wish

            public void BeforeNavigate2(object pDisp, ref object URL, ref object flags, ref object targetFrameName, ref object postData, ref object headers, ref bool cancel)
            {
                _Browser.OnBeforeNavigate((string)URL, (string)targetFrameName, out cancel);
            }

            public void NewWindow3(object pDisp, ref bool cancel, ref object flags, ref object URLContext, ref object URL)
            {
                _Browser.OnBeforeNewWindow((string)URL, out cancel);
            }

        }
        [System.Runtime.InteropServices.ComImport(), System.Runtime.InteropServices.Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D"),
        System.Runtime.InteropServices.InterfaceTypeAttribute(System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIDispatch),
        System.Runtime.InteropServices.TypeLibType(System.Runtime.InteropServices.TypeLibTypeFlags.FHidden)]
        public interface DWebBrowserEvents2
        {

            [System.Runtime.InteropServices.DispId(250)]
            void BeforeNavigate2(
                [System.Runtime.InteropServices.In,
                System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.IDispatch)] object pDisp,
                [System.Runtime.InteropServices.In] ref object URL,
                [System.Runtime.InteropServices.In] ref object flags,
                [System.Runtime.InteropServices.In] ref object targetFrameName, [System.Runtime.InteropServices.In] ref object postData,
                [System.Runtime.InteropServices.In] ref object headers,
                [System.Runtime.InteropServices.In,
                System.Runtime.InteropServices.Out] ref bool cancel);
            [System.Runtime.InteropServices.DispId(273)]
            void NewWindow3(
                [System.Runtime.InteropServices.In,
                System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.IDispatch)] object pDisp,
                [System.Runtime.InteropServices.In, System.Runtime.InteropServices.Out] ref bool cancel,
                [System.Runtime.InteropServices.In] ref object flags,
                [System.Runtime.InteropServices.In] ref object URLContext,
                [System.Runtime.InteropServices.In] ref object URL);

        }
    }

    public class WebBrowserExtendedNavigatingEventArgs : System.ComponentModel.CancelEventArgs
    {
        private string _Url;
        public string Url
        {
            get { return _Url; }
        }

        private string _Frame;
        public string Frame
        {
            get { return _Frame; }
        }

        public WebBrowserExtendedNavigatingEventArgs(string url, string frame)
            : base()
        {
            _Url = url;
            _Frame = frame;
        }
    }


    class tools
    {

        public static void killSearchWords()
        {

            string curPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            curPath = curPath.Replace("SearchWords.vshost.exe", "");
            curPath = curPath.Replace("SearchWords.exe", "");
            string AppName = "SearchWords";
            string AppPath = curPath + "SearchWords.exe";
            System.Diagnostics.Process[] Ps = System.Diagnostics.Process.GetProcessesByName(AppName);
            if (Ps.Length == 0)
            {
                return;
            }
            else
            {
                bool isrun = false;
                foreach (System.Diagnostics.Process p in Ps)
                {
                    if (p.MainModule.FileName == AppPath)
                    {
                        isrun = true;
                        break;
                    }
                }
                if (isrun)
                {
                    //MessageBox.Show(this, "检测到【" + AppFileName + "】正在运行，升级程序将将其强制关闭。 \r\n请在按下确定前手动关闭以避免数据丢失。", "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Ps = System.Diagnostics.Process.GetProcessesByName(AppName);
                    foreach (System.Diagnostics.Process p in Ps)
                    {
                        if (p.MainModule.FileName == AppPath)
                        {
                            try
                            {
                                p.Kill();
                                p.WaitForExit(10000);
                            }
                            catch (Exception exx)
                            {
                                throw exx;
                            }
                        }
                    }


                }
                else
                {
                    return;
                }

            }
        }


        public static int MaxTreadingCount = 100;
        public static double[] GetSortASC(double[] array)//数组冒泡排序
        {
            //外层循环n-1
            for (int i = 0; i < array.Length - 1; i++)
            {
                //内层循环n-1-i
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        double temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array.ToArray();
        }

        public static double[] GetSortDESC(double[] array)//数组冒泡排序
        {
            //外层循环n-1
            for (int i = 0; i < array.Length - 1; i++)
            {
                //内层循环n-1-i
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        double temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array.ToArray();
        }



        public static List<Thread> ThreadingPool = new List<Thread>();

        public static object _object = new object();
        public static void ThreadPoolAdd(Thread Task)
        {
            lock (_object)
            {
                tools.ThreadingPool.Add(Task);
            }
        }

        public static void WaitThread()
        {
            int ActiveTreadingCount = 0;
            do
            {
                System.Windows.Forms.Application.DoEvents();
                tools.Delay(100);

                ActiveTreadingCount = 0;
                for (int TreadingCount = 0; TreadingCount < ThreadingPool.Count; TreadingCount++)
                {
                    if (ThreadingPool[TreadingCount] != null && ThreadingPool[TreadingCount].ThreadState != ThreadState.Stopped)
                        ActiveTreadingCount++;
                }
            } while (ActiveTreadingCount > MaxTreadingCount);
        }

        public static int ThreadCount()
        {
            int ActiveTreadingCount = 0;


            for (int i = 0; i < ThreadingPool.Count; i++)
            {
                if (ThreadingPool[i] != null && ThreadingPool[i].ThreadState != ThreadState.Stopped)
                    ActiveTreadingCount++;
            }
            return ActiveTreadingCount;
        }

        public static void ThreadAbort()
        {
            for (int i = 0; i < ThreadingPool.Count; i++)
            {
                if (ThreadingPool[i].ThreadState != ThreadState.Stopped)
                    ThreadingPool[i].Abort();
            }
        }

        public static bool WordMatch(string str1, string str2)
        {
            int flag = 0;
            str1 = str1.Replace(" ", "");
            str2 = str2.Replace(" ", "");
            if (str1.Length == str2.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    if (!str2.Contains(str1[i]))
                    {
                        flag = 1;
                        break;
                    }
                }
                for (int i = 0; i < str2.Length; i++)
                {
                    if (!str1.Contains(str2[i]))
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    return true;
                }
            }
            return false;
        }

      

        public static string ChineseToUnicode(char chr) //c# 中文转unicode
        {
            return "\\u" + ((int)chr).ToString("x");
        }

        public static string UnicodeToChinese(string str) //c# unicode转中文
        {

            Regex reg = new Regex("(\\\\u[0-9a-zA-Z]{4})");
            var mats = reg.Matches(str);
            foreach (Match m in mats)
            {
                string str0 = m.Groups[1].Value;
                string str1 = str0.Substring(2, str0.Length - 2);
                str1 = ((char)int.Parse(str1, System.Globalization.NumberStyles.HexNumber)).ToString();
                str = str.Replace(str0, str1);
            }


            return str;
        }

        public static List<Cookie> GetAllCookies(CookieContainer cc)
        {
            List<Cookie> lstCookies = new List<Cookie>();
            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
                System.Reflection.BindingFlags.Instance, null, cc, new object[] { });
            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                    | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies) lstCookies.Add(c);
            }
            return lstCookies;
        }

        public static void showlog(string str)
        {
            log f = new log();
            f.textBox1.Text = str;
            f.Show();
        }


        //string 写入 txt文件
        public static void WriteTxt(string str)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.txt|*.txt";
            string filename = "";
            if (sfd.ShowDialog() == DialogResult.OK)
                filename = sfd.FileName;
            if (filename.Length == 0)
                return;
            FileStream fs = new FileStream(filename, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(str);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        public static void Writelog(string str)//log写入文件
        {
            //string curPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string filename = @"C:\Users\Administrator\Desktop\log.txt";
            FileStream fs = new FileStream(filename, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(str);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        //延时函数
        public static void Delay(int DelayTime = 100)
        {
            int time = Environment.TickCount;
            while (true)
            {
                if (Environment.TickCount - time >= DelayTime)
                {
                    break;
                }
                Application.DoEvents();
                Thread.Sleep(10);
            }
        }

        // 时间戳转为C#格式时间
        public static DateTime StampToDateTime(string timeStamp)
        {
            DateTime dateTimeStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dateTimeStart.Add(toNow);
        }

        //C#格式时间转为时间戳
        public static string DateTimeToStamp(DateTime dt)
        {
            DateTime dateTimeStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (dt - dateTimeStart).TotalSeconds.ToString(); ;
        }

        //Url解码
        public static string MyUrlDeCode(string str)
        {
            Encoding encoding;

            Encoding utf8 = Encoding.UTF8;
            //首先用utf-8进行解码                    
            string code = HttpUtility.UrlDecode(str.ToUpper(), utf8);
            //将已经解码的字符再次进行编码.
            string encode = HttpUtility.UrlEncode(code, utf8).ToUpper();
            if (str == encode)
                encoding = Encoding.UTF8;
            else
                encoding = Encoding.GetEncoding("gb2312");

            return HttpUtility.UrlDecode(str, encoding);
        }

        //Url编码
        public static string MyUrlEnCode(string str)
        {
            return HttpUtility.UrlEncode(str, System.Text.Encoding.GetEncoding("GB2312")).ToUpper();
        }

        public static string MyUrlEnCode_UTF8(string str)
        {
            return HttpUtility.UrlEncode(str, System.Text.Encoding.UTF8).ToUpper();
        }

        public static CookieContainer cc = new CookieContainer();
        //用于实现CookieContainer的复制操作
        private CookieContainer GetCookieContainerCopy(CookieContainer CC)
        {
            CookieContainer newCC = new CookieContainer();
            newCC.Capacity = cc.Capacity;
            newCC.MaxCookieSize = cc.MaxCookieSize;
            newCC.PerDomainCapacity = cc.PerDomainCapacity;
            newCC.Add(CC.GetCookies(new Uri("http://www.taobao.com")));
            newCC.Add(CC.GetCookies(new Uri("http://www.tmall.com")));

            return newCC;
        }

        //得到webbrowsers的cookie
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref int pcchCookieData, int dwFlags, object lpReserved);

        public static string GetWebBrowsersCookieString(string url)
        {
            // Determine the size of the cookie     
            int datasize = 256;
            StringBuilder cookieData = new StringBuilder(datasize);

            if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, null))
            {
                if (datasize < 0)
                    return null;

                // Allocate stringbuilder large enough to hold the cookie     
                cookieData = new StringBuilder(datasize);
                if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, null))
                    return null;
            }
            return cookieData.ToString();
        }

        public static string CreateWebBrowser(string url)
        {
            Rectangle screen = Screen.PrimaryScreen.Bounds;

            WebBrowser wb = new WebBrowser();
            wb.Width = screen.Width;
            wb.Height = screen.Height;
            wb.ScriptErrorsSuppressed = true;
            wb.ScrollBarsEnabled = true;

            // Console.WriteLine("正在加载页面...");
            wb.Navigate(url);

            //等待页面加载完毕
            while (wb.ReadyState != WebBrowserReadyState.Complete)
            {
                System.Windows.Forms.Application.DoEvents();
            }
            // Console.WriteLine("页面加载完成");

            //计算网页Document的宽和高
            Rectangle body = wb.Document.Body.ScrollRectangle;
            Size size = new Size(body.Width > screen.Width ? body.Width : screen.Width,
                 body.Height > screen.Height ? body.Height : screen.Height);
            wb.Width = size.Width;
            wb.Height = size.Height;
            string html = wb.Document.Body.InnerText;
            return html;
        }
        public static void writeToTxt(DataTable dt,string txtfilename)//写入TXT
        {
            string pathout = "D:\\" + txtfilename + ".txt";
            StreamWriter sw = new StreamWriter(pathout, true);
            for (int rows = 0; rows < dt.Rows.Count;rows++ )
            {
                for (int cols = 0; cols < dt.Columns.Count;cols++ ) 
                {
                    sw.WriteLine(dt.Rows[rows][cols].ToString() + "|");
                }
                sw.WriteLine("\r\n");
            }
            sw.Close();
            sw.Dispose();
        }
        public static void ListToXmlFile1(Type type, Object obj, string filename)
        {
            //Type type = typeof(object);
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                //序列化对象
                xml.Serialize(Stream, obj);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            FileStream fs = new FileStream(filename, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            sw.Write(str);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 过滤表
        /// </summary>
        /// <param name="dt">需要过滤的表</param>
        /// <param name="columName">需要取出的列名称的集合</param>
        /// <param name="sqlStr">过滤御语句</param>
        /// <returns></returns>
        public static DataTable dtFilter(DataTable dt, string[] columName, string sqlStr)
        {
            DataTable dt1 = new DataTable();
            try
            {
                DataRow[] drArr = dt.Select(sqlStr);//查询
                DataTable dtNew = dt.Clone();
                for (int i = 0; i < drArr.Length; i++)
                {
                    dtNew.ImportRow(drArr[i]);
                }
                dt1 = dtNew.DefaultView.ToTable(true, columName);
            }
            catch { return dt1; }
            return dt1;
        }

        public static int ToInt(object obj)
        {
            try
            {
                return int.Parse((string)obj);
            }
            catch
            {
                return 0;
            }
        }

        public static void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush((sender as DataGridView).RowHeadersDefaultCellStyle.ForeColor);
            try
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), (sender as DataGridView).DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
            catch { }
        }
    }
}
