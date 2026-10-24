using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using Pro.Common.Components;
using Pro.Localization;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Presentation;
using ProPresenter.UI.ViewModels.QuickSearch;

namespace ProPresenter.ViewModels.QuickSearch;

public class MultiTracksPreviewVM : NotifyPropertyChangedBase, IQuickSearchPreviewVM, INotifyPropertyChanged
{
	private MultiTracksSearchResult? _activeSearchResult;

	public IEnumerable<QuickSearchPreviewType> AvailablePreviews { get; } = new QuickSearchPreviewType[1] { QuickSearchPreviewType.FeaturedImage };

	public QuickSearchPreviewType SelectedPreview
	{
		get
		{
			return QuickSearchPreviewType.FeaturedImage;
		}
		set
		{
		}
	}

	public MultiTracksSearchResult? ActiveSearchResult
	{
		get
		{
			return _activeSearchResult;
		}
		set
		{
			SetValue<MultiTracksSearchResult>("ActiveSearchResult", ref _activeSearchResult, value, delegate(MultiTracksSearchResult o, MultiTracksSearchResult n)
			{
				OnPropertyChanged("Title");
				OnPropertyChanged("Subtitle1");
				OnPropertyChanged("Subtitle2");
				OnPropertyChanged("ID");
				OnPropertyChanged("Content");
				OnPropertyChanged("Image");
				OnPropertyChanged("MusicalKey");
				OnPropertyChanged("HasLyrics");
				OnPropertyChanged("HasChords");
				OnPropertyChanged("HasAutomation");
				OnPropertyChanged("ShowPreview");
				if (o != null)
				{
					o.PropertyChanged -= ActiveSearchResultPropertyChanged;
				}
				if (n != null)
				{
					n.PropertyChanged += ActiveSearchResultPropertyChanged;
				}
			});
		}
	}

	public string? Title => ActiveSearchResult?.Title;

	public string? Subtitle1 => ActiveSearchResult?.Artist;

	public string? Subtitle2 => ActiveSearchResult?.Album;

	public string ID => LocalizedStrings.Get("PRESENTATION_QUICK_SEARCH_MTID_label", new object[1] { ActiveSearchResult?.ID ?? 0 });

	public string? Content => ActiveSearchResult?.LyricsPreview;

	public BitmapSource? Image => ActiveSearchResult?.Image;

	public bool ShowPreview => ActiveSearchResult != null;

	public ISearchCommandVM[] CommandVMs { get; }

	public IPresentation? SelectedPresentation => null;

	public bool IsAvailable => true;

	public ICommand<IPresentation>? OpenWebsiteCommand => null;

	public ICommand<IPresentation>? RetryAuthorizationCommand => null;

	public string MusicalKey => ActiveSearchResult?.OriginalKey?.ToString() ?? string.Empty;

	public bool HasLyrics => ActiveSearchResult?.HasLyrics ?? false;

	public bool HasChords => ActiveSearchResult?.HasChords ?? false;

	public bool HasAutomation => ActiveSearchResult?.HasAutomation ?? false;

	public MultiTracksPreviewVM(params ISearchCommandVM[] commands)
	{
		CommandVMs = commands;
	}

	private void ActiveSearchResultPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Image")
		{
			OnPropertyChanged("Image");
		}
	}
}
