using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.DO.Audio;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public interface IStream : INotifyEnumerableChanged<IDestination>, IEnumerable<IDestination>, IEnumerable, INotifyCollectionChanged, ICloneable<IStream>, INotifyPropertyChanged
{
	AudioMap<Bus, StreamAudioChannel> AudioOutputMap { get; }

	DestinationType DestinationType { get; set; }

	StreamEncoder Encoder { get; }

	Guid ID { get; }

	ChannelSet<StreamAudioChannel> OutputChannelSet { get; }

	Guid ScreenID { get; set; }

	string ScreenName { get; set; }

	event System.Action DataModified;

	event Action<DestinationType> DestinationChanged;

	void AddDestination(IDestination destination);

	void Clear();

	void Deserialize(Recording.Types.Stream protoStream);

	void RemoveDestination(IDestination destination);

	Recording.Types.Stream Serialize();
}
