using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Timer;

namespace ProPresenter.Controller.NetworkAPI.Receive.Command;

public class TimerCommandHandler : CommandHandlerBase
{
	private readonly IImmutableObservableCollection<TimerData>? _timers;

	public TimerCommandHandler(ITriggering triggering, IImmutableObservableCollection<TimerData>? timers)
		: base(triggering)
	{
		_timers = timers;
	}

	public override void Handle(Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action command)
	{
		Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Timer timer = command.Timer;
		if (timer.TimerActionCase == Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Timer.TimerActionOneofCase.Configure)
		{
			ConfigureTimer(timer.Configure.Identifier.ParseIdentifier(), timer.Configure.Configuration);
		}
	}

	private void ConfigureTimer(string? timer, Timer.Types.Configuration configuration)
	{
		if (_timers != null && !string.IsNullOrWhiteSpace(timer))
		{
			(int.TryParse(timer, out var result) ? _timers.ElementAtOrDefault(result) : _timers.FirstOrDefault((TimerData t) => t.Name == timer))?.UpdateSource(configuration);
		}
	}
}
