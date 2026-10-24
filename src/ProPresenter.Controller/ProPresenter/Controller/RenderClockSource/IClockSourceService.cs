using Pro.ssAPI.Devices;

namespace ProPresenter.Controller.RenderClockSource;

public interface IClockSourceService
{
	ClockSourceCollection ClockSources { get; }

	void SetClockSource(ClockSource clockSource);

	void RefreshClockSources();
}
