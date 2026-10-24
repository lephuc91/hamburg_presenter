using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Pro.UI.Controls;

public partial class AddWorkspaceDialog : UserControl, IComponentConnector
{
	public static readonly DependencyProperty WorkspaceNameProperty = DependencyProperty.Register("WorkspaceName", typeof(string), typeof(AddWorkspaceDialog));

	public static readonly DependencyProperty IsCloudWorkspaceProperty = DependencyProperty.Register("IsCloudWorkspace", typeof(bool), typeof(AddWorkspaceDialog));

	public string? WorkspaceName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(WorkspaceNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WorkspaceNameProperty, (object)value);
		}
	}

	public bool IsCloudWorkspace
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsCloudWorkspaceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsCloudWorkspaceProperty, (object)value);
		}
	}

	public AddWorkspaceDialog()
	{
		InitializeComponent();
		base.Loaded += delegate
		{
			Keyboard.Focus(WorkspaceNameTextBox);
		};
	}
}
