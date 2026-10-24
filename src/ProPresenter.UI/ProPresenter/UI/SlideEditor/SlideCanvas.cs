using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.FileSystem;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.Editor;
using Pro.Editor.Canvas.Controls;
using Pro.Editor.Canvas.Guidelines;
using Pro.Editor.Canvas.Handles;
using Pro.Editor.Canvas.Popovers;
using Pro.Editor.Canvas.Snapping.Lines;
using Pro.Editor.Canvas.Transforming;
using Pro.Localization;
using Pro.Text;
using Pro.UI.Commands;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.DependencyInjection;
using Pro.UI.DragDropHelper;
using Pro.UI.Themes;
using Pro.UI.Utility;
using Pro.ssAPI;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Custom.Elements.Handles;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;
using ProPresenter.DO.Slide.Custom.Elements.Strokes;
using ProPresenter.Rendering;
using ProPresenter.UI.SlideEditor.Handles;
using ProPresenter.UI.SlideEditor.Pens;
using ProPresenter.UI.SlideEditor.TabStops;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.UI.SlideEditor;

public class SlideCanvas : CanvasControl
{
	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly Dictionary<IHandleData, BezierHandleSetProvider> _bezierHandleSetMap = new Dictionary<IHandleData, BezierHandleSetProvider>();

	private readonly LinearGradientBrush _placeholderBackgroundBrush;

	private readonly ImageSource? _placeholderImage;

	private ICommand<(FileInfo[], Vector2<double>)>? _importMediaCommand;

	private IInputActions _inputActions;

