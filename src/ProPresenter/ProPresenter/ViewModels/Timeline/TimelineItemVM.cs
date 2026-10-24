using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Time;
using Pro.UI.Themes;
using Pro.ssAPI;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;
using ProPresenter.UI.ViewModels.Timeline;

namespace ProPresenter.ViewModels.Timeline;

public class TimelineItemVM : LinkedNotifyPropertyChangedBase, ITimelineItemVM, INotifyPropertyChanged
{
	private bool _fillToNextItem;

	private TimelineItemInfo _item;

	private TimelineItemNamePattern _namePattern;

	public Brush? Background => GetBackground();

	public TimeSlice Duration => GetDuration();

	public bool FillToNextItem
	{
		get
		{
			return _fillToNextItem;
		}
		set
		{
			SetValue("FillToNextItem", ref _fillToNextItem, value);
		}
	}

	public string GroupName => Item?.GroupName ?? string.Empty;

	public TimelineItemInfo Item
	{
		get
		{
			return _item;
		}
		[MemberNotNull("_item")]
		private set
		{
			SetValue("Item", ref _item, value, (Action)delegate
			{
				OnPropertyChanged("Name");
			}, (Predicate<TimelineItemInfo>?)null, referenceComparison: false);
		}
	}

	public TimelineItemType ItemType => Item?.Item.TimelineItemType ?? TimelineItemType.Slide;

	public string Name => Item.GetName(NamePattern);

	public TimelineItemNamePattern NamePattern
	{
		get
		{
			return _namePattern;
		}
		set
		{
			SetValue("NamePattern", ref _namePattern, value, (Action)delegate
			{
				OnPropertyChanged("Name");
			}, (Predicate<TimelineItemNamePattern>?)null, referenceComparison: false);
		}
	}

	public TimeSlice StartTime
	{
		get
		{
			return Item?.SlideTime ?? TimeSlice.Zero;
		}
		set
		{
			if (Item != null)
			{
				Item.SlideTime = value;
			}
		}
	}

	public TimelineItemVM(TimelineItemInfo item)
	{
		Item = item;
		if (Item.Item is SlideCue slideCue && slideCue.ParentPresentation?.DefaultArrangement.ArrangedCues != null)
		{
			slideCue.ParentPresentation.DefaultArrangement.ArrangedCues.CollectionChanged += delegate
			{
				OnPropertyChanged("Name");
				OnPropertyChanged("Background");
			};
		}
		else if (ItemType == TimelineItemType.AudioMedia || ItemType == TimelineItemType.VisualMedia)
		{
			if (((MediaAction)Item.Item).Media is ITransportMedia transportMedia)
			{
				LinkProperties(new string[4] { "InOutDuration", "PlaybackBehaviorType", "LoopCount", "LoopTime" }, "Duration");
				transportMedia.Transport.PropertyChanged += base.RaiseLinkedValues;
			}
			else
			{
				FillToNextItem = true;
			}
		}
		LinkProperties("GroupName", "GroupName");
		LinkProperties("GroupColor", "Background");
		LinkProperties("SlideTime", "StartTime");
		LinkProperties("Name", "Name");
		Item.PropertyChanged += base.RaiseLinkedValues;
	}

	private Brush? GetBackground()
	{
		if (ItemType == TimelineItemType.Slide)
		{
			if (Item.GroupColor.HasValue)
			{
				return new SolidColorBrush(Item.GroupColor.Value);
			}
			return Pro.UI.Themes.Brushes.GetBrush(Pro.UI.Themes.Brushes.ThumbnailUngroupedBrush);
		}
		if (ItemType == TimelineItemType.AudioMedia || ItemType == TimelineItemType.VisualMedia)
		{
			if (ItemType != TimelineItemType.AudioMedia)
			{
				return Pro.UI.Themes.Brushes.GetBrush(Pro.UI.Themes.Brushes.TimelineVisualMediaItem);
			}
			return Pro.UI.Themes.Brushes.GetBrush(Pro.UI.Themes.Brushes.TimelineAudioMediaItem);
		}
		return System.Windows.Media.Brushes.Transparent;
	}

	private TimeSlice GetDuration()
	{
		if (Item.Item is MediaAction { Media: ITransportMedia media })
		{
			switch (media.Transport.PlaybackBehaviorType)
			{
			case PlaybackBehaviorType.Stop:
				FillToNextItem = false;
				return media.Transport.InOutDuration;
			case PlaybackBehaviorType.Loop:
				FillToNextItem = true;
				return media.Transport.InOutDuration;
			case PlaybackBehaviorType.LoopForCount:
				FillToNextItem = false;
				return media.Transport.InOutDuration * media.Transport.LoopCount;
			case PlaybackBehaviorType.LoopForTime:
				FillToNextItem = false;
				return media.Transport.LoopTime;
			}
		}
		return TimeSlice.FromMinutes(1.0);
	}
}
