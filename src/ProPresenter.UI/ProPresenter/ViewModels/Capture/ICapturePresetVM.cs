using CommunityToolkit.Mvvm.Input;
using ProPresenter.DO.Capture;

namespace ProPresenter.ViewModels.Capture;

public interface ICapturePresetVM
{
	ICapturePresetCollection Presets { get; }

	ICapturePreset? ActivePreset { get; set; }

	bool ExistingPresetSelected { get; }

	bool AnyPresets { get; }

	IRelayCommand NoPresetCommand { get; }

	IRelayCommand<ICapturePreset> SelectPresetCommand { get; }

	IRelayCommand SaveAsPresetCommand { get; }

	IRelayCommand RenamePresetCommand { get; }

	IRelayCommand DeletePresetCommand { get; }
}
