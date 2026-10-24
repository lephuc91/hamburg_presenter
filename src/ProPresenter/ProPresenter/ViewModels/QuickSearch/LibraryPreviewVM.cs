using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Components;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.Localization.Services;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.PanelViewSettings;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.QuickSearch;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.UI.ViewModels.QuickSearch;

namespace ProPresenter.ViewModels.QuickSearch;

public class LibraryPreviewVM : LinkedNotifyPropertyChangedBase, IQuickSearchPreviewVM, INotifyPropertyChanged
{
	private IPresentation? _selectedPresentation;

	private QuickSearchPreviewType _selectedPreview;

	private int _rowCapacity;

	private readonly IApp _app;

	private readonly ILocalization _localization;

	private readonly IMultiTracksSearchService _multiTracksSearchService;

	public IEnumerable<QuickSearchPreviewType> AvailablePreviews { get; } = new QuickSearchPreviewType[2]
	{
		QuickSearchPreviewType.Text,
		QuickSearchPreviewType.Thumbnail
	};

	public QuickSearchPreviewType SelectedPreview
	{
		get
		{
			return _selectedPreview;
		}
		set
		{
			SetValue("SelectedPreview", ref _selectedPreview, value, delegate(QuickSearchPreviewType o, QuickSearchPreviewType n)
			{
				_app.SelectedLibrarySearchPreview = n;
			});
		}
	}

	public ThumbnailViewSettings ThumbnailSettings { get; }

	public int RowCapacity
	{
		get
		{
			return _rowCapacity;
		}
		set
		{
			SetValue("RowCapacity", ref _rowCapacity, value, delegate(int o, int n)
			{
				_app.LibrarySearchPreviewRowCapacity = n;
			});
		}
	}

	public IPresentation? SelectedPresentation
	{
		get
		{
			return _selectedPresentation;
		}
		set
		{
			SetValue("SelectedPresentation", ref _selectedPresentation, value, OnSelectedPresentationChanged);
		}
	}

	private IArrangement? ActiveArrangement
	{
		get
		{
			object obj = SelectedPresentation?.ActiveArrangement;
			if (obj == null)
			{
				IPresentation? selectedPresentation = SelectedPresentation;
				if (selectedPresentation == null)
				{
					return null;
				}
				obj = selectedPresentation.DefaultArrangement;
			}
			return (IArrangement?)obj;
		}
	}

	public bool ShowPreview => SelectedPresentation != null;

	public string? Title
	{
		get
		{
			if (!(ActiveArrangement?.Name).NullableIsNullOrEmpty())
			{
				return SelectedPresentation?.Name + " - [ " + ActiveArrangement.Name + " ]";
			}
			return SelectedPresentation?.Name;
		}
	}

	public string? Subtitle1 => SelectedPresentation?.CCLIInfo.Artist;

	public string? Subtitle2 => null;

	public string? ID
	{
		get
		{
			if (!(SelectedPresentation?.CCLIInfo.SongNumber).NullableIsNullOrWhiteSpace())
			{
				return _localization.Get("PRESENTATION_QUICK_SEARCH_CCLI_label", new object[1] { SelectedPresentation.CCLIInfo.SongNumber });
			}
			return null;
		}
	}

	public string Content => ParseContent();

	public BitmapSource? Image => null;

	public ISearchCommandVM[] CommandVMs { get; }

	public bool IsAvailable => SelectedPresentation?.IsAvailable ?? true;

	public ICommand<IPresentation> OpenWebsiteCommand => new RelayCommand<IPresentation>(delegate
	{
		ProcessHelper.StartProcess("https://multitracks.com");
	});

	public ICommand<IPresentation> RetryAuthorizationCommand => new RelayCommand<IPresentation>(delegate(IPresentation p)
	{
		OnRetryMultiTracksAuthorization(p as MultiTracksPresentation);
	});

	public string? MusicalKey => null;

	public bool HasLyrics => false;

	public bool HasChords => false;

	public bool HasAutomation => false;

	public LibraryPreviewVM(IMultiTracksSearchService multiTracksSearchService, IApp app, ILocalization localization, params ISearchCommandVM[] commands)
	{
		CommandVMs = commands;
		_app = app;
		_localization = localization;
		_selectedPreview = _app.SelectedLibrarySearchPreview;
		_rowCapacity = _app.LibrarySearchPreviewRowCapacity;
		_multiTracksSearchService = multiTracksSearchService;
		ThumbnailSettings = new ThumbnailViewSettings(byGroups: false, useBackgroundColor: false, default(Color), app)
		{
			ShowScrimItems = false
		};
		LinkProperties(new string[2] { "Title", "ActiveArrangement" }, "Title");
		LinkProperties("Artist", "Subtitle1");
		LinkProperties("SongNumber", "ID");
		LinkProperties("IsAvailable", "IsAvailable");
	}

	private void OnSelectedPresentationChanged(IPresentation? oldValue, IPresentation? newValue)
	{
		OnPropertyChanged("ShowPreview");
		OnPropertyChanged("Title");
		OnPropertyChanged("Subtitle1");
		OnPropertyChanged("ID");
		OnPropertyChanged("Content");
		OnPropertyChanged("IsAvailable");
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= base.RaiseLinkedValues;
			oldValue.CCLIInfo.PropertyChanged -= base.RaiseLinkedValues;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += base.RaiseLinkedValues;
			newValue.CCLIInfo.PropertyChanged += base.RaiseLinkedValues;
		}
	}

	private string ParseContent()
	{
		if (SelectedPresentation != null)
		{
			return string.Join("\r\n\r\n", ActiveArrangement?.Select((CueGroup g) => ParseContent(g.Cues.Select((SlideCue c) => c.SlideAction?.Slide).OfType<CustomSlide>())).Where(IsValid) ?? Enumerable.Empty<string>());
		}
		return string.Empty;
	}

	private static string ParseContent(IEnumerable<CustomSlide> slides)
	{
		return string.Join("\r\n", slides.Select(text).Where(IsValid));
		static string? text(CustomSlide s)
		{
			return s.GetPrimaryTextElement(useDisplayText: false)?.Text?.AllText.Trim();
		}
	}

	private static bool IsValid([NotNullWhen(true)] string? s)
	{
		return !s.NullableIsNullOrWhiteSpace();
	}

	private void OnRetryMultiTracksAuthorization(MultiTracksPresentation? presentation)
	{
		if (presentation != null)
		{
			_multiTracksSearchService.RetryAuthorization(presentation);
		}
	}
}
