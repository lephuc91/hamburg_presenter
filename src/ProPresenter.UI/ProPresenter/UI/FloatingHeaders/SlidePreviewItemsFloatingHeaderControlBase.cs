using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI.Commands;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.UI.SlideEditor;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.UI.FloatingHeaders;

public abstract class SlidePreviewItemsFloatingHeaderControlBase<T> : FloatingHeaderControl<T, ObservableCollection<T>> where T : class
{
	private const double SelectSlideInterval = 0.5;

	private readonly DragSource _dragSource;

	private readonly DispatcherTimer _selectSlideTimer = new DispatcherTimer
	{
		Interval = TimeSpan.FromSeconds(0.5)
	};

	private EditorPreviewItem? _clickedItem;

	private Vector2<double> _mouseDownPosition;

	private string _slideIndex = string.Empty;

	public static readonly DependencyProperty SelectedSlideProperty = DependencyProperty.Register("SelectedSlide", typeof(CustomSlide), typeof(SlidePreviewItemsFloatingHeaderControlBase<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(SelectedSlideChanged)));

	public static readonly DependencyProperty SelectedSlidesProperty = DependencyProperty.Register("SelectedSlides", typeof(IEnumerable<CustomSlide>), typeof(SlidePreviewItemsFloatingHeaderControlBase<T>));

	public static readonly DependencyProperty MoveSlidesCommandProperty = DependencyProperty.Register("MoveSlidesCommand", typeof(ICommand<DragDropCommandParameters<CustomSlide, PresentationBase>>), typeof(SlidePreviewItemsFloatingHeaderControlBase<T>));

	public static readonly DependencyProperty SelectSlideByIndexCommandProperty = DependencyProperty.Register("SelectSlideByIndexCommand", typeof(ICommand<int>), typeof(SlidePreviewItemsFloatingHeaderControlBase<T>));

	public CustomSlide? SelectedSlide
	{
		get
		{
			return (CustomSlide)((DependencyObject)this).GetValue(SelectedSlideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedSlideProperty, (object)value);
		}
	}

	public IEnumerable<CustomSlide>? SelectedSlides
	{
		get
		{
			return (IEnumerable<CustomSlide>)((DependencyObject)this).GetValue(SelectedSlidesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedSlidesProperty, (object)value);
		}
	}

	public ICommand<DragDropCommandParameters<CustomSlide, PresentationBase?>>? MoveSlidesCommand
	{
		get
		{
			return (ICommand<DragDropCommandParameters<CustomSlide, PresentationBase>>)((DependencyObject)this).GetValue(MoveSlidesCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MoveSlidesCommandProperty, (object)value);
		}
	}

	public ICommand<int>? SelectSlideByIndexCommand
	{
		get
		{
			return (ICommand<int>)((DependencyObject)this).GetValue(SelectSlideByIndexCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectSlideByIndexCommandProperty, (object)value);
		}
	}

