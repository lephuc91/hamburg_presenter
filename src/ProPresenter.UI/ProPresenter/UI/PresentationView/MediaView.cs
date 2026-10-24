using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Utility;
using Pro.UI.Components;
using Pro.UI.DependencyInjection;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Media;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Thumbnails;

namespace ProPresenter.UI.PresentationView;

public partial class MediaView : UserControl, IComponentConnector
{
	private readonly IMediaCueThumbnailOverlayVMFactory _overlayVMFactory;

	private readonly IInputActions _inputActions;

	public static readonly DependencyProperty MediaItemProperty = DependencyProperty.Register("MediaItem", typeof(ProPresenterCue), typeof(MediaView), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(CueChangedCallback)));

	public static readonly DependencyProperty ActiveItemProperty = DependencyProperty.Register("ActiveItem", typeof(ProPresenterCue), typeof(MediaView));

	public static readonly DependencyProperty TriggerMediaItemCommandProperty = DependencyProperty.Register("TriggerMediaItemCommand", typeof(ICommand<MediaCue>), typeof(MediaView));

	public static readonly DependencyProperty MediaActionProperty = DependencyProperty.Register("MediaAction", typeof(MediaAction), typeof(MediaView));

	public static readonly DependencyProperty OverlayVMProperty = DependencyProperty.Register("OverlayVM", typeof(IMediaOverlayVM), typeof(MediaView), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));

	public ProPresenterCue? MediaItem
	{
		get
		{
			return (ProPresenterCue)((DependencyObject)this).GetValue(MediaItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaItemProperty, (object)value);
		}
	}

	public ProPresenterCue? ActiveItem
	{
		get
		{
			return (ProPresenterCue)((DependencyObject)this).GetValue(ActiveItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveItemProperty, (object)value);
		}
	}

	public ICommand<MediaCue>? TriggerMediaItemCommand
	{
		get
		{
			return (ICommand<MediaCue>)((DependencyObject)this).GetValue(TriggerMediaItemCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TriggerMediaItemCommandProperty, (object)value);
		}
	}

	private MediaAction? MediaAction
	{
		get
		{
			return (MediaAction)((DependencyObject)this).GetValue(MediaActionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaActionProperty, (object)value);
		}
	}

	private IMediaOverlayVM? OverlayVM
	{
		get
		{
			return (IMediaOverlayVM)((DependencyObject)this).GetValue(OverlayVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OverlayVMProperty, (object)value);
		}
	}

	private static void CueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((MediaView)(object)d).OnCueChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ProPresenterCue);
	}

	public MediaView()
	{
		_overlayVMFactory = UIServiceProvider.GetService<IMediaCueThumbnailOverlayVMFactory>();
		_inputActions = UIServiceProvider.GetService<IInputActions>();
		InitializeComponent();
	}

	private void PlayButton_Click(object? sender, RoutedEventArgs e)
	{
		if (MediaItem == null)
		{
			return;
		}
		CueType type = MediaItem.Type;
		MediaCue mediaCue = null;
		switch (type)
		{
		default:
			return;
		case CueType.Media:
			mediaCue = MediaItem as MediaCue;
			break;
		case CueType.Placeholder:
			mediaCue = new MediaCue((MediaItem as PlaceholderCue)?.MediaAction);
			break;
		case CueType.PCO:
			mediaCue = new MediaCue(((MediaItem as PCOMediaCue)?.PCOAction ?? (MediaItem as PCOPlanCue)?.PCOAction ?? (MediaItem as PCOSongCue)?.PCOAction)?.MediaAction);
			break;
		case CueType.Header:
			return;
		}
		MediaAction mediaAction = mediaCue.MediaAction;
		if (mediaAction != null)
		{
			if (mediaAction.Media.MediaType == MediaType.Web)
			{
				((DependencyObject)(object)this).FindVisualParent<MainLayout>()?.NavigateTargetURL((mediaAction.Media as WebMedia)?.Url);
			}
			else
			{
				MediaBase media = mediaAction.Media;
				if (media == null || media.MediaType != 0)
				{
					MediaBase media2 = mediaAction.Media;
					if (media2 == null || media2.MediaType != MediaType.Video)
					{
						MediaBase media3 = mediaAction.Media;
						if (media3 == null || media3.MediaType != MediaType.Audio)
						{
							MediaBase media4 = mediaAction.Media;
							if (media4 == null || media4.MediaType != MediaType.LiveVideo)
							{
								goto IL_0186;
							}
						}
					}
				}
				TriggerMediaItemCommand?.Invoke(mediaCue);
			}
		}
		goto IL_0186;
		IL_0186:
		SetActivePlaylistItem();
	}

	private void SetActivePlaylistItem()
	{
		if (MediaItem != null)
		{
			((DependencyObject)this).SetCurrentValue(ActiveItemProperty, (object)MediaItem);
		}
	}

	private void OpenFileLocation(object? sender, RoutedEventArgs e)
	{
		SetActivePlaylistItem();
		if (!string.IsNullOrEmpty(MediaFileLocation.Text))
		{
			ProcessHelper.ShowFileInExplorer(MediaFileLocation.Text);
		}
	}

	private void OnCueChanged(ProPresenterCue? proPresenterCue)
	{
		if (proPresenterCue == null)
		{
			((DependencyObject)this).SetCurrentValue(MediaActionProperty, (object)null);
			return;
		}
		if (proPresenterCue is IMediaCue source)
		{
			SetBinding(MediaActionProperty, new Binding("MediaAction")
			{
				Source = source
			});
		}
		OverlayVM = _overlayVMFactory?.Create(proPresenterCue, OverlayType.CenterClickable, _inputActions.ProMenu.Input.BindCommand);
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		SetActivePlaylistItem();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
