using System;
using System.ComponentModel;
using Pro.Common.ObjectBinding;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public interface IDestination : INotifyPropertyChanged
{
	DestinationType Type { get; }

	event System.Action DataModified;

	Recording.Types.Stream.Types.Destination Serialize();

	void Deserialize(Recording.Types.Stream.Types.Destination protoDestination);

	ObjectBinder<IDestination, IRecording.Types.IStream.Types.IDestination> Bind(IEntityFactory entityFactory, IRecording.Types.IStream.Types.IDestination entity);
}
