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
using System.Reflection;
using System.IO;


namespace UTCRM
{
    class keqq
    {
        public List<KeQQPlan> GetKeQQPlan(string qq, string bkn)
        {
            string url = "http://ke.qq.com/cgi-bin/user/user_center/get_plan_detail?cid=57050&uin=" + qq + "&bkn=" + bkn + "&r=" + rand();
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = url,
                Referer = "http://ke.qq.com/user/tasks/index.html?cid=57050&tid=100079090",
                Cookie = frmMain.CK
            };
            HttpResult result = http.GetHtml(item);
            string htmlText = result.Html;
            List<KeQQPlan> lstkp = new List<KeQQPlan>();

            Regex reg = new Regex("(task_list\":\\[{.*?}\\])");
            var mats = reg.Matches(htmlText);

            foreach (Match m in mats)
            {
                string mstr = m.Groups[1].Value;
                //MessageBox.Show(mstr);
                KeQQPlan kp = new KeQQPlan();

                reg = new Regex("endtime\":(.*?),");
                kp.SubjectEndTime = tools.StampToDateTime(reg.Match(mstr).Groups[1].Value);//结束时间

                reg = new Regex("bgtime\":(.*?),");
                kp.SubjectBeginTime = tools.StampToDateTime(reg.Match(mstr).Groups[1].Value);//开始时间

                reg = new Regex("name\":\"(.*?)\",");
                kp.SubjectName = reg.Match(mstr).Groups[1].Value;//课程名称

                // MessageBox.Show("kp.SubjectName=" + kp.SubjectName + "    kp.SubjectBeginTime=" + kp.SubjectBeginTime + "   kp.SubjectEndTime=" + kp.SubjectEndTime + "\n");

                lstkp.Add(kp);
            }

            return lstkp;
        }

        public string rand()
        {
            Type obj = Type.GetTypeFromProgID("ScriptControl");
            if (obj == null) return "";
            object ScriptControl = Activator.CreateInstance(obj);
            obj.InvokeMember("Language", BindingFlags.SetProperty, null, ScriptControl, new object[] { "JScript" });
            string js = "function random(){return Math.random()}";
            obj.InvokeMember("AddCode", BindingFlags.InvokeMethod, null, ScriptControl, new object[] { js });
            string str = obj.InvokeMember("Eval", BindingFlags.InvokeMethod, null, ScriptControl, new object[] { "random()" }).ToString();
            return str;
        }

        public int GetKePid(string title)
        {
            int pid = process.GetPidByTitle(title);
            if (pid <= 0)
            {
                MessageBox.Show("监控【" + title + "】失败，可能该目标已关闭或不是腾讯课堂窗体");
                return 0;
            }
            return pid;
        }

        public string GetKeQQ_1(int pid)
        {
            string str = "";
            uint qq = 0;
            int baseAddress = (int)process.GetDllBaseAddress(pid, "GF.dll");//模块基址的地址
            int _endi, _menp;
            baseAddress = baseAddress + 0x16EA48;//2017年9月2日（0x171ad8;） 旧： 0x16EA48
            _endi = process.ReadMemoryValue(baseAddress + 0x6, pid);
            _endi = _endi & 0xFFFF;
            for (var i = 1; i < _endi; i++)
            {
                _menp = process.ReadMemoryValue(baseAddress + i * 0x4 + 4, pid);
                if (process.ReadMemoryValue(_menp + 0x74, pid) == 69 && process.ReadMemoryValue(_menp + 0x78, pid) == 238)
                {
                    int[] _uidAdd = new int[2];
                    baseAddress = process.ReadMemoryValue(_menp + 0x2F4, pid); //2017年9月2日（0x2C4;）旧： 0x2F4
                    baseAddress = process.ReadMemoryValue(baseAddress + 0xC, pid);
                    _uidAdd[0] = process.ReadMemoryValue(baseAddress + 0xCC, pid);
                    _uidAdd[1] = process.ReadMemoryValue(baseAddress + 0xD0, pid);
                    while (_uidAdd[0] < _uidAdd[1])
                    {
                        qq = (uint)process.ReadMemoryValue(_uidAdd[0], pid);
                        _uidAdd[0] = _uidAdd[0] + 0x28;
                        str += qq + "\t";
                    }
                }
            }
            return str;
        }

