using ProPresenter.DO.Timecode;

namespace ProPresenter.DO.Settings;

public class TimecodeSettingsRepository : ITimecodeSettingsRepository
{
	private readonly IApp _app;

	public ITimecodeSettings ActiveSettings => _app.Timecode;

	public TimecodeSettingsRepository(IApp app)
	{
		_app = app;
	}
}
