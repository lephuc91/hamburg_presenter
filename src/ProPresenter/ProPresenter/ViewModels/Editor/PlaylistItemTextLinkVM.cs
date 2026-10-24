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
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

public class PlaylistItemTextLinkVM : NotifyPropertyChangedBase, IPlaylistItemTextLinkVM, INotifyPropertyChanged
{
	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private IEnumerable<TextLink> TextLinks => SelectedElements.Select((ClosedBezierPath e) => e.TextLink);

	private PlaylistItemLinkedObject? PlaylistItemLinkedObject => TextLinks.FirstOrDefault()?.LinkedObject as PlaylistItemLinkedObject;

	private UndoStack? UndoStack => PlaylistItemLinkedObject?.UndoStack;

	public PlaylistItemSource PlaylistItemSource
	{
		get
		{
			return PlaylistItemLinkedObject?.PlaylistItemSource ?? PlaylistItemSource.Current;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.PlaylistItem.ToAction());
			UpdatePlaylistItemLinks(value, ShowArrangement);
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public bool ShowArrangement
	{
		get
		{
			return PlaylistItemLinkedObject?.ShowArrangement ?? false;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.ShowArrangement.ToAction());
			UpdatePlaylistItemLinks(PlaylistItemSource, value);
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public PlaylistItemTextLinkVM(ObservableCollection<ICanvasElement> selectedElements)
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
		OnPropertyChanged("PlaylistItemSource");
		OnPropertyChanged("ShowArrangement");
	}

	private void UpdatePlaylistItemLinks(PlaylistItemSource source, bool showArrangement)
	{
		foreach (TextLink textLink in TextLinks)
		{
			if (textLink.LinkedObject is PlaylistItemLinkedObject playlistItemLinkedObject)
			{
				playlistItemLinkedObject.PlaylistItemSource = source;
				playlistItemLinkedObject.ShowArrangement = showArrangement;
			}
			else
			{
				textLink.LinkedObject = new PlaylistItemLinkedObject
				{
					PlaylistItemSource = source,
					ShowArrangement = showArrangement
				};
			}
		}
		NotifyPropertyChanges();
	}
}
