using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Abstractions;
using System.Reactive.Subjects;
using Pro.Common.Collections;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.Common.Time.Timer;

namespace Pro.Common.ProcessSupervision;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_process", "_state", "_checkProcessRunningTimer" })]
public class ProcessSupervisor : IProcessSupervisor, IDisposable
{
	private readonly ReplaySubject<ProcessState> _state = new ReplaySubject<ProcessState>(1);

	private Process? _process;

	private readonly string _processName;

	private readonly string _filePath;

	private readonly string _workingDirectory;

	private readonly IPeriodicTimer _checkProcessRunningTimer;

	private readonly ILogger _logger;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IObservable<ProcessState> WhenStateChanges => _state;

	public ProcessSupervisor(ILogger logger, string processName, string filePath, ITimerFactory timerFactory, IFileSystem fileSystem, string? workingDirectory = null)
	{
		_logger = logger;
		_processName = processName;
		_filePath = filePath;
		logger.Info("Monitoring Process \"{0}\" at \"{1}\" with initial working directory \"{2}\"", _processName, _filePath, workingDirectory ?? "NULL");
		if (!fileSystem.File.Exists(_filePath))
		{
			throw new FileNotFoundException($"No file exists at path \"{filePath}\" with name \"{processName}\" to monitor");
		}
		_workingDirectory = ((string.IsNullOrEmpty(workingDirectory) || !fileSystem.Directory.Exists(workingDirectory)) ? fileSystem.Path.GetTempPath() : workingDirectory);
		logger.Info("Using working directory \"{0}\"", _workingDirectory);
		_checkProcessRunningTimer = timerFactory.CreatePeriodic(TimeSlice.FromMilliseconds(500.0), OnCheckProcessRunning);
	}

	public void Start()
	{
		Process[] processesByName = Process.GetProcessesByName(_processName);
		switch (processesByName.Length)
		{
		case 0:
			_state.OnNext(ProcessState.NotRunning);
			StartProcess();
			break;
		case 1:
			_process = processesByName[0];
			if (_process != null)
			{
				_checkProcessRunningTimer.Start();
				_state.OnNext(ProcessState.Running);
			}
			break;
		default:
			_logger.Warning("{0} can only accomodate 0 or 1 instances of a supervised process.", "ProcessSupervisor");
			break;
		}
	}

	private void OnCheckProcessRunning()
	{
		if (Process.GetProcessesByName(_processName).Empty())
		{
			_checkProcessRunningTimer.Stop();
			OnProcessExited();
		}
	}

	private void OnProcessExited()
	{
		_state.OnNext(ProcessState.NotRunning);
		_process?.Dispose();
		StartProcess();
	}

	[MemberNotNull("_process")]
	private void StartProcess()
	{
		_process = Process.Start(new ProcessStartInfo
		{
			FileName = _filePath,
			UseShellExecute = true,
			WorkingDirectory = _workingDirectory
		});
		_process.ThrowWhenNull("_process");
		_state.OnNext(ProcessState.Running);
		_checkProcessRunningTimer.Start();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
			_process?.Dispose();
			_state.Dispose();
			_checkProcessRunningTimer.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_checkProcessRunningTimer.Stop();
	}
}
