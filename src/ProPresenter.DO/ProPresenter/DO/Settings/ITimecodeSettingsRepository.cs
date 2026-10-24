using ProPresenter.DO.Timecode;

namespace ProPresenter.DO.Settings;

public interface ITimecodeSettingsRepository
{
	ITimecodeSettings ActiveSettings { get; }
}
