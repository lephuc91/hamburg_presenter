using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using Pro.DO.Audio;
using Pro.DO.Storage;
using Pro.UI.Components;
using ProPresenter.DO.Capture;
using ProPresenter.UI.ViewModels.Capture;

namespace ProPresenter.UI.ViewModels;

public interface IRtmpCaptureVM : INotifyPropertyChanged
{
	string Address { get; set; }

	string Key { get; set; }

	bool SaveLocalCopy { get; set; }

	RelativePath SaveToLocation { get; set; }

	IEnumerable<RelativePath> DefaultSaveToLocations { get; }

	Encoder? Encoder
	{
		get; [param: DisallowNull]
		set;
	}

	AudioMap<Bus, StreamAudioChannel>? AudioOutputMap { get; }

	ICustomEncoderVM CustomEncoderVM { get; }

	ICommand SaveToOtherLocationCommand { get; }

	ICommand<RelativePath> SelectDefaultLocationCommand { get; }

	ICommand<Encoder> SelectEncoderCommand { get; }

	ICommand SelectCustomEncoderCommand { get; }
}
