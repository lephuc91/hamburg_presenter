using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.Services;

namespace ProPresenter.Registration.CallbackHandlers;

public class HardExitHandler : IRegistrationCallbackHandler
{
	private readonly IForcedShutdownMessageProvider _forcedShutdownMessageProvider;

	public HardExitHandler(IForcedShutdownMessageProvider forcedShutdownMessageProvider)
	{
		_forcedShutdownMessageProvider = forcedShutdownMessageProvider;
	}

	public bool HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		if (responseCallback.CallbackCase == Callback.CallbackOneofCase.HardExit)
		{
			_forcedShutdownMessageProvider.ShowForcedApplicationShutdownDialog(Convert(responseCallback.HardExit.Reason));
			return true;
		}
		return false;
	}

	private static IForcedShutdownMessageProvider.ShutdownReason Convert(HardExit.Types.Reason reason)
	{
		if (reason == HardExit.Types.Reason.HostsFile)
		{
			return IForcedShutdownMessageProvider.ShutdownReason.HostsFile;
		}
		return IForcedShutdownMessageProvider.ShutdownReason.SystemTime;
	}
}
