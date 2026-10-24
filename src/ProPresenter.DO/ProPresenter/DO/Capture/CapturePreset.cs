using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public class CapturePreset : NotifyPropertyChangedBase, ICapturePreset, ICloneable<ICapturePreset>, INotifyPropertyChanged
{
	private string _name = string.Empty;

	private readonly IStreamFactory _streamFactory;

	public Guid ID { get; set; } = Guid.NewGuid();

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value, delegate(string o, string n)
			{
				OnDataModified();
				UndoStack?.Commit(UndoActionTypes.RenamePreset.ToAction(), this, "Name", o, n);
			});
		}
	}

	public IStream DefaultStream => Streams.First();

	public IStreamCollection Streams { get; }

	public IDiskDestination? DiskDestination => DefaultStream.OfType<IDiskDestination>().FirstOrDefault();

	public IRtmpDestination? RTMPDestination => DefaultStream.OfType<IRtmpDestination>().FirstOrDefault();

	public IResiDestination? ResiDestination => DefaultStream.OfType<IResiDestination>().FirstOrDefault();

	public UndoStack? UndoStack { get; set; }

	public event System.Action? DataModified;

	public static ObjectBinder<ICapturePreset, IRecording.Types.IPreset> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, ICapturePreset left, IRecording.Types.IPreset right)
	{
		IReadOnlyObjectBinder<IStreamCollection, IComplexCollection<IRecording.Types.IStream>> streamsBinder = left.Streams.CreateBinder(scheduler, entityFactory, right.Streams);
		ObjectBinder<ICapturePreset, IRecording.Types.IPreset> objectBinder = new ObjectBinder<ICapturePreset, IRecording.Types.IPreset>(left, right);
		objectBinder.Bind((ICapturePreset l) => l.WhenPropertyChanges("ID"), (IRecording.Types.IPreset r) => r.Id.WhenValueChanges, delegate(ICapturePreset l, IRecording.Types.IPreset r)
		{
			r.Id.Set(l.ID);
		}, delegate(IRecording.Types.IPreset r, ICapturePreset l)
		{
			l.ID = r.Id.Value;
		}).Bind((ICapturePreset l) => l.WhenPropertyChanges("Name"), (IRecording.Types.IPreset r) => r.Name.WhenValueChanges, delegate(ICapturePreset l, IRecording.Types.IPreset r)
		{
			r.Name.Set(l.Name);
		}, delegate(IRecording.Types.IPreset r, ICapturePreset l)
		{
			l.Name = r.Name.Value;
		}).DoOnInitializeLeftFromRight(streamsBinder.InitializeLeftFromRight)
			.DoOnInitializeRightFromLeft(streamsBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(() => streamsBinder);
		return objectBinder;
	}

	public CapturePreset(IStreamFactory streamFactory)
	{
		Streams = new StreamCollection(streamFactory);
		_streamFactory = streamFactory;
		Streams.CollectionChanged += Streams_CollectionChanged;
		Streams.DataModified += OnDataModified;
	}

	private void Streams_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<IStream>().ForEach(delegate(IStream s)
		{
			s.CollectionChanged -= Stream_CollectionChanged;
		});
		e.NewItems?.OfType<IStream>().ForEach(delegate(IStream s)
		{
			s.CollectionChanged += Stream_CollectionChanged;
		});
		NotifyPropertyChanged();
	}

	private void Stream_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<IDestination>().ForEach(delegate(IDestination d)
		{
			d.PropertyChanged -= Destination_PropertyChanged;
		});
		e.NewItems?.OfType<IDestination>().ForEach(delegate(IDestination d)
		{
			d.PropertyChanged += Destination_PropertyChanged;
		});
		NotifyPropertyChanged();
	}

	private void Destination_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Location" || e.PropertyName == "Address" || e.PropertyName == "Profile")
		{
			NotifyPropertyChanged();
		}
	}

	private void NotifyPropertyChanged()
	{
		OnPropertyChanged("DefaultStream");
		OnPropertyChanged("DiskDestination");
		OnPropertyChanged("RTMPDestination");
		OnPropertyChanged("ResiDestination");
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public Recording.Types.Preset Serialize()
	{
		return new Recording.Types.Preset
		{
			Id = ID.ToUUID(),
			Name = (Name ?? string.Empty),
			Streams = { Streams.Select((IStream s) => s.Serialize()) }
		};
	}

	public void Deserialize(Recording.Types.Preset protoPreset)
	{
		if (protoPreset != null)
		{
			ID = protoPreset.Id?.ToGuid() ?? Guid.NewGuid();
			Name = protoPreset.Name ?? string.Empty;
			Streams.Deserialize(protoPreset.Streams);
			if (Streams.Empty())
			{
				Streams.Reset();
			}
		}
	}

	public ICapturePreset Clone()
	{
		CapturePreset capturePreset = new CapturePreset(_streamFactory)
		{
			_name = Name
		};
		capturePreset.Streams.Clear();
		Streams.Select((IStream s) => s.Clone()).ForEach(capturePreset.Streams.AddStream);
		return capturePreset;
	}
}
