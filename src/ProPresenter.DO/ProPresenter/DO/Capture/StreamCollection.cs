using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Google.Protobuf.Collections;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public class StreamCollection : ImmutableObservableCollection<IStream>, IStreamCollection, INotifyEnumerableChanged<IStream>, IEnumerable<IStream>, IEnumerable, INotifyCollectionChanged
{
	private readonly IStreamFactory _streamFactory;

	public IStreamFactory Factory => _streamFactory;

	public event System.Action? DataModified;

	public IReadOnlyObjectBinder<IStreamCollection, IComplexCollection<IRecording.Types.IStream>> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IComplexCollection<IRecording.Types.IStream> right)
	{
		ObjectBinder<StreamCollection, IComplexCollection<IRecording.Types.IStream>> objectBinder = new ObjectBinder<StreamCollection, IComplexCollection<IRecording.Types.IStream>>(this, right);
		objectBinder.Bind((StreamCollection l) => l.WhenCollectionChanges(), (IComplexCollection<IRecording.Types.IStream> r) => r.WhenCollectionChanges, delegate(StreamCollection l, IComplexCollection<IRecording.Types.IStream> r)
		{
			r.SynchronizeFrom(l.OfType<Stream>().ToList(), (Stream m, IRecording.Types.IStream e) => m.ID == e.Id.Value, delegate(Stream m)
			{
				IRecording.Types.IStream stream = entityFactory.Create<IRecording.Types.IStream>();
				ObjectBinder<Stream, IRecording.Types.IStream> objectBinder2 = Stream.CreateBinder(scheduler, entityFactory, m, stream);
				objectBinder2.InitializeRightFromLeft();
				stream.RegisterLinkedDisposable(objectBinder2);
				return stream;
			});
		}, delegate(IComplexCollection<IRecording.Types.IStream> r, StreamCollection l)
		{
			r.Items.SynchronizeTo(l, (IRecording.Types.IStream e, IStream m) => m.ID == e.Id.Value, delegate(IRecording.Types.IStream e, int i)
			{
				IStream stream2 = l.Factory.CreateStream();
				ObjectBinder<Stream, IRecording.Types.IStream> objectBinder3 = Stream.CreateBinder(scheduler, entityFactory, (Stream)stream2, e);
				objectBinder3.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(objectBinder3);
				l.InsertStream(stream2, i);
			}, l.MoveStream, delegate(int i)
			{
				IStream stream3 = l.ElementAtOrDefault(i);
				if (stream3 != null)
				{
					l.RemoveStream(stream3);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public StreamCollection(IStreamFactory streamFactory)
		: this(streamFactory, Array.Empty<IStream>())
	{
	}

	public StreamCollection(IStreamFactory streamFactory, IEnumerable<IStream> items)
		: base(items)
	{
		_streamFactory = streamFactory;
		Reset();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public void Clear()
	{
		base.Collection.ToArray().ForEach(RemoveStream);
	}

	public void AddStream(IStream stream)
	{
		InsertStream(stream, base.Count);
	}

	public void InsertStream(IStream stream, int index)
	{
		if (stream != null)
		{
			stream.DataModified += OnDataModified;
			base.Collection.Insert(index, stream);
			OnDataModified();
		}
	}

	public void RemoveStream(IStream stream)
	{
		if (stream != null)
		{
			stream.DataModified -= OnDataModified;
			base.Collection.Remove(stream);
			OnDataModified();
		}
	}

	public void MoveStream(int fromIndex, int toIndex)
	{
		base.Collection.Move(fromIndex, toIndex);
		OnDataModified();
	}

	public void Reset()
	{
		Clear();
		AddStream(_streamFactory.CreateStream());
	}

	public void Deserialize(RepeatedField<Recording.Types.Stream> protoStreams)
	{
		base.Collection.DeserializeCollection(protoStreams, (IStream m, Recording.Types.Stream p) => m.ID == p.Id.ToGuid(), (Recording.Types.Stream p) => _streamFactory.CreateStream(), AddStream, RemoveStream, delegate(IStream m, Recording.Types.Stream p)
		{
			m.DataModified -= OnDataModified;
			m.Deserialize(p);
			m.DataModified += OnDataModified;
		});
	}

	public IEnumerable<Recording.Types.Stream> Serialize()
	{
		return base.Collection.Select((IStream s) => s.Serialize()).ToArray();
	}
}
