using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Editor;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

public class AutoAdvanceTextLinkVM : NotifyPropertyChangedBase, IAutoAdvanceTextLinkVM, INotifyPropertyChanged
{
	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private IEnumerable<TextLink> TextLinks => SelectedElements.Select((ClosedBezierPath e) => e.TextLink);

	private AutoAdvanceLinkedObject? AutoAdvanceLinkedObject => TextLinks.FirstOrDefault()?.LinkedObject as AutoAdvanceLinkedObject;

	private UndoStack? UndoStack => AutoAdvanceLinkedObject?.UndoStack;

	public SourceType AutoAdvanceSource
	{
		get
		{
			return AutoAdvanceLinkedObject?.AutoAdvanceSource ?? SourceType.Presentation;
		}
		set
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LinkSlideText));
			UpdateAutoAdvanceLinks(value);
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public TimerFormatData? TimerFormatData => AutoAdvanceLinkedObject?.TimerFormatData;

	public TimerFormatStyle SelectedHourFormat
	{
		get
		{
			return TimerFormatData?.HourFormat ?? TimerFormatStyle.None;
		}
		set
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TimeFormat));
			UpdateAutoAdvanceTimerFormat(value, SelectedMinuteFormat, SelectedSecondFormat, SelectedMillisecondFormat);
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public TimerFormatStyle SelectedMinuteFormat
	{
		get
		{
			return TimerFormatData?.MinuteFormat ?? TimerFormatStyle.None;
		}
		set
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TimeFormat));
			UpdateAutoAdvanceTimerFormat(SelectedHourFormat, value, SelectedSecondFormat, SelectedMillisecondFormat);
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public TimerFormatStyle SelectedSecondFormat
	{
		get
		{
			return TimerFormatData?.SecondFormat ?? TimerFormatStyle.None;
		}
		set
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TimeFormat));
			UpdateAutoAdvanceTimerFormat(SelectedHourFormat, SelectedMinuteFormat, value, SelectedMillisecondFormat);
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public TimerFormatStyle SelectedMillisecondFormat
	{
		get
		{
			return TimerFormatData?.MillisecondFormat ?? TimerFormatStyle.None;
		}
		set
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TimeFormat));
			UpdateAutoAdvanceTimerFormat(SelectedHourFormat, SelectedMinuteFormat, SelectedSecondFormat, value);
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public AutoAdvanceTextLinkVM(ObservableCollection<ICanvasElement> selectedElements)
	{
		_selectedElements = selectedElements;
		_selectedElements.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			e.OldItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath elem)
			{
				elem.TextLink.LinkObjectUpdated -= NotifyPropertyChanges;
			});
			e.NewItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath elem)
			{
				elem.TextLink.LinkObjectUpdated += NotifyPropertyChanges;
			});
			NotifyPropertyChanges();
		};
	}

	private void NotifyPropertyChanges()
	{
		OnPropertyChanged("AutoAdvanceSource");
		OnPropertyChanged("TimerFormatData");
		OnPropertyChanged("SelectedHourFormat");
		OnPropertyChanged("SelectedMinuteFormat");
		OnPropertyChanged("SelectedSecondFormat");
		OnPropertyChanged("SelectedMillisecondFormat");
	}

	private void UpdateAutoAdvanceLinks(SourceType value)
	{
		foreach (TextLink textLink in TextLinks)
		{
			if (textLink.LinkedObject is AutoAdvanceLinkedObject autoAdvanceLinkedObject)
			{
				autoAdvanceLinkedObject.AutoAdvanceSource = value;
				continue;
			}
			textLink.LinkedObject = new AutoAdvanceLinkedObject
			{
				AutoAdvanceSource = value
			};
		}
		NotifyPropertyChanges();
	}

	private void UpdateAutoAdvanceTimerFormat(TimerFormatStyle hourFormat, TimerFormatStyle minuteFormat, TimerFormatStyle secondFormat, TimerFormatStyle millisecondFormat)
	{
		foreach (TextLink textLink in TextLinks)
		{
			if (textLink.LinkedObject is AutoAdvanceLinkedObject autoAdvanceLinkedObject)
			{
				TimerFormatData timerFormatData = autoAdvanceLinkedObject.TimerFormatData;
				timerFormatData.HourFormat = hourFormat;
				timerFormatData.MinuteFormat = minuteFormat;
				timerFormatData.SecondFormat = secondFormat;
				timerFormatData.MillisecondFormat = millisecondFormat;
			}
			else
			{
				textLink.LinkedObject = AutoAdvanceLinkedObject?.Clone();
			}
		}
		NotifyPropertyChanges();
	}
}
