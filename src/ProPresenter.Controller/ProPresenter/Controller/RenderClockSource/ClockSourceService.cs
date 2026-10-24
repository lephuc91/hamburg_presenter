using Pro.Common.Dispatcher;
using Pro.ssAPI.Devices;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.RenderClockSource;

public class ClockSourceService : IClockSourceService
{
	private readonly IProCoreInstance _proCore;

	private readonly IClockSourceProvider _provider;

	public ClockSourceCollection ClockSources { get; }

	public ClockSourceService(IClockSourceProvider provider, IProCoreInstance proCore, IUiDispatcher uiDispatcher)
	{
		_proCore = proCore;
		_provider = provider;
		ClockSources = new ClockSourceCollection(_provider);
	}

	public void SetClockSource(ClockSource clockSource)
	{
		_proCore.SetClockSource(clockSource.Serialize());
	}

	public void RefreshClockSources()
	{
		_provider.RefreshClockSources();
	}
}
