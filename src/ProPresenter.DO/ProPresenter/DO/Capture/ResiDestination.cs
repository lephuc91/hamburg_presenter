using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public class ResiDestination : NotifyPropertyChangedBase, IResiDestination, IDestination, INotifyPropertyChanged
{
	private Guid _group;

	private Guid _profile;

	public DestinationType Type => DestinationType.Resi;

	public Guid Group
	{
		get
		{
			return _group;
		}
		set
		{
			SetValue("Group", ref _group, value, OnDataModified);
		}
	}

	public Guid Profile
	{
		get
		{
			return _profile;
		}
		set
		{
			SetValue("Profile", ref _profile, value, OnDataModified);
		}
	}

	public event System.Action? DataModified;

	public ObjectBinder<IDestination, IRecording.Types.IStream.Types.IDestination> Bind(IEntityFactory entityFactory, IRecording.Types.IStream.Types.IDestination entity)
	{
		IRecording.Types.IStream.Types.IDestination.Types.IDestination.IResi resi = entity._Destination.Value as IRecording.Types.IStream.Types.IDestination.Types.IDestination.IResi;
		if (resi == null)
		{
			resi = entityFactory.Create<IRecording.Types.IStream.Types.IDestination.Types.IDestination.IResi>();
			entity._Destination.Set(resi);
		}
		ObjectBinder<ResiDestination, IRecording.Types.IStream.Types.IDestination.Types.IResi> binder = new ObjectBinder<ResiDestination, IRecording.Types.IStream.Types.IDestination.Types.IResi>(this, resi.Value);
		binder.Bind((ResiDestination l) => l.WhenPropertyChanges("Group"), (IRecording.Types.IStream.Types.IDestination.Types.IResi r) => r.DestinationGroupId.WhenValueChanges, delegate(ResiDestination l, IRecording.Types.IStream.Types.IDestination.Types.IResi r)
		{
			r.DestinationGroupId.Set(l.Group);
		}, delegate(IRecording.Types.IStream.Types.IDestination.Types.IResi r, ResiDestination l)
		{
			l.Group = r.DestinationGroupId.ToGuidOrEmpty();
		}).Bind((ResiDestination l) => l.WhenPropertyChanges("Profile"), (IRecording.Types.IStream.Types.IDestination.Types.IResi r) => r.EncoderProfileId.WhenValueChanges, delegate(ResiDestination l, IRecording.Types.IStream.Types.IDestination.Types.IResi r)
		{
			r.EncoderProfileId.Set(l.Profile);
		}, delegate(IRecording.Types.IStream.Types.IDestination.Types.IResi r, ResiDestination l)
		{
			l.Profile = r.EncoderProfileId.ToGuidOrEmpty();
		});
		ObjectBinder<IDestination, IRecording.Types.IStream.Types.IDestination> objectBinder = new ObjectBinder<IDestination, IRecording.Types.IStream.Types.IDestination>(this, entity);
		objectBinder.DoOnInitializeLeftFromRight(binder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(binder.InitializeRightFromLeft).RegisterChildDisposable(() => binder);
		return objectBinder;
	}

	public void Deserialize(Recording.Types.Stream.Types.Destination protoDestination)
	{
		if (protoDestination.Resi != null)
		{
			Group = protoDestination.Resi.DestinationGroupId.ToGuid();
			Profile = protoDestination.Resi.EncoderProfileId.ToGuid();
		}
	}

	public Recording.Types.Stream.Types.Destination Serialize()
	{
		return new Recording.Types.Stream.Types.Destination
		{
			Resi = new Recording.Types.Stream.Types.Destination.Types.Resi
			{
				DestinationGroupId = Group.ToUUID(),
				EncoderProfileId = Profile.ToUUID()
			}
		};
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
