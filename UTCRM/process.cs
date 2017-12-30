using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UTCRM
{
    public abstract class process
    {
        #region API

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory
            (
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            IntPtr lpBuffer,
            int nSize,
            IntPtr lpNumberOfBytesRead
            );

        [DllImportAttribute("kernel32.dll")]
        public static extern bool WriteProcessMemory
            (
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            int[] lpBuffer,
            int nSize,
            IntPtr lpNumberOfBytesWritten
            );

        [DllImportAttribute("kernel32.dll")]
        public static extern IntPtr OpenProcess
            (
            int dwDesiredAccess,
            bool bInheritHandle,
            int dwProcessId
            );

        [DllImport("kernel32.dll")]
        public static extern void CloseHandle
            (
            IntPtr hObject
            );

        #endregion

        #region 方法

        /// <summary>
        /// 根据窗口标题获取PID
        /// </summary>
        /// <param name="windowTitle">窗口标题</param>
        /// <returns></returns>
        public static int GetPidByTitle(string windowTitle)
        {
            int rs = -1;
            Process[] arrayProcess = Process.GetProcesses();
            string tmpstr = "";
            foreach (Process p in arrayProcess)
            {
                //string str = Encoding.Unicode.GetString(Encoding.Unicode.GetBytes(p.MainWindowTitle));
                string str = p.MainWindowTitle;
                tmpstr += str + "\t";
                if (str==windowTitle)
                {
                    rs = p.Id;
                    frmMain.Subject = str;
                    break;
                }
            }

            return rs;
        }

        /// <summary>
        /// 根据进程名获取PID
        /// </summary>
        /// <param name="processName">进程名字</param>
        /// <returns></returns>
        public static int GetPidByProcessName(string processName)
        {
            Process[] arrayProcess = Process.GetProcesses();
            foreach (Process p in arrayProcess)
            {
                if (p.ProcessName == processName)
                {
                    return p.Id;
                }
            }
            return 0;
        }

        /// <summary>
        /// 根据窗口标题查找窗口句柄
        /// </summary>
        /// <param name="title">窗口标题</param>
        /// <returns></returns>
        public static IntPtr FindWindow(string title)
        {
            Process[] ps = Process.GetProcesses();
            foreach (Process p in ps)
            {
                if (p.MainWindowTitle.Contains(title))
                {
                    return p.MainWindowHandle;
                }
            }
            return IntPtr.Zero;
        }

        /// <summary>
        /// 获取窗口标题
        /// </summary>
        /// <returns></returns>
        public static string FindWindowTitle()
        {
            string titles = "";
            Process[] ps = Process.GetProcesses();
            foreach (Process p in ps)
            {
                titles += p.MainWindowTitle + "\t";
            }
            return titles;
        }

        /// <summary>
        /// 读取内存中的值
        /// </summary>
        /// <param name="baseAddress">地址</param>
        /// <param name="processName">进程名</param>
        /// <returns></returns>
        public static int ReadMemoryValue(int baseAddress, string processName)
        {
            try
            {
                var buffer = new byte[4];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0); //获取缓冲区地址
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, GetPidByProcessName(processName));
                ReadProcessMemory(hProcess, (IntPtr)baseAddress, byteAddress, 4, IntPtr.Zero); //将制定内存中的值读入缓冲区
                CloseHandle(hProcess);
                return Marshal.ReadInt32(byteAddress);
            }
            catch
            {
                return 0;
            }
        }

        public static int ReadMemoryValue(int baseAddress, int processid)
        {
            try
            {
                var buffer = new byte[4];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0); //获取缓冲区地址
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, processid);
                ReadProcessMemory(hProcess, (IntPtr)baseAddress, byteAddress, 4, IntPtr.Zero); //将制定内存中的值读入缓冲区
                CloseHandle(hProcess);
                return Marshal.ReadInt32(byteAddress);
            }
            catch
            {
                return 0;
            }
        }

        public static byte[] ReadMemoryValue(int baseAddress, int processid,int length)
        {
            byte[] buffer = new byte[length];
            try
            {
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0); //获取缓冲区地址
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, processid);
                ReadProcessMemory(hProcess, (IntPtr)baseAddress, byteAddress, length, IntPtr.Zero); //将指定内存中的值读入缓冲区
                CloseHandle(hProcess);

                return buffer;
            }
            catch
            {
                return buffer;
            }
        }

        /// <summary>
        /// 将值写入指定内存地址中
        /// </summary>
        /// <param name="baseAddress">地址</param>
        /// <param name="processName">进程名</param>
        /// <param name="value"></param>
        public static void WriteMemoryValue(int baseAddress, string processName, int value)
        {
            IntPtr hProcess = OpenProcess(0x1F0FFF, false, GetPidByProcessName(processName)); //0x1F0FFF 最高权限
            WriteProcessMemory(hProcess, (IntPtr)baseAddress, new[] { value }, 4, IntPtr.Zero);
            CloseHandle(hProcess);
        }

        #endregion

        [DllImport("KERNEL32.DLL ")]
        public static extern IntPtr CreateToolhelp32Snapshot(uint flags, uint processid);
        [DllImport("KERNEL32.DLL ")]
        public static extern int Module32First(IntPtr handle, ref   MODULEENTRY32 pe);
        [DllImport("KERNEL32.DLL ")]
        public static extern int Module32Next(IntPtr handle, ref   MODULEENTRY32 pe);

        public static IntPtr GetDllBaseAddress(int pid, string Module)
        {
            pid = GetPidByProcessName("QQ");

            IntPtr handle = CreateToolhelp32Snapshot(0x00000008, (uint)pid);  //TH32CS_SNAPMODULE=0x00000008 ProcessEntry32 TH32CS_SNAPMODULE
            List<MODULEENTRY32> list = new List<MODULEENTRY32>();

            if ((int)handle <= 0)//INVALID_HANDLE_VALUE =-1
            {
                MessageBox.Show("进程" + pid + "快照失败");
                return (IntPtr)0;
            }
            MODULEENTRY32 pe32 = new MODULEENTRY32();
            pe32.dwSize = (int)Marshal.SizeOf(pe32);
            int bMore = Module32First(handle, ref pe32);
            if (bMore <= 0)
            {
                MessageBox.Show("第一次打开快照失败，返回值=" + bMore + " pe32.dwSize=" + pe32.dwSize);
                return (IntPtr)0;
            }
            while (bMore == 1)
            {
                IntPtr temp = Marshal.AllocHGlobal((int)pe32.dwSize);
                Marshal.StructureToPtr(pe32, temp, true);
                MODULEENTRY32 pe = (MODULEENTRY32)Marshal.PtrToStructure(temp, typeof(MODULEENTRY32));
                Marshal.FreeHGlobal(temp);
                list.Add(pe);
                bMore = Module32Next(handle, ref pe32);
            }
            CloseHandle(handle);

            foreach (MODULEENTRY32 p in list)
            {
                string st = Encoding.Default.GetString(Encoding.UTF32.GetBytes(p.szModule));
                st = st.Replace("\0", "");
                if (st.Contains(Module))
                    return p.hModule;
            }
            return (IntPtr)0;
        }

        #region MODULEENTRY32

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct MODULEENTRY32
        {
            public int dwSize;
            public int th32ModuleID;
            public int th32ProcessID;
            public int GlblcntUsage;
            public int ProccntUsage;
            public byte modBaseAddr;
            public int modBaseSize;
            public IntPtr hModule;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szModule;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExePath;
        }

        #endregion
    }


}
