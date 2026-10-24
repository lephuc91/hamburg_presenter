using Pro.DO.Triggering;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Actions.PCO;

public class PCOPlanAction : PCOActionBase
{
	public override ActionType ActionType => ActionType.Document;

	public PCOPlanAction(IApp app)
		: base(app)
	{
	}
}
