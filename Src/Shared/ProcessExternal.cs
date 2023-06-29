using System.Runtime.InteropServices;
using System.Text;

namespace Shared
{
    public static class ProcessExternal
    {
        [DllImport("USER32.DLL")]
        public static extern void SetWindowText(IntPtr hWnd, string text);

        [DllImport("USER32.DLL")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("USER32.DLL")]
        public static extern IntPtr GetShellWindow();

        [DllImport("USER32.DLL")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("USER32.DLL", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("USER32.DLL")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        public static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        public static IDictionary<IntPtr, string> GetOpenWindowsFromPID(int processID)
        {
            dictWindows.Clear();
            currentProcessID = processID;
            EnumWindows(new EnumWindowsProc(EnumWindowsInternal), 0);
            return dictWindows;
        }

        public static bool EnumWindowsInternal(IntPtr hWnd, int lParam)
        {
            bool flag = hWnd != hShellWindow;
            if (flag)
            {
                bool flag2 = !IsWindowVisible(hWnd);
                if (flag2)
                {
                    return true;
                }
                int windowTextLength = GetWindowTextLength(hWnd);
                bool flag3 = windowTextLength == 0;
                if (flag3)
                {
                    return true;
                }
                uint num;
                GetWindowThreadProcessId(hWnd, out num);
                bool flag4 = (ulong)num != (ulong)((long)currentProcessID);
                if (flag4)
                {
                    return true;
                }
                StringBuilder stringBuilder = new StringBuilder(windowTextLength);
                GetWindowText(hWnd, stringBuilder, checked(windowTextLength + 1));
                dictWindows.Add(hWnd, stringBuilder.ToString());
            }
            return true;
        }

        public static IntPtr hShellWindow = GetShellWindow();
        public static Dictionary<IntPtr, string> dictWindows = new Dictionary<IntPtr, string>();
        public static int currentProcessID;

        public delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);
        public delegate bool CallbackDef(int hWnd, int lParam);
    }
}
