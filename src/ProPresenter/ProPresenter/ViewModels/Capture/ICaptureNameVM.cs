using System.ComponentModel;

namespace ProPresenter.ViewModels.Capture;

public interface ICaptureNameVM : INotifyPropertyChanged
{
	string PresetName { get; }

	bool TryGetPresetName(out string presetName, string? nameValue = "");
}