	private static void SelectedSlideChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((SlidePreviewItemsFloatingHeaderControlBase<T>)(object)callerObject).ScrollToSlide((CustomSlide)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	protected SlidePreviewItemsFloatingHeaderControlBase()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		base.DataContextChanged += (DependencyPropertyChangedEventHandler)delegate(object s, DependencyPropertyChangedEventArgs e)
		{
			if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is ISlideEditorVM slideEditorVM)
			{
				base.CommandBindings.Add(CommonApplicationCommands.NavigateUpCommand, slideEditorVM.MovePreviousSlideCommand);
				base.CommandBindings.Add(CommonApplicationCommands.SelectPreviousCommand, slideEditorVM.MovePreviousSlideCommand);
				base.CommandBindings.Add(CommonApplicationCommands.NavigateDownCommand, slideEditorVM.MoveNextSlideCommand);
				base.CommandBindings.Add(CommonApplicationCommands.SelectNextCommand, slideEditorVM.MoveNextSlideCommand);
				base.CommandBindings.Add(CommonApplicationCommands.Copy, slideEditorVM.CopyCommand);
				base.CommandBindings.Add(CommonApplicationCommands.CutCommand, slideEditorVM.CutCommand);
				base.CommandBindings.Add(CommonApplicationCommands.Paste, slideEditorVM.PasteCommand);
				base.CommandBindings.Add(CommonApplicationCommands.Delete, slideEditorVM.DeleteCommand);
				base.CommandBindings.Add(CommonApplicationCommands.SelectAllCommand, slideEditorVM.SelectAllSlidesCommand);
				base.CommandBindings.Add(CommonApplicationCommands.Duplicate, slideEditorVM.DuplicateCommand);
			}
		};
		_dragSource = new DragSource((DependencyObject)(object)this);
		DropTarget dropTarget = new DropTarget((DependencyObject)(object)this);
		base.AllowDrop = true;
		DropAction<CustomSlide[]> dropAction = dropTarget.AddDropType<CustomSlide[]>();
		dropAction.SetCanCopyPredicate((CustomSlide[] i, DragEventArgs e) => true);
		dropAction.SetOnDataDraggedAction(OnSlidesDragged);
		dropAction.SetOnDataDroppedAction(OnSlidesDropped);
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		_selectSlideTimer.Tick += delegate
		{
			_selectSlideTimer.Stop();
			if (int.TryParse(_slideIndex, out var result))
			{
				SelectSlideByIndexCommand?.Invoke(result);
			}
			_slideIndex = string.Empty;
		};
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		if (((DependencyObject)(object)(e.OriginalSource as FrameworkElement))?.FindVisualParent<EditableTextBlock>() == null)
		{
			Focus();
			_mouseDownPosition = (Vector2<double>)e.GetPosition(this);
			if (TryFindItem(e, out EditorPreviewItem hitElement))
			{
				_clickedItem = hitElement;
			}
		}
	}

	protected override void OnPreviewMouseMove(MouseEventArgs e)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		if (e.LeftButton == MouseButtonState.Pressed && _clickedItem != null && e.CanDrag(this, _mouseDownPosition))
		{
			IEnumerable<CustomSlide> draggedSlides = GetDraggedSlides(SelectedSlides, _clickedItem);
			if (!_dragSource.StartDrag(draggedSlides.ToArray(), CreateDragVisual(_clickedItem, draggedSlides.Count()), DragDropEffects.Copy | DragDropEffects.Move, (Vector2<double>)e.GetPosition(_clickedItem)))
			{
				_clickedItem = null;
				((DependencyObject)(object)this).ResetDropIndicator();
			}
		}
	}

	private static IEnumerable<CustomSlide> GetDraggedSlides(IEnumerable<CustomSlide>? slides, EditorPreviewItem clickedItem)
	{
		if (clickedItem.Source == null)
		{
			return Array.Empty<CustomSlide>();
		}
		if (slides == null || !slides.Contains<CustomSlide>(clickedItem.Source))
		{
			return new CustomSlide[1] { clickedItem.Source };
		}
		return slides;
	}

	private static DragVisual CreateDragVisual(EditorPreviewItem draggedItem, int count)
	{
		return draggedItem.ToDragVisual(count, null);
	}

	protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		_clickedItem = null;
	}

	protected virtual void ScrollToSlide(CustomSlide slide)
	{
		T item = slide as T;
		bool scrollToTop = !base.IsVisible;
		ScrollIntoView(item, 0.0, null, scrollToTop);
	}

	private void OnSlidesDragged(IEnumerable<CustomSlide> slides, DragEventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		((DependencyObject)(object)this).ResetDropIndicator();
		if (TryFindItem(e, out EditorPreviewItem hitElement))
		{
			EditorPreviewItem depObj = hitElement;
			Point position = e.GetPosition(hitElement);
			depObj.ShowDropIndicator((((Point)(ref position)).Y < hitElement.ActualHeight / 2.0) ? AdornerPosition.Top : AdornerPosition.Bottom, Colors.Blue, 3.0);
		}
	}

	private void OnSlidesDropped(IEnumerable<CustomSlide> slides, DragEventArgs e)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		((DependencyObject)(object)this).ResetDropIndicator();
		if (TryFindItem(e, out EditorPreviewItem hitElement))
		{
			ICommand<DragDropCommandParameters<CustomSlide, PresentationBase?>>? moveSlidesCommand = MoveSlidesCommand;
			if (moveSlidesCommand != null)
			{
				CustomSlide? source = hitElement.Source;
				Point position = e.GetPosition(hitElement);
				moveSlidesCommand.Invoke<DragDropCommandParameters<CustomSlide, PresentationBase>>(new DragDropCommandParameters<CustomSlide, PresentationBase>(null, slides, source, 0, ((Point)(ref position)).Y < hitElement.ActualHeight / 2.0, droppedOutside: false, e.Effects.HasFlag(DragDropEffects.Copy)));
			}
			_clickedItem = null;
		}
	}

	private bool TryFindItem(DragEventArgs e, [NotNullWhen(true)] out EditorPreviewItem? hitElement)
	{
		hitElement = e.FindHitElement<EditorPreviewItem>(this);
		return hitElement?.IsVisible ?? false;
	}

	private bool TryFindItem(MouseEventArgs e, [NotNullWhen(true)] out EditorPreviewItem? hitElement)
	{
		hitElement = e.FindHitElement<EditorPreviewItem>(this);
		return hitElement?.IsVisible ?? false;
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Invalid comparison between Unknown and I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected I4, but got Unknown
		if (!(e.OriginalSource is TextBox))
		{
			Key key = e.Key;
			if (((int)key >= 34 && (int)key <= 43) || ((int)key >= 74 && (int)key <= 83))
			{
				_slideIndex += (((int)key >= 74) ? (key - 74) : (key - 34));
				_selectSlideTimer.Stop();
				_selectSlideTimer.Start();
			}
		}
	}
}
