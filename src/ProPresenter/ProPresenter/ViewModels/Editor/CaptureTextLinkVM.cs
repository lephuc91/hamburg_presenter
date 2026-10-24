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

public class CaptureTextLinkVM : NotifyPropertyChangedBase, ICaptureTextLinkVM, INotifyPropertyChanged
{
	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private IEnumerable<TextLink> TextLinks => SelectedElements.Select((ClosedBezierPath e) => e.TextLink);

	private CaptureTextLinkedObject? CaptureTextLinkedObject => TextLinks.FirstOrDefault()?.LinkedObject as CaptureTextLinkedObject;

	private UndoStack? UndoStack => CaptureTextLinkedObject?.UndoStack;

	public TimerFormatData? TimerFormatData => CaptureTextLinkedObject?.TimerFormatData;

	public CaptureTextType CaptureTextType
	{
		get
		{
			return CaptureTextLinkedObject?.CaptureTextType ?? CaptureTextType.StatusText;
		}
		set
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LinkSlideText));
			UpdateCaptureTextLinks(value);
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public TimerFormatStyle SelectedHourFormat
	{
		get
		{
			return TimerFormatData?.HourFormat ?? TimerFormatStyle.None;
		}
		set
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TimeFormat));
			UpdateCaptureElapsedTimeFormat(value, SelectedMinuteFormat, SelectedSecondFormat, SelectedMillisecondFormat);
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
			UpdateCaptureElapsedTimeFormat(SelectedHourFormat, value, SelectedSecondFormat, SelectedMillisecondFormat);
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
			UpdateCaptureElapsedTimeFormat(SelectedHourFormat, SelectedMinuteFormat, value, SelectedMillisecondFormat);
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
			UpdateCaptureElapsedTimeFormat(SelectedHourFormat, SelectedMinuteFormat, SelectedSecondFormat, value);
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public CaptureTextLinkVM(ObservableCollection<ICanvasElement> selectedElements)
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

	private void UpdateCaptureTextLinks(CaptureTextType value)
	{
		foreach (TextLink textLink in TextLinks)
		{
			if (textLink.LinkedObject is CaptureTextLinkedObject captureTextLinkedObject)
			{
				captureTextLinkedObject.CaptureTextType = value;
				continue;
			}
			textLink.LinkedObject = new CaptureTextLinkedObject
			{
				CaptureTextType = value
			};
		}
		NotifyPropertyChanges();
	}

	private void NotifyPropertyChanges()
	{
		OnPropertyChanged("CaptureTextType");
		OnPropertyChanged("TimerFormatData");
		OnPropertyChanged("SelectedHourFormat");
		OnPropertyChanged("SelectedMinuteFormat");
		OnPropertyChanged("SelectedSecondFormat");
		OnPropertyChanged("SelectedMillisecondFormat");
	}

	private void UpdateCaptureElapsedTimeFormat(TimerFormatStyle hourFormat, TimerFormatStyle minuteFormat, TimerFormatStyle secondFormat, TimerFormatStyle millisecondFormat)
	{
		foreach (TextLink textLink in TextLinks)
		{
			if (textLink.LinkedObject is CaptureTextLinkedObject captureTextLinkedObject)
			{
				TimerFormatData timerFormatData = captureTextLinkedObject.TimerFormatData;
				timerFormatData.HourFormat = hourFormat;
				timerFormatData.MinuteFormat = minuteFormat;
				timerFormatData.SecondFormat = secondFormat;
				timerFormatData.MillisecondFormat = millisecondFormat;
			}
			else
			{
				textLink.LinkedObject = CaptureTextLinkedObject?.Clone();
			}
		}
		NotifyPropertyChanges();
	}
}
