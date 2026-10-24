using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace Pro.UI.Controls;

public class ResizeablePopup<T> : ProxyPopup<T> where T : FrameworkElement, IPopup, new()
{
	public ResizeablePopup()
	{
		ResizeableContent resizeableContent = new ResizeableContent
		{
			HorizontalAlignment = HorizontalAlignment.Stretch,
			VerticalAlignment = VerticalAlignment.Stretch
		};
		resizeableContent.Resized += OnContentResized;
		resizeableContent.SetBinding(ContentControl.ContentProperty, new Binding("Child")
		{
			Source = this,
			Mode = BindingMode.TwoWay
		});
		base.PopupControl.Child = resizeableContent;
	}

	protected override bool AllowBind(DependencyProperty dp)
	{
		return dp != Popup.ChildProperty;
	}

	protected virtual void OnContentResized(DragDeltaEventArgs e)
	{
		FrameworkElement frameworkElement = base.Child as FrameworkElement;
		base.PopupControl.Width = Math.Max((frameworkElement?.ActualWidth ?? 0.0) + e.HorizontalChange, 0.0);
		base.PopupControl.Height = Math.Max((frameworkElement?.ActualHeight ?? 0.0) + e.VerticalChange, 0.0);
	}
}
