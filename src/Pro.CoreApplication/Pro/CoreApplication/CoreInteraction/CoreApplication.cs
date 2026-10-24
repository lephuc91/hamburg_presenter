using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using CoreApplication;
using Google.Protobuf;
using Pro.Common.Background;
using Pro.Common.Collections.Concurrency.Locking;
using Pro.Common.ErrorReporting;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using Pro.CoreApplication.Document.CoreInteraction;
using Pro.CoreApplication.FeatureFlag.CoreInteraction;
using Pro.CoreApplication.Media.V1.CoreInteraction;
using Pro.CoreApplication.Media.V2.CoreInteraction;
using Pro.CoreApplication.Registration.CoreInteraction;
using Pro.CoreApplication.Workspace.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.Application;
using Pro.SerializationInterop.RVProtoData.Logging;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;
using Pro.SerializationInterop.RVProtoData.RVError;

namespace Pro.CoreApplication.CoreInteraction;

[Pro.Common.SourceGenerator.Attributes.AsyncDisposable("_asyncExecutor", "OnDisposeAsync", new string[] { })]
public class CoreApplication : global::CoreApplication.CoreApplication, ICoreApplication, ISubscriptionDisposer, IDisposable, IAsyncDisposable
{
	private sealed class StartupCallbackReceiver(TaskCompletionSource<nint> _completor, IApplicationExceptionFactory applicationExceptionFactory) : IManagedNativeCallbackReceiver
	{
		public void NativeCallback(nint instancePointer)
		{
			_completor.SetResult(instancePointer);
		}

		public void NativeCallback(byte[] protoData)
		{
			try
			{
				Error error = Error.Parser.ParseFrom(protoData);
				_completor.TrySetException(applicationExceptionFactory.Create(error));
			}
			catch (Exception exception)
			{
				_completor.TrySetException(exception);
			}
		}

		public void NativeErrorCallback()
		{
			_completor.TrySetException(new ApplicationException());
		}
	}

	private sealed class LoggingCallbackReceiver(ILogger _logger) : IManagedNativeCallbackReceiver
	{
		private const string RustCore = "RustCore";

		public void NativeCallback(nint instancePointer)
		{
			_logger.Error("[{0}] Logging invoked from {1} but got instance pointer instead of protobuf buffer.", "CoreApplication", "RustCore");
		}

		public void NativeCallback(byte[] protoData)
		{
			LogEntry logEntry = LogEntry.Parser.ParseFrom(protoData);
			string message = "[{0}] {1}";
			switch (logEntry.Level)
			{
			case LogLevel.LevelTrace:
			case LogLevel.LevelDebug:
				_logger.Debug(message, "RustCore", logEntry.Message);
				break;
			case LogLevel.LevelInfo:
				_logger.Info(message, "RustCore", logEntry.Message);
				break;
			case LogLevel.LevelWarn:
				_logger.Warning(message, "RustCore", logEntry.Message);
				break;
			case LogLevel.LevelError:
				_logger.Error(message, "RustCore", logEntry.Message);
				break;
			}
		}

		public void NativeErrorCallback()
		{
			_logger.Error("[{0}] Logging invoked from {1} but no payload was provided.", "CoreApplication", "RustCore");
		}
	}

	private sealed class ErrorCallbackReceiver(IErrorReporter _reporter) : IManagedNativeCallbackReceiver
	{
		private const string RustCore = "RustCore";

		public void NativeCallback(nint instancePointer)
		{
			_reporter.Error("[{0}] Error reporting invoked from {1} but got instance pointer instead of protobuf buffer.", "CoreApplication", "RustCore");
		}

		public void NativeCallback(byte[] protoData)
		{
			ReportedError reportedError = ReportedError.Parser.ParseFrom(protoData);
			((reportedError.Severity == ReportedError.Types.Severity.Handled) ? new Action<string, object[]>(_reporter.Error) : new Action<string, object[]>(_reporter.FatalError))("[{0}] Error reported from the rust code.\ndescription: {1}\nerror: {2} happened in {3} on line {4}", new object[5] { "RustCore", reportedError.Description, reportedError.Type, reportedError.File, reportedError.Line });
		}

		public void NativeErrorCallback()
		{
			_reporter.Error("[{0}] Error reporting invoked from {1} but no payload was provided.", "CoreApplication", "RustCore");
		}
	}

	private sealed class ShutdownCallbackReceiver(TaskCompletionSource _completor, IApplicationExceptionFactory applicationExceptionFactory) : IManagedNativeCallbackReceiver
	{
		public void NativeCallback(nint instancePointer)
		{
			_completor.SetException(new ApplicationException());
		}

