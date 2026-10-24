using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.Looks;

public class AudienceLook : NotifyPropertyChangedBase, ICloneable<AudienceLook>, IIdentifiable, ITriggerable
{
	private readonly AudienceScreenArrangementCollection _audienceScreens;

	private Guid _id = Guid.NewGuid();

	private string _name;

	private TimeSlice _transitionDuration = DefaultTransitionDuration;

	public static readonly TimeSlice MinimumTransitionDuration = TimeSlice.Zero;

	public static readonly TimeSlice MaximumTransitionDuration = TimeSlice.FromSeconds(5.0);

	public static readonly TimeSlice DefaultTransitionDuration = TimeSlice.FromSeconds(1.0);

	public Guid ID => _id;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value, OnDataModified);
		}
	}

	public ScreenLookCollection ScreenLooks { get; }

	public TimeSlice TransitionDuration
	{
		get
		{
			return _transitionDuration;
		}
		set
		{
			SetValue("TransitionDuration", ref _transitionDuration, SanitizeTransitionDuration(value), OnDataModified);
		}
	}

	public event System.Action? DataModified;

	public static ObjectBinder<AudienceLook, IProAudienceLook> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, AudienceLook? left, IProAudienceLook right)
	{
		ObjectBinder<ScreenLookCollection, IComplexCollection<IProAudienceLook.Types.IProScreenLook>> screenLooksBinder = ScreenLookCollection.CreateBinder(scheduler, entityFactory, left?.ScreenLooks, right.ScreenLooks);
		ObjectBinder<AudienceLook, IProAudienceLook> objectBinder = new ObjectBinder<AudienceLook, IProAudienceLook>(left, right);
		objectBinder.Bind((AudienceLook l) => l.WhenPropertyChanges("ID"), (IProAudienceLook r) => r.Uuid.WhenValueChanges, delegate(AudienceLook l, IProAudienceLook r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IProAudienceLook r, AudienceLook l)
		{
			l._id = r.Uuid.Value;
		}).Bind((AudienceLook l) => l.WhenPropertyChanges("Name"), (IProAudienceLook r) => r.Name.WhenValueChanges, delegate(AudienceLook l, IProAudienceLook r)
		{
			r.Name.Set(l.Name);
		}, delegate(IProAudienceLook r, AudienceLook l)
		{
			l.Name = r.Name.Value ?? string.Empty;
		}).Bind((AudienceLook l) => l.WhenPropertyChanges("TransitionDuration"), (IProAudienceLook r) => r.TransitionDuration.WhenValueChanges, delegate(AudienceLook l, IProAudienceLook r)
		{
			r.TransitionDuration.Set(l.TransitionDuration.TotalSeconds);
		}, delegate(IProAudienceLook r, AudienceLook l)
		{
			l.TransitionDuration = TimeSlice.FromSeconds(r.TransitionDuration.Value);
		})
			.DoOnInitializeLeftFromRight(screenLooksBinder.InitializeLeftFromRight)
			.DoOnInitializeRightFromLeft(screenLooksBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(() => screenLooksBinder);
		return objectBinder;
	}

	public AudienceLook(string name, AudienceScreenArrangementCollection audienceScreens)
		: this(audienceScreens)
	{
		_name = name;
		CreateScreenLooks();
	}

	internal AudienceLook(AudienceScreenArrangementCollection audienceScreens)
	{
		_name = string.Empty;
		_audienceScreens = audienceScreens;
		ScreenLooks = new ScreenLookCollection();
		ScreenLooks.DataModified += OnDataModified;
		_audienceScreens.CollectionChanged += AudienceScreens_CollectionChanged;
	}

	public void Update(AudienceLook? other)
	{
		if (other != null)
		{
			Name = other.Name;
			TransitionDuration = other.TransitionDuration;
			ScreenLooks.Update(other.ScreenLooks);
		}
	}

	private void CreateScreenLooks()
	{
		_audienceScreens.Select((ScreenArrangementBase x) => x.ID).Cast<Guid?>().ForEach(ScreenLooks.AddScreenLook);
	}

	private void AudienceScreens_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		List<ScreenLook> list = new List<ScreenLook>();
		if (e.OldItems != null)
		{
			IEnumerable<ScreenArrangementBase> enumerable = e.OldItems?.OfType<ScreenArrangementBase>();
			if (enumerable != null)
			{
				foreach (ScreenArrangementBase oldScreen in enumerable)
				{
					ScreenLook screenLook = ScreenLooks.FirstOrDefault((ScreenLook l) => l.ScreenId == oldScreen.ID);
					if ((object)screenLook != null)
					{
						list.Add(screenLook);
					}
					ScreenLooks.RemoveScreenLook(oldScreen);
				}
			}
		}
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
		case NotifyCollectionChangedAction.Remove:
			e.NewItems?.OfType<ScreenArrangementBase>().ForEach(delegate(ScreenArrangementBase a)
			{
				ScreenLooks.InsertScreenLook(e.NewStartingIndex, a.ID);
			});
			break;
		case NotifyCollectionChangedAction.Move:
			list?.ForEach(delegate(ScreenLook l)
			{
				ScreenLooks.InsertScreenLook(e.NewStartingIndex, l);
			});
			break;
		case NotifyCollectionChangedAction.Replace:
		case NotifyCollectionChangedAction.Reset:
			break;
		}
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public ProAudienceLook Serialize()
	{
		ProAudienceLook proAudienceLook = new ProAudienceLook();
		proAudienceLook.Uuid = ID.ToUUID();
		proAudienceLook.Name = Name;
		proAudienceLook.TransitionDuration = TransitionDuration.TotalSeconds;
		proAudienceLook.ScreenLooks.AddRange(ScreenLooks.Serialize());
		return proAudienceLook;
	}

	public void Deserialize(ProAudienceLook? audienceLook, bool deserializeID)
	{
		if (audienceLook != null)
		{
			if (deserializeID)
			{
				_id = audienceLook.Uuid.ToGuid();
			}
			_name = audienceLook.Name;
			_transitionDuration = SanitizeTransitionDuration(TimeSlice.FromSeconds(audienceLook.TransitionDuration));
			ScreenLooks.Deserialize(audienceLook.ScreenLooks);
		}
	}

	public AudienceLook Clone()
	{
		AudienceLook audienceLook = new AudienceLook(_name, _audienceScreens);
		audienceLook.TransitionDuration = TransitionDuration;
		audienceLook.ScreenLooks.Update(ScreenLooks);
		return audienceLook;
	}

	private TimeSlice SanitizeTransitionDuration(TimeSlice value)
	{
		return TimeSlice.FromSeconds(Math.Round(value.TotalSeconds, 1)).Clamp(MinimumTransitionDuration, MaximumTransitionDuration);
	}

	internal void LoadDefaults(string name)
	{
		_id = Guid.NewGuid();
		Name = name;
		TransitionDuration = DefaultTransitionDuration;
	}
}
