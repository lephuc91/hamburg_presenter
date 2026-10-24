using System.Windows.Input;
using Pro.UI.Controls;
using ProPresenter.UI.ViewModels.Workspaces;

namespace ProPresenter.UI.Workspaces;

public class WorkspacesListBox : ListBoxBase<IWorkspaceItemVM, ListBoxItem>
{
	public WorkspacesListBox()
	{
		base.SelectOnMouseUp = true;
		base.DeselectOnLostFocus = false;
	}

	protected override bool ShouldDeselectOnMouseUp(MouseButtonEventArgs e)
	{
		return false;
	}
}