	public static readonly DependencyProperty IsTemplateGuidelineVisibleProperty = DependencyProperty.Register("IsTemplateGuidelineVisible", typeof(bool), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(IsTemplateGuidelineVisibleChanged)));

	public static readonly DependencyProperty TemplateGuidelineColorProperty = DependencyProperty.Register("TemplateGuidelineColor", typeof(Color), typeof(CanvasControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)System.Windows.Media.Colors.Cyan, new PropertyChangedCallback(TemplateGuidelineColorChanged)));

	public static readonly DependencyProperty VideoInputThumbnailImageProperty;

	public static readonly DependencyProperty BackgroundColorProperty;

	public static readonly DependencyProperty BackgroundImageProperty;

	public static readonly DependencyProperty IsBackgroundImagePendingProperty;

	public static readonly DependencyProperty IncludeBackgroundProperty;

	public static readonly DependencyProperty BackgroundImageScaleProperty;

	public static readonly DependencyProperty BackgroundImageAlignmentProperty;

	public static readonly DependencyProperty OutputControllerProperty;

	public static readonly DependencyProperty ViewportRequestorProperty;

	public static readonly DependencyProperty MouseClickedElementsProperty;

	public static readonly DependencyProperty MouseClickedElementProperty;

	public static readonly DependencyProperty OverlayEditTargetProperty;

	private static readonly DependencyPropertyKey IsSelectedElementMediaTypePropertyKey;

	public static readonly DependencyProperty IsSelectedElementMediaTypeProperty;

	private static readonly DependencyPropertyKey EditTextMenuItemHeaderPropertyKey;

	public static readonly DependencyProperty EditTextMenuItemHeaderProperty;

	public static readonly DependencyProperty TextSelectionRangesProperty;

	private CustomSlide? Slide => base.RootElement as CustomSlide;

	private UndoStack? UndoStack => Slide?.UndoStack;

	public bool IsTemplateGuidelineVisible
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsTemplateGuidelineVisibleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsTemplateGuidelineVisibleProperty, (object)value);
		}
	}

	public Color TemplateGuidelineColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(TemplateGuidelineColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TemplateGuidelineColorProperty, (object)value);
		}
	}

	public BitmapSource? VideoInputThumbnailImage
	{
		get
		{
			return (BitmapSource)((DependencyObject)this).GetValue(VideoInputThumbnailImageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VideoInputThumbnailImageProperty, (object)value);
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

	public BitmapSource? BackgroundImage
	{
		get
		{
			return (BitmapSource)((DependencyObject)this).GetValue(BackgroundImageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackgroundImageProperty, (object)value);
		}
	}

	public bool IsBackgroundImagePending
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsBackgroundImagePendingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsBackgroundImagePendingProperty, (object)value);
		}
	}

	public bool IncludeBackground
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IncludeBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IncludeBackgroundProperty, (object)value);
		}
	}

	public ScaleBehavior BackgroundImageScale
	{
		get
		{
			return (ScaleBehavior)((DependencyObject)this).GetValue(BackgroundImageScaleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackgroundImageScaleProperty, (object)value);
		}
	}

	public ScaleAlignment BackgroundImageAlignment
	{
		get
		{
			return (ScaleAlignment)((DependencyObject)this).GetValue(BackgroundImageAlignmentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackgroundImageAlignmentProperty, (object)value);
		}
	}

	public ssAPIOutput? OutputController
	{
		get
		{
			return (ssAPIOutput)((DependencyObject)this).GetValue(OutputControllerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OutputControllerProperty, (object)value);
		}
	}

	public ViewportRequestor? ViewportRequestor
	{
		get
		{
			return (ViewportRequestor)((DependencyObject)this).GetValue(ViewportRequestorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewportRequestorProperty, (object)value);
		}
	}

	public IEnumerable<SlideElementBase>? MouseClickedElements
	{
		get
		{
			return (IEnumerable<SlideElementBase>)((DependencyObject)this).GetValue(MouseClickedElementsProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(MouseClickedElementsProperty, (object)value);
		}
	}

	public SlideElementBase? MouseClickedElement
	{
		get
		{
			return (SlideElementBase)((DependencyObject)this).GetValue(MouseClickedElementProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(MouseClickedElementProperty, (object)value);
		}
	}

	public ClosedBezierPath? OverlayEditTarget
	{
		get
		{
			return (ClosedBezierPath)((DependencyObject)this).GetValue(OverlayEditTargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OverlayEditTargetProperty, (object)value);
		}
	}

	public bool IsSelectedElementMediaType
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSelectedElementMediaTypeProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(IsSelectedElementMediaTypePropertyKey, (object)value);
		}
	}

	public string? EditTextMenuItemHeader
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(EditTextMenuItemHeaderProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(EditTextMenuItemHeaderPropertyKey, (object)value);
		}
	}

	public Pro.Text.Range[]? TextSelectionRanges
	{
		get
		{
			return (Pro.Text.Range[])((DependencyObject)this).GetValue(TextSelectionRangesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextSelectionRangesProperty, (object)value);
		}
	}

	public ICommand MakeEditableCommand => new RelayCommand(OnMakeEditableCommand, () => base.SelectedElements?.Any() ?? false);

	public ICommand EditTextCommand => new RelayCommand(OnEditTextCommand, () => base.SelectedElements?.FirstOrDefaultOf<ClosedBezierPath>()?.SupportsEditMode == true);

	public ICommand EditMediaCommand { get; }

	private TextTabStopControlCollection TextTabStops { get; } = new TextTabStopControlCollection();

	public ICommand<(TabStopType, Vector2<double>)> AddTabStopCommand => new RelayCommand<(TabStopType, Vector2<double>)>(OnAddTabStopCommand, ((TabStopType, Vector2<double>) p) => TextTabStops?.IsEditing ?? false);

	private static void IsTemplateGuidelineVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((SlideCanvas)(object)d).OnTemplateGuidelineVisibilityChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void TemplateGuidelineColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((SlideCanvas)(object)d).InvalidateGuidelines();
	}

	private static void BackgroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((SlideCanvas)(object)d).InvalidateRootVisual();
	}

	private static void ViewportRequestorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((SlideCanvas)(object)d).OnViewportRequestorChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ViewportRequestor, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ViewportRequestor);
	}

	public SlideCanvas()
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		_inputActions = UIServiceProvider.GetService<IInputActions>();
		_factoryProvider = UIServiceProvider.GetService<IProPresenterDOFactoryProvider>();
		_placeholderBackgroundBrush = (LinearGradientBrush)Pro.UI.Themes.Brushes.GetBrush(Pro.UI.Themes.Brushes.PendingMediaBackgroundGradient);
		_placeholderImage = Icons.GetIcon(Icons.MediaPendingPlaceholder);
		base.AllowDrop = true;
		((DependencyObject)this).SetCurrentValue(CanvasControl.TabStopsProperty, (object)TextTabStops);
		EditMediaCommand = new RelayCommand(OnEditMediaCommand, () => IsSelectedElementMediaType);
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(SlideCanvas_DataContextChanged);
		DropTarget dropTarget = new DropTarget((DependencyObject)(object)this);
		DropAction<FileInfo[]> dropAction = dropTarget.AddFileDrop();
		dropAction.SetIsValidDataPredicate(CanDropFile);
		dropAction.SetOnDataDroppedAction(delegate(FileInfo[] f, DragEventArgs e)
		{
			_importMediaCommand?.Invoke((f, GetMousePosition(e.GetPosition)));
		});
		DropAction<FileInfo[]> dropAction2 = dropTarget.AddWebMediaDrop();
		dropAction2.SetIsValidDataPredicate(CanDropFile);
		dropAction2.SetOnDataDroppedAction(delegate(FileInfo[] f, DragEventArgs e)
		{
			_importMediaCommand?.Invoke((f, GetMousePosition(e.GetPosition)));
		});
	}

	protected override PopoverControl GeneratePopoverControlFromIPopover(IEnumerable<IPopover> popOvers)
	{
		return new PopoverControl(popOvers.Select(getPopovers).NonNull());
		static PopoverBase? getPopovers(IPopover popover)
		{
			if (popover is SliderPopoverModel dataContext)
			{
				return new SliderPopover(dataContext);
			}
			return null;
		}
	}

	protected override HandleBase[] OnGetHandleControls(IHandleData handle)
	{
		if (!(handle is NewBezierPointHandleData newBezierPointHandleData))
		{
			if (!(handle is BezierHandleSetData setData))
			{
				if (handle is TextOverflowHandleData textOverflowHandleData)
				{
					return new TextOverflowHandle[1]
					{
						new TextOverflowHandle(textOverflowHandleData.AttachedElement)
					};
				}
				return Array.Empty<HandleBase>();
			}
			BezierHandleSetProvider bezierHandleSetProvider = new BezierHandleSetProvider(setData);
			_bezierHandleSetMap[handle] = bezierHandleSetProvider;
			return bezierHandleSetProvider.Handles;
		}
		return new NewBezierPointHandle[1]
		{
			new NewBezierPointHandle(newBezierPointHandleData.Path, newBezierPointHandleData.StartPoint, newBezierPointHandleData.Endpoint)
		};
	}

	protected override void OnCleanupHandleControls(IHandleData handle, HandleBase[] handleControls)
	{
		if (_bezierHandleSetMap.TryGetValue(handle, out BezierHandleSetProvider value))
		{
			_bezierHandleSetMap.Remove(handle);
			value.UnhookEventHandlers();
		}
	}

	protected override void SelectedElementsChanged(ObservableCollection<ICanvasElement>? oldCollection, ObservableCollection<ICanvasElement>? newCollection)
	{
		if (oldCollection != null)
		{
			oldCollection.CollectionChanged -= SelectedElements_CollectionChanged;
		}
		if (newCollection != null)
		{
			newCollection.CollectionChanged += SelectedElements_CollectionChanged;
		}
		SetupTabStops();
	}

	private void SelectedElements_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		ClosedBezierPath closedBezierPath = base.SelectedElements?.FirstOrDefaultOf<ClosedBezierPath>();
		EditTextMenuItemHeader = ((closedBezierPath != null && closedBezierPath.SupportsEditMode && closedBezierPath.Text.HasText) ? LocalizedStrings.Get("EDITOR_MENU_EDIT_TEXT_title") : LocalizedStrings.Get("EDITOR_MENU_ADD_TEXT_title"));
		UpdateIsSelectedElementMediaType();
		ClosedBezierPath closedBezierPath2 = e.OldItems?.FirstOrDefaultOf<ClosedBezierPath>();
		if (closedBezierPath2 != null && closedBezierPath2 != null)
		{
			closedBezierPath2.FillChanged -= SelectedElement_FillChanged;
		}
		ClosedBezierPath closedBezierPath3 = e.NewItems?.FirstOrDefaultOf<ClosedBezierPath>();
		if (closedBezierPath3 != null && closedBezierPath3 != null)
		{
			closedBezierPath3.FillChanged += SelectedElement_FillChanged;
		}
		SetupTabStops();
	}

	private void SelectedElement_FillChanged(IFill oldValue, IFill newValue)
	{
		UpdateIsSelectedElementMediaType();
	}

	private void UpdateIsSelectedElementMediaType()
	{
		ObservableCollection<ICanvasElement>? selectedElements = base.SelectedElements;
		IsSelectedElementMediaType = selectedElements != null && selectedElements.OfType<ClosedBezierPath>().Count((ClosedBezierPath e) => e.Fill.Type == ProPresenter.DO.Slide.Custom.Elements.Fills.FillType.Media) == 1;
		((RelayCommand)EditMediaCommand).NotifyCanExecuteChanged();
	}

	private void SetupTabStops()
	{
		ClosedBezierPath element = base.SelectedElements?.OfType<ClosedBezierPath>().FirstOrDefault();
		TextTabStops.SetElement(element);
	}

	private void OnAddTabStopCommand((TabStopType type, Vector2<double> mousePos) param)
	{
		TextTabStops?.AddTabStop(param.mousePos, param.type);
	}

	private void SlideCanvas_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue is ISlideEditorVM slideEditorVM)
		{
			slideEditorVM.RequestCanvasScroll -= base.CenterCanvas;
		}
		object newValue = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		ISlideEditorVM newSlideEditorVM = newValue as ISlideEditorVM;
		if (newSlideEditorVM == null)
		{
			return;
		}
		newSlideEditorVM.RequestCanvasScroll += base.CenterCanvas;
		_importMediaCommand = newSlideEditorVM.ImportMediaCommand;
		base.CommandBindings.Add(CommonApplicationCommands.SelectAllCommand, delegate
		{
			SelectAll(Slide?.Elements.Where((SlideElementBase el) => el.IsSelectable));
		}, () => Slide?.Elements.Any() ?? false);
		base.CommandBindings.Add(CommonApplicationCommands.Copy, newSlideEditorVM.CopyElementsCommand);
		base.CommandBindings.Add(CommonApplicationCommands.Paste, newSlideEditorVM.PasteElementsCommand);
		base.CommandBindings.Add(CommonApplicationCommands.CutCommand, cut, () => newSlideEditorVM.CutElementsCommand?.CanExecute(null) ?? true);
		base.CommandBindings.Add(CommonApplicationCommands.Delete, delete, () => newSlideEditorVM.DeleteElementsCommand?.CanExecute(null) ?? true);
		this.AddTunnelingCommand(_inputActions.ProCommon.BreakTextToNewSlide.BindCommand, newSlideEditorVM.BreakTextToNewSlideCommand);
		this.AddTunnelingCommand(_inputActions.ProCommon.BreakTextToNextSlide.BindCommand, newSlideEditorVM.BreakTextToNextSlideCommand);
		base.CommandBindings.Add(CommonApplicationCommands.Duplicate, newSlideEditorVM.DuplicateElementsCommand);
		base.CommandBindings.Add(CommonApplicationCommands.DeselectAll, base.DeselectAll, () => base.SelectedElements?.Any() ?? false);
		void cut()
		{
			newSlideEditorVM.CutElementsCommand?.Invoke();
			base.ActivePen = null;
		}
		void delete()
		{
			if (base.SelectedHandles.AnyOf<BezierPointHandle>())
			{
				base.SelectedHandles.OfType<BezierPointHandle>().ToArray().ForEach(delegate(BezierPointHandle h)
				{
					newSlideEditorVM.RemovePointCommand?.Invoke(h.Point);
				});
			}
			else
			{
				newSlideEditorVM.DeleteElementsCommand?.Invoke();
			}
			base.ActivePen = null;
		}
	}

	private bool CanDropFile(FileInfo[] files, DragEventArgs e)
	{
		if (base.DataContext is ISlideEditorVM slideEditorVM)
		{
			if (slideEditorVM.EditMode == EditMode.Mask)
			{
				return files.All((FileInfo i) => i.FullName.IsImageFile());
			}
			return files.All((FileInfo i) => i.FullName.IsVisualMediaFile());
		}
		return false;
	}

	public void FitCanvas()
	{
		ScaleToFitContent();
	}

	protected override void OnRenderElement(ICanvasElement? element, DrawingVisual target)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		if (element == null || element.IsHidden)
		{
			return;
		}
		if (element is BezierPath path)
		{
			BezierPathRenderer.DrawBezierPath(path, target, new BezierPathRenderParams(element is ClosedBezierPath closedBezierPath && !closedBezierPath.IsInlineEditActive, highlight: false, includeRotation: false, includePosition: false, includeTextPlaceholder: true, 1.0, useFullsizeMedia: false, RenderingMode.Editor));
			return;
		}
		if (element is CustomSlide customSlide)
		{
			using DrawingContext drawingContext = target.RenderOpen();
			Rect<double> rect = new Rect<double>(customSlide.Size);
			if (VideoInputThumbnailImage != null)
			{
				Rect<double> rect2 = new Rect<double>(Vector2<double>.Zero, new Vector2<double>(VideoInputThumbnailImage.Width, VideoInputThumbnailImage.Height));
				drawingContext.PushClip(new RectangleGeometry(rect));
				drawingContext.DrawImage(VideoInputThumbnailImage, rect2);
				drawingContext.Pop();
			}
			if (BackgroundImage != null)
			{
				Rect<double> rect3 = new Rect<double>(Vector2<double>.Zero, new Vector2<double>(BackgroundImage.Width, BackgroundImage.Height));
				if (BackgroundImageScale.IsAnyOf(ScaleBehavior.ScaleToFit, ScaleBehavior.ScaleToFill, ScaleBehavior.ScaleAndBlur))
				{
					double num = ((BackgroundImageScale != ScaleBehavior.ScaleToFill) ? rect3.Size.ScaleToFitScalar(rect.Size) : rect3.Size.ScaleToFillScalar(rect.Size));
					ScaleAlignment scaleAlignment = ((BackgroundImageScale == ScaleBehavior.ScaleAndBlur) ? ScaleAlignment.MiddleCenter : BackgroundImageAlignment);
					rect3.Size *= num;
					rect3.Position = scaleAlignment switch
					{
						ScaleAlignment.TopLeft => rect.TopLeft - rect3.TopLeft, 
						ScaleAlignment.TopCenter => rect.TopCenter - rect3.TopCenter, 
						ScaleAlignment.TopRight => rect.TopRight - rect3.TopRight, 
						ScaleAlignment.MiddleLeft => rect.LeftCenter - rect3.LeftCenter, 
						ScaleAlignment.MiddleCenter => rect.Center - rect3.Center, 
						ScaleAlignment.MiddleRight => rect.RightCenter - rect3.RightCenter, 
						ScaleAlignment.BottomLeft => rect.BottomLeft - rect3.BottomLeft, 
						ScaleAlignment.BottomCenter => rect.BottomCenter - rect3.BottomCenter, 
						ScaleAlignment.BottomRight => rect.BottomRight - rect3.BottomRight, 
						_ => rect.Center - rect3.Center, 
					};
				}
				else
				{
					rect3 = rect;
				}
				if (BackgroundImageScale == ScaleBehavior.ScaleAndBlur && FindResource(Pro.UI.Themes.Brushes.LargeScaleAndBlurPlaceholderFill) is Brush brush)
				{
					drawingContext.DrawGeometry(brush, null, new RectangleGeometry(rect));
				}
				drawingContext.PushClip(new RectangleGeometry(rect));
				drawingContext.DrawImage(BackgroundImage, rect3);
				drawingContext.Pop();
			}
			if (IncludeBackground)
			{
				drawingContext.DrawRectangle(new SolidColorBrush(BackgroundColor), null, rect);
			}
			if (IsBackgroundImagePending)
			{
				drawingContext.DrawRectangle(_placeholderBackgroundBrush, null, rect);
				double val = Math.Min(rect.Height * 0.75, rect.Width * 0.75);
				val = Math.Max(val, 32.0);
				double x = rect.Width / 2.0 - val / 2.0;
				double y = rect.Height / 2.0 - val / 2.0;
				drawingContext.DrawImage(_placeholderImage, new Rect<double>(x, y, val, val));
			}
			return;
		}
		if (!(element is MediaFillCropElement mediaFillCropElement))
		{
			return;
		}
		ImageBrush brush2 = new ImageBrush(mediaFillCropElement.PreviewImage)
		{
			Opacity = 0.25
		};
		using DrawingContext drawingContext2 = target.RenderOpen();
		bool flag = false;
		if (element.CanvasParent is BezierPath path2)
		{
			drawingContext2.PushTransform(BezierPathHelper.GenerateFlipTransform(path2, element.Size * 0.5));
			flag = true;
		}
		drawingContext2.DrawRectangle(brush2, null, new Rect<double>(Vector2<double>.Zero, mediaFillCropElement.Size).Abs());
		if (flag)
		{
			drawingContext2.Pop();
		}
		if (element.CanvasParent is ClosedBezierPath closedBezierPath2 && !closedBezierPath2.Stroke.IsEnabled)
		{
			drawingContext2.PushTransform(new RotateTransform(element.Rotation.CartesianValue, element.Size.X * 0.5, element.Size.Y * 0.5));
			drawingContext2.PushTransform(new TranslateTransform(0.0 - element.Position.X, 0.0 - element.Position.Y));
			Pen pen = new Pen(new SolidColorBrush(System.Windows.Media.Colors.Gray), 3.0);
			drawingContext2.DrawGeometry(null, pen, BezierPathHelper.GenerateClosedPathGeometry(closedBezierPath2));
			drawingContext2.Pop();
			drawingContext2.Pop();
		}
	}

	protected override void OnElementEdited(Vector2<double> point, ICanvasElement element)
	{
		if (element is ClosedBezierPath { ShouldEditInline: false } closedBezierPath)
		{
			if (element != OverlayEditTarget)
			{
				OverlayShownEvent.Publish(OverlayShowSource.DoubleClick);
			}
			OverlayEditTarget = closedBezierPath;
		}
	}

	protected override void OnElementDeselected(ICanvasElement element)
	{
		if (element == OverlayEditTarget)
		{
			OverlayEditTarget = null;
		}
	}

	protected override void OnStaticGuidesChanged(StaticSLCollection? guides)
	{
		if (guides != null)
		{
			guides.ForEach(delegate(StaticSL g)
			{
				g.IsEnabled = (g.IsEditable && base.IsStaticGuidelineVisible) || (!g.IsEditable && IsTemplateGuidelineVisible);
			});
			InvalidateGuidelines();
		}
	}

	protected override void OnStaticGuidelineVisibilityChanged(bool isVisible)
	{
		if (base.StaticGuides != null)
		{
			UpdateStaticGuidelineVisibility(base.StaticGuides.Where((StaticSL g) => g.IsEditable), isVisible);
		}
	}

	protected override void OnTransformStart(ITransform? transform)
	{
		if (transform is PositionTransform)
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementPosition));
		}
		else if (transform is SizeTransform)
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementSize));
		}
		else if (transform is RotationTransform)
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementRotation));
		}
	}

	protected override void OnTransformEnd()
	{
		UndoStack? undoStack = UndoStack;
		if (undoStack != null && undoStack.IsRecording)
		{
			UndoStack.EndCommit();
			UndoStack.FinalizeNextAction();
		}
	}

	private void OnTemplateGuidelineVisibilityChanged(bool isVisible)
	{
		if (base.StaticGuides != null)
		{
			UpdateStaticGuidelineVisibility(base.StaticGuides.Where((StaticSL g) => !g.IsEditable), isVisible);
		}
	}

	private void OnViewportRequestorChanged(ViewportRequestor? oldValue, ViewportRequestor? newValue)
	{
		if (oldValue != null)
		{
			oldValue.Request -= ViewportRequested;
		}
		if (newValue != null)
		{
			newValue.Request += ViewportRequested;
		}
	}

	private Rect<double> ViewportRequested()
	{
		return base.CanvasViewport;
	}

	private void UpdateStaticGuidelineVisibility(IEnumerable<StaticSL> guides, bool isVisible)
	{
		guides.ForEach(delegate(StaticSL g)
		{
			g.IsEnabled = isVisible;
		});
		InvalidateGuidelines();
	}

	protected override Color GetGuidelineColor(GuidelineBase guideline)
	{
		if (guideline is StaticGuideline staticGuideline)
		{
			if (!staticGuideline.Guide.IsEditable)
			{
				return TemplateGuidelineColor;
			}
			return base.StaticGuidelineColor;
		}
		return base.GetGuidelineColor(guideline);
	}

	protected override IEnumerable<ICanvasElement> DuplicateSelectedElements()
	{
		return Slide?.DuplicateElements(base.SelectedElements, respostionElement: false) ?? Enumerable.Empty<ICanvasElement>();
	}

	protected override void OnDragFromRuler(bool isRulerHorizontal)
	{
		if (base.IsStaticGuidelineVisible)
		{
			Slide?.StaticGuides.AddStaticSL(new StaticSL(isRulerHorizontal, updatePosition: true));
		}
	}

	protected override void OnPenActivated()
	{
		if (base.ActivePen is OpenBezierPathPen openBezierPathPen)
		{
			openBezierPathPen.DrawingStarted += OnPenDrawingStarted;
			openBezierPathPen.DrawingCompleted += OnPenDrawingCompleted;
			openBezierPathPen.ClosePath += ClosePath;
		}
	}

	protected override void OnPenDeactivated()
	{
		if (base.ActivePen is OpenBezierPathPen openBezierPathPen)
		{
			openBezierPathPen.DrawingStarted -= OnPenDrawingStarted;
			openBezierPathPen.DrawingCompleted -= OnPenDrawingCompleted;
			openBezierPathPen.ClosePath -= ClosePath;
			openBezierPathPen.Unload();
			Slide?.Elements.OfType<OpenBezierPath>().ForEach(delegate(OpenBezierPath e)
			{
				e.LeaveEditMode();
			});
		}
	}

	private void OnPenDrawingStarted(BezierPath newPath, bool pathIsNew)
	{
		UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(pathIsNew ? UndoActionTypes.AddShape : UndoActionTypes.ElementAddPoint));
		if (pathIsNew)
		{
			Slide?.AddElement(newPath, userInitiated: false);
			newPath.Stroke.StrokeThickness = 3.0;
			newPath.Stroke.StrokeColor = (BackgroundColor.IsLuminous() ? System.Windows.Media.Colors.Black : System.Windows.Media.Colors.White);
			newPath.Stroke.IsEnabled = true;
			ElementSelected(newPath);
		}
	}

	private void OnPenDrawingCompleted()
	{
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	private void ClosePath(OpenBezierPath openPath)
	{
		Slide.ThrowWhenNull("Slide");
		UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementClosePath));
		CustomShape customPath = new CustomShape(_factoryProvider.MediaFactory, _factoryProvider.TextDocumentFactory, openPath, Slide.ContainerId)
		{
			Fill = new SolidColorFill(),
			Stroke = new Stroke()
		};
		UndoStack?.StartIgnoring();
		Slide?.RemoveElement(openPath);
		Slide?.AddElement(customPath, userInitiated: false);
		ElementSelected(customPath);
		customPath.EnterEditMode();
		UndoStack?.StopIgnoring();
		UndoStack?.Commit(delegate
		{
			Slide?.RemoveElement(customPath);
			Slide?.AddElement(openPath, userInitiated: false);
			ElementSelected(openPath);
			openPath.EnterEditMode();
		}, delegate
		{
			Slide?.RemoveElement(openPath);
			Slide?.AddElement(customPath, userInitiated: false);
			ElementSelected(customPath);
			customPath.EnterEditMode();
		});
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	private void OnMakeEditableCommand()
	{
		UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.EditShape));
		BezierPath[] elements = (base.SelectedElements?.OfType<BezierPath>() ?? Array.Empty<BezierPath>()).ToArray();
		BezierPath[] previous = elements;
		UndoStack?.Commit(delegate
		{
			SelectAll(previous);
		}, delegate
		{
		});
		for (int i = 0; i < elements.Length; i++)
		{
			if (elements[i] is ClosedBezierPath element && Slide != null)
			{
				elements[i] = Slide.MakeElementEditable(element);
			}
		}
		enterEditMode();
		UndoStack?.Commit(delegate
		{
		}, enterEditMode);
		UndoStack?.EndCommit(null, null, autoFinalize: true);
		void enterEditMode()
		{
			SelectAll(elements);
			elements.OfType<CustomShape>().ForEach(delegate(CustomShape e)
			{
				e.EnterEditMode();
			});
			elements.OfType<OpenBezierPath>().ForEach(delegate(OpenBezierPath e)
			{
				e.EnterEditMode();
			});
		}
	}

	private void OnEditTextCommand()
	{
		ElementEdited(Vector2<double>.Zero, base.SelectedElements?.FirstOf<ClosedBezierPath>());
		AdjustCaretWidth(base.ZoomFactor);
		base.SelectedElements?.FirstOf<ClosedBezierPath>().EditTextbox?.SelectAll();
	}

	private void OnEditMediaCommand()
	{
		ClosedBezierPath closedBezierPath = base.SelectedElements?.OfType<ClosedBezierPath>().FirstOrDefault((ClosedBezierPath e) => e.Fill is MediaFill);
		if (closedBezierPath != null)
		{
			if (closedBezierPath.Fill is MediaFill mediaFill)
			{
				mediaFill.ScaleType = ScaleBehavior.CustomFit;
			}
			closedBezierPath.EditChildren();
			ChildElementSelected(closedBezierPath.CanvasChildren.First());
		}
	}

	protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
	{
		if (Slide != null)
		{
			Vector2<double> position = GetMousePosition(e.GetPosition);
			SlideElementBase[] array = (from el in Slide.Elements
				orderby el.ZOrder descending
				where el.SnapBounds.Contains(position)
				select el).ToArray();
			((DependencyObject)this).SetCurrentValue(MouseClickedElementsProperty, (object)array);
			((DependencyObject)this).SetCurrentValue(MouseClickedElementProperty, (object)array.FirstOrDefault());
			base.OnPreviewMouseDown(e);
		}
	}

	protected override void OnZoomFactorChanged(double newValue)
	{
		AdjustCaretWidth(newValue);
	}

	private void AdjustCaretWidth(double factor)
	{
		ClosedBezierPath[] array = (from e in base.SelectedElements?.OfType<ClosedBezierPath>()
			where e.IsEditModeActive
			select e).ToArray();
		if (array != null && array.Any())
		{
			ClosedBezierPath[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].EditTextbox?.AdjustCaretWidth(factor);
			}
		}
	}

	private void OnOverlayEditTargetChanged(ClosedBezierPath? oldValue, ClosedBezierPath? newValue)
	{
		ElementDeselected(oldValue);
		if (newValue != null)
		{
			ElementEdited(Vector2<double>.Zero, newValue, forceMask: true);
		}
	}

	protected override void OnTextInput(TextCompositionEventArgs e)
	{
		if (!(base.SelectedElements?.FirstOrDefault() is TextShape textShape))
		{
			base.OnTextInput(e);
			return;
		}
		if (textShape.IsEditModeActive)
		{
			base.OnTextInput(e);
			return;
		}
		OnEditTextCommand();
		textShape.CustomChildren?.OfType<FormattedTextBox>().FirstOrDefault()?.SendTextInput(e);
		base.OnTextInput(e);
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.Key == 13)
		{
			e.Handled = !(base.SelectedElements?.FirstOrDefault() is TextShape textShape) || !textShape.IsEditModeActive;
			DeselectAll();
		}
		base.OnPreviewKeyDown(e);
	}

	static SlideCanvas()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected O, but got Unknown
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected O, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		Type? typeFromHandle = typeof(BitmapSource);
		Type? typeFromHandle2 = typeof(SlideCanvas);
		FrameworkPropertyMetadata frameworkPropertyMetadata = new FrameworkPropertyMetadata();
		((PropertyMetadata)frameworkPropertyMetadata).PropertyChangedCallback = (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is SlideCanvas slideCanvas)
			{
				slideCanvas.InvalidateRootVisual();
			}
		};
		VideoInputThumbnailImageProperty = DependencyProperty.Register("VideoInputThumbnailImage", typeFromHandle, typeFromHandle2, (PropertyMetadata)(object)frameworkPropertyMetadata);
		BackgroundColorProperty = DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(SlideCanvas), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)System.Windows.Media.Colors.Black, new PropertyChangedCallback(BackgroundColorChanged)));
		Type? typeFromHandle3 = typeof(BitmapSource);
		Type? typeFromHandle4 = typeof(SlideCanvas);
		FrameworkPropertyMetadata frameworkPropertyMetadata2 = new FrameworkPropertyMetadata();
		((PropertyMetadata)frameworkPropertyMetadata2).PropertyChangedCallback = (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is SlideCanvas slideCanvas2)
			{
				slideCanvas2.InvalidateRootVisual();
			}
		};
		BackgroundImageProperty = DependencyProperty.Register("BackgroundImage", typeFromHandle3, typeFromHandle4, (PropertyMetadata)(object)frameworkPropertyMetadata2);
		Type? typeFromHandle5 = typeof(bool);
		Type? typeFromHandle6 = typeof(SlideCanvas);
		FrameworkPropertyMetadata frameworkPropertyMetadata3 = new FrameworkPropertyMetadata();
		((PropertyMetadata)frameworkPropertyMetadata3).PropertyChangedCallback = (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is SlideCanvas slideCanvas3)
			{
				slideCanvas3.InvalidateRootVisual();
			}
		};
		IsBackgroundImagePendingProperty = DependencyProperty.Register("IsBackgroundImagePending", typeFromHandle5, typeFromHandle6, (PropertyMetadata)(object)frameworkPropertyMetadata3);
		IncludeBackgroundProperty = DependencyProperty.Register("IncludeBackground", typeof(bool), typeof(SlideCanvas), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		BackgroundImageScaleProperty = DependencyProperty.Register("BackgroundImageScale", typeof(ScaleBehavior), typeof(SlideCanvas));
		BackgroundImageAlignmentProperty = DependencyProperty.Register("BackgroundImageAlignment", typeof(ScaleAlignment), typeof(SlideCanvas));
		OutputControllerProperty = DependencyProperty.Register("OutputController", typeof(ssAPIOutput), typeof(CanvasControl));
		ViewportRequestorProperty = DependencyProperty.Register("ViewportRequestor", typeof(ViewportRequestor), typeof(SlideCanvas), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(ViewportRequestorChanged)));
		MouseClickedElementsProperty = DependencyProperty.Register("MouseClickedElements", typeof(IEnumerable<SlideElementBase>), typeof(SlideCanvas));
		MouseClickedElementProperty = DependencyProperty.Register("MouseClickedElement", typeof(SlideElementBase), typeof(SlideCanvas));
		OverlayEditTargetProperty = DependencyProperty.Register("OverlayEditTarget", typeof(ClosedBezierPath), typeof(SlideCanvas), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((SlideCanvas)(object)s).OnOverlayEditTargetChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ClosedBezierPath, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ClosedBezierPath);
		}));
		IsSelectedElementMediaTypePropertyKey = DependencyProperty.RegisterReadOnly("IsSelectedElementMediaType", typeof(bool), typeof(SlideCanvas), new PropertyMetadata((object)false));
		IsSelectedElementMediaTypeProperty = IsSelectedElementMediaTypePropertyKey.DependencyProperty;
		EditTextMenuItemHeaderPropertyKey = DependencyProperty.RegisterReadOnly("EditTextMenuItemHeader", typeof(string), typeof(SlideCanvas), new PropertyMetadata((object)LocalizedStrings.Get("EDITOR_MENU_ADD_TEXT_title")));
		EditTextMenuItemHeaderProperty = EditTextMenuItemHeaderPropertyKey.DependencyProperty;
		TextSelectionRangesProperty = DependencyProperty.Register("TextSelectionRanges", typeof(Pro.Text.Range[]), typeof(SlideCanvas));
	}
}