        public string GetKeQQ_2(int pid)//2017年9月7日
        {
            string str = "";
            uint qq = 0;
            int baseAddress = (int)process.GetDllBaseAddress(pid, "GF.dll");//模块基址的地址
            int _endi, _menp;
            baseAddress = baseAddress + 0x170AE0;//2017年9月2日（0x171ad8;） 旧： 0x16EA48
            _endi = process.ReadMemoryValue(baseAddress + 0x6, pid);
            _endi = _endi & 0xFFFF;
            for (var i = 1; i < _endi; i++)
            {
                _menp = process.ReadMemoryValue(baseAddress + i * 0x4 + 4, pid);
                if (process.ReadMemoryValue(_menp + 0x74, pid) == 69 && process.ReadMemoryValue(_menp + 0x78, pid) == 238)
                {
                    int[] _uidAdd = new int[2];
                    baseAddress = process.ReadMemoryValue(_menp + 0x2C4, pid); //2017年9月2日（0x2C4;）旧： 0x2F4
                    baseAddress = process.ReadMemoryValue(baseAddress + 0xC, pid);
                    _uidAdd[0] = process.ReadMemoryValue(baseAddress + 0xCC, pid);
                    _uidAdd[1] = process.ReadMemoryValue(baseAddress + 0xD0, pid);
                    while (_uidAdd[0] < _uidAdd[1])
                    {
                        qq = (uint)process.ReadMemoryValue(_uidAdd[0], pid);
                        _uidAdd[0] = _uidAdd[0] + 0x28;
                        str += qq + "\t";
                    }
                }
            }
            return str;

            //string str = "";
            //uint qq = 0;
            //int baseAddress = (int)process.GetDllBaseAddress(pid, "GF.dll");//模块基址的地址
            //baseAddress = process.ReadMemoryValue(baseAddress + 0x17114C, pid);
            //baseAddress = process.ReadMemoryValue(baseAddress + 0x2C4, pid);
            //baseAddress = process.ReadMemoryValue(baseAddress + 0xC, pid);

            //baseAddress = process.ReadMemoryValue(baseAddress + 0x28, pid);
            //qq = (uint)process.ReadMemoryValue(baseAddress, pid);
            //while (qq != 0)
            //{
            //    str += qq + "\t";
            //    baseAddress = process.ReadMemoryValue(baseAddress + 0x28, pid);
            //    qq = (uint)process.ReadMemoryValue(baseAddress, pid);
            //}
            //return str;
        }

        public string GetKeQQ_3(int pid)//2017年9月2日
        {
            string str = "";
            uint qq = 0;
            int baseAddress = (int)process.GetDllBaseAddress(pid, "GF.dll");//模块基址的地址
            int _endi, _menp;
            baseAddress = baseAddress + 0x171ad8;//2017年9月2日（0x171ad8;） 旧： 0x16EA48
            _endi = process.ReadMemoryValue(baseAddress + 0x6, pid);
            _endi = _endi & 0xFFFF;
            for (var i = 1; i < _endi; i++)
            {
                _menp = process.ReadMemoryValue(baseAddress + i * 0x4 + 4, pid);
                if (process.ReadMemoryValue(_menp + 0x74, pid) == 69 && process.ReadMemoryValue(_menp + 0x78, pid) == 238)
                {
                    int[] _uidAdd = new int[2];
                    baseAddress = process.ReadMemoryValue(_menp + 0x2C4, pid); //2017年9月2日（0x2C4;）旧： 0x2F4
                    baseAddress = process.ReadMemoryValue(baseAddress + 0xC, pid);
                    _uidAdd[0] = process.ReadMemoryValue(baseAddress + 0xCC, pid);
                    _uidAdd[1] = process.ReadMemoryValue(baseAddress + 0xD0, pid);
                    while (_uidAdd[0] < _uidAdd[1])
                    {
                        qq = (uint)process.ReadMemoryValue(_uidAdd[0], pid);
                        _uidAdd[0] = _uidAdd[0] + 0x28;
                        str += qq + "\t";
                    }
                }
            }
            return str;
        }

