using System;
using System.ComponentModel;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop;

namespace Pro.ssAPI.Devices;

internal class AirCastVideoInputDevice : VideoInputDevice, IAirCastVideoInputDevice, IVideoInputDevice, IDevice, INotifyPropertyChanged
{
	private const string HardcodedAirCastName = "AirCast";

	private const string HardcodedAirCastModelName = "AirCast";

	private string? _serviceName = "ProPresenter AirCast";

	private string? _password;

	private bool _enabled;

	public string? ServiceName
	{
		get
		{
			return _serviceName;
		}
		set
		{
			SetValue("ServiceName", ref _serviceName, value, OnDataModified);
		}
	}

	public string? Password
	{
		get
		{
			return _password;
		}
		set
		{
			SetValue("Password", ref _password, value, OnDataModified);
		}
	}

	public bool PasswordEnabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			SetValue("PasswordEnabled", ref _enabled, value, OnDataModified);
		}
	}

	public event System.Action? DataModified;

	internal AirCastVideoInputDevice(ProVideoInputDevice videoInputDevice)
		: base(videoInputDevice, VideoDeviceType.Aircast)
	{
		base.UUID = Guid.NewGuid().ToString();
		base.Name = "AirCast";
		base.ModelName = "AirCast";
		base.DeviceName = "AirCast";
		base.SupportsAudio = true;
		base.AudioChannelCount = 2;
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public void Update(ProVideoInputDevice device)
	{
		Init(device);
	}

	public void Deserialize(Media.Types.VideoDevice.Types.AirCast protoAirCast, string deviceRenderID)
	{
		base.UUID = deviceRenderID;
		ServiceName = protoAirCast.ServiceName;
		Password = protoAirCast.Password;
		PasswordEnabled = protoAirCast.PasswordEnabled;
	}
}
