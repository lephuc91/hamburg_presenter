using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.Print;

namespace ProPresenter.UI.Print;

public partial class PrintOptionDialog : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty PrintOptionsProperty = DependencyProperty.Register("PrintOptions", typeof(PrintOptions), typeof(PrintOptionDialog));

	public static readonly DependencyProperty OpenPrintSettingCommandProperty = DependencyProperty.Register("OpenPrintSettingCommand", typeof(ICommand), typeof(PrintOptionDialog));

	public static readonly DependencyProperty OpenPreviewCommandProperty = DependencyProperty.Register("OpenPreviewCommand", typeof(ICommand), typeof(PrintOptionDialog));

	public PrintOptions PrintOptions
	{
		get
		{
			return (PrintOptions)((DependencyObject)this).GetValue(PrintOptionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PrintOptionsProperty, (object)value);
		}
	}

	public ICommand OpenPrintSettingCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(OpenPrintSettingCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OpenPrintSettingCommandProperty, (object)value);
		}
	}

	public ICommand OpenPreviewCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(OpenPreviewCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OpenPreviewCommandProperty, (object)value);
		}
	}

	public PrintOptionDialog()
	{
		InitializeComponent();
	}

	private void DoneButton_Click(object? sender, RoutedEventArgs e)
	{
		e.Handled = true;
		CloseDialog();
	}

	private void CloseDialog()
	{
		base.Owner.Focus();
		Hide();
	}
}
