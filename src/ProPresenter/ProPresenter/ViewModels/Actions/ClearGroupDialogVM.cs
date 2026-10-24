using System.Collections.Generic;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.ClearGroups;

namespace ProPresenter.ViewModels.Actions;

public class ClearGroupDialogVM : ActionDialogContentVM
{
	public IEnumerable<ClearGroup> ClearGroups => DataVault.ClearGroups;

	public ICommand<ClearGroup> SelectClearGroupCommand => new RelayCommand<ClearGroup>(OnSelectClearGroupCommand, (ClearGroup m) => base.ActionStore.CanAssignData(m, base.Action));

	private void OnSelectClearGroupCommand(ClearGroup clearGroup)
	{
		if (base.Action is ClearGroupAction clearGroupAction)
		{
			clearGroupAction.SetIdentifier(clearGroup.ID, clearGroup.Name);
		}
	}
}
