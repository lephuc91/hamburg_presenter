using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Input;
using Microsoft.Win32;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.Entity;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;
using ProPresenter.UI;
using ProPresenter.UI.CueInspector;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.CueInspector;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Preview;
using ProPresenter.UI.ViewModels.Thumbnails;
using ProPresenter.ViewModels.CueInspector;

namespace ProPresenter.ViewModels;

public class CueInspectorVM : NotifyPropertyChangedBase, ICueInspectorVM, INotifyPropertyChanged
{
	private readonly ICoreManager _manager;

	private readonly IMediaCueThumbnailOverlayVMFactory _overlayVMFactory;

	private IInspectedMediaCueVM? _activeMediaCue;

	private int _activeTab;

	private IMediaOverlayVM? _overlayVM;

	public ssAPIOutput OutputController { get; }

	public IInspectedMediaCueVM? ActiveMediaCue
	{
		get
		{
			return _activeMediaCue;
		}
		set
		{
			SetValue<IInspectedMediaCueVM>("ActiveMediaCue", ref _activeMediaCue, value, delegate(IInspectedMediaCueVM o, IInspectedMediaCueVM n)
			{
				MediaCue mediaCue = n?.MediaCue;
				if (CanBeInspected(mediaCue) && mediaCue.MediaAction != null)
				{
					_manager.InspectAction(mediaCue.MediaAction);
				}
				mediaCue?.MediaAction?.FileMedia?.SourceFile.UpdateValidity();
				InfoVM.ActiveMediaCue = mediaCue;
				PropertiesVM.ActiveMediaCue = mediaCue;
				PropertiesVM.SupportsAudioNextBehavior = n?.SupportsAudioNextBehavior ?? false;
				PropertiesVM.ActiveInlineView = n?.ActiveInlineView ?? InlineType.Bible;
				PropertiesVM.ShowRetriggeringBehaviorField = n?.ShowRetriggeringBehaviorField ?? false;
				EffectsVM.ActiveMediaCue = mediaCue;
				AudioVM.ActiveMediaCue = mediaCue;
				PlaybackMarkersVM.ActiveMediaCue = mediaCue;
				CIMediaControlVM.ActiveMediaCue = mediaCue;
				OverlayVM = _overlayVMFactory.Create(n?.MediaCue, OverlayType.CenterClickable, InfoVM.OpenVideoInputSetupCommand);
				OnPropertyChanged("IsMediaFileValid");
			});
		}
	}

	public ObservableCollection<IInspectedMediaCueVM> Items { get; } = new ObservableCollection<IInspectedMediaCueVM>();

	public bool IsMediaFileValid
	{
		get
		{
			MediaCue mediaCue = ActiveMediaCue?.MediaCue;
			if (mediaCue != null)
			{
				if (mediaCue.MediaAction?.LiveVideo == null)
				{
					return mediaCue.MediaAction?.FileMedia?.SourceFile?.IsValid == true;
				}
				return true;
			}
			return false;
		}
	}

	public int ActiveTab
	{
		get
		{
			return _activeTab;
		}
		set
		{
			SetValue("ActiveTab", ref _activeTab, value);
		}
	}

	public IInfoVM InfoVM { get; }

	public IPropertiesVM PropertiesVM { get; }

	public IEffectsVM EffectsVM { get; }

	public IAudioVM AudioVM { get; }

	public IPlaybackMarkersVM PlaybackMarkersVM { get; }

	public ICIMediaControlVM CIMediaControlVM { get; }

	public IMediaOverlayVM? OverlayVM
	{
		get
		{
			return _overlayVM;
		}
		set
		{
			SetValue("OverlayVM", ref _overlayVM, value);
		}
	}

	public IOutputPreviewVM PreviewVM { get; }

	public ICommand<InspectorParameter> InspectCuesCommand => new RelayCommand<InspectorParameter>(InspectCuesExecute);

	public ICommand<IInspectedMediaCueVM> ChangeActiveMediaCueCommand => new RelayCommand<IInspectedMediaCueVM>(delegate(IInspectedMediaCueVM c)
	{
		ActiveMediaCue = c;
	}, (IInspectedMediaCueVM c) => Items?.Contains(c) ?? false);

	public ICommand<CreateRenderViewParameters> LoadCIOutputCommand => new RelayCommand<CreateRenderViewParameters>(_manager.CreateRenderView);

	public ICommand<DestroyRenderViewParameters> UnloadCIOutputCommand => new RelayCommand<DestroyRenderViewParameters>(_manager.DestroyRenderView);

	public ICommand CloseCICommand => new RelayCommand(delegate
	{
		_manager.ClearCI();
		ActiveMediaCue = null;
		Items.Clear();
	});

