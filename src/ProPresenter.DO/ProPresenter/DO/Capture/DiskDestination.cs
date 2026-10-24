using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public class DiskDestination : NotifyPropertyChangedBase, IDiskDestination, IDestination, INotifyPropertyChanged
{
	private RelativePath _location = RelativePath.Empty();

	private Container _container = Container.MP4;

	public DestinationType Type => DestinationType.Disk;

	public RelativePath Location
	{
		get
		{
			return _location;
		}
		set
		{
			SetValue("Location", ref _location, value, OnDataModified);
		}
	}

	public Container Container
	{
		get
		{
			return _container;
		}
		set
		{
			SetValue("Container", ref _container, value, OnDataModified);
		}
	}

	public event System.Action? DataModified;

	public ObjectBinder<IDestination, IRecording.Types.IStream.Types.IDestination> Bind(IEntityFactory entityFactory, IRecording.Types.IStream.Types.IDestination entity)
	{
		IRecording.Types.IStream.Types.IDestination.Types.IDestination.IDisk disk = entity._Destination.Value as IRecording.Types.IStream.Types.IDestination.Types.IDestination.IDisk;
		if (disk == null)
		{
			disk = entityFactory.Create<IRecording.Types.IStream.Types.IDestination.Types.IDestination.IDisk>();
			entity._Destination.Set(disk);
		}
		ObjectBinder<DiskDestination, IRecording.Types.IStream.Types.IDiskDestination> binder = new ObjectBinder<DiskDestination, IRecording.Types.IStream.Types.IDiskDestination>(this, disk.Value);
		binder.Bind((DiskDestination l) => l.WhenPropertyChanges("Location"), (IRecording.Types.IStream.Types.IDiskDestination r) => r.Location.WhenValueChanges, delegate(DiskDestination l, IRecording.Types.IStream.Types.IDiskDestination r)
		{
			r.Location.Set(RelativePath.Create(l.Location));
		}, delegate(IRecording.Types.IStream.Types.IDiskDestination r, DiskDestination l)
		{
			l.Location = RelativePath.Create(r.Location.Value, out URL _);
		}).Bind((DiskDestination l) => l.WhenPropertyChanges("Container"), (IRecording.Types.IStream.Types.IDiskDestination r) => r.Container.WhenValueChanges, delegate(DiskDestination l, IRecording.Types.IStream.Types.IDiskDestination r)
		{
			r.Container.Set(l.Container.ToEntityContainer());
		}, delegate(IRecording.Types.IStream.Types.IDiskDestination r, DiskDestination l)
		{
			l.Container = r.Container.Value.ToContainer();
		});
		ObjectBinder<IDestination, IRecording.Types.IStream.Types.IDestination> objectBinder = new ObjectBinder<IDestination, IRecording.Types.IStream.Types.IDestination>(this, entity);
		objectBinder.DoOnInitializeLeftFromRight(binder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(binder.InitializeRightFromLeft).RegisterChildDisposable(() => binder);
		return objectBinder;
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public Recording.Types.Stream.Types.Destination Serialize()
	{
		return new Recording.Types.Stream.Types.Destination
		{
			Disk = new Recording.Types.Stream.Types.DiskDestination
			{
				Location = Location.Serialize(),
				Container = Container.ToProtoContainer()
			}
		};
	}

	public void Deserialize(Recording.Types.Stream.Types.Destination protoDestination)
	{
		if (protoDestination != null && protoDestination.Disk != null)
		{
			Recording.Types.Stream.Types.DiskDestination disk = protoDestination.Disk;
			Location = new RelativePath(disk.Location);
			Container = disk.Container.ToContainer();
		}
	}
}
