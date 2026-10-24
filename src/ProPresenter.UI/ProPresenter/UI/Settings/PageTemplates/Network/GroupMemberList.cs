using System.Windows.Input;
using Pro.UI.Controls;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.Settings.PageTemplates.Network;

public class GroupMemberList : ListBoxBase<IGroupMemberVM, ListBoxItem>
{
	protected override bool ShouldDeselectOnMouseUp(MouseButtonEventArgs e)
	{
		return false;
	}
}
