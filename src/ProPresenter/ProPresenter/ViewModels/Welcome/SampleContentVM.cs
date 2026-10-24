using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Components.Reversibility;
using Pro.Common.FeatureFlag;
using Pro.Common.HTTP;
using Pro.Common.SourceGenerator.Attributes;
using Pro.DO;
using Pro.DO.Storage;
using Pro.Localization;
using ProPresenter.DO;
using ProPresenter.DO.Analytics.Events.Welcome;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Sample;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Welcome;

namespace ProPresenter.ViewModels.Welcome;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class SampleContentVM : ObservableObject, ISampleContentVM, INotifyPropertyChanged, IDisposable
{
	private readonly IApp _app;

	private readonly IMediaImportService _mediaImportService;

	private readonly IProPresenterResourceService _resourceService;

	private readonly IWelcomeAnalyticEventsPublisher _analytics;

	private readonly IWebSourceProvider _webSource;

	private readonly SampleContentClient _client;

	private readonly Dictionary<SampleData, VisualPlaylist> _targetMediaPlaylist = new Dictionary<SampleData, VisualPlaylist>();

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IMediaFactory _mediaFactory;

	private readonly IOutputRepository _outputRepository;

	private readonly IFlagService _flagService;

	private IDisposable? _userStateSubscription;

	private IImportProcess? _currentImportProcess;

