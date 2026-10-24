using Pro.DO.Triggering;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Actions.PCO;

public class PCOMediaAction : PCOActionBase
{
	public override ActionType ActionType => ActionType.Media;

	public PCOMediaAction(IApp app)
		: base(app)
	{
	}
}
