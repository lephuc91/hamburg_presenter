using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Time;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Timecode;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class TimecodeItemVM : LinkedNotifyPropertyChangedBase, ITimecodeItemVM, INotifyPropertyChanged
{
	private readonly ITimecodeService _service;

	private TimeSlice _time;

	private TimerFormatData FormatData { get; }

	public ITimeTriggerable Item { get; }

	public TimeSlice Time
	{
		get
		{
			return _time;
		}
		set
		{
			SetValue("Time", ref _time, value, (Action<TimeSlice, TimeSlice>?)delegate
			{
				OnPropertyChanged("TimeStr");
			}, (Predicate<TimeSlice>?)null, referenceComparison: false);
		}
	}

	public string TimeStr => Time.FormatTime(_service.ActiveTimecodeSettings.Format.ToDouble(), showSubSeconds: true, FormatData) ?? string.Empty;

	public string Name => Item?.GetName(TimelineItemNamePattern.Timecode) ?? string.Empty;

	public Guid SequenceID { get; } = Guid.NewGuid();

	public TimecodeItemVM(ITimeTriggerable item, ITimecodeService timecodeService)
	{
		Item = item;
		_service = timecodeService;
		FormatData = new TimerFormatData
		{
			HourFormat = TimerFormatStyle.Long,
			MinuteFormat = TimerFormatStyle.Long,
			SecondFormat = TimerFormatStyle.Long,
			MillisecondFormat = TimerFormatStyle.None
		};
		LinkProperties("Format", "TimeStr");
		LinkProperties("Name", "Name");
		LinkAction(new string[2] { "TriggerTime", "Offset" }, UpdateTime);
		LinkProperties("Name", "Name");
		if (item is TimelineItemInfo timelineItemInfo)
		{
			if (item.Item is SlideCue)
			{
				timelineItemInfo.Owner.Presentation.DefaultArrangement.ArrangedCues.CollectionChanged += delegate
				{
					OnPropertyChanged("Name");
				};
			}
			timelineItemInfo.Owner.Presentation.PropertyChanged += base.RaiseLinkedValues;
		}
		Item.PropertyChanged += base.RaiseLinkedValues;
		_service.ActiveTimecodeSettings.PropertyChanged += base.RaiseLinkedValues;
		UpdateTime();
	}

	private void UpdateTime()
	{
		Time = TimeSlice.FromSeconds((Item?.TriggerTime.TotalSeconds ?? 0.0) + (Item?.Offset.TotalSeconds ?? 0.0));
	}
}
