using System;
using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Triggering;
using Pro.Entity;
using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Presentation;

public class TimelineItemInfo : LinkedNotifyPropertyChangedBase, ITimeTriggerable, ICloneable<ITimeTriggerable>, INotifyPropertyChanged
{
	private TimeSlice _slideTime = TimeSlice.Zero;

	private string _name = string.Empty;

	public Guid ID => Item.ID;

	public string GroupName => (Item as ITimelineSlideItem)?.GroupName ?? string.Empty;

	public System.Windows.Media.Color? GroupColor => (Item as ITimelineSlideItem)?.GroupColor;

	public ITimelineItem Item { get; }

	public TimeSlice SlideTime
	{
		get
		{
			return _slideTime;
		}
		set
		{
			SetValue("SlideTime", ref _slideTime, value, (Action<TimeSlice, TimeSlice>?)delegate
			{
				OnDataModified();
				OnPropertyChanged("TriggerTime");
			}, (Predicate<TimeSlice>?)null, referenceComparison: false);
		}
	}

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

	public Timeline Owner { get; }

	public TimeSlice TriggerTime => SlideTime;

	ITriggerable ITimeTriggerable.Item => Item;

	public TimeSlice Offset => Owner.TimecodeOffset;

	string ITimeTriggerable.Name => Item.Name;

	Guid ITimeTriggerable.ID { get; } = Guid.NewGuid();

	public event Action? DataModified;

	public ObjectBinder<TimelineItemInfo, Pro.Entity.IPresentation.Types.ITimeline.Types.ICue> Bind(Pro.Entity.IPresentation.Types.ITimeline.Types.ICue right)
	{
		ObjectBinder<TimelineItemInfo, Pro.Entity.IPresentation.Types.ITimeline.Types.ICue> objectBinder = new ObjectBinder<TimelineItemInfo, Pro.Entity.IPresentation.Types.ITimeline.Types.ICue>(this, right);
		objectBinder.Bind((TimelineItemInfo l) => l.WhenPropertyChanges("TriggerTime"), (Pro.Entity.IPresentation.Types.ITimeline.Types.ICue r) => r.TriggerTime.WhenValueChanges, delegate(TimelineItemInfo l, Pro.Entity.IPresentation.Types.ITimeline.Types.ICue r)
		{
			r.TriggerTime.Set(l.TriggerTime.TotalSeconds);
		}, delegate(Pro.Entity.IPresentation.Types.ITimeline.Types.ICue r, TimelineItemInfo l)
		{
			l.SlideTime = TimeSlice.FromSeconds(r.TriggerTime.Value);
		}).Bind((TimelineItemInfo l) => l.WhenPropertyChanges("Name"), (Pro.Entity.IPresentation.Types.ITimeline.Types.ICue r) => r.Name.WhenValueChanges, delegate(TimelineItemInfo l, Pro.Entity.IPresentation.Types.ITimeline.Types.ICue r)
		{
			r.Name.Set(l.Name);
		}, delegate(Pro.Entity.IPresentation.Types.ITimeline.Types.ICue r, TimelineItemInfo l)
		{
			l.Name = r.Name.Value;
		});
		return objectBinder;
	}

	public TimelineItemInfo(ITimelineItem item, TimeSlice slideTime, string name, Timeline owner)
	{
		Item = item;
		SlideTime = slideTime;
		Name = name;
		Owner = owner;
		if (item is Pro.DO.Triggering.IAction action)
		{
			action.DataModified += OnDataModified;
		}
		else if (item is SlideCue slideCue)
		{
			slideCue.DataModified += delegate
			{
				OnDataModified();
			};
		}
		LinkAction("Name", delegate
		{
			Name = Item.Name;
		});
		LinkProperties("GroupName", "GroupName");
		LinkProperties("GroupColor", "GroupColor");
		LinkProperties("TimecodeOffset", "Offset");
		Item.PropertyChanged += base.RaiseLinkedValues;
		Owner.PropertyChanged += base.RaiseLinkedValues;
	}

	public ITimeTriggerable Clone()
	{
		return new TimelineItemInfo(Item, SlideTime, Name, Owner);
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
