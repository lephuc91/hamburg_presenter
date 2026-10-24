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

public class PlaybackMarkerColorFillLinkVM : NotifyPropertyChangedBase, IPlaybackMarkerLinkVM, INotifyPropertyChanged
{
	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private IEnumerable<FillLink> FillLinks => SelectedElements.Select((ClosedBezierPath e) => e.FillLink);

	private PlaybackMarkerColorLinkedObject? LinkedObject => FillLinks.FirstOrDefault()?.LinkedObject as PlaybackMarkerColorLinkedObject;

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
			return PlaybackMarkerTextType.Name;
		}
		set
		{
		}
	}

	public TimerFormatData PlaybackMarkerTimerFormat
	{
		get
		{
			return new TimerFormatData();
		}
		set
		{
		}
	}

	public bool PlaybackMarkerUsesMarkerColor
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public PlaybackMarkerColorFillLinkVM(ObservableCollection<ICanvasElement> selectedElements)
	{
		_selectedElements = selectedElements;
		_selectedElements.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			e.OldItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath elem)
			{
				elem.FillLink.LinkObjectUpdated -= NotifyPropertyChanges;
			});
			e.NewItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath elem)
			{
				elem.FillLink.LinkObjectUpdated += NotifyPropertyChanges;
			});
			NotifyPropertyChanges();
		};
	}

	private void NotifyPropertyChanges()
	{
		OnPropertyChanged("PlaybackMarkerIdentifierDestination");
		OnPropertyChanged("PlaybackMarkerIdentifierType");
		OnPropertyChanged("PlaybackMarkerIdentifierName");
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
		foreach (FillLink fillLink in FillLinks)
		{
			if (fillLink.LinkedObject is PlaybackMarkerColorLinkedObject playbackMarkerColorLinkedObject)
			{
				playbackMarkerColorLinkedObject.MarkerIdentifier = changeFunc(playbackMarkerColorLinkedObject.MarkerIdentifier);
			}
			else
			{
				fillLink.LinkedObject = new PlaybackMarkerColorLinkedObject(newValue);
			}
		}
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}
}
