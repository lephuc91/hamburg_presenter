using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public class ItemsControlBase : ItemsControl
{
	private bool _adornerAdded;

	private readonly ItemGroupAdorner _itemGroupAdorner;

	public ItemsControlBase()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		_itemGroupAdorner = new ItemGroupAdorner(this);
		base.Loaded += ItemsControlBase_Loaded;
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(ItemsControlBase_IsVisibleChanged);
	}

	private void ItemsControlBase_Loaded(object? sender, RoutedEventArgs e)
	{
		base.Loaded -= ItemsControlBase_Loaded;
		if (!_adornerAdded)
		{
			_adornerAdded = this.AddAdorner(_itemGroupAdorner);
		}
	}

	private void ItemsControlBase_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (base.IsVisible)
		{
			if (!_adornerAdded)
			{
				_adornerAdded = this.AddAdorner(_itemGroupAdorner);
			}
		}
		else
		{
			_itemGroupAdorner.Hide();
		}
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		DependencyObject containerForItemOverride = base.GetContainerForItemOverride();
		if (containerForItemOverride is ContentPresenter contentPresenter)
		{
			contentPresenter.ContextMenuOpening += Container_ContextMenuOpening;
			contentPresenter.ContextMenuClosing += Container_ContextMenuClosing;
		}
		return containerForItemOverride;
	}

	protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Remove)
		{
			_itemGroupAdorner.Hide();
		}
	}

	private void Container_ContextMenuOpening(object? sender, ContextMenuEventArgs e)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		if (sender is ContentPresenter { ContextMenu: not null } contentPresenter)
		{
			IEnumerable<Rect<double>> item = new Rect<double>((Vector2<double>)contentPresenter.TranslatePoint(Vector2<double>.Zero, this), (Vector2<double>)contentPresenter.RenderSize).ToEnumerable();
			_itemGroupAdorner.UpdateBounds(item.ToEnumerable());
		}
	}

	private void Container_ContextMenuClosing(object? sender, ContextMenuEventArgs e)
	{
		_itemGroupAdorner.Hide();
	}
}
