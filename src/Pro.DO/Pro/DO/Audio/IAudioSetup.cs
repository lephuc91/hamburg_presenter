using System;
using System.ComponentModel;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Audio;

public interface IAudioSetup : INotifyPropertyChanged
{
	int BusCount { get; set; }

	ChannelSet<Bus> Buses { get; }

	bool DisableMainOutputDevice { get; set; }

	IAudioDestination MainOutputDestination { get; }

	TimeSlice MainDelay { get; set; }

	bool MonitorOnMains { get; set; }

	IAudioDestination MonitorOutputDestination { get; }

	bool SdiNdiOutputActive { get; set; }

	IAudioDestination SdiNdiOutputDestination { get; }

	TimeSlice SdiNdiDelay { get; set; }

	event System.Action DataModified;

	event System.Action LevelChanged;

	void Deserialize(Pro.SerializationInterop.RVProtoData.Audio.Types.SettingsDocument protoAudioSettings);

	void Deserialize(DigitalAudio.Types.Setup protoAudioSetup);

	DigitalAudio.Types.Setup Serialize();

	IReadOnlyObjectBinder<AudioSetup, IDigitalAudio.Types.ISetup> Bind(IUiScheduler uiScheduler, IEntityFactory entityFactory, IDigitalAudio.Types.ISetup? right);
}
