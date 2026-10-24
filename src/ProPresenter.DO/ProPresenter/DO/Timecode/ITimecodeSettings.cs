using System;
using System.ComponentModel;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Timecode;

public interface ITimecodeSettings : INotifyPropertyChanged
{
	int Channel { get; set; }

	string DeviceID { get; set; }

	TimecodeFormat Format { get; set; }

	bool IsActive { get; set; }

	double Offset { get; set; }

	Guid Playlist { get; set; }

	event System.Action DataModified;

	void Deserialize(Pro.SerializationInterop.RVProtoData.TimecodeSettings settings);

	Pro.SerializationInterop.RVProtoData.TimecodeSettings Serialize();
}
