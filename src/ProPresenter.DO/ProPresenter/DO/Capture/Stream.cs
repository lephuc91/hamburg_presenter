using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Audio;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public class Stream : ImmutableObservableCollection<IDestination>, IStream, INotifyEnumerableChanged<IDestination>, IEnumerable<IDestination>, IEnumerable, INotifyCollectionChanged, ICloneable<IStream>, INotifyPropertyChanged
{
	private const int DefaultOutputChannelCount = 2;

	private readonly ChannelSet<Bus> _buses;

	private readonly IDestinationFactory _destinationFactory;

	private Guid _screenID = Guid.Empty;

	private string _screenName = string.Empty;

	private DestinationType _destinationType = DestinationType.Resi;

	public Guid ID { get; private set; } = Guid.NewGuid();

	public Guid ScreenID
	{
		get
		{
			return _screenID;
		}
		set
		{
			SetValue("ScreenID", ref _screenID, value, OnDataModified);
		}
	}

	public string ScreenName
	{
		get
		{
			return _screenName;
		}
		set
		{
			SetValue("ScreenName", ref _screenName, value, OnDataModified);
		}
	}

	public DestinationType DestinationType
	{
		get
		{
			return _destinationType;
		}
		set
		{
			SetValue("DestinationType", ref _destinationType, value, OnDestinationTypeChanged);
		}
	}

	public StreamEncoder Encoder { get; } = new StreamEncoder();

	public ChannelSet<StreamAudioChannel> OutputChannelSet { get; } = new ChannelSet<StreamAudioChannel>();

	public AudioMap<Bus, StreamAudioChannel> AudioOutputMap { get; }

	public event System.Action? DataModified;

	public event Action<DestinationType>? DestinationChanged;

	public static ObjectBinder<Stream, IRecording.Types.IStream> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, Stream left, IRecording.Types.IStream right)
	{
		ObjectBinder<AudioMap<Bus, StreamAudioChannel>, IRecording.Types.IStream> audioMapBinder = AudioMap<Bus, StreamAudioChannel>.CreateBinder(scheduler, entityFactory, left.AudioOutputMap, right, inputToOutput: false);
		ObjectBinder<Stream, IRecording.Types.IStream> objectBinder = new ObjectBinder<Stream, IRecording.Types.IStream>(left, right);
		objectBinder.Bind((Stream l) => l.WhenPropertyChanges("ID"), (IRecording.Types.IStream r) => r.Id.WhenValueChanges, delegate(Stream l, IRecording.Types.IStream r)
		{
			r.Id.Set(l.ID);
		}, delegate(IRecording.Types.IStream r, Stream l)
		{
			l.ID = r.Id.Value;
		}).Bind((Stream l) => l.WhenPropertyChanges("Encoder"), (IRecording.Types.IStream r) => r.Encoder.WhenValueChanges, delegate(Stream l, IRecording.Types.IStream r)
		{
			IRecording.Types.IStream.Types.IEncoder encoder = entityFactory.Create<IRecording.Types.IStream.Types.IEncoder>();
			r.Encoder.Set(encoder);
			ObjectBinder<StreamEncoder, IRecording.Types.IStream.Types.IEncoder> objectBinder2 = StreamEncoder.CreateBinder(scheduler, l.Encoder, encoder);
			objectBinder2.InitializeRightFromLeft();
			encoder.RegisterLinkedDisposable(objectBinder2);
		}, delegate(IRecording.Types.IStream r, Stream l)
		{
			ObjectBinder<StreamEncoder, IRecording.Types.IStream.Types.IEncoder> objectBinder3 = StreamEncoder.CreateBinder(scheduler, l.Encoder, r.Encoder.Value);
			objectBinder3.InitializeLeftFromRight();
			r.Encoder.Value.RegisterLinkedDisposable(objectBinder3);
		}).Bind((Stream l) => l.WhenCollectionChanges(), (IRecording.Types.IStream r) => r.Destinations.WhenCollectionChanges, delegate(Stream l, IRecording.Types.IStream r)
		{
			List<IRecording.Types.IStream.Types.IDestination> list = new List<IRecording.Types.IStream.Types.IDestination>();
			foreach (IDestination item in l)
			{
				IRecording.Types.IStream.Types.IDestination destination = entityFactory.Create<IRecording.Types.IStream.Types.IDestination>();
				ObjectBinder<IDestination, IRecording.Types.IStream.Types.IDestination> disposable = item.Bind(entityFactory, destination);
				destination.RegisterLinkedDisposable(disposable);
				list.Add(destination);
			}
			r.Destinations.Reset(list);
		}, delegate(IRecording.Types.IStream r, Stream l)
		{
			l.Clear();
			foreach (IRecording.Types.IStream.Types.IDestination item2 in r.Destinations.Items)
			{
				IDestination destination2 = l._destinationFactory.Create(ToDestinationType(item2));
				ObjectBinder<IDestination, IRecording.Types.IStream.Types.IDestination> disposable2 = destination2.Bind(entityFactory, item2);
				item2.RegisterLinkedDisposable(disposable2);
				l.AddDestination(destination2);
			}
		}, null, scheduler.Scheduler)
			.Bind((Stream l) => l.WhenPropertyChanges("ScreenID").Merge(l.WhenPropertyChanges("ScreenName")), (IRecording.Types.IStream r) => r.Source.WhenAnyValueChanges.ToUnit(), delegate(Stream l, IRecording.Types.IStream r)
			{
				IRecording.Types.IStream.Types.ISource.IOutputScreen outputScreen = r.Source as IRecording.Types.IStream.Types.ISource.IOutputScreen;
				if (outputScreen == null)
				{
					outputScreen = entityFactory.Create<IRecording.Types.IStream.Types.ISource.IOutputScreen>();
					r.Source.Set(outputScreen);
				}
				outputScreen.Value.ScreenId.Set(l.ScreenID);
				outputScreen.Value.ScreenName.Set(l.ScreenName);
			}, delegate(IRecording.Types.IStream r, Stream l)
			{
				if (r.Source is IRecording.Types.IStream.Types.ISource.IOutputScreen outputScreen2)
				{
					l.ScreenID = outputScreen2.Value.ScreenId.ToGuidOrEmpty();
					l.ScreenName = outputScreen2.Value.ScreenName.Value ?? string.Empty;
				}
			})
			.DoOnInitializeLeftFromRight(audioMapBinder.InitializeLeftFromRight)
			.DoOnInitializeRightFromLeft(audioMapBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(() => new global::_003C_003Ez__ReadOnlySingleElementList<IDisposable>(audioMapBinder));
		return objectBinder;
	}

	private static DestinationType ToDestinationType(IRecording.Types.IStream.Types.IDestination destination)
	{
		if (destination._Destination.Value is IRecording.Types.IStream.Types.IDestination.Types.IDestination.IDisk)
		{
			return DestinationType.Disk;
		}
		if (destination._Destination.Value is IRecording.Types.IStream.Types.IDestination.Types.IDestination.IResi)
		{
			return DestinationType.Resi;
		}
		if (destination._Destination.Value is IRecording.Types.IStream.Types.IDestination.Types.IDestination.IRtmp)
		{
			return DestinationType.RTMP;
		}
		return DestinationType.Disk;
	}

	public Stream(ChannelSet<Bus> buses, IDestinationFactory destinationFactory)
	{
		_buses = buses;
		_destinationFactory = destinationFactory;
		SetDestination(DestinationType.Resi);
		Encoder.DataModified += OnDataModified;
		OutputChannelSet.Resize(2);
		AudioOutputMap = new AudioMap<Bus, StreamAudioChannel>(buses, OutputChannelSet);
		AudioOutputMap.MapInvalidated += OnDataModified;
	}

	private void OnDestinationTypeChanged(DestinationType oldValue, DestinationType newValue)
	{
		Clear();
		SetDestination(newValue);
		OnDataModified();
		this.DestinationChanged?.Invoke(newValue);
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public void Clear()
	{
		base.Collection.ToArray().ForEach(RemoveDestination);
	}

	public void AddDestination(IDestination destination)
	{
		destination.DataModified += OnDataModified;
		base.Collection.Add(destination);
		OnDataModified();
	}

	public void RemoveDestination(IDestination destination)
	{
		destination.DataModified -= OnDataModified;
		base.Collection.Remove(destination);
		OnDataModified();
	}

	private void SetDestination(DestinationType type)
	{
		AddDestination(_destinationFactory.Create(type));
		Encoder.SetDestinationDefaults(type);
	}

	public Recording.Types.Stream Serialize()
	{
		return new Recording.Types.Stream
		{
			Id = ID.ToUUID(),
			OutputScreen = new Recording.Types.Stream.Types.OutputScreenSource
			{
				ScreenId = ScreenID.ToUUID(),
				ScreenName = (ScreenName ?? string.Empty)
			},
			Encoder = Encoder.Serialize(),
			Destinations = { base.Collection.Select((IDestination c) => c.Serialize()) },
			AudioMap = { AudioOutputMap.Serialize(inputToOutput: false) },
			IsAudioCustomMapped = AudioOutputMap.IsCustomMap
		};
	}

	public void Deserialize(Recording.Types.Stream? protoStream)
	{
		if (protoStream == null)
		{
			return;
		}
		ID = protoStream.Id?.ToGuid() ?? Guid.NewGuid();
		ScreenID = protoStream.OutputScreen?.ScreenId?.ToGuid() ?? Guid.Empty;
		ScreenName = protoStream.OutputScreen?.ScreenName ?? string.Empty;
		Encoder.Deserialize(protoStream.Encoder);
		Clear();
		foreach (Recording.Types.Stream.Types.Destination destination2 in protoStream.Destinations)
		{
			IDestination destination = _destinationFactory.Create(destination2.DestinationCase);
			if (destination != null)
			{
				destination.Deserialize(destination2);
				AddDestination(destination);
			}
		}
		if (base.Collection.Empty())
		{
			_destinationType = DestinationType.Resi;
			SetDestination(_destinationType);
		}
		else
		{
			_destinationType = base.Collection[0].Type;
		}
		AudioOutputMap.MapInvalidated -= OnDataModified;
		AudioOutputMap.Deserialize(protoStream.AudioMap, protoStream.IsAudioCustomMapped, inputToOutput: false);
		AudioOutputMap.MapInvalidated += OnDataModified;
	}

	public IStream Clone()
	{
		Stream stream = new Stream(_buses, _destinationFactory);
		Recording.Types.Stream protoStream = Serialize();
		stream.Deserialize(protoStream);
		stream.ID = Guid.NewGuid();
		return stream;
	}
}
