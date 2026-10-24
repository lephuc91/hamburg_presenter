using System;
using System.ComponentModel;
using Pro.DO.Audio;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;

namespace ProPresenter.DO.Audio;

public interface IAudioInput : INotifyPropertyChanged
{
	BehaviorMode BehaviorMode { get; set; }

	string Description { get; set; }

	string DefaultDescription { get; }

	int Index { get; set; }

	Guid ID { get; }

	ILinkedVideoInputs LinkedVideoInputs { get; }

	AudioSource Source { get; }

	string LongName { get; }

	event System.Action DataModified;

	void Deserialize(Pro.SerializationInterop.RVProtoData.AudioInput protoAudioInput, IAudioInputDeviceCollection audioDevices, IVideoInputDeviceCollection videoDevices);

	Pro.SerializationInterop.RVProtoData.AudioInput Serialize();

	void SetBehaviorMode(Pro.SerializationInterop.RVProtoData.AudioInput.Types.BehaviorMode protoBehaviorMode);
}
