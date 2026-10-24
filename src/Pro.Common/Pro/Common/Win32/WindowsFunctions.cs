using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Pro.Common.Win32;

public static class WindowsFunctions
{
	public delegate bool EnumWindowProc(nint hwnd, nint lParam);

	private const string NtDLL = "ntdll.dll";

	private const string User32DLL = "user32.dll";

	private const string WiniNetDLL = "wininet.dll";

	private const string Kernel32DLL = "kernel32.dll";

	private const string ShCoreDLL = "shcore.dll";

	private const string Shell32DLL = "shell32.dll";

	private const string ShLwApiDLL = "shlwapi.dll";

	private const string Gdi32DLL = "gdi32.dll";

	private const string DbgHelpDLL = "dbghelp.dll";

	private const string ImmDLL = "imm32.dll";

	private const string Msvcrt = "msvcrt.dll";

	[DllImport("ntdll.dll")]
	public static extern NTSTATUS RtlGetVersion(ref OSVERSIONINFOEXW versionInfo);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetWindowRect(nint hWnd, out RECT lpRect);

	[DllImport("user32.dll")]
	public static extern bool SetWindowPos(nint hWnd, nint hWndInsertAfter, int x, int y, int width, int height, SWP uFlags);

	[DllImport("wininet.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetGetConnectedState(out int description, int reservedValue);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCursorPos(ref POINT pt);

	[DllImport("user32.dll")]
	public static extern nint SetCursor(nint hCursor);

	[DllImport("user32.dll")]
	public static extern nint LoadCursor(nint hInstance, nint lpCursorName);

	[DllImport("user32.dll")]
	public static extern nint GetWindowLong(nint hWnd, GWL nIndex);

	[DllImport("user32.dll")]
	public static extern nint SetWindowLong(nint hWnd, GWL nIndex, nint dWNewLong);

	[DllImport("user32.dll")]
	public static extern bool SetCursorPos(int x, int y);

	[DllImport("user32.dll")]
	public static extern bool CreateCaret(nint hWnd, nint hBitmap, int nWidth, int nHeight);

	[DllImport("user32.dll")]
	public static extern bool DestroyCaret();

	[DllImport("user32.dll")]
	public static extern bool SetCaretPos(int x, int y);

	[DllImport("user32.dll")]
	public static extern nint DefWindowProc(nint hWnd, uint uMsg, nint wParam, nint lParam);

	[DllImport("user32.dll")]
	public static extern bool IsZoomed(nint hWnd);

	[DllImport("user32.dll")]
	public static extern nint SetFocus(nint hWnd);

	[DllImport("user32.dll")]
	public static extern int RegisterWindowMessageW([MarshalAs(UnmanagedType.LPWStr)] string message);

	[DllImport("user32.dll")]
	public static extern bool PostMessage(nint hWnd, int msg, nint wParam, nint lParam);

	[DllImport("user32.dll")]
	public static extern bool SendMessage(nint hWnd, int msg, nint wParam, nint lParam);

	[DllImport("user32.dll")]
	public static extern nint SetParent(nint child, nint parent);

	[DllImport("user32.dll")]
	public static extern bool GetWindowPlacement(nint hWnd, out WINDOWPLACEMENT lpwndpl);

	[DllImport("user32.dll")]
	public static extern bool SetWindowPlacement(nint hWnd, ref WINDOWPLACEMENT lpwndpl);

	[DllImport("user32.dll")]
	public static extern nint MonitorFromWindow(nint hWnd, MONITOR dwFlags);

	[DllImport("user32.dll")]
	public static extern nint MonitorFromPoint(POINT pt, MONITOR dwFlags);

	[DllImport("user32.dll")]
	public static extern bool GetMonitorInfoW(nint hMonitor, ref MONITORINFO lpmi);

	[DllImport("shcore.dll")]
	public static extern uint GetDpiForMonitor(nint hMonitor, MDT dpiType, out uint dpiX, out uint dpiY);

	[DllImport("user32.dll")]
	public static extern int GetSystemMetricsForDpi(SM nIndex, uint dpi);

	[DllImport("kernel32.dll")]
	public static extern bool AllocConsole();

	[DllImport("kernel32.dll")]
	public static extern nint GetConsoleWindow();

	[DllImport("user32.dll")]
	public static extern bool ShowWindow(nint hWnd, SW nCmdShow);

	[DllImport("user32.dll")]
	public static extern bool BringWindowToTop(nint hWnd);

	[DllImport("shell32.dll")]
	public static extern SHFILEOPERROR SHFileOperationW(ref SHFILEOPSTRUCT fileOp);

	[DllImport("shell32.dll")]
	public static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, nint hToken, out nint ppszPath);

	[DllImport("shlwapi.dll")]
	public static extern bool PathIsUNCW([MarshalAs(UnmanagedType.LPWStr)] string path);

	[DllImport("gdi32.dll")]
	public static extern bool DeleteObject(nint hObject);

	[DllImport("kernel32.dll")]
	public static extern nint CreateFileMappingW(nint hFile, nint lpfileMappingAttributes, PAGE flProtect, uint dwMaximumSizeHigh, uint dwMaximumSizeLow, [MarshalAs(UnmanagedType.LPWStr)] string lpName);

	[DllImport("kernel32.dll")]
	public static extern nint OpenFileMappingW(FILE_MAP dwDesiredAccess, bool bInheritHandle, [MarshalAs(UnmanagedType.LPWStr)] string lpName);

	[DllImport("kernel32.dll")]
	public static extern nint MapViewOfFile(nint fFileMappingObject, FILE_MAP dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, nint dwNumberOfBytesToMap);

	[DllImport("kernel32.dll")]
	public static extern bool UnmapViewOfFile(nint lpBaseAddress);

	[DllImport("kernel32.dll")]
	public static extern bool CloseHandle(nint hObject);

	[DllImport("kernel32.dll")]
	public static extern LPTOP_LEVEL_EXCEPTION_FILTER SetUnhandledExceptionFilter(LPTOP_LEVEL_EXCEPTION_FILTER lpTopLevelExceptionFilter);

	[DllImport("kernel32.dll")]
	public static extern int GetCurrentThreadId();

	[DllImport("dbghelp.dll")]
	public static extern bool MiniDumpWriteDump(nint hProcess, int processId, SafeFileHandle hFile, MINIDUMP_TYPE dumpType, ref MINIDUMP_EXCEPTION_INFORMATION exception, nint userStream, nint callback);

	[DllImport("shlwapi.dll")]
	public static extern int StrCmpLogicalW([MarshalAs(UnmanagedType.LPWStr)] string lhs, [MarshalAs(UnmanagedType.LPWStr)] string rhs);

	[DllImport("imm32.dll")]
	public static extern nint ImmGetContext(nint hWnd);

	[DllImport("imm32.dll")]
	public static extern bool ImmReleaseContext(nint hWnd, nint hIMC);

	[DllImport("imm32.dll", CharSet = CharSet.Unicode)]
	public static extern uint ImmGetCompositionString(nint hIMC, GCS dwIndex, byte[] lpBuf, uint dwBufLen);

	[DllImport("imm32.dll")]
	public static extern int ImmSetCandidateWindow(nint hIMC, ref CANDIDATEFORM lpCandidateForm);

	[DllImport("user32.dll")]
	public static extern int GetGuiResources(nint hProcess, GR uiFlags);

	[DllImport("shell32.dll", ExactSpelling = true)]
	public static extern void ILFree(nint pidlList);

	[DllImport("shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
	public static extern nint ILCreateFromPathW(string pszPath);

	[DllImport("shell32.dll", ExactSpelling = true)]
	public static extern int SHOpenFolderAndSelectItems(nint pidlList, uint cild, nint children, uint dwFlags);

	[DllImport("shell32.dll")]
	public static extern nint SHGetFileInfoW([MarshalAs(UnmanagedType.LPWStr)] string pszPath, FILE_ATTRIBUTE dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, SHGFI uFlags);

	[DllImport("user32.dll")]
	public static extern bool DestroyIcon(nint hIcon);

	[DllImport("shell32.dll")]
	public static extern nint SHAppBarMessage(ABM dwMessage, ref APPBARDATA pData);

	[DllImport("user32.dll")]
	public static extern nint SetWindowsHookExW(WH idHook, HOOKPROC lpfn, nint hMod, int dwThreadID);

	[DllImport("user32.dll")]
	public static extern bool UnhookWindowsHookEx(nint hHook);

	[DllImport("user32.dll")]
	public static extern nint CallNextHookEx(nint hook, int code, nint wParam, nint lParam);

	[DllImport("kernel32.dll")]
	public static extern void SetLastError(uint dwLastError);

	[DllImport("user32.dll")]
	public static extern nint GetActiveWindow();

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumWindows(EnumWindowProc callback, nint lParam);
}
