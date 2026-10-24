using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Presentation;

namespace ProPresenter.UI.ViewModels.QuickSearch;

public interface IQuickSearchPreviewVM : INotifyPropertyChanged
{
	IEnumerable<QuickSearchPreviewType> AvailablePreviews { get; }

	QuickSearchPreviewType SelectedPreview { get; set; }

	string? Title { get; }

	string? Subtitle1 { get; }

	string? Subtitle2 { get; }

	string? ID { get; }

	string? Content { get; }

	BitmapSource? Image { get; }

	bool ShowPreview { get; }

	ISearchCommandVM[] CommandVMs { get; }

	bool IsAvailable { get; }

	IPresentation? SelectedPresentation { get; }

	ICommand<IPresentation>? OpenWebsiteCommand { get; }

	ICommand<IPresentation>? RetryAuthorizationCommand { get; }

	string? MusicalKey { get; }

	bool HasLyrics { get; }

	bool HasChords { get; }

	bool HasAutomation { get; }
}
