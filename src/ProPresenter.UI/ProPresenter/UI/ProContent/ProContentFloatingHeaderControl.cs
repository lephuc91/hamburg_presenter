using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.UI.Components;
using Pro.UI.Controls;
using ProPresenter.UI.ViewModels.ProContent.Collection;

namespace ProPresenter.UI.ProContent;

public class ProContentFloatingHeaderControl : FloatingHeaderControl<IProContentCollectionVM, INotifyEnumerableChanged<IProContentCollectionVM>, LayoutType, LayoutType>
{
	protected override bool ResetScrollOnItemsLoaded => true;

	protected override bool CanScroll(MouseWheelEventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if (((Enum)Keyboard.Modifiers).HasFlag((Enum)(object)(ModifierKeys)4))
		{
			return false;
		}
		return base.CanScroll(e);
	}

	protected override DataTemplate? FindHeaderTemplate(LayoutType key)
	{
		return base.HeaderTemplates?.FirstOrDefault();
	}

	protected override DataTemplate? FindItemTemplate(LayoutType key)
	{
		if (key == LayoutType.Grid)
		{
			return base.ItemTemplates?.FirstOrDefault((DataTemplate t) => t is TaggedDataTemplate taggedDataTemplate && taggedDataTemplate.Tag is LayoutType layoutType && layoutType == key) ?? null;
		}
		return base.ItemTemplates?.FirstOrDefault((DataTemplate t) => t is TaggedDataTemplate taggedDataTemplate2 && taggedDataTemplate2.Tag == null);
	}

	protected override LayoutType GetHeaderKey(IProContentCollectionVM item)
	{
		return item.LayoutType;
	}

	protected override LayoutType GetItemKey(IProContentCollectionVM item)
	{
		return item.LayoutType;
	}
}
