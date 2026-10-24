using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.DO.Actions;

namespace ProPresenter.UI.ActionsMenu;

public partial class EditActionMenuSource : FrameworkCollection, IComponentConnector, IStyleConnector
{
	private static readonly DependencyProperty MediaActionProperty = DependencyProperty.Register("MediaAction", typeof(MediaAction), typeof(EditActionMenuSource));

	private MediaAction MediaAction
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

	public EditActionMenuSource()
	{
		InitializeComponent();
	}

	private void MenuItem_SubmenuOpened(object? sender, RoutedEventArgs e)
	{
		((DependencyObject)this).SetCurrentValue(MediaActionProperty, (object)((sender as MenuItem)?.DataContext as MediaAction));
	}

	private void MenuItem_Unloaded(object? sender, RoutedEventArgs e)
	{
		if (sender is MenuItem menuItem)
		{
			menuItem.Unloaded -= MenuItem_Unloaded;
			menuItem.SubmenuOpened -= MenuItem_SubmenuOpened;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