		public void NativeCallback(byte[] protoData)
		{
			try
			{
				ResultEnvelope resultEnvelope = ResultEnvelope.Parser.ParseFrom(protoData);
				if (resultEnvelope.ResultCase == ResultEnvelope.ResultOneofCase.Error)
				{
					Error error = resultEnvelope.Error;
					_completor.TrySetException(applicationExceptionFactory.Create(error));
				}
				else
				{
					_completor.TrySetResult();
				}
			}
			catch (Exception exception)
			{
				_completor.TrySetException(exception);
			}
		}

		public void NativeErrorCallback()
		{
			_completor.TrySetException(new ApplicationException());
		}
	}

	private sealed record StartupResult(nint ApplicationPointer, Exception? Error, bool IsFatalError)
	{
		[MemberNotNullWhen(false, "Error")]
		public bool IsSuccess
		{
			[MemberNotNullWhen(false, "Error")]
			get
			{
				return ApplicationPointer != IntPtr.Zero;
			}
		}
	}

	public const string WorkspaceHelperProcessName = "ProPresenter Helper - Workspaces";

	public const string WorkspaceHelperExeRelativePathName = "Workspaces\\ProPresenter Helper - Workspaces.exe";

	private readonly ILogger _logger;

	private readonly IAsyncExecutor _asyncExecutor;

	private readonly IApplicationExceptionFactory _applicationExceptionFactory;

	private readonly IErrorReporter _errorReporter;

	private readonly Task<StartupResult> _startupTask;

	private readonly TaskCompletionSource<(ApplicationStartParams Params, IApplicationFailureMessageService ApplicationFailureMessageService, Action Quit, Action Update)> _startupOptions;

	private readonly LockingList<IAsyncDisposable> _subscriptions = new LockingList<IAsyncDisposable>();

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public CoreApplication(ILogger logger, IAsyncExecutor asyncExecutor, IApplicationExceptionFactory applicationExceptionFactory, IErrorReporter errorReporter)
	{
		_logger = logger;
		_asyncExecutor = asyncExecutor;
		_applicationExceptionFactory = applicationExceptionFactory;
		_errorReporter = errorReporter;
		_startupOptions = new TaskCompletionSource<(ApplicationStartParams, IApplicationFailureMessageService, Action, Action)>();
		_startupTask = StartupAsync();
	}

	public Task<ServiceResult<ICoreMediaServiceV1>> GetMediaServiceV1Async()
	{
		return GetServiceAsync((Func<nint, nint>)base.GetMediaServiceV1, (Func<nint, ICoreMediaServiceV1>)((nint s) => new CoreMediaServiceV1(s, this)), (Func<ICoreMediaServiceV1>)(() => new StubCoreMediaServiceV1()));
	}

	public Task<ServiceResult<ICoreMediaServiceV2>> GetMediaServiceV2Async()
	{
		return GetServiceAsync((Func<nint, nint>)base.GetMediaServiceV2, (Func<nint, ICoreMediaServiceV2>)((nint s) => new CoreMediaServiceV2(s, this)), (Func<ICoreMediaServiceV2>)(() => new StubCoreMediaServiceV2()));
	}

	public Task<ServiceResult<ICoreFeatureFlagService?>> GetFeatureFlagServiceAsync()
	{
		return GetServiceAsync(base.GetFeatureFlagService, (nint s) => new CoreFeatureFlagService(s, this), () => (ICoreFeatureFlagService?)null);
	}

	public Task<ServiceResult<ICoreCloudWorkspaceService?>> GetCoreCloudWorkspaceServiceAsync()
	{
		return GetServiceAsync(base.GetWorkspaceService, (nint s) => new CoreCloudWorkspaceService(s, this), () => (ICoreCloudWorkspaceService?)null);
	}

	public Task<ServiceResult<ICoreCloudDocumentService?>> GetCoreCloudDocumentServiceAsync()
	{
		return GetServiceAsync(base.GetDocumentService, (nint s) => new CoreCloudDocumentService(s, this), () => (ICoreCloudDocumentService?)null);
	}

	public Task<ServiceResult<ICoreRegistrationService?>> GetRegistrationServiceAsync(byte[] config, IManagedNativeCallbackReceiver receiver)
	{
		return GetServiceAsync((nint a) => GetRegistrationService(a, config, receiver), (nint s) => new CoreRegistrationService(s), () => (ICoreRegistrationService?)null);
	}

	public void Start(ApplicationStartParams @params, IApplicationFailureMessageService applicationFailureMessageService, Action quit, Action update)
	{
		_startupOptions.SetResult((@params, applicationFailureMessageService, quit, update));
	}

	public void RegisterSubscription(IAsyncDisposable subscription)
	{
		_subscriptions.Add(subscription);
	}

	private async Task<ServiceResult<T>> GetServiceAsync<T>(Func<nint, nint> getService, Func<nint, T> createServiceInstance, Func<T> createDefaultValue)
	{
		StartupResult startupResult = await _startupTask;
		if (!startupResult.IsSuccess)
		{
			return new ServiceResult<T>(createDefaultValue(), startupResult.Error, startupResult.IsFatalError);
		}
		nint num = getService(startupResult.ApplicationPointer);
		return (num == IntPtr.Zero) ? new ServiceResult<T>(createDefaultValue(), ApplicationException.ForInvalidPointer(num), isFatalError: true) : new ServiceResult<T>(createServiceInstance(num));
	}

