using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using CoreRegistrationClient;
using Google.Protobuf;
using Pro.Common.Collections.Concurrency.Locking;
using Pro.Common.ErrorReporting;
using Pro.Common.FeatureFlag;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace Pro.Registration;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_registrationInteractor", "_operations", "_callbackHandlers" })]
public sealed class RegistrationClient : IRegistrationClient, IRegistrationRequestSender, IRegistrationInteractorCallbackReceiver, IDisposable
{
	private readonly IRegistrationInteractor _registrationInteractor;

	private readonly LockingList<IRegistrationOperation> _operations = new LockingList<IRegistrationOperation>();

	private readonly LockingList<IRegistrationCallbackHandler> _callbackHandlers = new LockingList<IRegistrationCallbackHandler>();

	private readonly ILogger _logger;

	private readonly IFlagService _flagService;

	private readonly IErrorReporter _errorReporter;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public RegistrationClient(IRegistrationInteractorFactory registrationInteractorFactory, ILogger logger, IFlagService flagService, IErrorReporter errorReporter)
	{
		_registrationInteractor = registrationInteractorFactory.Create(this);
		_logger = logger;
		_flagService = flagService;
		_errorReporter = errorReporter;
	}

	public void Start()
	{
		ResolvedFeatureFlags message = new ResolvedFeatureFlags
		{
			StagingApiEndpointEnabled = _flagService.IsFlagEnabled(Flag.SimulateCrashOnStartup),
			SubscriptionEnabled = true,
			EndpointVersion11Enabled = _flagService.IsFlagEnabled(Flag.ShowCrashUiOnStartup)
		};
		_registrationInteractor.Start(message.ToByteArray());
	}

	public void Add(IRegistrationOperation operation)
	{
		_operations.Add(operation);
		Send(operation.Start());
	}

	public void Add(IRegistrationCallbackHandler callbackHandler)
	{
		_callbackHandlers.Add(callbackHandler);
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
		IEnumerable<IRegistrationOperation> source = ((IEnumerable<IRegistrationOperation>)_operations).ToList().Where(delegate(IRegistrationOperation operation)
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
		_operations.RemoveAll((IList<IRegistrationOperation>)source.ToList());
		if (!messageHandled)
		{
			_logger.Error("[{0}]Received message {1} that was not handled by anybody", "RegistrationClient", decodedMessage);
		}
	}

	public bool Send(Request request)
	{
		return _registrationInteractor.Send(request.ToByteArray());
	}

	public void LogError(string message, params object[] @params)
	{
		_logger.Error(message, @params);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_registrationInteractor.Dispose();
			_operations.Dispose();
			_callbackHandlers.Dispose();
		}
	}
}
