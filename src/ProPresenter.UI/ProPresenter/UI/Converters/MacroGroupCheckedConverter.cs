using Pro.DO.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;

namespace ProPresenter.UI.Converters;

public class MacroGroupCheckedConverter : GroupCheckedConverterBase<MacroGroup, ProPresenterMacro>
{
	public override bool DoesGroupContainActionItem(ProPresenterMacro item, ActionBase action)
	{
		if (action is MacroAction macroAction)
		{
			return item.ID == macroAction.MacroID;
		}
		return false;
	}
}
