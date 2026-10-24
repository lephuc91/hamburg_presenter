using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Timer;

namespace ProPresenter.Controller.NetworkAPI.Transmit.Command;

public class ConfigureTimerCommand : INetworkCommand
{
	private readonly int _index;

	private readonly TimerBase? _timer;

	public ConfigureTimerCommand(int index, TimerBase? timer)
	{
		_index = index;
		_timer = timer;
	}

	public Pro.SerializationInterop.RVProtoData.NetworkAPI GetCommandProto()
	{
		return ProtoCommandExtensions.Build(delegate(Pro.SerializationInterop.RVProtoData.NetworkAPI c)
		{
			c.ConfigureTimer(_index, _timer?.Serialize());
		});
	}
}
