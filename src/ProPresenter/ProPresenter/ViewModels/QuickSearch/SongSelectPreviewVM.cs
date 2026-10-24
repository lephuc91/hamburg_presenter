using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using Pro.Common.Components;
using Pro.Localization;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.SongSelect;
using ProPresenter.UI.ViewModels.QuickSearch;

namespace ProPresenter.ViewModels.QuickSearch;

public class SongSelectPreviewVM : LinkedNotifyPropertyChangedBase, IQuickSearchPreviewVM, INotifyPropertyChanged
{
	private ISongSelectSearchResult? _selectedItemToPreview;

	public IEnumerable<QuickSearchPreviewType> AvailablePreviews { get; } = new QuickSearchPreviewType[1];

	public QuickSearchPreviewType SelectedPreview
	{
		get
		{
			return QuickSearchPreviewType.Text;
		}
		set
		{
		}
	}

	public ISongSelectSearchResult? SelectedItemToPreview
	{
		get
		{
			return _selectedItemToPreview;
		}
		set
		{
			SetValue("SelectedItemToPreview", ref _selectedItemToPreview, value, OnPreviewChanged);
		}
	}

	public bool ShowPreview => SelectedItemToPreview != null;

	public string? Title => SelectedItemToPreview?.Title;

	public string? Subtitle1 => SelectedItemToPreview?.Authors;

	public string? Subtitle2 => null;

	public string? ID
	{
		get
		{
			int? num = SelectedItemToPreview?.SongNumber;
			if (num.HasValue)
			{
				int valueOrDefault = num.GetValueOrDefault();
				return LocalizedStrings.Get("PRESENTATION_QUICK_SEARCH_CCLI_label", new object[1] { valueOrDefault });
			}
			return null;
		}
	}

	public string? Content => SelectedItemToPreview?.LyricsPreview;

	public BitmapSource? Image => null;

	public ISearchCommandVM[] CommandVMs { get; }

	public IPresentation? SelectedPresentation => null;

	public bool IsAvailable => true;

	public ICommand<IPresentation>? OpenWebsiteCommand => null;

	public ICommand<IPresentation>? RetryAuthorizationCommand => null;

	public string? MusicalKey => null;

	public bool HasLyrics => false;

	public bool HasChords => false;

	public bool HasAutomation => false;

	public SongSelectPreviewVM(params ISearchCommandVM[] commands)
	{
		CommandVMs = commands;
	}

	private void OnPreviewChanged(ISongSelectSearchResult? oldValue, ISongSelectSearchResult? newValue)
	{
		OnPropertyChanged("ShowPreview");
		OnPropertyChanged("Title");
		OnPropertyChanged("Subtitle1");
		OnPropertyChanged("ID");
		OnPropertyChanged("Content");
	}
}
