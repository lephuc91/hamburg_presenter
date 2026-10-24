using System;
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

public class PlaybackMarkerTextLinkVM : NotifyPropertyChangedBase, IPlaybackMarkerLinkVM, INotifyPropertyChanged
{
	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private IEnumerable<TextLink> TextLinks => SelectedElements.Select((ClosedBezierPath e) => e.TextLink);

	private PlaybackMarkerTextLinkedObject? LinkedObject => TextLinks.FirstOrDefault()?.LinkedObject as PlaybackMarkerTextLinkedObject;

	private UndoStack? UndoStack => LinkedObject?.UndoStack;

	public PlaybackMarkerIdentifierDestination PlaybackMarkerIdentifierDestination
	{
		get
		{
			return LinkedObject?.MarkerIdentifier.Destination ?? PlaybackMarkerIdentifierDestination.Presentation;
		}
		set
		{
			OnPlaybackMarkerIdentifierDestinationChanged(value);
		}
	}

	public PlaybackMarkerIdentifierType PlaybackMarkerIdentifierType
	{
		get
		{
			return LinkedObject?.MarkerIdentifier.Type ?? PlaybackMarkerIdentifierType.Next;
		}
		set
		{
			OnPlaybackMarkerIdentifierTypeChanged(value);
		}
	}

	public string PlaybackMarkerIdentifierName
	{
		get
		{
			return LinkedObject?.MarkerIdentifier.Name ?? string.Empty;
		}
		set
		{
			OnPlaybackMarkerIdentifierNameChanged(value);
		}
	}

	public PlaybackMarkerTextType PlaybackMarkerTextType
	{
		get
		{
			return LinkedObject?.TextType ?? PlaybackMarkerTextType.Name;
		}
		set
		{
			OnPlaybackMarkerTextTypeChanged(value);
		}
	}

	public TimerFormatData PlaybackMarkerTimerFormat
	{
		get
		{
			return LinkedObject?.TimerFormat ?? new TimerFormatData(TimerFormatStyle.None, TimerFormatStyle.Long, TimerFormatStyle.Long, TimerFormatStyle.None);
		}
		set
		{
			OnPlaybackMarkerTimerFormatChanged(value);
		}
	}

	public bool PlaybackMarkerUsesMarkerColor
	{
		get
		{
			return LinkedObject?.UsesMarkerColor ?? false;
		}
		set
		{
			OnPlaybackMarkerUsesMarkerColorChanged(value);
		}
	}

	public TimerFormatStyle HourFormat
	{
		get
		{
			return PlaybackMarkerTimerFormat.HourFormat;
		}
		set
		{
			OnPlaybackMarkerTimerFormatChanged(new TimerFormatData(value, PlaybackMarkerTimerFormat.MinuteFormat, PlaybackMarkerTimerFormat.SecondFormat, PlaybackMarkerTimerFormat.MillisecondFormat));
		}
	}

	public TimerFormatStyle MinuteFormat
	{
		get
		{
			return PlaybackMarkerTimerFormat.MinuteFormat;
		}
		set
		{
			OnPlaybackMarkerTimerFormatChanged(new TimerFormatData(PlaybackMarkerTimerFormat.HourFormat, value, PlaybackMarkerTimerFormat.SecondFormat, PlaybackMarkerTimerFormat.MillisecondFormat));
		}
	}

	public TimerFormatStyle SecondFormat
	{
		get
		{
			return PlaybackMarkerTimerFormat.SecondFormat;
		}
		set
		{
			OnPlaybackMarkerTimerFormatChanged(new TimerFormatData(PlaybackMarkerTimerFormat.HourFormat, PlaybackMarkerTimerFormat.MinuteFormat, value, PlaybackMarkerTimerFormat.MillisecondFormat));
		}
	}

	public TimerFormatStyle MillisecondFormat
	{
		get
		{
			return PlaybackMarkerTimerFormat.MillisecondFormat;
		}
		set
		{
			OnPlaybackMarkerTimerFormatChanged(new TimerFormatData(PlaybackMarkerTimerFormat.HourFormat, PlaybackMarkerTimerFormat.MinuteFormat, PlaybackMarkerTimerFormat.SecondFormat, value));
		}
	}

