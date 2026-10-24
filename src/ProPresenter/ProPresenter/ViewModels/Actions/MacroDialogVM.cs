using System.Collections.Generic;
using Pro.Common.Collections;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;

namespace ProPresenter.ViewModels.Actions;

public class MacroDialogVM : ActionDialogContentVM
{
	public IEnumerable<ProPresenterMacro> Macros => DataVault.MacroSource.FlatCollection;

	public INotifyEnumerableChanged<MacroGroup> MacroGroups => DataVault.MacroGroups;

	public ICommand<ProPresenterMacro> SelectMacroCommand => new RelayCommand<ProPresenterMacro>(OnSelectMacroCommand, (ProPresenterMacro m) => base.ActionStore.CanAssignData(m, base.Action));

	private void OnSelectMacroCommand(ProPresenterMacro macro)
	{
		if (base.Action is MacroAction macroAction)
		{
			macroAction.SetIdentifier(macro.ID, macro.Name, macro.ParentCollectionID, macro.ParentCollectionName);
		}
	}
}