	private async Task<StartupResult> StartupAsync()
	{
		int attempts = 1;
		while (true)
		{
			if (attempts >= 3)
			{
				try
				{
					_logger.Info("Attempting to terminate workspaces helper before attempting to reconnect");
					Process[] processesByName = Process.GetProcessesByName("ProPresenter Helper - Workspaces");
					Process[] array = processesByName;
					foreach (Process obj in array)
					{
						_logger.Info("Terminating running workspace helper instance.");
						obj.Kill();
					}
					Array.ForEach(processesByName, delegate(Process x)
					{
						x.Dispose();
					});
				}
				catch (Exception ex)
				{
					_logger.Error("Error terminating Workspace Helper Instance: {0}", ex.Message);
				}
			}
			_logger.Info("[{0}] Connecting to Core Application attempt {1}", "CoreApplication", attempts);
			(ApplicationStartParams Params, IApplicationFailureMessageService ApplicationFailureMessageService, Action Quit, Action Update) options = await _startupOptions.Task.ConfigureAwait(continueOnCapturedContext: false);
			TaskCompletionSource<nint> taskCompletionSource = new TaskCompletionSource<nint>(TaskCreationOptions.RunContinuationsAsynchronously);
			StartupCallbackReceiver callbackReceiver = new StartupCallbackReceiver(taskCompletionSource, _applicationExceptionFactory);
			LoggingCallbackReceiver loggingCallbackReceiver = new LoggingCallbackReceiver(_logger);
			ErrorCallbackReceiver errorCallbackReceiver = new ErrorCallbackReceiver(_errorReporter);
			Start(options.Params.ToByteArray(), callbackReceiver, loggingCallbackReceiver, errorCallbackReceiver);
			try
			{
				nint applicationPointer = await taskCompletionSource.Task;
				_logger.Info("[{0}] Done connecting to Core Application", "CoreApplication");
				return new StartupResult(applicationPointer, null, IsFatalError: false);
			}
			catch (MediaServiceException ex2)
			{
				if (ex2.ErrorCode == RequestError.Types.ErrorCode.ServiceVersionMismatch)
				{
					_logger.Error("[{0}] Media service API mismatch detected", "CoreApplication");
					bool isFatalError = false;
					switch (options.ApplicationFailureMessageService.ShowMediaServiceApiVersionMismatch())
					{
					case IApplicationFailureMessageService.VersionMismatchUserSelection.Quit:
						options.Quit();
						isFatalError = true;
						break;
					case IApplicationFailureMessageService.VersionMismatchUserSelection.Update:
						options.Update();
						break;
					}
					return new StartupResult(IntPtr.Zero, ex2, isFatalError);
				}
				_logger.Error("[{0}] Failed to connect to Core Application Media Service: {1}", "CoreApplication", ex2);
				switch (options.ApplicationFailureMessageService.ShowMediaServiceStartupFailure(ex2.ToString()))
				{
				case IApplicationFailureMessageService.StartupUserSelection.Continue:
					return new StartupResult(IntPtr.Zero, ex2, IsFatalError: false);
				case IApplicationFailureMessageService.StartupUserSelection.Quit:
					options.Quit();
					return new StartupResult(IntPtr.Zero, ex2, IsFatalError: true);
				}
			}
			catch (ApplicationException ex3)
			{
				_logger.Error("[{0}] Application bootstrapping failed: {1}", "CoreApplication", ex3);
				options.ApplicationFailureMessageService.ShowServiceBootstrapError();
				options.Quit();
				return new StartupResult(IntPtr.Zero, ex3, IsFatalError: true);
			}
			finally
			{
				attempts++;
			}
		}
	}

	private async ValueTask OnDisposeAsync()
	{
		StartupResult result = await _startupTask;
		await Task.WhenAll(_subscriptions.Select((IAsyncDisposable x) => x.DisposeAsync().AsTask()));
		if (result.ApplicationPointer != IntPtr.Zero)
		{
			_logger.Info("[{0}] Disconnecting from Core Application", "CoreApplication");
			TaskCompletionSource taskCompletionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
			Shutdown(callbackReceiver: new ShutdownCallbackReceiver(taskCompletionSource, _applicationExceptionFactory), application: result.ApplicationPointer);
			await taskCompletionSource.Task;
			_logger.Info("[{0}] Done disconnecting from Core Application", "CoreApplication");
		}
		OnShutdownComplete();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		_asyncExecutor.ExecuteAsyncValueTask(DisposeAsync);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public async ValueTask DisposeAsync()
	{
		await DisposeAsync(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual async ValueTask DisposeAsync(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			await OnDisposeAsync();
		}
	}
}
