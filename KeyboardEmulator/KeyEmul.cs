using System;
using System.Runtime.InteropServices;
using System.Drawing;

//////
/// var hWnd = procFinder.ScanPrcesses("PotPlayer");
/// new KeyEmul().PostClick(hWnd);

namespace KeyboardEmulator
{
    public class KeyEmul
    {
        [DllImport("user32.dll")]
        private static extern bool PostMessage(
           IntPtr hWnd, // handle to destination window
           UInt32 Msg, // message
           Int32 wParam, // first message parameter
           Int32 lParam // second message parameter
       );
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string className, string windowName);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        

        public void PostClick(IntPtr hWnd, Point pt)
        {
            PostMessage(hWnd, (UInt32)WM.LBUTTONDOWN, 1, ((pt.X << 16) | (pt.Y & 0xFFFF)));
            PostMessage(hWnd, (UInt32)WM.LBUTTONUP, 1, ((pt.X << 16) | (pt.Y & 0xFFFF)));
        }
        public void PostClick(IntPtr hWnd, Int32 key)
        {            
            PostMessage(hWnd, (UInt32)WM.KEYDOWN, key, 0);
            PostMessage(hWnd, (UInt32)WM.KEYUP, key, 0);
        }

        public void PostDownButton(IntPtr hWnd, Int32 key)
        {
            PostMessage(hWnd, (UInt32)WM.KEYDOWN, key, 0);            
        }
        public void PostUpButton(IntPtr hWnd, Int32 key)
        {            
            PostMessage(hWnd, (UInt32)WM.KEYUP, key, 0);
        }
    }
}