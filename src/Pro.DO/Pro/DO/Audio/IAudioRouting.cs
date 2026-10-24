using System;
using System.ComponentModel;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Audio;

public interface IAudioRouting<I, O> : INotifyPropertyChanged where I : IChannel, new() where O : IChannel, new()
{
	bool InputToOutput { get; }

	int ChannelCount { get; }

	ChannelSet<DeviceChannel> ChannelSet { get; }

	DeviceChannel MasterChannel { get; }

	AudioMap<I, O> ChannelMap { get; }

	event System.Action? DataModified;

	DigitalAudio.Types.Device.Types.Routing Serialize();

	void Deserialize(DigitalAudio.Types.Device.Types.Routing? protoAudioRouting);

	ObjectBinder<IAudioRouting<I, O>, IDigitalAudio.Types.IDevice.Types.IRouting> Bind(IUiScheduler uiScheduler, IEntityFactory entityFactory, IDigitalAudio.Types.IDevice.Types.IRouting right);
}
