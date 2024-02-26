using System;
using System.Runtime.InteropServices;
using UnityEngine;


public static class WindowPosition
{
    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
    
    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    const int SWP_NOSIZE = 0x0001;

    const int SWP_NOZORDER = 0x0004;

    const int HWND_TOP = 0;

    public static void SetWindowPosition(int x, int y)
    {
        
        SetWindowActive();
        IntPtr windowPtr = GetActiveWindow();
        SetWindowPos(windowPtr, new IntPtr(HWND_TOP), x, y, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
    }

    public static void SetWindowActive()
    {
        var windowHandle = GetForegroundWindow();
        if (windowHandle != IntPtr.Zero)
        {
            Debug.LogWarning("Active Window do not correspond to foreground");
            // Bring the Unity window to the foreground
            SetForegroundWindow(windowHandle);
        }
    }
}