using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Navigation;
using Pro.Common.Utility;

namespace ProPresenter.UI;

public partial class FolderPermissionWarning : UserControl, IComponentConnector
{
	private static readonly DependencyProperty FolderWarningMessageProperty = DependencyProperty.Register("FolderWarningMessage", typeof(string), typeof(FolderPermissionWarning));

	private string? FolderWarningMessage
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(FolderWarningMessageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FolderWarningMessageProperty, (object)value);
		}
	}

	public FolderPermissionWarning(string folderWarningMessage)
	{
		FolderWarningMessage = folderWarningMessage;
		InitializeComponent();
	}

	private void Hyperlink_RequestNavigate(object? sender, RequestNavigateEventArgs e)
	{
		ProcessHelper.StartProcess(e.Uri.AbsoluteUri);
	}
}
