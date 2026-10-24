using Pro.Common.Logging;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace ProPresenter.Registration.CallbackHandlers;

public class LogHandler : IRegistrationCallbackHandler
{
	private readonly ILogger _logger;

	public LogHandler(ILogger logger)
	{
		_logger = logger;
	}

	public bool HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		if (responseCallback.CallbackCase == Callback.CallbackOneofCase.Log)
		{
			string message = responseCallback.Log.Message;
			switch (responseCallback.Log.Level)
			{
			case Pro.SerializationInterop.RVProtoData.Registration.Log.Types.Level.Debug:
				_logger.Debug(message);
				break;
			case Pro.SerializationInterop.RVProtoData.Registration.Log.Types.Level.Info:
				_logger.Info(message);
				break;
			case Pro.SerializationInterop.RVProtoData.Registration.Log.Types.Level.Warning:
				_logger.Warning(message);
				break;
			case Pro.SerializationInterop.RVProtoData.Registration.Log.Types.Level.Error:
				_logger.Error(message);
				break;
			}
			return true;
		}
		return false;
	}
}
