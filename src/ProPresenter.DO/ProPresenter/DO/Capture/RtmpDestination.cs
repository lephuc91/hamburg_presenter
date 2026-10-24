using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public class RtmpDestination : NotifyPropertyChangedBase, IRtmpDestination, IDestination, INotifyPropertyChanged
{
	public static readonly string RtmpScheme = "rtmp";

	public static readonly string RtmpsScheme = "rtmps";

	private string _address = string.Empty;

	private string _key = string.Empty;

	public DestinationType Type => DestinationType.RTMP;

	public string Address
	{
		get
		{
			return _address;
		}
		set
		{
			SetValue("Address", ref _address, value, OnDataModified, (string a) => a.IsValidAddress());
		}
	}

	public string Key
	{
		get
		{
			return _key;
		}
		set
		{
			SetValue("Key", ref _key, value, OnDataModified);
		}
	}

	public event System.Action? DataModified;

	public ObjectBinder<IDestination, IRecording.Types.IStream.Types.IDestination> Bind(IEntityFactory entityFactory, IRecording.Types.IStream.Types.IDestination entity)
	{
		IRecording.Types.IStream.Types.IDestination.Types.IDestination.IRtmp rtmp = entity._Destination.Value as IRecording.Types.IStream.Types.IDestination.Types.IDestination.IRtmp;
		if (rtmp == null)
		{
			rtmp = entityFactory.Create<IRecording.Types.IStream.Types.IDestination.Types.IDestination.IRtmp>();
			entity._Destination.Set(rtmp);
		}
		ObjectBinder<RtmpDestination, IRecording.Types.IStream.Types.IRtmpDestination> binder = new ObjectBinder<RtmpDestination, IRecording.Types.IStream.Types.IRtmpDestination>(this, rtmp.Value);
		binder.Bind((RtmpDestination l) => l.WhenPropertyChanges("Address"), (IRecording.Types.IStream.Types.IRtmpDestination r) => r.Address.WhenValueChanges, delegate(RtmpDestination l, IRecording.Types.IStream.Types.IRtmpDestination r)
		{
			r.Address.Set(l.Address);
		}, delegate(IRecording.Types.IStream.Types.IRtmpDestination r, RtmpDestination l)
		{
			l.Address = r.Address.Value;
		}).Bind((RtmpDestination l) => l.WhenPropertyChanges("Key"), (IRecording.Types.IStream.Types.IRtmpDestination r) => r.Key.WhenValueChanges, delegate(RtmpDestination l, IRecording.Types.IStream.Types.IRtmpDestination r)
		{
			r.Key.Set(l.Key);
		}, delegate(IRecording.Types.IStream.Types.IRtmpDestination r, RtmpDestination l)
		{
			l.Key = r.Key.Value;
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
			Rtmp = new Recording.Types.Stream.Types.RTMPDestination
			{
				Address = (Address ?? string.Empty),
				Key = (Key ?? string.Empty)
			}
		};
	}

	public void Deserialize(Recording.Types.Stream.Types.Destination protoDestination)
	{
		if (protoDestination != null && protoDestination.Rtmp != null)
		{
			Recording.Types.Stream.Types.RTMPDestination rtmp = protoDestination.Rtmp;
			Address = rtmp.Address;
			Key = rtmp.Key;
		}
	}
}
