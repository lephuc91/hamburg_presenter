using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Timecode;

public class TimecodeSettings : NotifyPropertyChangedBase, ITimecodeSettings, INotifyPropertyChanged
{
	private string? _deviceID;

	private int _channel = 1;

	private TimecodeFormat _format;

	private double _offset;

	private Guid _playlist;

	private bool _isActive;

	public string DeviceID
	{
		get
		{
			return _deviceID ?? string.Empty;
		}
		set
		{
			SetValue("DeviceID", ref _deviceID, value, OnDataModified);
		}
	}

	public int Channel
	{
		get
		{
			return _channel;
		}
		set
		{
			SetValue("Channel", ref _channel, value, OnDataModified);
		}
	}

	public TimecodeFormat Format
	{
		get
		{
			return _format;
		}
		set
		{
			SetValue("Format", ref _format, value, OnDataModified);
		}
	}

	public double Offset
	{
		get
		{
			return _offset;
		}
		set
		{
			SetValue("Offset", ref _offset, value, OnDataModified);
		}
	}

	public Guid Playlist
	{
		get
		{
			return _playlist;
		}
		set
		{
			SetValue("Playlist", ref _playlist, value, OnDataModified);
		}
	}

	public bool IsActive
	{
		get
		{
			return _isActive;
		}
		set
		{
			SetValue("IsActive", ref _isActive, value, OnDataModified);
		}
	}

	public event System.Action? DataModified;

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public Pro.SerializationInterop.RVProtoData.TimecodeSettings Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.TimecodeSettings
		{
			DeviceIdentifier = (DeviceID ?? string.Empty),
			Channel = Channel,
			Format = Format.ToProtoTimecodeFormat(),
			Offset = Offset,
			PlaylistIdentifier = Playlist.ToUUID(),
			IsActive = IsActive
		};
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.TimecodeSettings? settings)
	{
		if (settings != null)
		{
			DeviceID = settings.DeviceIdentifier;
			Channel = settings.Channel;
			Format = settings.Format.ToTimecodeFormat();
			Offset = settings.Offset;
			Playlist = settings.PlaylistIdentifier.ToGuid();
			IsActive = settings.IsActive;
		}
	}
}
