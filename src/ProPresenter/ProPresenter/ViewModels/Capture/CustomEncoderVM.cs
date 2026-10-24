using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.DO.Capture;
using ProPresenter.UI.ViewModels.Capture;

namespace ProPresenter.ViewModels.Capture;

public class CustomEncoderVM : ObservableObject, ICustomEncoderVM, INotifyPropertyChanged
{
	public static readonly IEnumerable<FrameRate> RtmpFrameRates = new FrameRate[4]
	{
		FrameRate._25,
		FrameRate._30,
		FrameRate._50,
		FrameRate._60
	};

	public static readonly IEnumerable<uint> RtmpVideoBitrates = new uint[18]
	{
		200000u, 400000u, 600000u, 800000u, 1000000u, 1500000u, 2000000u, 2500000u, 3000000u, 3500000u,
		4000000u, 4500000u, 6000000u, 8000000u, 10000000u, 12000000u, 16000000u, 20000000u
	};

	public static readonly IEnumerable<FrameRate> DiskFrameRates = new FrameRate[7]
	{
		FrameRate._24,
		FrameRate._25,
		FrameRate._2997,
		FrameRate._30,
		FrameRate._50,
		FrameRate._5994,
		FrameRate._60
	};

	public static readonly IEnumerable<uint> DiskVideoBitrates = new uint[16]
	{
		1000000u, 1500000u, 2000000u, 4000000u, 6000000u, 8000000u, 10000000u, 12000000u, 14000000u, 16000000u,
		18000000u, 20000000u, 25000000u, 30000000u, 35000000u, 40000000u
	};

	private readonly ICapturePrompt _capturePrompt;

	private readonly IEncoderValidator _validator;

	[ObservableProperty]
	private uint _width;

	[ObservableProperty]
	private uint _height;

	[ObservableProperty]
	private FrameRate _frameRate;

	[ObservableProperty]
	private uint _videoBitrate;

	[ObservableProperty]
	private uint _audioBitrate;

	[ObservableProperty]
	private IEnumerable<FrameRate> _frameRates = Enumerable.Empty<FrameRate>();

	[ObservableProperty]
	private IEnumerable<uint> _videoBitrates = Enumerable.Empty<uint>();

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? createEncoderCommand;

	public IEnumerable<uint> AudioBitrates => new uint[8] { 24000u, 48000u, 64000u, 96000u, 128000u, 192000u, 256000u, 320000u };

	public bool IsValidationTakingTime => _validator.IsValidationTakingTime;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public uint Width
	{
		get
		{
			return _width;
		}
		set
		{
			if (!EqualityComparer<uint>.Default.Equals(_width, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Width);
				_width = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Width);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public uint Height
	{
		get
		{
			return _height;
		}
		set
		{
			if (!EqualityComparer<uint>.Default.Equals(_height, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Height);
				_height = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Height);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public FrameRate FrameRate
	{
		get
		{
			return _frameRate;
		}
		set
		{
			if (!EqualityComparer<FrameRate>.Default.Equals(_frameRate, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.FrameRate);
				_frameRate = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.FrameRate);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public uint VideoBitrate
	{
		get
		{
			return _videoBitrate;
		}
		set
		{
			if (!EqualityComparer<uint>.Default.Equals(_videoBitrate, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.VideoBitrate);
				_videoBitrate = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.VideoBitrate);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public uint AudioBitrate
	{
		get
		{
			return _audioBitrate;
		}
		set
		{
			if (!EqualityComparer<uint>.Default.Equals(_audioBitrate, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AudioBitrate);
				_audioBitrate = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AudioBitrate);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IEnumerable<FrameRate> FrameRates
	{
		get
		{
			return _frameRates;
		}
		[MemberNotNull("_frameRates")]
		set
		{
			if (!EqualityComparer<IEnumerable<FrameRate>>.Default.Equals(_frameRates, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.FrameRates);
				_frameRates = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.FrameRates);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IEnumerable<uint> VideoBitrates
	{
		get
		{
			return _videoBitrates;
		}
		[MemberNotNull("_videoBitrates")]
		set
		{
			if (!EqualityComparer<IEnumerable<uint>>.Default.Equals(_videoBitrates, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.VideoBitrates);
				_videoBitrates = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.VideoBitrates);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand CreateEncoderCommand => createEncoderCommand ?? (createEncoderCommand = new AsyncRelayCommand(CreateEncoder, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	public CustomEncoderVM(ICapturePrompt capturePrompt, IEncoderValidator validator)
	{
		_capturePrompt = capturePrompt;
		_validator = validator;
		_validator.PropertyChanged += Validator_PropertyChanged;
	}

	private void Validator_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsValidationTakingTime")
		{
			OnPropertyChanged("IsValidationTakingTime");
		}
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	private async Task CreateEncoder()
	{
		Encoder encoder = new Encoder(Width, Height, FrameRate, VideoBitrate, AudioBitrate);
		if (await _validator.ValidateEncoderAsync(encoder, CancellationToken.None) || _capturePrompt.ShowEncoderInvalid())
		{
			_capturePrompt.CloseCustomEncoderDialog();
		}
	}

	public bool TryGetCustomEncoder(DestinationType destinationType, [NotNullWhen(true)] out Encoder? encoder, Encoder? encoderValue = null)
	{
		ResetDefaults(destinationType, encoderValue);
		bool flag = _capturePrompt.ShowCustomEncoderDialog(this);
		encoder = (flag ? new Encoder(Width, Height, FrameRate, VideoBitrate, AudioBitrate) : null);
		return flag;
	}

	private void ResetDefaults(DestinationType destinationType, Encoder? defaultValue = null)
	{
		Encoder encoder = new Encoder();
		switch (destinationType)
		{
		case DestinationType.Disk:
			FrameRates = DiskFrameRates;
			VideoBitrates = DiskVideoBitrates;
			encoder = defaultValue ?? Encoder.DiskDefault;
			break;
		case DestinationType.RTMP:
			FrameRates = RtmpFrameRates;
			VideoBitrates = RtmpVideoBitrates;
			encoder = defaultValue ?? Encoder.RtmpDefault;
			break;
		}
		Width = encoder.VideoWidth;
		Height = encoder.VideoHeight;
		FrameRate = encoder.FrameRate;
		VideoBitrate = encoder.VideoBitrate;
		AudioBitrate = encoder.AudioBitrate;
	}
}
