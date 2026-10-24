using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.Import.Requests;

namespace ProPresenter.UI.PresentationView;

public partial class SelectLinkFileControl : UserControl, IComponentConnector
{
	private static readonly DependencyProperty FilesProperty = DependencyProperty.Register("Files", typeof(IEnumerable<FileImportRequest>), typeof(SelectLinkFileControl));

	private static readonly DependencyProperty FileProperty = DependencyProperty.Register("File", typeof(FileImportRequest), typeof(SelectLinkFileControl));

	public IEnumerable<FileImportRequest> Files
	{
		get
		{
			return (IEnumerable<FileImportRequest>)((DependencyObject)this).GetValue(FilesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FilesProperty, (object)value);
		}
	}

	public FileImportRequest File
	{
		get
		{
			return (FileImportRequest)((DependencyObject)this).GetValue(FileProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FileProperty, (object)value);
		}
	}

	public SelectLinkFileControl()
	{
		InitializeComponent();
	}
}
