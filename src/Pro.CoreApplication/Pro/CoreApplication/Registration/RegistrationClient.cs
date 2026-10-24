using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using CoreApplication;
using Google.Protobuf;
using Pro.Common.Background;
using Pro.Common.Collections.Concurrency.Locking;
using Pro.Common.ErrorReporting;
using Pro.Common.FeatureFlag;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using Pro.CoreApplication.CoreInteraction;
using Pro.CoreApplication.Registration.CoreInteraction;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace Pro.CoreApplication.Registration;

[Pro.Common.SourceGenerator.Attributes.AsyncDisposable("_asyncExecutor", "OnDisposeAsync", new string[] { "_operations", "_cancellationTokenSource" })]
public sealed class RegistrationClient : IRegistrationClient, IManagedNativeCallbackReceiver, IRegistrationRequestSender, IDisposable, IAsyncDisposable
{
	private readonly LockingList<IRegistrationOperation> _operations = new LockingList<IRegistrationOperation>();

	private readonly IReadOnlyCollection<IRegistrationCallbackHandler> _callbackHandlers;

	private readonly ILogger _logger;

	private readonly IFlagService _flagService;

	private readonly IErrorReporter _errorReporter;

	private readonly IAsyncExecutor _asyncExecutor;

	private readonly Task _sendTask;

	private readonly Channel<Request> _sendChannel;

	private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public RegistrationClient(ICoreApplication application, ILogger logger, IFlagService flagService, IErrorReporter errorReporter, IAsyncExecutor asyncExecutor, IEnumerable<IRegistrationCallbackHandler> callbackHandlers)
	{
		_callbackHandlers = (IReadOnlyCollection<IRegistrationCallbackHandler>)(object)callbackHandlers.ToArray();
		_logger = logger;
		_flagService = flagService;
		_errorReporter = errorReporter;
		_asyncExecutor = asyncExecutor;
		_sendChannel = Channel.CreateUnbounded<Request>();
		_sendTask = StartupAndSendAsync(application);
	}

	public void Add(IRegistrationOperation operation)
	{
		_operations.Add(operation);
		Send(operation.Start());
	}

	public void NativeCallback(nint instancePointer)
	{
		_logger.Error("[{0}]Received instance callback but only serialized messages are supported.", "RegistrationClient");
	}

	public void NativeCallback(byte[] protoData)
	{
		OnRegistrationCallback(protoData);
	}

	public void NativeErrorCallback()
	{
		_logger.Error("[{0}] Received callback without Payload.", "RegistrationClient");
	}

	public void OnRegistrationCallback(byte[] data)
	{
		bool messageHandled = false;
		Callback decodedMessage = Callback.Parser.ParseFrom(data);
		foreach (IRegistrationCallbackHandler callbackHandler in _callbackHandlers)
		{
			try
			{
				messageHandled |= callbackHandler.HandleResponse(decodedMessage, this);
			}
			catch (Exception e)
			{
				_errorReporter.FatalError(e, "Core registration callback handler crashed");
			}
		}
		IEnumerable<IRegistrationOperation> source = _operations.ToList().Where(delegate(IRegistrationOperation operation)
		{
			RegistrationOperationHandleResponse registrationOperationHandleResponse;
			try
			{
				registrationOperationHandleResponse = operation.HandleResponse(decodedMessage, this);
			}
			catch (Exception e2)
			{
				_errorReporter.FatalError(e2, "Core registration operation crashed handling a response");
				return false;
			}
			messageHandled |= registrationOperationHandleResponse.MessageHandled;
			return registrationOperationHandleResponse.OperationCompleted;
		});
		_operations.RemoveAll(source.ToList());
		if (!messageHandled)
		{
			_logger.Warning("[{0}]Received message {1} that was not handled by anybody", "RegistrationClient", decodedMessage);
		}
	}

	public bool Send(Request request)
	{
		return _sendChannel.Writer.TryWrite(request);
	}

	public void LogError(string message, params object[] @params)
	{
		_logger.Error(message, @params);
	}

	private async Task StartupAndSendAsync(ICoreApplication application)
	{
		ResolvedFeatureFlags message = new ResolvedFeatureFlags
		{
			StagingApiEndpointEnabled = _flagService.IsFlagEnabled(Flag.StagingApiEndpoints)
		};
		ServiceResult<ICoreRegistrationService> serviceResult = await application.GetRegistrationServiceAsync(message.ToByteArray(), this).ConfigureAwait(continueOnCapturedContext: false);
		if (!serviceResult.IsSuccess)
		{
			_logger.Error("[{0}]Failed to get registration service: {1}", "RegistrationClient", serviceResult.Error);
			_sendChannel.Writer.Complete(serviceResult.Error);
			return;
		}
		ICoreRegistrationService registrationService = serviceResult.Instance;
		while (true)
		{
			bool flag = !_cancellationTokenSource.Token.IsCancellationRequested;
			if (flag)
			{
				flag = await _sendChannel.Reader.WaitToReadAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			if (flag)
			{
				Request item;
				while (!_cancellationTokenSource.Token.IsCancellationRequested && _sendChannel.Reader.TryRead(out item))
				{
					registrationService.Send(item);
				}
				continue;
			}
			break;
		}
	}

	private async ValueTask OnDisposeAsync()
	{
		await _cancellationTokenSource.CancelAsync().ConfigureAwait(continueOnCapturedContext: false);
		_sendChannel.Writer.TryComplete();
		await _sendTask;
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
	private async ValueTask DisposeAsync(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			await OnDisposeAsync();
			_operations.Dispose();
			_cancellationTokenSource.Dispose();
		}
	}
}