	[ObservableProperty]
	[NotifyPropertyChangedFor("DownloadProgressText")]
	private double _downloadProgress;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor("GetSampleContentCommand")]
	private bool _isDownloading;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor("GetSampleContentCommand")]
	private bool _hasNetwork = true;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? getSampleContentCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? cancelDownloadCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? openProContentCommand;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public string DownloadProgressText => LocalizedStrings.Get("IMPORT_PROGRESS_PERCENTAGE_label", new object[1] { (int)(DownloadProgress * 100.0) });

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double DownloadProgress
	{
		get
		{
			return _downloadProgress;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_downloadProgress, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DownloadProgress);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DownloadProgressText);
				_downloadProgress = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DownloadProgress);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DownloadProgressText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsDownloading
	{
		get
		{
			return _isDownloading;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isDownloading, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsDownloading);
				_isDownloading = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsDownloading);
				GetSampleContentCommand.NotifyCanExecuteChanged();
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasNetwork
	{
		get
		{
			return _hasNetwork;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasNetwork, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.HasNetwork);
				_hasNetwork = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.HasNetwork);
				GetSampleContentCommand.NotifyCanExecuteChanged();
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand GetSampleContentCommand => getSampleContentCommand ?? (getSampleContentCommand = new RelayCommand(GetSampleContent, CanGetSampleContent));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CancelDownloadCommand => cancelDownloadCommand ?? (cancelDownloadCommand = new RelayCommand(CancelDownload));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand OpenProContentCommand => openProContentCommand ?? (openProContentCommand = new RelayCommand(OpenProContent));

	public SampleContentVM(IApp app, IProPresenterResourceService resourceService, IWelcomeAnalyticEventsPublisher analytics, IWebSourceProvider webSource, IHyperlinkService hyperlinkService, IImportProcessFactory importProcessFactory, IMediaImportService mediaImportService, IMediaFactory mediaFactory, IOutputRepository outputRepository, ICloudOnboardingService cloudOnboardingService, IFlagService flagService)
	{
		_app = app;
		_resourceService = resourceService;
		_analytics = analytics;
		_webSource = webSource;
		_hyperlinkService = hyperlinkService;
		_importProcessFactory = importProcessFactory;
		_client = new SampleContentClient(webSource);
		_mediaImportService = mediaImportService;
		_mediaFactory = mediaFactory;
		_outputRepository = outputRepository;
		_flagService = flagService;
		HasNetwork = cloudOnboardingService.GetUserState() != OnboardingUserState.NoNetwork;
		_userStateSubscription = cloudOnboardingService.WhenUserStateChanges.Subscribe(delegate(OnboardingUserState state)
		{
			HasNetwork = state != OnboardingUserState.NoNetwork;
		});
	}

	[RelayCommand(CanExecute = "CanGetSampleContent")]
	private void GetSampleContent()
	{
		if (!CanGetSampleContent())
		{
			return;
		}
		_analytics.DownloadSampleContent();
		IsDownloading = true;
		_client.GetSampleData(delegate(SampleContents? d)
		{
			if (d == null)
			{
				IsDownloading = false;
			}
			else
			{
				SampleData[]? mediaData = d.MediaData;
				if (mediaData != null && mediaData.Any())
				{
					string samplePlaylistName = "Sample Content";
					VisualGroupPlaylist visualGroupPlaylist = _resourceService.VisualPlaylists.FirstOrDefault((IPlaylist<MediaCue> p) => p.Name.Equals(samplePlaylistName)) as VisualGroupPlaylist;
					if (visualGroupPlaylist == null)
					{
						visualGroupPlaylist = _resourceService.VisualPlaylists.AddNewVisualGroupPlaylist();
						visualGroupPlaylist.Name = samplePlaylistName;
					}
					SampleData[] mediaData2 = d.MediaData;
					foreach (SampleData data in mediaData2)
					{
						ConstructMediaPlaylist(data, visualGroupPlaylist, _resourceService.VisualPlaylists?.UndoStack);
					}
				}
				_client.DownloadContents(d, delegate(double p)
				{
					DownloadProgress = p;
				}, null, AllDownloadComplete);
			}
		});
	}

	private bool CanGetSampleContent()
	{
		if (!IsDownloading)
		{
			return HasNetwork;
		}
		return false;
	}

	[RelayCommand]
	private void CancelDownload()
	{
		_client.Cancel();
		_currentImportProcess?.CancelImport();
		_currentImportProcess = null;
		IsDownloading = false;
	}

	[RelayCommand]
	private void OpenProContent()
	{
		_hyperlinkService.Open(_webSource.ProContent);
	}

	private void ConstructMediaPlaylist(SampleData data, VisualGroupPlaylist rootPlaylist, UndoStack? undoStack)
	{
		if (data.Name == null)
		{
			return;
		}
		switch (data.Type)
		{
		case SampleType.Group:
		{
			VisualGroupPlaylist visualGroupPlaylist = rootPlaylist.FirstOrDefault((IPlaylist<MediaCue> p) => p.Name.Equals(data.Name)) as VisualGroupPlaylist;
			if (visualGroupPlaylist == null)
			{
				visualGroupPlaylist = new VisualGroupPlaylist(_app, _mediaImportService, _mediaFactory, undoStack, _outputRepository.AvailableTransitions, _flagService)
				{
					Name = data.Name
				};
				rootPlaylist.AddChild(visualGroupPlaylist);
			}
			IEnumerable<SampleData> children = data.Children;
			{
				foreach (SampleData item in children ?? Enumerable.Empty<SampleData>())
				{
					ConstructMediaPlaylist(item, visualGroupPlaylist, undoStack);
				}
				break;
			}
		}
		case SampleType.Content:
		{
			VisualPlaylist visualPlaylist = rootPlaylist.FirstOrDefault((IPlaylist<MediaCue> p) => p.Name.Equals(data.Name)) as VisualPlaylist;
			if (visualPlaylist == null)
			{
				visualPlaylist = new VisualPlaylist(_app, _mediaImportService, _mediaFactory, _outputRepository.AvailableTransitions, _flagService, undoStack, data.Name);
				rootPlaylist.AddChild(visualPlaylist);
			}
			_targetMediaPlaylist[data] = visualPlaylist;
			break;
		}
		}
	}

	private void AllDownloadComplete(IEnumerable<DownloadData> downloads)
	{
		ILibrary library = _resourceService.LibraryCollection.FirstOrDefault((ILibrary l) => l.Name.Equals("Sample"));
		if (library == null)
		{
			library = _resourceService.LibraryCollection.Add("Sample");
		}
		List<FileImportRequest> list = new List<FileImportRequest>();
		foreach (DownloadData item in downloads.Where((DownloadData d) => d.Success))
		{
			switch (item.Location)
			{
			case PlaylistLocation.Library:
				list.Add(new FileImportRequest(item.FileDestination, new PlaylistImportData(PlaylistLocation.Library, overWritePlaylist: true))
				{
					OverWriteOnConflict = true
				});
				break;
			case PlaylistLocation.MediaBin:
			{
				if (!_targetMediaPlaylist.TryGetValue(item.Data, out VisualPlaylist playlist))
				{
					break;
				}
				list.Add(new FileImportRequest(item.FileDestination, delegate(string _, string n, FileMediaBase? createdMedia)
				{
					if (createdMedia != null)
					{
						playlist.AddMediaItem(createdMedia, userInitiated: true);
					}
					else
					{
						playlist.ImportMedia((RelativePath)n);
					}
				})
				{
					OverWriteOnConflict = true,
					ContainerId = MediaContainerIds.Playlist(playlist.ID)
				});
				break;
			}
			}
		}
		_currentImportProcess = _importProcessFactory.Create(list);
		_currentImportProcess.ShowProgressDialog = false;
		_currentImportProcess.SelectedLibrary = library;
		_currentImportProcess.ImportComplete += OnImportComplete;
		_currentImportProcess.StartImport();
		void OnImportComplete(IImportProcess p)
		{
			p.ImportComplete -= OnImportComplete;
			_currentImportProcess = null;
			IsDownloading = false;
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_userStateSubscription?.Dispose();
	}
}
