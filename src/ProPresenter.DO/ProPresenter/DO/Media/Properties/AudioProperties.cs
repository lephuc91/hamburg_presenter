using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Linq;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.DO.Audio;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Media.Properties;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class AudioProperties : NotifyPropertyChangedBase, ICloneable<AudioProperties>, IDisposable
{
	private double _volume = 1.0;

	private readonly ChannelSet<Bus> _buses;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public double Volume
	{
		get
		{
			return _volume;
		}
		set
		{
			SetValue("Volume", ref _volume, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.VideoMediaVolume), this, "Volume", o, n);
				OnDataModified();
			});
		}
	}

	public AudioMap<MediaChannel, Bus>? AudioMap { get; }

	private bool IsCustomMap => AudioMap?.IsCustomMap ?? false;

	public ChannelSet<MediaChannel> InputChannelSet { get; } = new ChannelSet<MediaChannel>();

	public UndoStack? UndoStack { get; set; }

	public event System.Action? DataModified;

	public static ObjectBinder<AudioProperties, IMedia.Types.IAudioProperties> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, AudioProperties left, IMedia.Types.IAudioProperties right)
	{
		ObjectBinder<AudioProperties, IMedia.Types.IAudioProperties> objectBinder = new ObjectBinder<AudioProperties, IMedia.Types.IAudioProperties>(left, right);
		objectBinder.Bind((AudioProperties l) => l.WhenPropertyChanges("Volume"), (IMedia.Types.IAudioProperties r) => r.Volume.WhenValueChanges, delegate(AudioProperties l, IMedia.Types.IAudioProperties r)
		{
			r.Volume.Set(l.Volume);
		}, delegate(IMedia.Types.IAudioProperties r, AudioProperties l)
		{
			l.Volume = r.Volume.Value;
		}).Bind((AudioProperties l) => l.InputChannelSet.WhenCollectionChanges().SelectMany((INotifyCollectionChanged _) => l.InputChannelSet.Select((MediaChannel l) => l.WhenAnyPropertyChanges())).Merge()
			.Merge(l.WhenPropertyChanges("IsCustomMap")), (IMedia.Types.IAudioProperties r) => r.AudioChannels.WhenAnyValueChanges.Merge(r.IsCustomMapping.WhenValueChanges.ToUnit()), delegate(AudioProperties l, IMedia.Types.IAudioProperties r)
		{
			l.SerializeToEntity(entityFactory, r);
		}, delegate(IMedia.Types.IAudioProperties r, AudioProperties l)
		{
			l.DeserializeEntity(r);
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	private static ObjectBinder<MediaChannel, IMedia.Types.IAudio.Types.IChannel> CreateChannelBinder(MediaChannel left, IMedia.Types.IAudio.Types.IChannel right)
	{
		ObjectBinder<MediaChannel, IMedia.Types.IAudio.Types.IChannel> objectBinder = new ObjectBinder<MediaChannel, IMedia.Types.IAudio.Types.IChannel>(left, right);
		objectBinder.Bind((MediaChannel l) => l.WhenPropertyChanges("Index"), (IMedia.Types.IAudio.Types.IChannel r) => r.Index.WhenValueChanges, delegate(MediaChannel l, IMedia.Types.IAudio.Types.IChannel r)
		{
			r.Index.Set((uint)l.Index);
		}, delegate(IMedia.Types.IAudio.Types.IChannel r, MediaChannel l)
		{
			l.Index = (int)r.Index.Value;
		}).Bind((MediaChannel l) => l.WhenPropertyChanges("MuteActive"), (IMedia.Types.IAudio.Types.IChannel r) => r.Muted.WhenValueChanges, delegate(MediaChannel l, IMedia.Types.IAudio.Types.IChannel r)
		{
			r.Muted.Set(l.MuteActive);
		}, delegate(IMedia.Types.IAudio.Types.IChannel r, MediaChannel l)
		{
			l.MuteActive = r.Muted.Value;
		}).Bind((MediaChannel l) => l.WhenPropertyChanges("Level"), (IMedia.Types.IAudio.Types.IChannel r) => r.Volume.WhenValueChanges, delegate(MediaChannel l, IMedia.Types.IAudio.Types.IChannel r)
		{
			r.Volume.Set(l.Level);
		}, delegate(IMedia.Types.IAudio.Types.IChannel r, MediaChannel l)
		{
			l.Level = r.Volume.Value;
		});
		return objectBinder;
	}

	public void SerializeToEntity(IEntityFactory entityFactory, IMedia.Types.IAudioProperties audio)
	{
		audio.Volume.Set(Volume);
		List<IMedia.Types.IAudio.Types.IChannel> list = new List<IMedia.Types.IAudio.Types.IChannel>();
		foreach (MediaChannel channel in InputChannelSet)
		{
			IEnumerable<IMedia.Types.IAudio.Types.IChannel.Types.IOutput> enumerable = AudioMap?.OutputSet.Where((Bus o) => AudioMap.IsMapped(channel, o)).Select(delegate(Bus o)
			{
				IMedia.Types.IAudio.Types.IChannel.Types.IOutput output = entityFactory.Create<IMedia.Types.IAudio.Types.IChannel.Types.IOutput>();
				output.ChannelIndex.Set(o.Index);
				return output;
			});
			IMedia.Types.IAudio.Types.IChannel channel2 = entityFactory.Create<IMedia.Types.IAudio.Types.IChannel>();
			ObjectBinder<MediaChannel, IMedia.Types.IAudio.Types.IChannel> disposable = CreateChannelBinder(channel, channel2);
			channel2.RegisterLinkedDisposable(disposable);
			if (enumerable != null)
			{
				channel2.Outputs.AddRange(enumerable);
			}
			list.Add(channel2);
		}
		audio.AudioChannels.Reset(list);
		audio.IsCustomMapping.Set(IsCustomMap);
	}

	public void DeserializeEntity(IMedia.Types.IAudioProperties audio)
	{
		if (AudioMap == null)
		{
			return;
		}
		InputChannelSet.Resize(audio.AudioChannels.Items.Count);
		if (audio.IsCustomMapping.Value)
		{
			AudioMap.ClearMap();
		}
		else
		{
			AudioMap.AutoMap();
		}
		foreach (MediaChannel item in InputChannelSet)
		{
			IMedia.Types.IAudio.Types.IChannel channel = audio.AudioChannels.Items.ElementAtOrDefault(item.Index);
			if (channel == null)
			{
				continue;
			}
			ObjectBinder<MediaChannel, IMedia.Types.IAudio.Types.IChannel> disposable = CreateChannelBinder(item, channel);
			channel.RegisterLinkedDisposable(disposable);
			if (!audio.IsCustomMapping.Value)
			{
				continue;
			}
			foreach (IMedia.Types.IAudio.Types.IChannel.Types.IOutput item2 in channel.Outputs.Items)
			{
				Bus bus = AudioMap.OutputSet.ElementAtOrDefault(item2.ChannelIndex.Value);
				if (bus != null)
				{
					AudioMap.ToggleOn(item, bus);
				}
			}
		}
	}

	public AudioProperties(IAudioSetup audioSetup)
		: this(audioSetup.Buses)
	{
	}

	private AudioProperties(ChannelSet<Bus> buses)
	{
		_buses = buses;
		AudioMap = new AudioMap<MediaChannel, Bus>(InputChannelSet, _buses);
		AudioMap.MapInvalidated += OnDataModified;
		AudioMap.IsCustomMapChanged += delegate
		{
			OnPropertyChanged("IsCustomMap");
		};
		InputChannelSet.CollectionChanged += OnInputChannelSet_CollectionChanged;
		CollectionChangedEventManager.AddHandler((INotifyCollectionChanged)_buses, (EventHandler<NotifyCollectionChangedEventArgs>)Buses_CollectionChanged);
	}

	public AudioProperties Clone()
	{
		AudioProperties audioProperties = new AudioProperties(_buses);
		audioProperties.Deserialize(Serialize());
		return audioProperties;
	}

	internal void TransposeProperties(AudioProperties audioProperties)
	{
		if (audioProperties != null)
		{
			Deserialize(audioProperties.Serialize());
		}
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public Pro.SerializationInterop.RVProtoData.Media.Types.AudioProperties Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Media.Types.AudioProperties audioProperties = new Pro.SerializationInterop.RVProtoData.Media.Types.AudioProperties
		{
			Volume = Volume
		};
		List<Pro.SerializationInterop.RVProtoData.Media.Types.Audio.Types.Channel> list = new List<Pro.SerializationInterop.RVProtoData.Media.Types.Audio.Types.Channel>();
		foreach (MediaChannel channel in InputChannelSet)
		{
			IEnumerable<Pro.SerializationInterop.RVProtoData.Media.Types.Audio.Types.Channel.Types.Output> enumerable = (from o in AudioMap?.OutputSet
				where AudioMap.IsMapped(channel, o)
				select new Pro.SerializationInterop.RVProtoData.Media.Types.Audio.Types.Channel.Types.Output
				{
					ChannelIndex = o.Index
				});
			Pro.SerializationInterop.RVProtoData.Media.Types.Audio.Types.Channel channel2 = channel.Serialize();
			if (enumerable != null)
			{
				channel2.Outputs.AddRange(enumerable);
			}
			list.Add(channel2);
		}
		audioProperties.AudioChannels.AddRange(list);
		audioProperties.IsCustomMapping = IsCustomMap;
		return audioProperties;
	}

	internal void Deserialize(Pro.SerializationInterop.RVProtoData.Media.Types.AudioProperties audio)
	{
		if (audio == null)
		{
			return;
		}
		Volume = audio.Volume;
		InputChannelSet.Resize(audio.AudioChannels.Count);
		if (audio.IsCustomMapping)
		{
			AudioMap?.ClearMap();
		}
		else
		{
			AudioMap?.AutoMap();
		}
		foreach (MediaChannel item in InputChannelSet)
		{
			Pro.SerializationInterop.RVProtoData.Media.Types.Audio.Types.Channel channel = audio.AudioChannels.ElementAtOrDefault(item.Index);
			if (channel == null)
			{
				continue;
			}
			item.Deserialize(channel);
			if (!audio.IsCustomMapping)
			{
				continue;
			}
			foreach (Pro.SerializationInterop.RVProtoData.Media.Types.Audio.Types.Channel.Types.Output output in channel.Outputs)
			{
				Bus bus = AudioMap?.OutputSet.ElementAtOrDefault(output.ChannelIndex);
				if (bus != null)
				{
					AudioMap?.ToggleOn(item, bus);
				}
			}
		}
	}

	private void OnInputChannelSet_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs args)
	{
		args.OldItems?.Cast<MediaChannel>().ToList().ForEach(delegate(MediaChannel channel)
		{
			channel.DataModified -= OnDataModified;
		});
		args.NewItems?.Cast<MediaChannel>().ToList().ForEach(delegate(MediaChannel channel)
		{
			channel.DataModified += OnDataModified;
		});
	}

	private void Buses_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs args)
	{
		args.OldItems?.Cast<Bus>().ToList().ForEach(delegate(Bus bus)
		{
			bus.DataModified -= OnDataModified;
		});
		args.NewItems?.Cast<Bus>().ToList().ForEach(delegate(Bus bus)
		{
			bus.DataModified += OnDataModified;
		});
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		InputChannelSet.CollectionChanged -= OnInputChannelSet_CollectionChanged;
		_buses.CollectionChanged -= Buses_CollectionChanged;
	}
}
