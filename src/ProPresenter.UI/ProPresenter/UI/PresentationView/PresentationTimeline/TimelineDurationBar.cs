using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using Pro.Common.Time;
using Pro.UI.DependencyInjection;
using ProPresenter.UI.ViewModels.Timeline;

namespace ProPresenter.UI.PresentationView.PresentationTimeline;

public class TimelineDurationBar : TimelineRow
{
	private enum Rounding
	{
		Up,
		Down
	}

	private enum TimeBarScale
	{
		Seconds,
		Minutes,
		Hours,
		Days
	}

	private readonly ObservableCollection<ITimelineItemVM> _timeBarSections = new ObservableCollection<ITimelineItemVM>();

	private readonly ITimelineItemVMFactory _factory;

	private int _subTickCount;

	static TimelineDurationBar()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TimelineDurationBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(TimelineDurationBar)));
	}

	public TimelineDurationBar()
	{
		base.ItemsSource = _timeBarSections;
		_factory = UIServiceProvider.GetService<ITimelineItemVMFactory>();
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		TimelineTimeSection timelineTimeSection = new TimelineTimeSection();
		timelineTimeSection.SubTickCount = _subTickCount;
		timelineTimeSection.Initialize(this);
		return (DependencyObject)(object)timelineTimeSection;
	}

	protected override void OnDurationChanged(TimeSlice oldValue, TimeSlice newValue)
	{
		Initialize();
	}

	protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
	{
	}

	protected override void OnVisibleDurationChanged(TimeSlice oldValue, TimeSlice newValue)
	{
		Initialize();
	}

	protected override void OnVisibleDurationStartChanged(TimeSlice oldValue, TimeSlice newValue)
	{
		Initialize();
	}

	private void Initialize()
	{
		_timeBarSections.Clear();
		if (base.Duration.Equals(TimeSlice.Zero) || base.VisibleDuration.Equals(TimeSlice.Zero))
		{
			return;
		}
		double num = base.VisibleDuration.TotalSeconds;
		TimeBarScale timeBarScale = TimeBarScale.Seconds;
		double num2 = 0.0;
		while (num > 20.0)
		{
			for (num2 += 5.0; 60.0 % num2 != 0.0; num2 += 5.0)
			{
			}
			switch (timeBarScale)
			{
			case TimeBarScale.Seconds:
				if (num2 > 30.0)
				{
					timeBarScale = TimeBarScale.Minutes;
					num2 = 0.0;
					num = base.VisibleDuration.TotalMinutes;
				}
				else
				{
					num = base.VisibleDuration.TotalSeconds / num2;
				}
				break;
			case TimeBarScale.Minutes:
				if (num2 > 30.0)
				{
					timeBarScale = TimeBarScale.Hours;
					num2 = 0.0;
					num = base.VisibleDuration.TotalHours;
				}
				else
				{
					num = base.VisibleDuration.TotalMinutes / num2;
				}
				break;
			case TimeBarScale.Hours:
				if (num2 > 30.0)
				{
					timeBarScale = TimeBarScale.Days;
					num2 = 0.0;
					num = base.VisibleDuration.TotalDays;
				}
				else
				{
					num = base.VisibleDuration.TotalHours / num2;
				}
				break;
			case TimeBarScale.Days:
				if (num2 <= 30.0)
				{
					num = base.VisibleDuration.TotalHours / num2;
				}
				break;
			}
		}
		if (num2 == 0.0)
		{
			num2 = 1.0;
		}
		TimeSlice timeSlice = TimeSlice.Zero;
		switch (timeBarScale)
		{
		case TimeBarScale.Seconds:
			timeSlice = TimeSlice.FromSeconds(num2);
			break;
		case TimeBarScale.Minutes:
			timeSlice = TimeSlice.FromMinutes(num2);
			break;
		case TimeBarScale.Hours:
			timeSlice = TimeSlice.FromHours(num2);
			break;
		case TimeBarScale.Days:
			timeSlice = TimeSlice.FromDays(num2);
			break;
		}
		if (Math.Abs(num2 - 1.0) < double.Epsilon)
		{
			_subTickCount = 4;
		}
		else if (Math.Abs(num2 - 5.0) < double.Epsilon)
		{
			_subTickCount = 5;
		}
		else if (Math.Abs(num2 - 10.0) < double.Epsilon)
		{
			_subTickCount = 10;
		}
		else if (Math.Abs(num2 - 15.0) < double.Epsilon)
		{
			_subTickCount = 3;
		}
		else if (Math.Abs(num2 - 20.0) < double.Epsilon)
		{
			_subTickCount = 4;
		}
		else if (Math.Abs(num2 - 30.0) < double.Epsilon)
		{
			_subTickCount = 6;
		}
		TimeSlice timeSlice2 = Round(timeBarScale, num2, base.VisibleDurationStart - timeSlice, Rounding.Down);
		TimeSlice timeSlice3 = base.VisibleDurationStart + base.VisibleDuration;
		if (timeSlice3 >= base.Duration)
		{
			timeSlice3 = ((!(base.Duration - base.VisibleDuration <= base.VisibleDurationStart)) ? (base.Duration - base.VisibleDuration) : base.Duration);
		}
		for (TimeSlice timeSlice4 = Round(timeBarScale, num2, timeSlice3 + timeSlice, Rounding.Up); timeSlice2 <= timeSlice4; timeSlice2 += timeSlice)
		{
			ITimeTickSection item = _factory.CreateTickSection(timeSlice2, timeSlice);
			_timeBarSections.Add(item);
		}
	}

	private TimeSlice Round(TimeBarScale timeScale, double multiplier, TimeSlice time, Rounding rounding)
	{
		double num = 0.0;
		switch (timeScale)
		{
		case TimeBarScale.Seconds:
			num = time.TotalSeconds % multiplier;
			break;
		case TimeBarScale.Minutes:
			num = time.TotalMinutes % multiplier;
			break;
		case TimeBarScale.Hours:
			num = time.TotalHours % multiplier;
			break;
		case TimeBarScale.Days:
			num = time.TotalDays % multiplier;
			break;
		}
		if (num == 0.0)
		{
			return time;
		}
		switch (timeScale)
		{
		case TimeBarScale.Seconds:
			if (rounding != 0)
			{
				return TimeSlice.FromSeconds(time.TotalSeconds - num);
			}
			return TimeSlice.FromSeconds(multiplier - num + time.TotalSeconds);
		case TimeBarScale.Minutes:
			if (rounding != 0)
			{
				return TimeSlice.FromMinutes(time.TotalMinutes - num);
			}
			return TimeSlice.FromMinutes(multiplier - num + time.TotalMinutes);
		case TimeBarScale.Hours:
			if (rounding != 0)
			{
				return TimeSlice.FromHours(time.TotalHours - num);
			}
			return TimeSlice.FromHours(multiplier - num + time.TotalHours);
		case TimeBarScale.Days:
			if (rounding != 0)
			{
				return TimeSlice.FromDays(time.TotalDays - num);
			}
			return TimeSlice.FromDays(multiplier - num + time.TotalDays);
		default:
			throw new NotSupportedException();
		}
	}
}
