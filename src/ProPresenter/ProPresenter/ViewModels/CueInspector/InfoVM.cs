using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.UI.Components;
using Pro.ssAPI.Devices;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media;
using ProPresenter.UI.ViewModels.CueInspector;

namespace ProPresenter.ViewModels.CueInspector;

public class InfoVM : LinkedNotifyPropertyChangedBase, IInfoVM, INotifyPropertyChanged
{
	private readonly ICoreManager _manager;

	private readonly IImportProcessFactory _importProcessFactory;

	private MediaCue? _activeMediaCue;

	private readonly ICIMediaControlVM _ciMediaControlVM;

	public MediaCue? ActiveMediaCue
	{
		get
		{
			return _activeMediaCue;
		}
		set
		{
			SetValue<MediaCue>("ActiveMediaCue", ref _activeMediaCue, value, delegate(MediaCue o, MediaCue n)
			{
				if (o != null)
				{
					if (o.MediaAction != null)
					{
						o.MediaAction.PropertyChanged -= base.RaiseLinkedValues;
					}
					if (o.MediaAction?.LiveVideo != null)
					{
						o.MediaAction.LiveVideo.PropertyChanged -= base.RaiseLinkedValues;
						o.MediaAction.LiveVideo.LiveVideo.PropertyChanged -= base.RaiseLinkedValues;
						o.MediaAction.LiveVideo.LiveVideo.VideoInputChanged -= LiveVideo_VideoInputChanged;
						if (o.MediaAction.LiveVideo.LiveVideo.Input != null)
						{
							o.MediaAction.LiveVideo.LiveVideo.Input.PropertyChanged -= base.RaiseLinkedValues;
						}
					}
					if (o.MediaAction?.FileMedia != null)
					{
						o.MediaAction.FileMedia.PropertyChanged -= base.RaiseLinkedValues;
						if (o.MediaAction.FileMedia.SourceFile != null)
						{
							o.MediaAction.FileMedia.SourceFile.PropertyChanged -= base.RaiseLinkedValues;
						}
					}
					if (o.MediaAction?.Media is ITransportMedia transportMedia)
					{
						transportMedia.Transport.PropertyChanged -= base.RaiseLinkedValues;
					}
				}
				if (n != null)
				{
					if (n.MediaAction != null)
					{
						n.MediaAction.PropertyChanged += base.RaiseLinkedValues;
					}
					if (n.MediaAction?.LiveVideo != null)
					{
						n.MediaAction.LiveVideo.PropertyChanged += base.RaiseLinkedValues;
						n.MediaAction.LiveVideo.LiveVideo.PropertyChanged += base.RaiseLinkedValues;
						n.MediaAction.LiveVideo.LiveVideo.VideoInputChanged += LiveVideo_VideoInputChanged;
						if (n.MediaAction.LiveVideo.LiveVideo.Input != null)
						{
							n.MediaAction.LiveVideo.LiveVideo.Input.PropertyChanged += base.RaiseLinkedValues;
						}
					}
					if (n.MediaAction?.FileMedia != null)
					{
						n.MediaAction.Media.PropertyChanged += base.RaiseLinkedValues;
						if (n.MediaAction.FileMedia.SourceFile != null)
						{
							n.MediaAction.FileMedia.SourceFile.PropertyChanged += base.RaiseLinkedValues;
						}
					}
					if (n.MediaAction?.Media is ITransportMedia transportMedia2)
					{
						transportMedia2.Transport.PropertyChanged += base.RaiseLinkedValues;
					}
				}
				NotifyProperties();
			});
		}
	}

	private MediaAction? MediaAction => ActiveMediaCue?.MediaAction;

	private ILiveVideoMedia? LiveVideoMedia => MediaAction?.Media as ILiveVideoMedia;

	public MediaBase? Media => MediaAction?.Media;

	private FileMediaBase? FileMedia => MediaAction?.FileMedia;

	public MediaType MediaType => Media?.MediaType ?? MediaType.Image;

	public string FilePath => FileMedia?.SourceFile.FullPath ?? string.Empty;

	public string Name
	{
		get
		{
			return MediaAction?.Name ?? string.Empty;
		}
		set
		{
			if (MediaAction != null)
			{
				MediaAction.Name = value;
			}
		}
	}

	public string FileType => FileMedia?.SourceFile.Extension.Replace(".", string.Empty).ToUpperInvariant() ?? string.Empty;

	public TimeSlice Duration => MediaAction?.MediaDuration ?? TimeSlice.Zero;

	public Vector2<int> Size => FileMedia?.Metadata?.Size ?? Vector2<int>.Zero;

	public double FPS => (FileMedia?.Metadata?.FPS).GetValueOrDefault();

	public bool IsHdrContent
	{
		get
		{
			if (LiveVideoMedia != null)
			{
				ColorFormat? colorFormat = LiveVideoMedia.LiveVideo?.Input?.VideoDevice?.ColorFormat;
				if (colorFormat.HasValue)
				{
					ColorFormat valueOrDefault = colorFormat.GetValueOrDefault();
					if ((uint)(valueOrDefault - 1) <= 1u)
					{
						return true;
					}
				}
				return false;
			}
			return FileMedia?.Metadata?.IsHdrContent == true;
		}
	}

	public GammaVariant GammaVariant
	{
		get
		{
			if (LiveVideoMedia != null)
			{
				ColorFormat? colorFormat = LiveVideoMedia.LiveVideo?.Input?.VideoDevice?.ColorFormat;
				if (colorFormat.HasValue && colorFormat == ColorFormat.HdrRec2100PQ)
				{
					return GammaVariant.HLG;
				}
				return GammaVariant.PQ;
			}
			return (FileMedia?.Metadata?.GammaVariant).GetValueOrDefault();
		}
	}

