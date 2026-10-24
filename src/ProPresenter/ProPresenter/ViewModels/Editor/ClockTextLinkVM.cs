using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Editor;
using Pro.Localization;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

public class ClockTextLinkVM : NotifyPropertyChangedBase, IClockTextLinkVM, INotifyPropertyChanged
{
	private readonly IApp _app;

	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private IEnumerable<TextLink> TextLinks => from e in _selectedElements.OfType<ClosedBezierPath>()
		select e.TextLink;

	private ClockTextLinkedObject? ClockTextLinkedObject => TextLinks.FirstOrDefault()?.LinkedObject as ClockTextLinkedObject;

	private UndoStack? UndoStack => ClockTextLinkedObject?.UndoStack;

	public FormatLength DateFormat
	{
		get
		{
			return ClockTextLinkedObject?.ClockData.DateFormatLength ?? FormatLength.None;
		}
		set
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.DateFormat));
			SetToClockTextLinkedObject(value, TimeFormat, Use24HourFormat);
			UndoStack?.EndCommit(null, NotifyPropertyChanges, autoFinalize: true);
		}
	}

	public FormatLength TimeFormat
	{
		get
		{
			return ClockTextLinkedObject?.ClockData.TimeFormatLength ?? FormatLength.None;
		}
		set
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TimeFormat));
			SetToClockTextLinkedObject(DateFormat, value, Use24HourFormat);
			UndoStack?.EndCommit(null, NotifyPropertyChanges, autoFinalize: true);
		}
	}

	public bool Use24HourFormat
	{
		get
		{
			return ClockTextLinkedObject?.ClockData.Use24HourFormat ?? false;
		}
		set
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.Use24HourFormat));
			SetToClockTextLinkedObject(DateFormat, TimeFormat, value);
			UndoStack?.EndCommit(null, NotifyPropertyChanges, autoFinalize: true);
		}
	}

	public string DisplayFormatText
	{
		get
		{
			return ClockTextLinkedObject?.DisplayFormatText ?? string.Empty;
		}
		set
		{
			if (ClockTextLinkedObject != null)
			{
				ClockTextLinkedObject.DisplayFormatText = value;
				OnPropertyChanged("DisplayFormatText");
			}
		}
	}

	public ClockTokenCollection? ClockTokens => ClockTextLinkedObject?.Tokens;

	public ClockData? ClockData => ClockTextLinkedObject?.ClockData;

	public ICommand SaveAsDefaultCommand => new RelayCommand(OnSaveAsDefaultCommand, () => !IsClockDataDefault(ClockTextLinkedObject?.ClockData));

	public ICommand ResetToDefaultCommand => new RelayCommand(OnResetToDefaultCommand, () => !IsClockDataDefault(ClockTextLinkedObject?.ClockData));

	public ClockTextLinkVM(ObservableCollection<ICanvasElement> selectedElements, IApp app)
	{
		_selectedElements = selectedElements;
		_app = app;
		_selectedElements.CollectionChanged += SelectedElements_CollectionChanged;
	}

	private void SetToClockTextLinkedObject()
	{
		SetToClockTextLinkedObject(_app.DefaultClockDateFormatLength, _app.DefaultClockTimeFormatLength, _app.DefaultClockUse24HourMode);
	}

	private void SetToClockTextLinkedObject(FormatLength dateFormat, FormatLength timeFormat, bool use24HourFormat)
	{
		foreach (TextLink textLink in TextLinks)
		{
			ILinkedTextObject? linkedObject = textLink.LinkedObject;
			if (linkedObject != null && linkedObject.LinkedTextType == LinkedTextType.Clock)
			{
				ClockTextLinkedObject obj = (ClockTextLinkedObject)textLink.LinkedObject;
				obj.ClockData.DateFormatLength = dateFormat;
				obj.ClockData.TimeFormatLength = timeFormat;
				obj.ClockData.Use24HourFormat = use24HourFormat;
			}
			else
			{
				ClockTextLinkedObject clockTextLinkedObject = new ClockTextLinkedObject();
				clockTextLinkedObject.ClockData.DateFormatLength = dateFormat;
				clockTextLinkedObject.ClockData.TimeFormatLength = timeFormat;
				clockTextLinkedObject.ClockData.Use24HourFormat = use24HourFormat;
				textLink.LinkedObject = clockTextLinkedObject;
			}
		}
	}

	private void SelectedElements_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath i)
		{
			i.TextLink.LinkObjectUpdated -= NotifyPropertyChanges;
		});
		e.NewItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath i)
		{
			i.TextLink.LinkObjectUpdated += NotifyPropertyChanges;
		});
		NotifyPropertyChanges();
	}

	private void NotifyPropertyChanges()
	{
		OnPropertyChanged("DateFormat");
		OnPropertyChanged("TimeFormat");
		OnPropertyChanged("Use24HourFormat");
		OnPropertyChanged("DisplayFormatText");
		OnPropertyChanged("ClockData");
		OnPropertyChanged("ClockTokens");
	}

	private void OnSaveAsDefaultCommand()
	{
		_app.SaveClockData(ClockData);
	}

	private void OnResetToDefaultCommand()
	{
		UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ResetToDefaultClockData));
		SetToClockTextLinkedObject();
		UndoStack?.EndCommit();
	}

	private bool IsClockDataDefault(ClockData? clockData)
	{
		if (clockData?.DateFormatLength == _app.DefaultClockDateFormatLength && clockData?.TimeFormatLength == _app.DefaultClockTimeFormatLength)
		{
			return clockData?.Use24HourFormat == _app.DefaultClockUse24HourMode;
		}
		return false;
	}
}
