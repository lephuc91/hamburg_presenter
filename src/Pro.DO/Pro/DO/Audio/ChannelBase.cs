using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Time;

namespace Pro.DO.Audio;

public abstract class ChannelBase : NotifyPropertyChangedBase, IChannel, INotifyPropertyChanged
{
	private double _level;

	private bool _muteActive;

	private bool _soloActive;

	private bool _testActive;

	private TimeSlice _delay;

	public int Index { get; set; }

	public abstract string Name { get; set; }

	public abstract bool CanRename { get; }

	public double Level
	{
		get
		{
			return _level;
		}
		set
		{
			SetValue("Level", ref _level, value, OnDataModified);
		}
	}

	public virtual bool MuteActive
	{
		get
		{
			return _muteActive;
		}
		set
		{
			SetValue("MuteActive", ref _muteActive, value, OnDataModified);
		}
	}

	public virtual bool SoloActive
	{
		get
		{
			return _soloActive;
		}
		set
		{
			SetValue("SoloActive", ref _soloActive, value, OnDataModified);
		}
	}

	public virtual bool TestActive
	{
		get
		{
			return _testActive;
		}
		set
		{
			SetValue("TestActive", ref _testActive, value, OnDataModified);
		}
	}

	public virtual TimeSlice Delay
	{
		get
		{
			return _delay;
		}
		set
		{
			SetValue("Delay", ref _delay, value, OnDataModified);
		}
	}

	public event Action? DataModified;

	protected void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
