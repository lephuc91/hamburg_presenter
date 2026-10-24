using System.Windows;
using System.Windows.Markup;
using Pro.Common.Utility;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.Import;

namespace ProPresenter.UI.Import;

public partial class ImportProgressWindow : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty ImportProcessProperty = DependencyProperty.Register("ImportProcess", typeof(ImportProcess), typeof(ImportProgressWindow));

	public ImportProcess? ImportProcess
	{
		get
		{
			return (ImportProcess)((DependencyObject)this).GetValue(ImportProcessProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ImportProcessProperty, (object)value);
		}
	}

	public ImportProgressWindow()
	{
		InitializeComponent();
	}

	public new bool? ShowDialog()
	{
		Application.Current.MainWindow?.BringToTop();
		return base.ShowDialog();
	}

	private void Cancel_Click(object? sender, RoutedEventArgs e)
	{
		ImportProcess?.CancelImport();
	}
}
