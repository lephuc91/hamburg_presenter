using System.ComponentModel;
using Pro.Common.Components;
using Pro.ssAPI.Devices;

namespace Pro.ssAPI;

internal class AudioChannelLevel : NotifyPropertyChangedBase, IAudioChannelLevel, INotifyPropertyChanged
{
	private double _rms = -100.0;

	private double _peak = -100.0;

	private bool _clip;

	public double RMS
	{
		get
		{
			return _rms;
		}
		set
		{
			SetValue("RMS", ref _rms, value);
		}
	}

	public double Peak
	{
		get
		{
			return _peak;
		}
		set
		{
			SetValue("Peak", ref _peak, value);
		}
	}

	public bool Clip
	{
		get
		{
			return _clip;
		}
		set
		{
			SetValue("Clip", ref _clip, value);
		}
	}
}
