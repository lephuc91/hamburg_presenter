using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.DO.Reversibility;
using Pro.DO.Transitions;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Themes;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

public class TemplateSlideInspectorVM : LinkedNotifyPropertyChangedBase, ITemplateSlideInspectorVM, INotifyPropertyChanged
{
	private EditMode _editMode;

	private TemplateSlide? _selectedTemplate;

	private readonly IMediaProvider _mediaProvider;

	private readonly IApp _app;

	private readonly IImport _import;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	public EditMode EditMode
	{
		get
		{
			return _editMode;
		}
		set
		{
			SetValue("EditMode", ref _editMode, value);
		}
	}

	public TemplateSlide? SelectedTemplate
	{
		get
		{
			return _selectedTemplate;
		}
		set
		{
			SetValue<TemplateSlide>("SelectedTemplate", ref _selectedTemplate, value, delegate(TemplateSlide o, TemplateSlide n)
			{
				if (o != null)
				{
					o.PropertyChanged -= base.RaiseLinkedValues;
					o.Slide.PropertyChanged -= base.RaiseLinkedValues;
				}
				if (n != null)
				{
					n.PropertyChanged += base.RaiseLinkedValues;
					n.Slide.PropertyChanged += base.RaiseLinkedValues;
				}
				OnPropertyChanged("Name");
				OnPropertyChanged("UseBackgroundColor");
				OnPropertyChanged("BackgroundColor");
				OnPropertyChanged("MediaAction");
				OnPropertyChanged("TransportMedia");
			});
		}
	}

	public string Name
	{
		get
		{
			return SelectedTemplate?.Name ?? string.Empty;
		}
		set
		{
			if (SelectedTemplate != null)
			{
				SelectedTemplate.Name = value;
			}
		}
	}

	public bool UseBackgroundColor
	{
		get
		{
			return SelectedTemplate?.Slide.UseBackgroundColor ?? false;
		}
		set
		{
			if (SelectedTemplate != null)
			{
				SelectedTemplate.Slide.UseBackgroundColor = value;
			}
		}
	}

	public Color BackgroundColor
	{
		get
		{
			return SelectedTemplate?.Slide.BackgroundColor ?? Colors.Black;
		}
		set
		{
			if (SelectedTemplate != null)
			{
				SelectedTemplate.Slide.BackgroundColor = value;
			}
		}
	}

	public MediaAction? MediaAction => SelectedTemplate?.MediaAction;

	public ICommand<ColorPair> ColorChangeFinishedCommand => new RelayCommand<ColorPair>(delegate(ColorPair c)
	{
		SelectedTemplate.ThrowWhenNull("SelectedTemplate");
		SelectedTemplate.Slide.CompleteColorChange(c.OldColor.Value);
	}, (ColorPair c) => c.OldColor.HasValue && SelectedTemplate != null);

	public ICommand AddMediaActionCommand => new RelayCommand(AddMediaActionCommandExecuted, () => SelectedTemplate != null && SelectedTemplate.MediaAction == null);

	public ICommand RemoveMediaActionCommand => new RelayCommand(RemoveMediaActionCommandExecuted, () => MediaAction != null);

	public ICommand ShowInFileExplorerCommand => new RelayCommand(ShowInFileExplorerCommandExecuted);

	public ICommand ChooseGraphicMediaFileCommand => new RelayCommand(ChooseGraphicMediaFileCommandExecuted, () => SelectedTemplate != null && SelectedTemplate.MediaAction != null);

	public ITransportMedia? TransportMedia => SelectedTemplate?.MediaAction?.Media as ITransportMedia;

	public TemplateSlideInspectorVM(IMediaProvider mediaProvider, IApp app, IImport import, ITransitionDescriptionCollection transitionDescriptions)
	{
		_mediaProvider = mediaProvider;
		_app = app;
		_import = import;
		_transitionDescriptions = transitionDescriptions;
		LinkProperties("Name", "Name");
		LinkProperties("UseBackgroundColor", "UseBackgroundColor");
		LinkProperties("BackgroundColor", "BackgroundColor");
		LinkProperties("MediaAction", "MediaAction");
	}

	private void AddMediaActionCommandExecuted()
	{
		SelectedTemplate.ThrowWhenNull("SelectedTemplate");
		_mediaProvider?.GetMedia(SelectedTemplate.ContainerId, delegate(MediaBase? m)
		{
			if (m != null)
			{
				AddMediaAction(m);
			}
		});
	}

	private void ChooseGraphicMediaFileCommandExecuted()
	{
		SelectedTemplate.ThrowWhenNull("SelectedTemplate");
		_mediaProvider?.GetMedia(SelectedTemplate.ContainerId, delegate(MediaBase? m)
		{
			if (m != null)
			{
				RemoveMediaActionCommandExecuted();
				AddMediaAction(m);
			}
		});
	}

	private void AddMediaAction(MediaBase media)
	{
		if (media == null)
		{
			return;
		}
		SelectedTemplate.ThrowWhenNull("SelectedTemplate");
		using (SelectedTemplate.UndoStack?.Transaction(Pro.DO.Reversibility.UndoActionTypes.AddAction.ToAction(), null, null, autoFinalize: true))
		{
			media.ApplyImportSetingsForSlideMediaAction(_import);
			MediaAction action = new MediaAction(media, _app, _transitionDescriptions);
			SelectedTemplate.Actions.Add(action);
			ITrackedMedia trackedMedia = media as ITrackedMedia;
			if (trackedMedia != null)
			{
				SelectedTemplate.UndoStack?.Commit(delegate
				{
					trackedMedia.RemoveFromMediaService(deleteAssets: false);
				}, delegate
				{
					trackedMedia.AddToMediaService(userInitiated: true);
				});
			}
			OnPropertyChanged("TransportMedia");
		}
	}

	private void ShowInFileExplorerCommandExecuted()
	{
		MediaAction.ThrowWhenNull("MediaAction");
		if (MediaAction.FileMedia?.SourceFile != null)
		{
			ProcessHelper.ShowFileInExplorer(MediaAction.FileMedia.SourceFile);
		}
	}

	private void RemoveMediaActionCommandExecuted()
	{
		SelectedTemplate.ThrowWhenNull("SelectedTemplate");
		MediaAction.ThrowWhenNull("MediaAction");
		if (MediaAction.Media is ITrackedMedia trackedMedia)
		{
			trackedMedia.RemoveFromMediaService(deleteAssets: false);
		}
		SelectedTemplate.Actions.Remove(MediaAction);
	}
}
