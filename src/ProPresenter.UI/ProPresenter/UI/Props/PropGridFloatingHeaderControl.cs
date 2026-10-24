using System.Windows;
using Pro.Common.Mathematics;
using ProPresenter.UI.FloatingHeaders;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.UI.Props;

public class PropGridFloatingHeaderControl : FlatFloatingHeaderControl
{
	public static readonly DependencyProperty PanelProperty = DependencyProperty.Register("Panel", typeof(PropGroupGrid), typeof(PropGridFloatingHeaderControl));

	public PropGroupGrid Panel
	{
		get
		{
			return (PropGroupGrid)((DependencyObject)this).GetValue(PanelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PanelProperty, (object)value);
		}
	}

	public PropGridFloatingHeaderControl()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(GridFloatingHeaderControl_DataContextChanged);
	}

	private void GridFloatingHeaderControl_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue is IPropGroupVM propGroupVM)
		{
			propGroupVM.NewItemAdded -= OnNewItemAdded;
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is IPropGroupVM propGroupVM2)
		{
			propGroupVM2.NewItemAdded += OnNewItemAdded;
		}
	}

	private void OnNewItemAdded(IPropCueVM item)
	{
		if (item != null)
		{
			UpdateLayout();
			Rect<double> thumbnailBounds = Panel.GetThumbnailBounds(item);
			CalculateOffsets(Panel, thumbnailBounds, out var topOffset, out var heightOffset);
			ScrollIntoView(Panel, topOffset, heightOffset);
			Panel.FocusAndRenameItem(item);
		}
	}
}
