using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Pro.Common.Collections.Concurrency.Locking;
using Pro.Common.Time;

namespace Pro.Common.Logging;

public static class Log
{
	private const string Config = "R";

	private static Clock? _runTime;

	private static Thread _outputWriterThread;

	private static readonly LockingList<TextWriter> _logOutputs;

	private static readonly ConcurrentQueue<string> _messageQueue;

	private static readonly int _processId;

	private static AutoResetEvent _writeLogs;

	private static CancellationTokenSource _stopLogging;

	public static Action<string, string, string>? BreadcrumbCallback { get; set; }

	static Log()
	{
		_runTime = null;
		_outputWriterThread = new Thread(LogWriterLoop);
		_logOutputs = new LockingList<TextWriter>();
		_messageQueue = new ConcurrentQueue<string>();
		_processId = Process.GetCurrentProcess().Id;
		_writeLogs = new AutoResetEvent(initialState: false);
		_stopLogging = new CancellationTokenSource();
		BreadcrumbCallback = null;
		_outputWriterThread.Start();
	}

	public static bool AddOutput(TextWriter output)
	{
		TextWriter resolvedItem;
		return !_logOutputs.TryGetOrAdd((TextWriter o) => o == output, () => output, out resolvedItem);
	}

	public static bool RemoveOutput(TextWriter output)
	{
		return _logOutputs.RemoveAll((TextWriter o) => o == output).Any();
	}

	public static void ShutdownOutputs()
	{
		_stopLogging.Cancel();
		_outputWriterThread.Join();
		_stopLogging.Dispose();
		WriteQueueToOutputs();
		foreach (TextWriter item in _logOutputs.RemoveAll((TextWriter o) => true))
		{
			item.Close();
			item.Dispose();
		}
	}

	private static void LogWriterLoop()
	{
		while (!_stopLogging.IsCancellationRequested)
		{
			WriteQueueToOutputs();
			WaitHandle.WaitAny(new WaitHandle[2]
			{
				_stopLogging.Token.WaitHandle,
				_writeLogs
			});
		}
	}

	private static void WriteQueueToOutputs()
	{
		string result;
		while (_messageQueue.TryDequeue(out result))
		{
			try
			{
				foreach (TextWriter logOutput in _logOutputs)
				{
					logOutput.WriteLine(result);
					logOutput.Flush();
				}
			}
			catch (Exception)
			{
			}
		}
	}

	private static void WriteMessage(string type, bool logBreadcrumb, string message, params object?[] args)
	{
		string text = (args.Any() ? string.Format(message, args) : message);
		if (_runTime == null)
		{
			_runTime = new Clock(autoStart: true);
		}
		TimeSlice elapsedTime = _runTime.ElapsedTime;
		_003C_003Ey__InlineArray7<object> buffer = default(_003C_003Ey__InlineArray7<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 0) = DateTime.UtcNow.ToString();
		ref object reference = ref global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 1);
		global::_003C_003Ey__InlineArray4<object> buffer2 = default(global::_003C_003Ey__InlineArray4<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer2, 0) = elapsedTime.Hours;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer2, 1) = elapsedTime.Minutes;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer2, 2) = elapsedTime.Seconds;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer2, 3) = elapsedTime.Milliseconds;
		reference = string.Format("{0}:{1:00}:{2:00}.{3:000}", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer2, 4));
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 2) = _processId;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 3) = Thread.CurrentThread.ManagedThreadId.ToString().PadRight(2);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 4) = "R";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 5) = type;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<object>, object>(ref buffer, 6) = text;
		string item = string.Format("{0}\t{1}\tP{2} T{3} [{4}]\t{5} - {6}", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<object>, object>(in buffer, 7));
		_messageQueue.Enqueue(item);
		_writeLogs.Set();
		if (logBreadcrumb && BreadcrumbCallback != null)
		{
			BreadcrumbCallback(type, "R", text);
		}
	}

	public static void Debug(Exception exception)
	{
		Debug(exception.ToString());
	}

	public static void Debug(string message, params object?[] args)
	{
	}

	public static void DebugWarning(Exception exception)
	{
		DebugWarning(exception.ToString());
	}

	public static void DebugWarning(string message, params object?[] args)
	{
	}

	public static void Info(Exception exception)
	{
		Info(exception.ToString());
	}

	public static void Info(string message, params object?[] args)
	{
		WriteMessage("INFO", logBreadcrumb: false, message, args);
	}

	public static void Warning(Exception exception)
	{
		Warning(exception.ToString());
	}

	public static void Warning(string message, params object?[] args)
	{
		WriteMessage("WARNING", logBreadcrumb: true, message, args);
	}

	public static void Error(Exception exception)
	{
		Error(exception.ToString());
	}

	public static void Error(string message, params object?[] args)
	{
		WriteMessage("ERROR", logBreadcrumb: true, message, args);
	}

	public static void FatalError(Exception exception)
	{
		FatalError(exception.ToString());
	}

	public static void FatalError(string message, params object?[] args)
	{
		WriteMessage("FATAL-ERROR", logBreadcrumb: true, message, args);
	}
}
