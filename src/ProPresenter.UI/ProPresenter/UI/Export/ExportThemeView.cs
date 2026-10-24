using System.Collections.Generic;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.Themes;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.Export;

public partial class ExportThemeView : ChromedWindow, IComponentConnector
{
	public IEnumerable<Theme>? ThemesToExport => (base.DataContext as TemplateExportVM)?.ThemesToExport;

	public ExportThemeView()
	{
		InitializeComponent();
	}

	private void ExportButton_Click(object? sender, RoutedEventArgs e)
	{
		base.DialogResult = true;
	}
}
