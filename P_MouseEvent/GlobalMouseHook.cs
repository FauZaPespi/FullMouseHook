using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

public class GlobalMouseHook
{
    /**
     * @author FauZaPespi
     * @date 13.11.2024
     * @detail Help to hook mouse 
     */

    // Define constants for hook type and mouse events
    private const int WH_MOUSE_LL = 14;
    private const int WM_LBUTTONDOWN = 0x0201;
    private const int WM_LBUTTONUP = 0x0202;
    private const int WM_RBUTTONDOWN = 0x0204;
    private const int WM_RBUTTONUP = 0x0205;

    private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
    private const int MOUSEEVENTF_LEFTUP = 0x0004;
    private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
    private const int MOUSEEVENTF_RIGHTUP = 0x0010;
    private const int VK_LBUTTON = 0x01;
    private const int VK_RBUTTON = 0x02;

    // Declare hook ID, hook procedure delegate, and button states
    private IntPtr _hookID = IntPtr.Zero;
    private LowLevelMouseProc _proc;
    private bool isLeftButtonHeld = false;
    private bool isRightButtonHeld = false;

    public GlobalMouseHook()
    {
        _proc = HookCallback;
        SetHook();
    }

    private void SetHook()
    {
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule)
        {
            _hookID = SetWindowsHookEx(WH_MOUSE_LL, _proc, GetModuleHandle(curModule.ModuleName), 0);
        }
    }

    public void Unhook()
    {
        UnhookWindowsHookEx(_hookID);
    }

    private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0)
        {
            MSLLHOOKSTRUCT hookStruct = Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam);
            Point cursorPosition = new Point(hookStruct.pt.x, hookStruct.pt.y);

            if (wParam == (IntPtr)WM_LBUTTONDOWN)
            {
                isLeftButtonHeld = true;
                OnGlobalMouseClick("LeftDown", cursorPosition);
            }
            else if (wParam == (IntPtr)WM_LBUTTONUP)
            {
                isLeftButtonHeld = false;
                OnGlobalMouseClick("LeftUp", cursorPosition);
            }
            else if (wParam == (IntPtr)WM_RBUTTONDOWN)
            {
                isRightButtonHeld = true;
                OnGlobalMouseClick("RightDown", cursorPosition);
            }
            else if (wParam == (IntPtr)WM_RBUTTONUP)
            {
                isRightButtonHeld = false;
                OnGlobalMouseClick("RightUp", cursorPosition);
            }
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }

    public event Action<string, Point> GlobalMouseClick;

    protected virtual void OnGlobalMouseClick(string button, Point position)
    {
        GlobalMouseClick?.Invoke(button, position);
    }

    [DllImport("user32.dll")]
    private static extern short GetAsyncKeyState(int vKey);

    public bool IsLeftDown()
    {
        return (GetAsyncKeyState(VK_LBUTTON) & 0x8000) != 0;
    }

    public bool IsRightDown()
    {
        return (GetAsyncKeyState(VK_RBUTTON) & 0x8000) != 0;
    }

    // Check if the left button is continuously held down
    public bool IsKeepingLeftDown()
    {
        return isLeftButtonHeld;
    }

    // Check if the right button is continuously held down
    public bool IsKeepingRightDown()
    {
        return isRightButtonHeld;
    }

    // Methods to simulate mouse button actions
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);

    public void SendLeftDown()
    {
        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
    }

    public void SendLeftUp()
    {
        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero);
    }

    public void SendRightDown()
    {
        mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, IntPtr.Zero);
    }

    public void SendRightUp()
    {
        mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, IntPtr.Zero);
    }

    // Windows API functions
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

    [StructLayout(LayoutKind.Sequential)]
    private struct POINT
    {
        public int x;
        public int y;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct MSLLHOOKSTRUCT
    {
        public POINT pt;
        public uint mouseData;
        public uint flags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
}
