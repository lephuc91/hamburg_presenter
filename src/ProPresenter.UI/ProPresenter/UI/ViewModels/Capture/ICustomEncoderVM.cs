using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.DO.Capture;

namespace ProPresenter.UI.ViewModels.Capture;

public interface ICustomEncoderVM : INotifyPropertyChanged
{
	uint Width { get; }

	uint Height { get; }

	FrameRate FrameRate { get; }

	uint VideoBitrate { get; }

	uint AudioBitrate { get; }

	IEnumerable<FrameRate> FrameRates { get; }

	IEnumerable<uint> VideoBitrates { get; }

	IEnumerable<uint> AudioBitrates { get; }

	bool IsValidationTakingTime { get; }

	IAsyncRelayCommand CreateEncoderCommand { get; }

	bool TryGetCustomEncoder(DestinationType destinationType, [NotNullWhen(true)] out Encoder? encoder, Encoder? encoderValue = null);
}
