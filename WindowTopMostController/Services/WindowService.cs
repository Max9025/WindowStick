using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using WindowTopMostController.Infrastructure;
using WindowTopMostController.Models;
using static WindowTopMostController.Infrastructure.WinApiWrapper;


namespace WindowTopMostController.Services
{
    public class WindowService
    {
        private readonly HashSet<IntPtr> _topMostWindows = new HashSet<IntPtr>();

        public List<WindowInfo> GetWindows()
        {
            List<WindowInfo> windows = new List<WindowInfo>();

            WinApiWrapper.EnumWindows((hWnd, lParam) =>
            {
                if (!WinApiWrapper.IsWindowVisible(hWnd))
                    return true;

                int length = WinApiWrapper.GetWindowTextLength(hWnd);
                if (length < 2)
                    return true;

                StringBuilder sd = new StringBuilder(length + 1);
                WinApiWrapper.GetWindowText(hWnd, sd, sd.Capacity);

                string title = sd.ToString();

                if (title.Contains("WindowTopMostController"))
                    return true;

                windows.Add(new WindowInfo(hWnd, title));
                return true;
            }, IntPtr.Zero);

            return windows;
        }

        public void SetTopMost(WindowInfo window, bool topMost)
        {
            if (window == null)
                return;

            WinApiWrapper.SetWindowPos(
                window.Handle,
                topMost ? WinApiWrapper.HWND_TOPMOST : WinApiWrapper.HWND_NOTOPMOST,
                0, 0, 0, 0,
                WinApiWrapper.SWP_NOMOVE | WinApiWrapper.SWP_NOSIZE);

            if (topMost)
                _topMostWindows.Add(window.Handle);
            else
                _topMostWindows.Remove(window.Handle);
        }

        public bool IsTopMost(WindowInfo window)
        {
            if (window == null)
                return false;

            return _topMostWindows.Contains(window.Handle);
        }

        public void ResetAllTopMost()
        {
            EnumWindows((hWnd, lParam) =>
            {
                if (!IsWindow(hWnd)) return true;

                SetWindowPos(hWnd, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
                return true;
            }, IntPtr.Zero);
        }
    }
}
