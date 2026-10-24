using System;
using System.Collections.ObjectModel;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Localization;
using ProPresenterCore.ProCore.Interop;

namespace Pro.ssAPI.Devices;

internal abstract class AudioDevice : NotifyPropertyChangedBase
{
	private int _channelCount;

	private readonly ObservableCollection<AudioChannelLevel> _channelLevels = new ObservableCollection<AudioChannelLevel>();

	public string UUID { get; }

	public string Name { get; }

	public AudioDeviceType DeviceType { get; }

	public int ChannelCount
	{
		get
		{
			return _channelCount;
		}
		internal set
		{
			if (value != _channelCount)
			{
				_channelCount = value;
				SyncChannelLevels();
				this.ChannelCountChanged?.Invoke();
			}
		}
	}

	public ImmutableObservableCollection<IAudioChannelLevel> ChannelLevels { get; }

	public event Action? ChannelCountChanged;

	protected AudioDevice(ProAudioDevice device)
	{
		UUID = device.DeviceID;
		Name = ((device.DeviceID == "System Setting") ? LocalizedStrings.Get("SETTINGS_AUDIO_SYSTEM_SETTING_DEVICE") : device.Name);
		DeviceType = (AudioDeviceType)device.AudioDeviceType;
		ChannelCount = device.ChannelCount;
		ChannelLevels = new ImmutableObservableCollection<IAudioChannelLevel>(_channelLevels.ConvertOneWay<IAudioChannelLevel, AudioChannelLevel>());
		SyncChannelLevels();
	}

	internal void UpdateLevels(ProAudioInputStatus inputStatus)
	{
		if (inputStatus == null)
		{
			throw new ArgumentNullException("inputStatus");
		}
		for (int i = 0; i < _channelCount && i < inputStatus.ChannelCount; i++)
		{
			AudioChannelLevel audioChannelLevel = _channelLevels[i];
			audioChannelLevel.RMS = inputStatus.RmsVolume[i];
			audioChannelLevel.Peak = inputStatus.PeakVolume[i];
			audioChannelLevel.Clip = inputStatus.IsClipped[i] != 0;
		}
	}

	private void SyncChannelLevels()
	{
		while (_channelLevels.Count > ChannelCount)
		{
			_channelLevels.RemoveAt(_channelLevels.Count - 1);
		}
		while (ChannelCount > _channelLevels.Count)
		{
			_channelLevels.Add(new AudioChannelLevel());
		}
	}
}
