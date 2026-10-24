using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using Pro.DO.Audio;
using Pro.DO.Storage;
using Pro.UI.Components;
using ProPresenter.DO.Capture;

namespace ProPresenter.UI.ViewModels;

public interface IDiskCaptureVM : INotifyPropertyChanged
{
	RelativePath SaveToLocation { get; set; }

	IEnumerable<RelativePath> DefaultSaveToLocations { get; }

	Codec Codec { get; set; }

	IEnumerable<Codec> Codecs { get; }

	Encoder? Encoder
	{
		get; [param: DisallowNull]
		set;
	}

	AudioMap<Bus, StreamAudioChannel>? AudioOutputMap { get; }

	ICommand<RelativePath> SelectDefaultLocationCommand { get; }

	ICommand SaveToOtherLocationCommand { get; }

	ICommand<Encoder> SelectEncoderCommand { get; }

	ICommand SelectCustomEncoderCommand { get; }
}
