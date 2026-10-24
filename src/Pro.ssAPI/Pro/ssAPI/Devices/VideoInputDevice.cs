using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using ProPresenterCore.ProCore.Interop;

namespace Pro.ssAPI.Devices;

[DebuggerDisplay("{Name,nq}")]
internal class VideoInputDevice : VideoDevice, IVideoInputDevice, IDevice, INotifyPropertyChanged
{
	private sealed class DummyMode : IVideoMode
	{
		public string Name { get; set; } = string.Empty;

		public Vector2<int> Size => Vector2<int>.Zero;

		public float Frequency => 0f;

		public int ModeIndex => 0;

		public bool Interlaced => false;
	}

	private sealed class AudioChannelLevelCollection : ObservableCollection<AudioChannelLevel>, IImmutableObservableCollection<IAudioChannelLevel>, IReadOnlyList<IAudioChannelLevel>, IEnumerable<IAudioChannelLevel>, IEnumerable, IReadOnlyCollection<IAudioChannelLevel>, INotifyEnumerableChanged<IAudioChannelLevel>, INotifyCollectionChanged
	{
		IAudioChannelLevel IReadOnlyList<IAudioChannelLevel>.this[int index] => base[index];

		int IReadOnlyCollection<IAudioChannelLevel>.Count => base.Count;

		bool IImmutableObservableCollection<IAudioChannelLevel>.Contains(IAudioChannelLevel value)
		{
			if (value is AudioChannelLevel item)
			{
				return Contains(item);
			}
			return false;
		}

		IEnumerator<IAudioChannelLevel> IEnumerable<IAudioChannelLevel>.GetEnumerator()
		{
			return GetEnumerator();
		}

		int IImmutableObservableCollection<IAudioChannelLevel>.IndexOf(IAudioChannelLevel item)
		{
			if (item is AudioChannelLevel item2)
			{
				return IndexOf(item2);
			}
			return -1;
		}
	}

	private DummyMode? _dummyMode;

	private readonly AudioChannelLevelCollection _channelLevels = new AudioChannelLevelCollection();

	private bool _isActive;

	private bool _hasSignal;

	private int _modeIndex;

	private bool _supportsAutoModeSelection;

	private bool _supportsAudio;

	private int _audioChannelCount;

	private bool _supportsAlphaChannel;

	private bool _shouldAutoMap;

	private ColorFormat _colorFormat;

	public VideoModeCollection Modes { get; } = new VideoModeCollection();

	public IVideoMode? CurrentMode => Modes?.FirstOrDefault((IVideoMode mode) => mode.ModeIndex == ModeIndex) ?? _dummyMode;

	internal int ModeIndex
	{
		get
		{
			return _modeIndex;
		}
		set
		{
			SetValue("ModeIndex", ref _modeIndex, value, (Action)delegate
			{
				OnPropertyChanged("CurrentMode");
			}, (Predicate<int>?)null, referenceComparison: false);
		}
	}

	public bool HasSignal
	{
		get
		{
			return _hasSignal;
		}
		internal set
		{
			SetValue("HasSignal", ref _hasSignal, value);
		}
	}

	public bool IsActive
	{
		get
		{
			return _isActive;
		}
		internal set
		{
			SetValue("IsActive", ref _isActive, value);
		}
	}

	public bool SupportsAutoModeSelection
	{
		get
		{
			return _supportsAutoModeSelection;
		}
		internal set
		{
			SetValue("SupportsAutoModeSelection", ref _supportsAutoModeSelection, value);
		}
	}

	public bool SupportsAudio
	{
		get
		{
			return _supportsAudio;
		}
		internal set
		{
			SetValue("SupportsAudio", ref _supportsAudio, value);
		}
	}

	public int AudioChannelCount
	{
		get
		{
			return _audioChannelCount;
		}
		internal set
		{
			SetValue("AudioChannelCount", ref _audioChannelCount, value);
		}
	}

	public IImmutableObservableCollection<IAudioChannelLevel> ChannelLevels => _channelLevels;

	public bool SupportsAlphaChannel
	{
		get
		{
			return _supportsAlphaChannel;
		}
		set
		{
			SetValue("SupportsAlphaChannel", ref _supportsAlphaChannel, value);
		}
	}

	public bool ShouldAutoMap
	{
		get
		{
			return _shouldAutoMap;
		}
		set
		{
			SetValue("ShouldAutoMap", ref _shouldAutoMap, value);
		}
	}

	public VideoDeviceType Type { get; }

	public ColorFormat ColorFormat
	{
		get
		{
			return _colorFormat;
		}
		set
		{
			SetValue("SupportsAlphaChannel", ref _colorFormat, value);
		}
	}

	public VideoInputDevice(ProVideoInputDevice nativeDevice, VideoDeviceType type = VideoDeviceType.Generic)
		: base(nativeDevice.DeviceID, nativeDevice.Name, nativeDevice.DeviceName, nativeDevice.VendorID, nativeDevice.ModelName)
	{
		Init(nativeDevice);
		Type = type;
	}

	protected void Init(ProVideoInputDevice nativeDevice)
	{
		Modes.Clear();
		foreach (ProVideoMode mode in nativeDevice.Modes)
		{
			if (mode.Width > 0 && mode.Height > 0)
			{
				Modes.AddMode(mode);
			}
		}
		if (Modes.Empty())
		{
			_dummyMode = new DummyMode();
		}
		OnPropertyChanged("Modes");
		OnPropertyChanged("CurrentMode");
		ModeIndex = nativeDevice.CurrentMode;
		IsActive = nativeDevice.IsActive;
		HasSignal = nativeDevice.HasSignal;
		SupportsAutoModeSelection = nativeDevice.SupportsAutoModeSelection;
		SupportsAudio = nativeDevice.SupportsAudio;
		AudioChannelCount = nativeDevice.AudioChannelCount;
		SupportsAlphaChannel = nativeDevice.SupportsAlphaKey;
		while (AudioChannelCount > _channelLevels.Count)
		{
			_channelLevels.Add(new AudioChannelLevel());
		}
		OnPropertyChanged("ChannelLevels");
	}

	internal void UpdateLevels(ProAudioInputStatus inputStatus)
	{
		if (inputStatus == null)
		{
			throw new ArgumentNullException("inputStatus");
		}
		for (int i = 0; i < AudioChannelCount && i < inputStatus.ChannelCount; i++)
		{
			AudioChannelLevel audioChannelLevel = _channelLevels[i];
			audioChannelLevel.RMS = inputStatus.RmsVolume[i];
			audioChannelLevel.Peak = inputStatus.PeakVolume[i];
			audioChannelLevel.Clip = inputStatus.IsClipped[i] != 0;
		}
	}

	internal void UpdateStatus(ProVideoInputStatus inputStatus)
	{
		if (_dummyMode != null)
		{
			_dummyMode.Name = inputStatus.ModeDescription;
		}
		IsActive = true;
		HasSignal = inputStatus.HasSignal;
		ModeIndex = inputStatus.CurrentMode;
		ColorFormat = inputStatus.ColorFormat.ToColorFormat();
	}
}
