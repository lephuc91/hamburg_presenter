using System;
using System.ComponentModel;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop;

namespace Pro.ssAPI.Devices;

public interface IAirCastVideoInputDevice : IVideoInputDevice, IDevice, INotifyPropertyChanged
{
	string? ServiceName { get; set; }

	string? Password { get; set; }

	bool PasswordEnabled { get; set; }

	event System.Action? DataModified;

	void Deserialize(Media.Types.VideoDevice.Types.AirCast protoAirCast, string deviceRenderID);

	void Update(ProVideoInputDevice device);
}