	public PlaybackMarkerTextLinkVM(ObservableCollection<ICanvasElement> selectedElements)
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
		OnPropertyChanged("PlaybackMarkerIdentifierDestination");
		OnPropertyChanged("PlaybackMarkerIdentifierType");
		OnPropertyChanged("PlaybackMarkerIdentifierName");
		OnPropertyChanged("PlaybackMarkerTextType");
		OnPropertyChanged("PlaybackMarkerTimerFormat");
		OnPropertyChanged("HourFormat");
		OnPropertyChanged("MinuteFormat");
		OnPropertyChanged("SecondFormat");
		OnPropertyChanged("MillisecondFormat");
		OnPropertyChanged("PlaybackMarkerUsesMarkerColor");
	}

	private void OnPlaybackMarkerIdentifierDestinationChanged(PlaybackMarkerIdentifierDestination value)
	{
		OnPlaybackMarkerIdentifierChanged((PlaybackMarkerIdentifier m) => new PlaybackMarkerIdentifier(value, m.Type, m.Name), new PlaybackMarkerIdentifier(value, PlaybackMarkerIdentifierType.Next));
		OnPropertyChanged("PlaybackMarkerIdentifierDestination");
	}

	private void OnPlaybackMarkerIdentifierTypeChanged(PlaybackMarkerIdentifierType value)
	{
		OnPlaybackMarkerIdentifierChanged((PlaybackMarkerIdentifier m) => new PlaybackMarkerIdentifier(m.Destination, value, m.Name), new PlaybackMarkerIdentifier(PlaybackMarkerIdentifierDestination.Presentation, value));
		OnPropertyChanged("PlaybackMarkerIdentifierType");
	}

	private void OnPlaybackMarkerIdentifierNameChanged(string value)
	{
		OnPlaybackMarkerIdentifierChanged((PlaybackMarkerIdentifier m) => new PlaybackMarkerIdentifier(m.Destination, PlaybackMarkerIdentifierType.Name, value), new PlaybackMarkerIdentifier(PlaybackMarkerIdentifierDestination.Presentation, PlaybackMarkerIdentifierType.Name, value));
		OnPropertyChanged("PlaybackMarkerIdentifierName");
	}

	private void OnPlaybackMarkerIdentifierChanged(Func<PlaybackMarkerIdentifier, PlaybackMarkerIdentifier> changeFunc, PlaybackMarkerIdentifier newValue)
	{
		UndoStack?.BeginCommit(UndoActionTypes.PlaybackMarkerIdentifier.ToAction());
		foreach (TextLink textLink in TextLinks)
		{
			if (textLink.LinkedObject is PlaybackMarkerTextLinkedObject playbackMarkerTextLinkedObject)
			{
				playbackMarkerTextLinkedObject.MarkerIdentifier = changeFunc(playbackMarkerTextLinkedObject.MarkerIdentifier);
				continue;
			}
			textLink.LinkedObject = new PlaybackMarkerTextLinkedObject
			{
				MarkerIdentifier = newValue
			};
		}
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	private void OnPlaybackMarkerTextTypeChanged(PlaybackMarkerTextType value)
	{
		UndoStack?.BeginCommit(UndoActionTypes.PlaybackMarkerTextType.ToAction());
		foreach (TextLink textLink in TextLinks)
		{
			if (textLink.LinkedObject is PlaybackMarkerTextLinkedObject playbackMarkerTextLinkedObject)
			{
				playbackMarkerTextLinkedObject.TextType = value;
				continue;
			}
			textLink.LinkedObject = new PlaybackMarkerTextLinkedObject
			{
				TextType = value
			};
		}
		UndoStack?.EndCommit(null, null, autoFinalize: true);
		OnPropertyChanged("PlaybackMarkerTextType");
	}

	private void OnPlaybackMarkerTimerFormatChanged(TimerFormatData value)
	{
		UndoStack?.BeginCommit(UndoActionTypes.PlaybackMarkerTimerFormat.ToAction());
		foreach (TextLink textLink in TextLinks)
		{
			if (textLink.LinkedObject is PlaybackMarkerTextLinkedObject playbackMarkerTextLinkedObject)
			{
				playbackMarkerTextLinkedObject.TimerFormat = value;
				continue;
			}
			textLink.LinkedObject = new PlaybackMarkerTextLinkedObject
			{
				TimerFormat = value
			};
		}
		UndoStack?.EndCommit(null, null, autoFinalize: true);
		OnPropertyChanged("PlaybackMarkerTimerFormat");
		OnPropertyChanged("HourFormat");
		OnPropertyChanged("MinuteFormat");
		OnPropertyChanged("SecondFormat");
		OnPropertyChanged("MillisecondFormat");
	}

	private void OnPlaybackMarkerUsesMarkerColorChanged(bool value)
	{
		UndoStack?.BeginCommit(UndoActionTypes.PlaybackMarkerTextUsesColor.ToAction());
		foreach (TextLink textLink in TextLinks)
		{
			if (textLink.LinkedObject is PlaybackMarkerTextLinkedObject playbackMarkerTextLinkedObject)
			{
				playbackMarkerTextLinkedObject.UsesMarkerColor = value;
				continue;
			}
			textLink.LinkedObject = new PlaybackMarkerTextLinkedObject
			{
				UsesMarkerColor = value
			};
		}
		UndoStack?.EndCommit(null, null, autoFinalize: true);
		OnPropertyChanged("PlaybackMarkerUsesMarkerColor");
	}
}
