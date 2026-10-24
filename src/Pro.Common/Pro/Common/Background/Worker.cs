using System;
using System.CodeDom.Compiler;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;

namespace Pro.Common.Background;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_cancellationTokenSource" })]
public class Worker : IDisposable
{
	private static readonly TimeSlice SleepTime = TimeSlice.FromMilliseconds(25.0);

	private static readonly TimeSlice StopTimeout = TimeSlice.FromSeconds(5.0);

	private readonly string _name;

	private JobQueue? _jobQueue;

	private Thread? _workerThread;

	private IJob? _currentJob;

	private IJob? _suspendedJob;

	private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public bool ShouldRun
	{
		get
		{
			if (_workerThread != null)
			{
				return !_cancellationTokenSource.IsCancellationRequested;
			}
			return false;
		}
	}

	internal Worker(string name)
	{
		_name = name;
	}

	internal void Start(JobQueue queue)
	{
		if (_workerThread != null)
		{
			throw new InvalidOperationException("Worker is already running");
		}
		Log.Debug("{0} | Start", _name);
		_jobQueue = queue;
		_workerThread = new Thread(WorkerLoop);
		_workerThread.SetApartmentState(ApartmentState.STA);
		_workerThread.IsBackground = true;
		_workerThread.Name = _name;
		_workerThread.Start();
	}

	internal void Stop()
	{
		if (_workerThread == null)
		{
			throw new InvalidOperationException("Worker is already stopped");
		}
		Log.Debug("{0} | Stop", _name);
		_cancellationTokenSource.Cancel();
		if (!_workerThread.Join((int)StopTimeout.TotalMilliseconds))
		{
			Log.DebugWarning("{0} | Failed to stop worker after {1} seconds... Aborting", _name, StopTimeout.TotalSeconds);
		}
		_workerThread = null;
	}

	internal void Abort()
	{
		if (_workerThread == null)
		{
			throw new InvalidOperationException("Worker is already stopped");
		}
		Log.Debug("{0} | Abort", _name);
		_cancellationTokenSource.Cancel();
		_workerThread = null;
	}

	private async void WorkerLoop()
	{
		Log.Debug("{0} | WorkerLoop Enter", _name);
		while (!_cancellationTokenSource.IsCancellationRequested)
		{
			if (_jobQueue?.TryFindJob(out _currentJob, includeLongRunning: true) ?? false)
			{
				Log.Debug("{0} | WorkerLoop ExecuteJob ({1})", _name, _currentJob.Name);
				await _currentJob.ExecuteJobAsync(this).ConfigureAwait(continueOnCapturedContext: true);
				Log.Debug("{0} | WorkerLoop JobComplete ({1})", _name, _currentJob.Name);
			}
			else
			{
				Suspend();
			}
		}
		Log.Debug("{0} | WorkerLoop Leave", _name);
	}

	public async Task Stall()
	{
		if (_currentJob == null)
		{
			Log.DebugWarning("{0} | Attempt to stall with no active job", _name);
			return;
		}
		if (_currentJob.Priority != JobPriority.LongRunning)
		{
			Log.DebugWarning("{0} | A non long running job is stalling", _name);
		}
		bool flag = false;
		if (_currentJob.Priority == JobPriority.LongRunning && _suspendedJob == null)
		{
			_suspendedJob = _currentJob;
			if (_jobQueue?.TryFindJob(out _currentJob, includeLongRunning: false) ?? false)
			{
				Log.Debug("{0} | Stall ExecuteJob ({1})", _name, _currentJob.Name);
				await _currentJob.ExecuteJobAsync(this).ConfigureAwait(continueOnCapturedContext: true);
				Log.Debug("{0} | Stall JobComplete ({1})", _name, _currentJob.Name);
				flag = true;
			}
			_currentJob = _suspendedJob;
			_suspendedJob = null;
		}
		if (!flag)
		{
			Suspend();
		}
	}

	public static void Suspend()
	{
		Thread.Sleep(SleepTime);
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
			_cancellationTokenSource.Dispose();
		}
	}
}
