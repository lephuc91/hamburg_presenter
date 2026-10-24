using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Timer;

namespace ProPresenter.Controller.AsyncTransferHandlers.NetworkTriggerDataHandlers;

public class TimerNetworkTriggerDataHandler : INetworkTriggerDataHandler
{
	private readonly TimerCollection? _timers;

	public TimerNetworkTriggerDataHandler(TimerCollection? timers)
	{
		_timers = timers;
	}

	public NetworkTriggerDataItem? Handle(NetworkIdentifier id, ITriggerOperation op)
	{
		if (_timers == null)
		{
			return null;
		}
		return id.FindItem(_timers)?.ToAction()?.ToTriggerDataItem();
	}
}
