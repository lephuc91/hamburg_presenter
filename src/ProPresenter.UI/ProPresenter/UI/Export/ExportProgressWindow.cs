using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.Export;

namespace ProPresenter.UI.Export;

public partial class ExportProgressWindow : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty ExportProcessProperty = DependencyProperty.Register("ExportProcess", typeof(IExportProcess), typeof(ExportProgressWindow));

	public IExportProcess? ExportProcess
	{
		get
		{
			return (IExportProcess)((DependencyObject)this).GetValue(ExportProcessProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ExportProcessProperty, (object)value);
		}
	}

	public ExportProgressWindow()
	{
		InitializeComponent();
	}

	private void Cancel_Click(object? sender, RoutedEventArgs e)
	{
		ExportProcess?.CancelExport();
	}
}
