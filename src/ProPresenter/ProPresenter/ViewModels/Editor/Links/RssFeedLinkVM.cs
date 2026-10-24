using System.Collections.ObjectModel;
using System.ComponentModel;
using Pro.Common.Components.Reversibility;
using Pro.Editor;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI.ViewModels.Editor.Links;

namespace ProPresenter.ViewModels.Editor.Links;

public class RssFeedLinkVM : LinkedTextObjectVMBase, IRssFeedLinkVM, INotifyPropertyChanged
{
	public RssFeedContentMode ContentMode
	{
		get
		{
			return RssFeedLinkedObject?.ContentMode ?? RssFeedContentMode.TextOnly;
		}
		set
		{
			base.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TickerSourceRSSContentMode));
			UpdateRssFeed(value, Url, TextDelimiter);
			base.UndoStack?.EndCommit(null, delegate
			{
				OnPropertyChanged("ContentMode");
			}, autoFinalize: true);
			NotifyPropertyChanges();
		}
	}

	public string Url
	{
		get
		{
			return RssFeedLinkedObject?.Url ?? string.Empty;
		}
		set
		{
			base.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TickerSourceRSSUrl));
			UpdateRssFeed(ContentMode, value, TextDelimiter);
			base.UndoStack?.EndCommit(null, delegate
			{
				OnPropertyChanged("Url");
			});
			NotifyPropertyChanges();
		}
	}

	public string? TextDelimiter
	{
		get
		{
			return RssFeedLinkedObject?.TextDelimiter;
		}
		set
		{
			base.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TickerDelimiter));
			UpdateRssFeed(ContentMode, Url, value);
			base.UndoStack?.EndCommit(null, delegate
			{
				OnPropertyChanged("TextDelimiter");
			});
			NotifyPropertyChanges();
		}
	}

	private RssFeedLinkedObject? RssFeedLinkedObject => base.LinkedTextObject as RssFeedLinkedObject;

	public RssFeedLinkVM(ObservableCollection<ICanvasElement> selectedElements)
		: base(selectedElements)
	{
	}

	protected override void NotifyPropertyChanges()
	{
		OnPropertyChanged("ContentMode");
		OnPropertyChanged("Url");
		OnPropertyChanged("TextDelimiter");
	}

	private void UpdateRssFeed(RssFeedContentMode contentMode, string url, string? textDelimiter)
	{
		foreach (TextLink textLink in base.TextLinks)
		{
			if (textLink.LinkedObject is RssFeedLinkedObject rssFeedLinkedObject)
			{
				rssFeedLinkedObject.ContentMode = contentMode;
				rssFeedLinkedObject.Url = url;
				rssFeedLinkedObject.TextDelimiter = textDelimiter;
			}
			else
			{
				textLink.LinkedObject = new RssFeedLinkedObject
				{
					ContentMode = contentMode,
					Url = url,
					TextDelimiter = textDelimiter
				};
			}
		}
	}
}
