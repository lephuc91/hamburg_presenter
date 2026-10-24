using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Pro.UI.Components;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public class CommandedDataGridTemplateColumn<T> : DataGridTemplateColumn
{
	public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand<T>), typeof(CommandedDataGridTemplateColumn<T>));

	public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(T), typeof(CommandedDataGridTemplateColumn<T>));

	public ICommand<T>? Command
	{
		get
		{
			return (ICommand<T>)((DependencyObject)this).GetValue(CommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CommandProperty, (object)value);
		}
	}

	public T CommandParameter
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(CommandParameterProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CommandParameterProperty, (object)value);
		}
	}

	public CommandedDataGridTemplateColumn()
	{
		base.HeaderStyle = new Style(typeof(DataGridColumnHeader), (Style)Application.Current.Resources[typeof(DataGridColumnHeader)]);
		base.HeaderStyle.Setters.Add(new EventSetter
		{
			Event = ButtonBase.ClickEvent,
			Handler = new RoutedEventHandler(HeaderClicked)
		});
	}

	private void HeaderClicked(object? sender, RoutedEventArgs e)
	{
		Command?.Invoke(CommandParameter);
	}
}
