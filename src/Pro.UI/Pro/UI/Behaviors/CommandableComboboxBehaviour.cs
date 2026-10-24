using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Xaml.Behaviors;

namespace Pro.UI.Behaviors;

public class CommandableComboboxBehaviour : Behavior<Selector>
{
	public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(CommandableComboboxBehaviour), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(OnSelectedItemChanged)));

	public static readonly DependencyProperty ChangeItemCommandProperty = DependencyProperty.Register("ChangeItemCommand", typeof(ICommand), typeof(CommandableComboboxBehaviour));

	public object SelectedItem
	{
		get
		{
			return ((DependencyObject)this).GetValue(SelectedItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedItemProperty, value);
		}
	}

	public ICommand? ChangeItemCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ChangeItemCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChangeItemCommandProperty, (object)value);
		}
	}

	protected override void OnAttached()
	{
		base.OnAttached();
		base.AssociatedObject.SelectionChanged += OnSelectionChanged;
	}

	protected override void OnDetaching()
	{
		base.OnDetaching();
		base.AssociatedObject.SelectionChanged -= OnSelectionChanged;
	}

	private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		CommandableComboboxBehaviour behavior = (CommandableComboboxBehaviour)(object)d;
		if (behavior.AssociatedObject == null)
		{
			Dispatcher.CurrentDispatcher.BeginInvoke((Delegate)(Action)delegate
			{
				Selector selector = behavior.AssociatedObject;
				if (selector != null)
				{
					selector.SelectedValue = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
				}
			}, Array.Empty<object>());
		}
		else
		{
			behavior.AssociatedObject.SelectedValue = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}
	}

	private void OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
	{
		if (e.AddedItems != null && e.AddedItems.Count != 0 && SelectedItem != base.AssociatedObject.SelectedItem)
		{
			object selectedItem = base.AssociatedObject.SelectedItem;
			base.AssociatedObject.SelectedItem = SelectedItem;
			ChangeItemCommand?.Execute(selectedItem);
		}
	}
}
