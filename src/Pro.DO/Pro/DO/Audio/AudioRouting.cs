using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Audio;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class AudioRouting<I, O> : NotifyPropertyChangedBase, IAudioRouting<I, O>, INotifyPropertyChanged, IDisposable where I : IChannel, new() where O : IChannel, new()
{
	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public bool InputToOutput { get; }

	public int ChannelCount => ChannelSet.ChannelCount;

	public ChannelSet<DeviceChannel> ChannelSet { get; } = new ChannelSet<DeviceChannel>();

	public DeviceChannel MasterChannel { get; } = new DeviceChannel();

	public AudioMap<I, O> ChannelMap { get; }

	public event System.Action? DataModified;

	public ObjectBinder<IAudioRouting<I, O>, IDigitalAudio.Types.IDevice.Types.IRouting> Bind(IUiScheduler uiScheduler, IEntityFactory entityFactory, IDigitalAudio.Types.IDevice.Types.IRouting right)
	{
		ObjectBinder<IAudioRouting<I, O>, IDigitalAudio.Types.IDevice.Types.IRouting> objectBinder = new ObjectBinder<IAudioRouting<I, O>, IDigitalAudio.Types.IDevice.Types.IRouting>(this, right);
		objectBinder.Bind((IAudioRouting<I, O> l) => l.ChannelSet.WhenCollectionChanges(), (IDigitalAudio.Types.IDevice.Types.IRouting r) => r.Channels.WhenCollectionChanges, delegate(IAudioRouting<I, O> l, IDigitalAudio.Types.IDevice.Types.IRouting r)
		{
			List<IDigitalAudio.Types.IDevice.Types.IChannel> list = new List<IDigitalAudio.Types.IDevice.Types.IChannel>();
			foreach (DeviceChannel item in l.ChannelSet)
			{
				IDigitalAudio.Types.IDevice.Types.IChannel channel = entityFactory.Create<IDigitalAudio.Types.IDevice.Types.IChannel>();
				list.Add(channel);
				ObjectBinder<DeviceChannel, IDigitalAudio.Types.IDevice.Types.IChannel> objectBinder2 = DeviceChannel.CreateBinder(item, channel);
				objectBinder2.InitializeRightFromLeft();
				channel.RegisterLinkedDisposable(objectBinder2);
			}
			r.Channels.Reset(list);
		}, delegate(IDigitalAudio.Types.IDevice.Types.IRouting r, IAudioRouting<I, O> l)
		{
			l.ChannelSet.Resize(r.Channels.Items.Count);
			for (int i = 0; i < r.Channels.Items.Count; i++)
			{
				IDigitalAudio.Types.IDevice.Types.IChannel channel2 = r.Channels.Items[i];
				ObjectBinder<DeviceChannel, IDigitalAudio.Types.IDevice.Types.IChannel> objectBinder3 = DeviceChannel.CreateBinder(l.ChannelSet[i], channel2);
				objectBinder3.InitializeLeftFromRight();
				channel2.RegisterLinkedDisposable(objectBinder3);
			}
		}, null, uiScheduler.Scheduler).Bind((IAudioRouting<I, O> l) => l.WhenPropertyChanges("MasterChannel"), (IDigitalAudio.Types.IDevice.Types.IRouting r) => r.MasterChannel.WhenValueChanges, delegate(IAudioRouting<I, O> l, IDigitalAudio.Types.IDevice.Types.IRouting r)
		{
			IDigitalAudio.Types.IDevice.Types.IChannel channel3 = entityFactory.Create<IDigitalAudio.Types.IDevice.Types.IChannel>();
			r.MasterChannel.Set(channel3);
			ObjectBinder<DeviceChannel, IDigitalAudio.Types.IDevice.Types.IChannel> objectBinder4 = DeviceChannel.CreateBinder(l.MasterChannel, channel3);
			objectBinder4.InitializeRightFromLeft();
			channel3.RegisterLinkedDisposable(objectBinder4);
		}, delegate(IDigitalAudio.Types.IDevice.Types.IRouting r, IAudioRouting<I, O> l)
		{
			if (r.MasterChannel.Value != null)
			{
				ObjectBinder<DeviceChannel, IDigitalAudio.Types.IDevice.Types.IChannel> objectBinder5 = DeviceChannel.CreateBinder(l.MasterChannel, r.MasterChannel.Value);
				objectBinder5.InitializeLeftFromRight();
				r.MasterChannel.Value.RegisterLinkedDisposable(objectBinder5);
			}
		}, uiScheduler.Scheduler, uiScheduler.Scheduler);
		return objectBinder;
	}

	public AudioRouting(bool inputToOutput, Func<ChannelSet<DeviceChannel>, AudioMap<I, O>> channelMapProvider)
	{
		InputToOutput = inputToOutput;
		ChannelSet.CollectionChanged += ChannelSet_CollectionChanged;
		ChannelSet.ForEach(delegate(DeviceChannel c)
		{
			c.DataModified += OnDataModified;
		});
		ChannelMap = channelMapProvider(ChannelSet);
		ChannelMap.MapInvalidated += OnDataModified;
		MasterChannel.DataModified += OnDataModified;
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public DigitalAudio.Types.Device.Types.Routing Serialize()
	{
		DigitalAudio.Types.Device.Types.Routing routing = new DigitalAudio.Types.Device.Types.Routing();
		routing.IsCustomMap = ChannelMap.IsCustomMap;
		routing.MasterChannel = MasterChannel.Serialize();
		routing.Channels.AddRange(ChannelSet.Select((DeviceChannel c) => c.Serialize()));
		routing.Map.AddRange(ChannelMap.Serialize(InputToOutput));
		return routing;
	}

	public void Deserialize(DigitalAudio.Types.Device.Types.Routing? protoAudioRouting)
	{
		if (protoAudioRouting == null)
		{
			ChannelSet.Resize(0);
			ChannelMap.Deserialize(Array.Empty<DigitalAudio.Types.Device.Types.Map>(), isCustomMap: false, inputToOutput: false);
			MasterChannel.Deserialize((DigitalAudio.Types.Device.Types.Channel?)null);
			return;
		}
		ChannelSet.Resize(protoAudioRouting.Channels.Count);
		int num = 0;
		foreach (DigitalAudio.Types.Device.Types.Channel channel in protoAudioRouting.Channels)
		{
			ChannelSet.ElementAtOrDefault(num++)?.Deserialize(channel);
		}
		ChannelMap.Deserialize(protoAudioRouting.Map, protoAudioRouting.IsCustomMap, InputToOutput);
		MasterChannel.Deserialize(protoAudioRouting.MasterChannel);
	}

	private void ChannelSet_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs args)
	{
		args.OldItems?.Cast<DeviceChannel>().ForEach(delegate(DeviceChannel channel)
		{
			channel.DataModified -= OnDataModified;
		});
		args.NewItems?.Cast<DeviceChannel>().ForEach(delegate(DeviceChannel channel)
		{
			channel.DataModified += OnDataModified;
		});
		OnPropertyChanged("ChannelCount");
		OnDataModified();
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
		ChannelSet.CollectionChanged -= ChannelSet_CollectionChanged;
		ChannelSet.ForEach(delegate(DeviceChannel c)
		{
			c.DataModified -= OnDataModified;
		});
		ChannelMap.MapInvalidated -= OnDataModified;
		MasterChannel.DataModified -= OnDataModified;
	}
}