	public ILiveVideoInputCollection AvailableVideoInputs
	{
		get
		{
			ILiveVideoInputCollection? availableLiveVideoInputs = OutputVault.AvailableLiveVideoInputs;
			availableLiveVideoInputs.ThrowWhenNull("inputs");
			return availableLiveVideoInputs;
		}
	}

	public LiveVideoInput? VideoInput
	{
		get
		{
			return LiveVideoMedia?.LiveVideo.Input;
		}
		set
		{
			if (LiveVideoMedia != null)
			{
				LiveVideoMedia.LiveVideo.Input = value;
			}
		}
	}

	public Color DisplayColor
	{
		get
		{
			return LiveVideoMedia?.LiveVideo.Input?.DisplayColor ?? Colors.Transparent;
		}
		set
		{
			if (LiveVideoMedia != null && LiveVideoMedia.LiveVideo.Input != null)
			{
				LiveVideoMedia.LiveVideo.Input.DisplayColor = value;
			}
		}
	}

	public ICommand<string> RenameMediaCommand => new RelayCommand<string>(delegate(string n)
	{
		Name = n;
	}, (string n) => _activeMediaCue != null);

	public ICommand ShowFileCommand => new RelayCommand(delegate
	{
		if (FileMedia != null && FileMedia.SourceFile.IsValid)
		{
			ProcessHelper.ShowFileInExplorer(FileMedia.SourceFile);
		}
	}, () => FileMedia != null && FileMedia.SourceFile.IsValid);

	public ICommand UpdateMediaCommand => new RelayCommand(OnUpdateMediaCommand);

	public ICommand SetToCurrentFrameCommand => new RelayCommand(OnSetToCurrentFrameCommand);

	public ICommand OpenVideoInputSetupCommand => new RelayCommand(OnOpenVideoInputSetupCommand);

	public event Action<LiveVideoInput>? OpenVideoInputSetup;

	public InfoVM(ICIMediaControlVM ciMediaControlVM, IImportProcessFactory importProcessFactory, ICoreManager coreManager)
	{
		_manager = coreManager;
		_ciMediaControlVM = ciMediaControlVM;
		_importProcessFactory = importProcessFactory;
		LinkProperties("Name", "Name");
		LinkProperties("Input", "VideoInput");
		LinkProperties("DisplayColor", "DisplayColor");
		LinkAction(new global::_003C_003Ez__ReadOnlyArray<string>(new string[5] { "Metadata", "InOutDuration", "MediaType", "SourceFile", "FullPath" }), NotifyProperties);
	}

	private void LiveVideo_VideoInputChanged(LiveVideoInput? oldInput, LiveVideoInput? newInput)
	{
		NotifyProperties();
	}

	private void OnUpdateMediaCommand()
	{
		if (_activeMediaCue?.MediaAction == null)
		{
			return;
		}
		OpenFileDialog openFileDialog = new OpenFileDialog();
		switch (_activeMediaCue.MediaAction.Media.MediaType)
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
		_activeMediaCue.MediaAction.FileMedia.ThrowWhenNull("_activeMediaCue.MediaAction.FileMedia");
		if (openFileDialog.ShowDialog() != true)
		{
			return;
		}
		_activeMediaCue.MediaAction.FileMedia.MetadataLoadSuccessful += Media_MetadataLoadSuccessful;
		_activeMediaCue.MediaAction.FileMedia.MetadataLoadFailed += Media_MetadataLoadFailed;
		_importProcessFactory.Create(new FileImportRequest(openFileDialog.FileName, delegate(string _, string newPath, FileMediaBase? createdMedia)
		{
			if (createdMedia == null)
			{
				_activeMediaCue.MediaAction.FileMedia.UpdateSource(userInitiated: true, (RelativePath)newPath);
			}
		})
		{
			OverWriteOnConflict = true,
			ExistingMedia = _activeMediaCue.MediaAction.FileMedia
		}).StartImport();
	}

	private void Media_MetadataLoadFailed(FileMediaBase media)
	{
		media.MetadataLoadSuccessful -= Media_MetadataLoadSuccessful;
		media.MetadataLoadFailed -= Media_MetadataLoadFailed;
	}

	private void Media_MetadataLoadSuccessful(FileMediaBase media)
	{
		media.MetadataLoadSuccessful -= Media_MetadataLoadSuccessful;
		media.MetadataLoadFailed -= Media_MetadataLoadFailed;
		if (_activeMediaCue?.MediaAction != null)
		{
			_activeMediaCue.MediaAction.Name = media.SourceFile.Filename;
			_manager.InspectAction(_activeMediaCue.MediaAction);
		}
	}

	private void OnSetToCurrentFrameCommand()
	{
		_ciMediaControlVM?.SetToCurrentFrame();
	}

	private void OnOpenVideoInputSetupCommand()
	{
		if (ActiveMediaCue?.LiveVideoInput != null)
		{
			this.OpenVideoInputSetup?.Invoke(ActiveMediaCue.LiveVideoInput);
		}
	}

	private void NotifyProperties()
	{
		OnPropertyChanged("Media");
		OnPropertyChanged("MediaType");
		OnPropertyChanged("FilePath");
		OnPropertyChanged("Name");
		OnPropertyChanged("FileType");
		OnPropertyChanged("Duration");
		OnPropertyChanged("Size");
		OnPropertyChanged("FPS");
		OnPropertyChanged("VideoInput");
		OnPropertyChanged("DisplayColor");
		OnPropertyChanged("GammaVariant");
		OnPropertyChanged("IsHdrContent");
	}
}
