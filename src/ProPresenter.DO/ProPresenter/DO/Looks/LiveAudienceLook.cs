using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Events;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.Looks;

public class LiveAudienceLook : NotifyPropertyChangedBase
{
	private AudienceLook? _original;

	private Guid? _originalId;

	private readonly AudienceLookCollection _audienceLooks;

	public AudienceLook Live { get; }

	public Guid OriginalID => _originalId ?? _original?.ID ?? Guid.Empty;

	public bool HasChanges
	{
		get
		{
			if (_original != null)
			{
				return !IsLive(_original);
			}
			return false;
		}
	}

	public static ObjectBinder<LiveAudienceLook, IProAudienceLook> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, LiveAudienceLook left, IProAudienceLook right)
	{
		ObjectBinder<AudienceLook, IProAudienceLook> baseBinder = AudienceLook.CreateBinder(scheduler, entityFactory, left.Live, right);
		ObjectBinder<LiveAudienceLook, IProAudienceLook> objectBinder = new ObjectBinder<LiveAudienceLook, IProAudienceLook>(left, right);
		objectBinder.Bind((LiveAudienceLook l) => l.WhenPropertyChanges("OriginalID"), (IProAudienceLook r) => r.OriginalLookUuid.WhenValueChanges, delegate(LiveAudienceLook l, IProAudienceLook r)
		{
			r.OriginalLookUuid.Set(l._originalId ?? l._original?.ID);
		}, delegate(IProAudienceLook r, LiveAudienceLook l)
		{
			l._originalId = r.OriginalLookUuid.Value;
			if (l._originalId.HasValue)
			{
				l.GoLive(l._originalId.Value);
			}
			else
			{
				l.SetOriginal(null);
			}
		});
		objectBinder.DoOnInitializeLeftFromRight(baseBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(baseBinder.InitializeRightFromLeft).RegisterChildDisposable(() => baseBinder);
		return objectBinder;
	}

	public LiveAudienceLook(string defaultName, AudienceScreenArrangementCollection audienceScreens, AudienceLookCollection audienceLooks)
	{
		_audienceLooks = audienceLooks;
		_audienceLooks.CollectionChanged += AudienceLooks_CollectionChanged;
		Live = new AudienceLook(defaultName, audienceScreens);
		Live.DataModified += delegate
		{
			OnPropertyChanged("HasChanges");
			CurrentLookUpdated.Publish(this);
		};
	}

	private void AudienceLooks_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (_original == null && _originalId.HasValue)
		{
			GoLive(_originalId.Value);
		}
	}

	public bool GoLive(Guid lookId)
	{
		AudienceLook audienceLook = _audienceLooks.FirstOrDefault((AudienceLook l) => l.ID == lookId);
		if (audienceLook == null)
		{
			return false;
		}
		SetOriginal(audienceLook);
		Live.Update(audienceLook);
		return true;
	}

	public void Save()
	{
		_original?.Update(Live);
	}

	public void Reset()
	{
		Live.Update(_original);
	}

	private void SetOriginal(AudienceLook? look)
	{
		if (_original != null)
		{
			_original.DataModified -= OnOriginalDataModified;
		}
		_original = look;
		_originalId = look?.ID;
		if (_original != null)
		{
			_original.DataModified += OnOriginalDataModified;
		}
		OnPropertyChanged("OriginalID");
		OnPropertyChanged("HasChanges");
	}

	private void OnOriginalDataModified()
	{
		OnPropertyChanged("HasChanges");
	}

	public ProAudienceLook Serialize()
	{
		ProAudienceLook proAudienceLook = Live.Serialize();
		proAudienceLook.OriginalLookUuid = _originalId?.ToUUID() ?? _original?.ID.ToUUID();
		return proAudienceLook;
	}

	public void Deserialize(ProAudienceLook? liveData, IEnumerable<AudienceLook> presets)
	{
		if (liveData?.OriginalLookUuid != null)
		{
			_originalId = liveData.OriginalLookUuid.ToGuid();
			GoLive(_originalId.Value);
		}
		else
		{
			SetOriginal(null);
		}
		Live.Deserialize(liveData, deserializeID: false);
	}

	public bool IsLive(AudienceLook look)
	{
		if (look != null && look.Name == Live.Name && Math.Abs(look.TransitionDuration.TotalSeconds - Live.TransitionDuration.TotalSeconds) <= 0.1)
		{
			return look.ScreenLooks.ContentsMatchExactly(Live.ScreenLooks);
		}
		return false;
	}

	internal void LoadDefaults(string name)
	{
		Live.LoadDefaults(name);
		SetOriginal(null);
	}
}
