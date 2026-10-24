using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Google.Protobuf.Collections;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public interface IStreamCollection : INotifyEnumerableChanged<IStream>, IEnumerable<IStream>, IEnumerable, INotifyCollectionChanged
{
	IStreamFactory Factory { get; }

	event System.Action DataModified;

	void AddStream(IStream stream);

	void InsertStream(IStream stream, int index);

	void Clear();

	void Deserialize(RepeatedField<Recording.Types.Stream> protoStreams);

	void RemoveStream(IStream stream);

	void Reset();

	IEnumerable<Recording.Types.Stream> Serialize();

	IReadOnlyObjectBinder<IStreamCollection, IComplexCollection<IRecording.Types.IStream>> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IComplexCollection<IRecording.Types.IStream> right);
}
