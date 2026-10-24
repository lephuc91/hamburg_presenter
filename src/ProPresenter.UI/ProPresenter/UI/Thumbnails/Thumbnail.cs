using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI.DependencyInjection;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Thumbnails;

namespace ProPresenter.UI.Thumbnails;

public partial class Thumbnail : UserControl, IThumbnailControl, IUniformViewControl, IComponentConnector, IStyleConnector
{
	public const string ListViewPreviewContainerKey = "listViewPreviewContainer";

	public const string PreviewContainerKey = "previewContainer";

	public const string ThumbnailTemplateKey = "thumbnailTemplate";

	public const string ListTemplateKey = "listTemplate";

	private RenderImageDelegate? _renderPreviewCallback;

	private RenderImageDelegate? _renderBackgroundCallback;

	private GetColorDelegate? _getBackgroundColorCallback;

	private GetColorDelegate? _getPreviewColorCallback;

	private GetContentDelegate? _getContentCallback;

	private GetContentDelegate? _getSecondaryContentCallback;

	private GetContentDelegate? _getSecondaryContentLabelCallback;

	private ClickedDelegate? _clickedCallback;

	private DraggedDelegate? _draggedCallback;

	private MenuOpeningDelegate? _menuOpeningCallback;

	private bool _waitingOnPreview;

	private bool _waitingOnBackground;

	private bool _sourceChanged = true;

	private bool _canTrigger;

	private Vector2<double> _mouseDownPosition = Vector2<double>.Zero;

	private bool _canDrag;

	private readonly IMediaCueThumbnailOverlayVMFactory? _overlayVMFactory;

