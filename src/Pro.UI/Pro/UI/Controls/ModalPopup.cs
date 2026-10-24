using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Pro.UI.Controls.Windowing;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public class ModalPopup : AnchoredPopup
{
	private sealed class OverlayAdorner : Adorner
	{
		private readonly Brush _overlayBrush;

		private readonly UIElement[] _exclude;

		public OverlayAdorner(UIElement adornedElement, Brush? overlayBrush, params UIElement[] exclude)
			: base(adornedElement)
		{
			_overlayBrush = overlayBrush ?? Brushes.Transparent;
			_exclude = exclude;
		}

		protected override void OnRender(DrawingContext drawingContext)
		{
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			GeometryGroup geometryGroup = new GeometryGroup
			{
				FillRule = FillRule.Nonzero
			};
			UIElement[] exclude = _exclude;
			foreach (UIElement uIElement in exclude)
			{
				geometryGroup.Children.Add(new RectangleGeometry(uIElement.TransformToAncestor(base.AdornedElement).TransformBounds(new Rect(uIElement.RenderSize))));
			}
			CombinedGeometry clipGeometry = new CombinedGeometry(GeometryCombineMode.Exclude, new RectangleGeometry(new Rect(base.AdornedElement.RenderSize)), geometryGroup);
			drawingContext.PushClip(clipGeometry);
			drawingContext.DrawRectangle(_overlayBrush, null, new Rect(base.AdornedElement.RenderSize));
			drawingContext.Pop();
		}
	}

	private OverlayAdorner? _overlay;

	public static readonly DependencyProperty IsModalProperty = DependencyProperty.Register("IsModal", typeof(bool), typeof(ModalPopup));

	public static readonly DependencyProperty OverlayBrushProperty = DependencyProperty.Register("OverlayBrush", typeof(Brush), typeof(ModalPopup), new PropertyMetadata((object)Brushes.Transparent));

	public bool IsModal
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsModalProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsModalProperty, (object)value);
		}
	}

	public Brush OverlayBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(OverlayBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OverlayBrushProperty, (object)value);
		}
	}

	public ModalPopup()
	{
		base.StaysOpen = true;
	}

	protected override void OnOpened(EventArgs e)
	{
		base.OnOpened(e);
		if (IsModal)
		{
			if (TryGetAdornedChromedElement(out UIElement windowGrid))
			{
				IEnumerable<FrameworkElement> source = ((DependencyObject)(object)windowGrid).FindChildrenByNames("PART_MinimizeButton", "PART_MaximizeRestoreButton", "PART_CloseButton");
				UIElement adornedElement = windowGrid;
				Brush overlayBrush = OverlayBrush;
				UIElement[] exclude = source.ToArray();
				_overlay = new OverlayAdorner(adornedElement, overlayBrush, exclude);
				windowGrid.AddAdorner(_overlay);
			}
			else if (base.ParentWindow?.Content is UIElement uIElement)
			{
				_overlay = new OverlayAdorner(uIElement, OverlayBrush);
				uIElement.AddAdorner(_overlay);
			}
		}
	}

	protected override void OnClosed(EventArgs e)
	{
		base.OnClosed(e);
		if (_overlay != null)
		{
			if (!TryGetAdornedChromedElement(out UIElement windowGrid))
			{
				windowGrid = base.ParentWindow?.Content as UIElement;
			}
			windowGrid?.RemoveAdorner(_overlay);
			_overlay = null;
		}
	}

	private bool TryGetAdornedChromedElement([NotNullWhen(true)] out UIElement? windowGrid)
	{
		if (base.ParentWindow is ChromedWindow depObj)
		{
			FrameworkElement frameworkElement = ((DependencyObject)(object)depObj).FindChildByName("windowGrid");
			if (frameworkElement != null)
			{
				windowGrid = frameworkElement;
				return true;
			}
		}
		windowGrid = null;
		return false;
	}
}