        public string ChatRecord()
        {
            int length = 0x1000;
            int loop=32;
            byte[] chatbytes;
            string str = "";
            string result = "";
            int pid = frmMain.pid;
            int baseAddress = (int)process.GetDllBaseAddress(pid, "RICHED20.dll");//模块基址
            //MessageBox.Show("baseAddress=" + Convert.ToString(baseAddress, 16));

            baseAddress = baseAddress + 0x000DA994;
            baseAddress = process.ReadMemoryValue(baseAddress, pid);
            //MessageBox.Show("baseAddress=" + Convert.ToString(baseAddress, 16));

            baseAddress = baseAddress + 0x500;
            baseAddress = process.ReadMemoryValue(baseAddress, pid) + 0x3E8;
            int[] baseAdr = { 0x3E8, 0x17220CA2, 0x11BA3964 };//偏移地址数组
            for (int j = 0; j < baseAdr.Length; j++)
            {
                int data_baseAddress = (baseAddress+ baseAdr[j])/ 0x10000 * 0x10000;
                // MessageBox.Show("begin baseAddress=" + Convert.ToString(baseAddress, 16));//13476D4A

                for (int i = 0; i < loop; i++)
                {
                    //int data_baseAddress = baseAddress + 0x3E8 + length*i;
                    data_baseAddress += length;
                    //MessageBox.Show("baseAddress=" + Convert.ToString(data_baseAddress, 16));
                    chatbytes = process.ReadMemoryValue(data_baseAddress, pid, length);

                    str = ToHexString(chatbytes);
                    //tools.showlog(str);

                    Regex reg = new Regex("(FCFF.*?0D00FCFF.*?0D00FCFF)");

                    var mats = reg.Matches(str);
                    foreach (Match m in mats)
                    {
                        string chatstr = m.Groups[1].Value;
                        if (chatstr.Contains("0D000D00"))//chatstr.Contains("FCFFFCFF") ||
                            continue;
                        //if (chatstr.Contains("0c8079720f613a4ea48b0c543a4ea48b0c54f456d57e2a5933963a4ea48b0c54".ToUpper()))
                        //    MessageBox.Show(chatstr);
                        if (chatstr.Length > 1000)
                            continue;
                        reg = new Regex("FCFF(.*?)0D00FCFF");
                        string name = reg.Match(chatstr).Groups[1].Value;
                        if (name.Length == 0 || name.Length % 4 != 0 || name.Contains("FCFFFCFF"))
                            continue;
                        name = HexStringToString(name);
                        reg = new Regex("0D00FCFF(.*?)0D00FCFF");
                        string words = reg.Match(chatstr).Groups[1].Value;
                        if (words.Length == 0 || words.Length % 4 != 0 || words.Contains("FCFFFCFF"))
                            continue;
                        words = HexStringToString(words);
                        result += name + "|" + words + "\t";
                    }
                    data_baseAddress -= 512;
                }
                // MessageBox.Show("end data_baseAddress=" + Convert.ToString(data_baseAddress, 16));
            }

            return result;
        }

        public static string HexStringToString(string str0)
        {
            string str = "";//4e00-9fbb
            for (int i = 0; i < str0.Length; i++)
            {
                if (i % 4 == 0)
                {
                    string tmp = str0.Substring(i, 4);
                    if (tmp == "FCFF")//去掉图标，表情
                        continue;
                    tmp = tmp.Substring(2, 2) + tmp.Substring(0, 2);
                    char c = (char)Convert.ToInt32(tmp, 16);
                    if( (int) c>255 &&( (int) c<0x4e00 || (int) c>0x9fbb) )//不是ASCII,不是汉字
                    {
                        str="";
                        break;
                    }
                    str += (char)Convert.ToInt32(tmp, 16);
                }
            }

            return str.ToUpper();
        }

        public static string StringToHexString(string str0)
        {
            string str = "";
            for (int i = 0; i < str0.Length; i++)
            {
                int a = (int)str0[i];
                string s = Convert.ToString(a, 16);
                if (a <= 255)
                    s = s + "00";
                s = s.Substring(2, 2) + s.Substring(0, 2);
                str += s;
            }
            return str;
        }

        public static char byteToChar(byte[] b)
        {
            char c = (char)(((b[0] & 0xFF) << 8) | (b[1] & 0xFF));
            return c;
        }

        public static string ToHexString(byte[] bytes) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;

            if (bytes != null)
            {

                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {

                    strB.Append(bytes[i].ToString("X2"));

                }

                hexString = strB.ToString();

            } return hexString;

        }

        public static byte[] GetBytes(string hexString, out int discarded)
        {
            discarded = 0;
            string newString = "";
            char c;
            // remove all none A-F, 0-9, characters
            for (int i = 0; i < hexString.Length; i++)
            {
                c = hexString[i];
                if (Uri.IsHexDigit(c))
                    newString += c;
                else
                    discarded++;
            }
            // if odd number of characters, discard last character
            if (newString.Length % 2 != 0)
            {
                discarded++;
                newString = newString.Substring(0, newString.Length - 1);
            }

            return HexToByte(newString);
        }

        public static byte[] HexToByte(string hexString)
        {
            if (string.IsNullOrEmpty(hexString))
            {
                hexString = "00";
            }
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }
    }
}
