using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Pro.Common.Logging;
using Pro.Common.Win32;

namespace Pro.Reporting;

public static class Dreamcatcher
{
	private const MINIDUMP_TYPE SmallMinidumpType = MINIDUMP_TYPE.WithIndirectlyReferencedMemory | MINIDUMP_TYPE.WithThreadInfo;

	private const MINIDUMP_TYPE FullMinidumpType = MINIDUMP_TYPE.WithFullMemory;

	private static readonly object _wakingLock;

	private static volatile bool _isWaking;

	private static volatile Thread? _wakingThread;

	private static readonly LPTOP_LEVEL_EXCEPTION_FILTER _unhandledCB;

	private static readonly string[] StackLinesToTrimOff;

	public static bool CreateFullDumps { get; set; }

	public static string LastLogFileName { get; set; }

	public static event Action<Crash>? WakeUp;

	static Dreamcatcher()
	{
		_wakingLock = new object();
		_isWaking = false;
		_wakingThread = null;
		CreateFullDumps = false;
		LastLogFileName = string.Empty;
		StackLinesToTrimOff = new string[3] { "System.Environment.GetStackTrace(", "System.Environment.get_StackTrace(", "Pro.Reporting.Dreamcatcher." };
		AppDomain.CurrentDomain.UnhandledException += delegate(object s, UnhandledExceptionEventArgs e)
		{
			OnUnhandledException(e.ExceptionObject as Exception, IntPtr.Zero);
		};
		_unhandledCB = delegate(nint exceptionInfo)
		{
			OnUnhandledException(null, exceptionInfo);
			return EXCEPTION_MODE.EXECUTE_HANDLER;
		};
		WindowsFunctions.SetUnhandledExceptionFilter(_unhandledCB);
	}

	private static bool ShouldTrimOffStackLine(string line)
	{
		return Array.Exists(StackLinesToTrimOff, line.Contains);
	}

	private static string TrimOffStackString(string stackString)
	{
		if (string.IsNullOrEmpty(stackString))
		{
			return string.Empty;
		}
		string[] array = stackString.Split('\n');
		int i;
		for (i = 0; i < array.Length && ShouldTrimOffStackLine(array[i]); i++)
		{
		}
		return string.Join("\n", array, i, array.Length - i);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ReportUnhandledException(Exception exception)
	{
		OnUnhandledException(exception, IntPtr.Zero);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnUnhandledException(Exception? exception, nint exceptionInfo)
	{
		bool flag = false;
		lock (_wakingLock)
		{
			if (!_isWaking)
			{
				_isWaking = true;
				_wakingThread = Thread.CurrentThread;
			}
			else
			{
				flag = true;
			}
		}
		if (flag)
		{
			_wakingThread?.Join();
			Thread.Sleep(-1);
			return;
		}
		if (exceptionInfo == IntPtr.Zero)
		{
			exceptionInfo = Marshal.GetExceptionPointers();
		}
		if ((exception == null || exception is SEHException) ? true : false)
		{
			exception = new UnmanagedException(exceptionInfo, exception);
		}
		try
		{
			Log.FatalError(exception.ToString());
			WriteHandleCountsToLog();
			Stargazer.GetAppInfo(out string reportRootPath, out string _, out string appName);
			string reportName = Stargazer.GetReportName(appName);
			string text = Path.Combine(reportRootPath, reportName + ".crash");
			string text2 = Path.Combine(reportRootPath, reportName + ".mdmp");
			string text3 = Path.Combine(reportRootPath, reportName + ".log");
			WriteCrashLogExtraction(text3);
			WriteCrashDumpFile(exception, text);
			Process currentProcess = Process.GetCurrentProcess();
			WriteMinidumpFile(exceptionInfo, text2, currentProcess);
			Dreamcatcher.WakeUp?.Invoke(new Crash(exception, text, text2, text3));
		}
		catch (Exception)
		{
		}
	}

	private static void WriteCrashLogExtraction(string reportLog)
	{
		try
		{
			if (string.IsNullOrEmpty(LastLogFileName) || !File.Exists(LastLogFileName))
			{
				return;
			}
			using FileStream fileStream = new FileStream(LastLogFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			fileStream.Seek(-81920L, SeekOrigin.End);
			using FileStream destination = new FileStream(reportLog, FileMode.Create, FileAccess.Write, FileShare.None);
			fileStream.CopyTo(destination);
		}
		catch (Exception)
		{
		}
	}

	private static void WriteMinidumpFile(nint exceptionInfo, string reportDump, Process process)
	{
		try
		{
			using FileStream fileStream = new FileStream(reportDump, FileMode.Create);
			MINIDUMP_EXCEPTION_INFORMATION mINIDUMP_EXCEPTION_INFORMATION = default(MINIDUMP_EXCEPTION_INFORMATION);
			mINIDUMP_EXCEPTION_INFORMATION.ThreadID = WindowsFunctions.GetCurrentThreadId();
			mINIDUMP_EXCEPTION_INFORMATION.ExceptionInfo = exceptionInfo;
			mINIDUMP_EXCEPTION_INFORMATION.ClientPointers = false;
			MINIDUMP_EXCEPTION_INFORMATION exception = mINIDUMP_EXCEPTION_INFORMATION;
			if (!WindowsFunctions.MiniDumpWriteDump(process.Handle, process.Id, fileStream.SafeFileHandle, CreateFullDumps ? MINIDUMP_TYPE.WithFullMemory : (MINIDUMP_TYPE.WithIndirectlyReferencedMemory | MINIDUMP_TYPE.WithThreadInfo), ref exception, IntPtr.Zero, IntPtr.Zero))
			{
				Log.Error("Failed to save a minidump");
			}
		}
		catch (Exception)
		{
		}
	}

	private static void WriteCrashDumpFile(Exception exception, string filePath)
	{
		try
		{
			File.WriteAllText(filePath, exception.ToString());
			Log.Info("Saved a crash report in \"{0}\"", filePath);
		}
		catch (Exception)
		{
		}
	}

	private static void WriteHandleCountsToLog()
	{
		try
		{
			using Process process = Process.GetCurrentProcess();
			Log.Info("Currently: {0} GDI handles, {1} user handles", WindowsFunctions.GetGuiResources(process.Handle, GR.GDIOBJECTS), WindowsFunctions.GetGuiResources(process.Handle, GR.USEROBJECTS));
			Log.Info("Peak: {0} GDI handles, {1} user handles", WindowsFunctions.GetGuiResources(process.Handle, GR.GDIOBJECTS_PEAK), WindowsFunctions.GetGuiResources(process.Handle, GR.USEROBJECTS_PEAK));
		}
		catch (Exception value)
		{
			Log.Warning($"Failed to log current handle count information: {value}");
		}
	}
}
