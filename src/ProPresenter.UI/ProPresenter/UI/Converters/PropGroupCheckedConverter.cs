using Pro.DO.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Props;

namespace ProPresenter.UI.Converters;

public class PropGroupCheckedConverter : GroupCheckedConverterBase<IPropGroup, IPropCue>
{
	public override bool DoesGroupContainActionItem(IPropCue item, ActionBase action)
	{
		if (action is PropAction propAction)
		{
			return item.ID == propAction.PropID;
		}
		return false;
	}
}