	public ICommand RelinkMediaCommand => new RelayCommand(OnRelinkMediaCommand, delegate
	{
		IInspectedMediaCueVM? activeMediaCue = ActiveMediaCue;
		return activeMediaCue != null && activeMediaCue.MediaCue?.MediaAction?.FileMedia?.SourceFile.IsValid == false;
	});

	public CueInspectorVM(ssAPIOutput outputController, IMediaCueThumbnailOverlayVMFactory overlayVMFactory, ICoreManager coreManager, IPlaybackMarkerAnalyticsEvents playbackMarkerAnalyticsEvents, IImportProcessFactory importProcessFactory, IApp app, ICoreManager manager, IActionsMenuVMFactory actionsMenuVMFactory, IOutputPreviewVMFactory previewControlVMFactory, IMediaFactory mediaFactory, IEntityFactory entityFactory, IUiDispatcher dispatcher, IDebouncerFactory debouncerFactory, ITransitionDescriptionCollection transitionDescriptions)
	{
		_manager = manager;
		OutputController = outputController;
		_overlayVMFactory = overlayVMFactory;
		EffectsVM = new EffectsVM(manager, debouncerFactory);
		AudioVM = new AudioVM(manager);
		CIMediaControlVM = new CIMediaControlVM(manager);
		PropertiesVM = new PropertiesVM(CIMediaControlVM, manager, dispatcher, debouncerFactory);
		InfoVM = new InfoVM(CIMediaControlVM, importProcessFactory, coreManager);
		PlaybackMarkersVM = new PlaybackMarkersVM(CIMediaControlVM, coreManager, playbackMarkerAnalyticsEvents, app, actionsMenuVMFactory, importProcessFactory, mediaFactory, entityFactory, transitionDescriptions);
		PreviewVM = previewControlVMFactory.Create(RenderViewType.Inspector);
	}

	private void InspectCuesExecute(InspectorParameter param)
	{
		InspectedMediaCueVM[] array = param.Cues?.Select((MediaCue c) => new InspectedMediaCueVM(c, param.ActiveInlineView, param.Options)).ToArray();
		if (array != null)
		{
			Items.AddRange(array);
			ActiveMediaCue = array.FirstOrDefault();
		}
		else
		{
			ActiveMediaCue = null;
		}
	}

	private static bool CanBeInspected([NotNullWhen(true)] MediaCue? cue)
	{
		MediaBase mediaBase = cue?.MediaAction?.Media;
		if (mediaBase == null)
		{
			return false;
		}
		switch (mediaBase.MediaType)
		{
		case MediaType.Image:
		case MediaType.Video:
		case MediaType.Audio:
			return ((FileMediaBase)mediaBase).SourceFile.IsValid;
		case MediaType.LiveVideo:
		{
			LiveVideoInput input = ((LiveVideoMedia)mediaBase).LiveVideo.Input;
			if (input == null)
			{
				return false;
			}
			OutputVault.AvailableLiveVideoInputs.ThrowWhenNull("OutputVault.AvailableLiveVideoInputs");
			return OutputVault.AvailableLiveVideoInputs.Contains(input);
		}
		default:
			return false;
		}
	}

	private void OnRelinkMediaCommand()
	{
		MediaCue mediaCue = _activeMediaCue?.MediaCue;
		OpenFileDialog openFileDialog = new OpenFileDialog();
		switch (mediaCue?.MediaAction?.Media.MediaType)
		{
		case MediaType.Image:
			openFileDialog.Filter = FileFilters.ImageFilter;
			break;
		case MediaType.Video:
			openFileDialog.Filter = FileFilters.VideoFilter;
			break;
		case MediaType.Audio:
			openFileDialog.Filter = FileFilters.AudioFilter;
			break;
		default:
			throw new Exception("Can't update media for this type");
		}
		if (mediaCue.MediaAction?.FileMedia != null && openFileDialog.ShowDialog() == true)
		{
			mediaCue.MediaAction.FileMedia.MetadataLoadSuccessful += Media_MetadataLoadSuccessful;
			mediaCue.MediaAction.FileMedia.MetadataLoadFailed += Media_MetadataLoadFailed;
			mediaCue.MediaAction.FileMedia.UpdateSource(userInitiated: true, (RelativePath)openFileDialog.FileName);
		}
	}

	private void Media_MetadataLoadSuccessful(FileMediaBase media)
	{
		media.MetadataLoadSuccessful -= Media_MetadataLoadSuccessful;
		media.MetadataLoadFailed -= Media_MetadataLoadFailed;
		ActiveMediaCue = null;
		ActiveMediaCue = Items.FirstOrDefault((IInspectedMediaCueVM c) => c.MediaCue.MediaAction?.Media == media);
	}

	private void Media_MetadataLoadFailed(FileMediaBase media)
	{
		media.MetadataLoadSuccessful -= Media_MetadataLoadSuccessful;
		media.MetadataLoadFailed -= Media_MetadataLoadFailed;
		OnPropertyChanged("IsMediaFileValid");
	}
}
