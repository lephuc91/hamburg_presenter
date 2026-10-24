using System.Collections.ObjectModel;
using System.ComponentModel;
using Pro.Common.Components.Reversibility;
using Pro.Editor;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels.Editor.Links;

namespace ProPresenter.ViewModels.Editor.Links;

public class FormatDataVM : LinkedTextObjectVMBase, IFormatDataVM, INotifyPropertyChanged
{
	private readonly UndoActionTypes _linkFormatUndoType;

	private readonly UndoActionTypes _timeFormatUndoType;

	public TimerLinkFormatData? FormatData => (base.LinkedTextObject as ITimerFormattable)?.FormatData;

	public IColorTriggersVM ColorTriggersVM { get; }

	public TimerTokenCollection? TimerTokens => FormatData?.Tokens;

	public TimerFormatData? TimerFormatData => FormatData?.Style;

	public string DisplayFormatText
	{
		get
		{
			return FormatData?.Text ?? string.Empty;
		}
		set
		{
			if (FormatData != null)
			{
				base.UndoStack?.BeginCommit(_linkFormatUndoType.ToAction());
				FormatData.Text = value;
				OnPropertyChanged("DisplayFormatText");
				base.UndoStack?.EndCommit(null, delegate
				{
					OnPropertyChanged("DisplayFormatText");
				});
			}
		}
	}

	public TimerFormatStyle SelectedHourFormat
	{
		get
		{
			return FormatData?.Style.HourFormat ?? TimerFormatStyle.None;
		}
		set
		{
			UpdateTimerTextLinks(value, SelectedMinuteFormat, SelectedSecondFormat, SelectedMillisecondFormat);
		}
	}

	public TimerFormatStyle SelectedMinuteFormat
	{
		get
		{
			return FormatData?.Style.MinuteFormat ?? TimerFormatStyle.None;
		}
		set
		{
			UpdateTimerTextLinks(SelectedHourFormat, value, SelectedSecondFormat, SelectedMillisecondFormat);
		}
	}

	public TimerFormatStyle SelectedSecondFormat
	{
		get
		{
			return FormatData?.Style.SecondFormat ?? TimerFormatStyle.None;
		}
		set
		{
			UpdateTimerTextLinks(SelectedHourFormat, SelectedMinuteFormat, value, SelectedMillisecondFormat);
		}
	}

	public TimerFormatStyle SelectedMillisecondFormat
	{
		get
		{
			return FormatData?.Style.MillisecondFormat ?? TimerFormatStyle.None;
		}
		set
		{
			UpdateTimerTextLinks(SelectedHourFormat, SelectedMinuteFormat, SelectedSecondFormat, value);
		}
	}

	public FormatDataVM(ObservableCollection<ICanvasElement> selectedElements, UndoActionTypes linkFormatUndoType, UndoActionTypes timeFormatUndoType, IColorTriggerVMFactory colorTriggerVMFactory)
		: base(selectedElements)
	{
		_linkFormatUndoType = linkFormatUndoType;
		_timeFormatUndoType = timeFormatUndoType;
		ColorTriggersVM = colorTriggerVMFactory.CreateColorTriggersVM();
	}

	protected override void NotifyPropertyChanges()
	{
		OnPropertyChanged("TimerFormatData");
		OnPropertyChanged("DisplayFormatText");
		OnPropertyChanged("TimerTokens");
		OnPropertyChanged("SelectedHourFormat");
		OnPropertyChanged("SelectedMinuteFormat");
		OnPropertyChanged("SelectedSecondFormat");
		OnPropertyChanged("SelectedMillisecondFormat");
		ColorTriggersVM.UpdateColorTriggers(this);
	}

	private void UpdateTimerTextLinks(TimerFormatStyle hourFormat, TimerFormatStyle minuteFormat, TimerFormatStyle secondFormat, TimerFormatStyle millisecondFormat)
	{
		base.UndoStack?.BeginCommit(_timeFormatUndoType.ToAction());
		foreach (TextLink textLink in base.TextLinks)
		{
			TimerLinkFormatData timerLinkFormatData = (textLink.LinkedObject as ITimerFormattable)?.FormatData;
			if (timerLinkFormatData != null)
			{
				timerLinkFormatData.Style.HourFormat = hourFormat;
				timerLinkFormatData.Style.MinuteFormat = minuteFormat;
				timerLinkFormatData.Style.SecondFormat = secondFormat;
				timerLinkFormatData.Style.MillisecondFormat = millisecondFormat;
			}
			else
			{
				textLink.LinkedObject = base.LinkedTextObject?.Clone();
			}
		}
		base.UndoStack?.EndCommit(null, null, autoFinalize: true);
	}
}