	public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(IThumbnailSource), typeof(Thumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(SourcePropertyChanged)));

	public static readonly DependencyProperty IndexProperty = DependencyProperty.Register("Index", typeof(int), typeof(Thumbnail));

	public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(Thumbnail));

	public static readonly DependencyProperty ViewSettingsProperty = DependencyProperty.Register("ViewSettings", typeof(IPanelViewSettings), typeof(Thumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(ViewSettingsPropertyChanged)));

	public static readonly DependencyProperty HideBackgroundImageProperty = DependencyProperty.Register("HideBackgroundImage", typeof(bool), typeof(Thumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(Thumbnail));

	public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(Thumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata(Colors.Transparent, FrameworkPropertyMetadataOptions.AffectsRender, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Thumbnail)(object)s)._sourceChanged = true;
	}));

	public static readonly DependencyProperty PreviewColorProperty = DependencyProperty.Register("PreviewColor", typeof(Color), typeof(Thumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata(Colors.Transparent, FrameworkPropertyMetadataOptions.AffectsRender, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Thumbnail)(object)s)._sourceChanged = true;
	}));

	public static readonly DependencyProperty ActiveBrushProperty = DependencyProperty.Register("ActiveBrush", typeof(Brush), typeof(Thumbnail));

	public static readonly DependencyProperty ActiveListBrushProperty = DependencyProperty.Register("ActiveListBrush", typeof(Brush), typeof(Thumbnail));

	public static readonly DependencyProperty ActiveBorderBrushProperty = DependencyProperty.Register("ActiveBorderBrush", typeof(Brush), typeof(Thumbnail));

	public static readonly DependencyProperty BackgroundImageProperty = DependencyProperty.Register("BackgroundImage", typeof(IBitmapHandle), typeof(Thumbnail));

	public static readonly DependencyProperty PreviewImageProperty = DependencyProperty.Register("PreviewImage", typeof(IBitmapHandle), typeof(Thumbnail));

	public static readonly DependencyProperty TextContentProperty = DependencyProperty.Register("TextContent", typeof(string), typeof(Thumbnail));

	public static readonly DependencyProperty SecondaryContentProperty = DependencyProperty.Register("SecondaryContent", typeof(string), typeof(Thumbnail));

	public static readonly DependencyProperty SecondaryContentLabelProperty = DependencyProperty.Register("SecondaryContentLabel", typeof(string), typeof(Thumbnail));

	public static readonly DependencyProperty DisplayModeProperty = DependencyProperty.Register("DisplayMode", typeof(DisplayMode), typeof(Thumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)DisplayMode.Label));

	public static readonly DependencyProperty WasActiveProperty = DependencyProperty.Register("WasActive", typeof(bool), typeof(Thumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public static readonly DependencyProperty ShowIndexProperty = DependencyProperty.Register("ShowIndex", typeof(bool), typeof(Thumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowBuildProgressProperty = DependencyProperty.Register("ShowBuildProgress", typeof(bool), typeof(Thumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty OverlayVMProperty = DependencyProperty.Register("OverlayVM", typeof(IMediaOverlayVM), typeof(Thumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));

	public static readonly DependencyProperty HideCheckerboardProperty = DependencyProperty.Register("HideCheckerboard", typeof(bool), typeof(Thumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public IThumbnailSource? Source
	{
		get
		{
			return (IThumbnailSource)((DependencyObject)this).GetValue(SourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SourceProperty, (object)value);
		}
	}

	public int Index
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(IndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IndexProperty, (object)value);
		}
	}

	public bool IsSelected
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSelectedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSelectedProperty, (object)value);
		}
	}

	public IPanelViewSettings? ViewSettings
	{
		get
		{
			return (IPanelViewSettings)((DependencyObject)this).GetValue(ViewSettingsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewSettingsProperty, (object)value);
		}
	}

	public bool HideBackgroundImage
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(HideBackgroundImageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HideBackgroundImageProperty, (object)value);
		}
	}

	public bool IsActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsActiveProperty, (object)value);
		}
	}

	public Color BackgroundColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(BackgroundColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackgroundColorProperty, (object)value);
		}
	}

	public Color PreviewColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(PreviewColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PreviewColorProperty, (object)value);
		}
	}

	public Brush? ActiveBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ActiveBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveBrushProperty, (object)value);
		}
	}

	public Brush? ActiveListBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ActiveListBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveListBrushProperty, (object)value);
		}
	}

	public Brush? ActiveBorderBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ActiveBorderBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveBorderBrushProperty, (object)value);
		}
	}

	public IBitmapHandle? BackgroundImage
	{
		get
		{
			return (IBitmapHandle)((DependencyObject)this).GetValue(BackgroundImageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackgroundImageProperty, (object)value);
		}
	}

	public IBitmapHandle? PreviewImage
	{
		get
		{
			return (IBitmapHandle)((DependencyObject)this).GetValue(PreviewImageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PreviewImageProperty, (object)value);
		}
	}

	public string? TextContent
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TextContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextContentProperty, (object)value);
		}
	}

	public string? SecondaryContent
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SecondaryContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SecondaryContentProperty, (object)value);
		}
	}

	public string? SecondaryContentLabel
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SecondaryContentLabelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SecondaryContentLabelProperty, (object)value);
		}
	}

	public DisplayMode DisplayMode
	{
		get
		{
			return (DisplayMode)((DependencyObject)this).GetValue(DisplayModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayModeProperty, (object)value);
		}
	}

	public bool WasActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(WasActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WasActiveProperty, (object)value);
		}
	}

	public bool ShowIndex
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowIndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowIndexProperty, (object)value);
		}
	}

	public bool ShowBuildProgress
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowBuildProgressProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowBuildProgressProperty, (object)value);
		}
	}

	public Vector2<double> ContainerSize => (Vector2<double>)(((DependencyObject)(object)this).FindVisualChild(delegate(PreviewContainer c)
	{
		string obj = (string)c.Tag;
		IPanelViewSettings? viewSettings = ViewSettings;
		return obj == ((viewSettings != null && viewSettings.ViewType == PanelViewType.List) ? "listViewPreviewContainer" : "previewContainer");
	})?.DesiredSize ?? ((Size)Vector2<double>.Zero));

	IUniformViewSource? IUniformViewControl.Source
	{
		get
		{
			return Source;
		}
		set
		{
			((DependencyObject)this).SetCurrentValue(SourceProperty, (object)(IThumbnailSource)value);
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

	public bool HideCheckerboard
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(HideCheckerboardProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HideCheckerboardProperty, (object)value);
		}
	}

	private static void SourcePropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((Thumbnail)(object)callerObject).SourceChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as IThumbnailSource, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as IThumbnailSource);
	}

	private static void ViewSettingsPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((Thumbnail)(object)callerObject).ViewSettingsChanged((IPanelViewSettings)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (IPanelViewSettings)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public Thumbnail()
	{
		InitializeComponent();
		_overlayVMFactory = UIServiceProvider.GetService<IMediaCueThumbnailOverlayVMFactory>();
	}

	private void SourceChanged(IThumbnailSource? oldValue, IThumbnailSource? newValue)
	{
		if (oldValue != null)
		{
			oldValue.VisualInvalidated -= OnSourceInvalidated;
		}
		if (newValue != null)
		{
			newValue.VisualInvalidated += OnSourceInvalidated;
		}
		PreviewImage?.Dispose();
		PreviewImage = null;
		BackgroundImage?.Dispose();
		BackgroundImage = null;
		OnSourceInvalidated();
		OverlayVM = _overlayVMFactory?.Create(newValue);
		if (OverlayVM == null && newValue is IMediaCueThumbnailVM mediaCueThumbnailVM)
		{
			OverlayVM = mediaCueThumbnailVM.MediaOverlayVM;
		}
	}

	internal void SetRenderingDelegates(RenderImageDelegate renderPreviewCallback, RenderImageDelegate renderBackgroundCallback, GetColorDelegate getBackgroundColorCallback, GetColorDelegate getPreviewColorCallback, GetContentDelegate getContentCallback, GetContentDelegate getSecondaryContentCallback, GetContentDelegate getSecondaryContentLabelCallback)
	{
		_renderPreviewCallback = renderPreviewCallback;
		_renderBackgroundCallback = renderBackgroundCallback;
		_getBackgroundColorCallback = getBackgroundColorCallback;
		_getPreviewColorCallback = getPreviewColorCallback;
		_getContentCallback = getContentCallback;
		_getSecondaryContentCallback = getSecondaryContentCallback;
		_getSecondaryContentLabelCallback = getSecondaryContentLabelCallback;
	}

	internal void SetUIDelegates(ClickedDelegate clickedCallback, DraggedDelegate draggedCallback, MenuOpeningDelegate menuOpeningCallback)
	{
		_clickedCallback = clickedCallback;
		_draggedCallback = draggedCallback;
		_menuOpeningCallback = menuOpeningCallback;
	}

	private void ViewSettingsChanged(IPanelViewSettings oldSettings, IPanelViewSettings newSettings)
	{
		if (oldSettings != null)
		{
			oldSettings.PropertyChanged -= ViewSettings_PropertyChanged;
		}
		if (newSettings != null)
		{
			newSettings.PropertyChanged += ViewSettings_PropertyChanged;
		}
		UpdateContentTemplate();
		UpdateBackgroundColor();
		UpdatePreviewColor();
	}

	private void ViewSettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "BackgroundColor":
		case "UseBackgroundColor":
			UpdateBackgroundColor();
			break;
		case "PreviewColor":
		case "UsePreviewColor":
			UpdatePreviewColor();
			break;
		}
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		_canTrigger = true;
		_mouseDownPosition = (Vector2<double>)e.GetPosition(this);
		ref bool canDrag = ref _canDrag;
		object originalSource = e.OriginalSource;
		canDrag = (((DependencyObject)((originalSource is DependencyObject) ? originalSource : null))?.FindAllVisualParents(typeof(Button)))?.Empty() ?? true;
	}

	protected override void OnMouseLeave(MouseEventArgs e)
	{
		_canTrigger = false;
	}

	protected override void OnPreviewMouseMove(MouseEventArgs e)
	{
		if (_canDrag && _canTrigger && e.LeftButton == MouseButtonState.Pressed && e.CanDrag(this, _mouseDownPosition))
		{
			_draggedCallback?.Invoke(this, e);
			_canTrigger = false;
		}
	}

	protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		if (e.ChangedButton == MouseButton.Left && _canTrigger)
		{
			_clickedCallback?.Invoke(this, Keyboard.Modifiers);
		}
		_canDrag = false;
		_canTrigger = false;
	}

	protected override void OnContextMenuOpening(ContextMenuEventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_menuOpeningCallback?.Invoke(this, Keyboard.Modifiers);
	}

	private void RenderBackgroundCompleted(IThumbnailSource source, IBitmapHandle? image)
	{
		_waitingOnBackground = false;
		BackgroundImage?.Dispose();
		BackgroundImage = image;
	}

	private void RenderPreviewCompleted(IThumbnailSource source, IBitmapHandle? image)
	{
		_waitingOnPreview = false;
		PreviewImage?.Dispose();
		PreviewImage = image;
	}

	private void OnSourceInvalidated()
	{
		_sourceChanged = true;
		((DispatcherObject)this).Dispatcher.BeginInvoke((Delegate)(Action)delegate
		{
			if (Source != null)
			{
				TextContent = _getContentCallback?.Invoke(Source);
				SecondaryContent = _getSecondaryContentCallback?.Invoke(Source);
				SecondaryContentLabel = _getSecondaryContentLabelCallback?.Invoke(Source);
				UpdateBackgroundColor();
				UpdatePreviewColor();
				InvalidateVisual();
			}
		}, Array.Empty<object>());
	}

	private void UpdateContentTemplate()
	{
		if (ViewSettings != null)
		{
			switch (ViewSettings.ViewType)
			{
			case PanelViewType.Thumbnail:
			case PanelViewType.EasyView:
				base.ContentTemplate = (DataTemplate)base.Resources["thumbnailTemplate"];
				break;
			case PanelViewType.List:
				base.ContentTemplate = (DataTemplate)base.Resources["listTemplate"];
				break;
			}
		}
	}

	private void UpdateBackgroundColor()
	{
		if (ViewSettings != null && Source != null)
		{
			BackgroundColor = _getBackgroundColorCallback?.Invoke(Source, ViewSettings.UseBackgroundColor ? new Color?(ViewSettings.BackgroundColor) : ((Color?)null)) ?? Colors.Transparent;
		}
	}

	private void UpdatePreviewColor()
	{
		if (ViewSettings != null && Source != null)
		{
			PreviewColor = _getPreviewColorCallback?.Invoke(Source, ViewSettings.UsePreviewColor ? new Color?(ViewSettings.PreviewColor) : ((Color?)null)) ?? Colors.Transparent;
		}
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		Vector2<double> containerSize = ContainerSize;
		Vector2<int> size = new Vector2<int>((int)Math.Ceiling(containerSize.X), (int)Math.Ceiling(containerSize.Y));
		if (size.X != 0 && size.Y != 0 && Source != null)
		{
			if (!_waitingOnPreview && (_sourceChanged || PreviewImage == null || PreviewImage.RenderSize.X < (double)size.X || PreviewImage.RenderSize.Y < (double)size.Y))
			{
				_waitingOnPreview = true;
				_renderPreviewCallback?.Invoke(Source, size, RenderPreviewCompleted);
			}
			if (!_waitingOnBackground && (_sourceChanged || BackgroundImage == null || BackgroundImage.RenderSize.X < (double)size.X || BackgroundImage.RenderSize.Y < (double)size.Y))
			{
				_waitingOnBackground = true;
				_renderBackgroundCallback?.Invoke(Source, size, RenderBackgroundCompleted);
			}
			_sourceChanged = false;
			base.OnRender(drawingContext);
		}
	}

	private void Grid_Loaded(object? sender, RoutedEventArgs e)
	{
		OnSourceInvalidated();
		(sender as UIElement)?.InvalidateMeasure();
	}

	public void TearDown()
	{
		Source = null;
		ViewSettings = null;
		base.ContextMenu = null;
		WasActive = false;
		BackgroundImage?.Dispose();
		BackgroundImage = null;
		PreviewImage?.Dispose();
		PreviewImage = null;
	}
}
